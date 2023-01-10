//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    using I = System.Reflection.Metadata.Ecma335.TableIndex;

    public partial class PeReader : IDisposable
    {
        [Op]
        public static PeReader create(FilePath src)
            => new PeReader(src);

        public static bool create(FilePath src, out PeReader dst)
        {
            var stream = File.OpenRead(src.Name);
            try
            {                
                var reader = new PEReader(stream,  PEStreamOptions.PrefetchMetadata);
                dst = new PeReader(src, stream, reader);
                return true;
            }
            catch(Exception)
            {
                stream.Dispose();
                dst = default;
                return false;
            }
        }

        public static PeFileInfo ReadPeInfo(PEReader src)
        {
            var pe = src.PEHeaders.PEHeader;
            var coff = src.PEHeaders.CoffHeader;
            var dst = new PeFileInfo();
            dst.Machine = coff.Machine;
            dst.ImageBase = pe.ImageBase;
            dst.EntryPointOffset = pe.AddressOfEntryPoint;
            dst.CodeOffset = pe.BaseOfCode;
            dst.CodeSize = (uint)pe.SizeOfCode;
            dst.DataOffset = pe.BaseOfData;
            dst.ImageSize = (uint)pe.SizeOfImage;
            dst.ExportDir = pe.ExportTableDirectory;
            dst.ImportDir = pe.ImportTableDirectory;
            dst.ResourceDir = pe.ResourceTableDirectory;
            dst.RelocationDir = pe.BaseRelocationTableDirectory;
            dst.ImportAddressDir = pe.ImportAddressTableDirectory;
            dst.LoadConfigDir = pe.LoadConfigTableDirectory;
            dst.DebugDir = pe.DebugTableDirectory;
            dst.Characteristics = coff.Characteristics;
            return dst;
        }

        public static CoffHeader ReadCoffInfo(PEReader pe)
        {
            var src = pe.PEHeaders.CoffHeader;
            var dst = new CoffHeader();
            dst.Characteristics = src.Characteristics;
            dst.Machine = src.Machine;
            dst.NumberOfSections = (ushort)src.NumberOfSections;
            dst.NumberOfSymbols = (uint)src.NumberOfSymbols;
            dst.PointerToSymbolTable = src.PointerToSymbolTable;
            dst.SizeOfOptionalHeader = (ushort)src.SizeOfOptionalHeader;
            dst.TimeDateStamp = (uint)src.TimeDateStamp;
            return dst;
        }

        public static CorHeaderInfo? cor(PEHeaders src)
        {
            var cor = src.CorHeader;
            var dst = default(CorHeaderInfo);
            if(cor != null)
            {
                dst = new();
                dst.MajorRuntimeVersion = cor.MajorRuntimeVersion;
                dst.MinorRuntimeVersion = cor.MinorRuntimeVersion;
                dst.MetadataDirectory = cor.MetadataDirectory;
                dst.Flags = cor.Flags;
                dst.EntryPointTokenOrRelativeVirtualAddress = cor.EntryPointTokenOrRelativeVirtualAddress;
                dst.ResourcesDirectory = cor.ResourcesDirectory;
                dst.StrongNameSignatureDirectory = cor.StrongNameSignatureDirectory;
                dst.CodeManagerTableDirectory = cor.CodeManagerTableDirectory;
                dst.VtableFixupsDirectory = cor.VtableFixupsDirectory;
                dst.ExportAddressTableJumpsDirectory = cor.ExportAddressTableJumpsDirectory;
                dst.ManagedNativeHeaderDirectory = cor.ManagedNativeHeaderDirectory;
            }
            return dst;
        }

        public static ReadOnlySeq<PeSectionHeader> headers(PEReader src)
        {
            var headers = src.PEHeaders;
            var pe = headers.PEHeader;
            var sections = src.PEHeaders.SectionHeaders.AsSpan();
            var count = sections.Length;
            var buffer = sys.alloc<PeSectionHeader>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var section = ref skip(sections,i);
                ref var dst = ref seek(buffer,i);
                dst.EntryPoint = (Address32)pe.AddressOfEntryPoint;
                dst.CodeBase = (Address32)pe.BaseOfCode;
                dst.GptRva = (Address32)pe.GlobalPointerTableDirectory.RelativeVirtualAddress;
                dst.GptSize = (ByteSize)pe.GlobalPointerTableDirectory.Size;
                dst.SectionFlags = section.SectionCharacteristics;
                dst.SectionName = section.Name;
                dst.RawDataAddress = (Address32)section.PointerToRawData;
                dst.RawDataSize = (uint)section.SizeOfRawData;
            }
            return buffer;
        }

        public static void modules(IDbArchive src, Action<CoffModule> dst)
        {
            iter(src.Enumerate(true, FileKind.Exe, FileKind.Dll, FileKind.Obj, FileKind.Lib), path => {                
                using var reader = PeReader.create(path);
                dst(reader.ModuleInfo());
            }, true);
        }

        public static EcmaRowIndex index(in PeStream state, Handle handle)
            => new EcmaToken(state.Reader.GetToken(handle));

        [MethodImpl(Inline), Op]
        public static PeDirectory directory(Address32 rva, uint size)
        {
            var dst = new PeDirectory();
            dst.Rva = rva;
            dst.Size = size;
            return dst;
        }

        public ReadOnlySeq<PeSectionHeader> Headers()
            => PeReader.headers(PE);


        PeReader(FilePath src, FileStream stream, PEReader reader)
        {
            Source = src;
            Stream = stream;
            PE = reader;
        }

        PeReader(FilePath src)
        {
            Source = src;
            Stream = File.OpenRead(src.Name);
            PE = new PEReader(Stream);            
        }

        readonly FilePath Source;

        readonly FileStream Stream;

        public ReadOnlySpan<EcmaConstInfo> Constants(ref uint counter)
        {
            var reader = MD;
            var count = ConstantCount();
            var dst = core.span<EcmaConstInfo>(count);
            for(var i=1u; i<=count; i++)
            {
                var k = MetadataTokens.ConstantHandle((int)i);
                var entry = reader.GetConstant(k);
                var parent = new EcmaRowIndex(MD.GetToken(entry.Parent));
                var blob = reader.GetBlobBytes(entry.Value);
                ref var target = ref seek(dst, i - 1u);
                target.Seq = counter++;
                target.ParentId = parent.Token;
                target.Source = parent.Table.ToString();
                target.DataType = entry.TypeCode;
                target.Content = blob;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public int ConstantCount()
            => MD.GetTableRowCount(I.Constant);

        PEReader PE {get;}

        public MetadataReader MD
        {
            [MethodImpl(Inline)]
            get
            {
                if(_MD == null)
                    _MD = PE.GetMetadataReader();
                return _MD;
            }
        }

        MetadataReader _MD;

        PEMemoryBlock? _MetadataBlock;

        PEMemoryBlock MetadataBlock
        {
            [MethodImpl(Inline)]
            get
            {
                if(!_MetadataBlock.HasValue)
                    _MetadataBlock = PE.GetMetadata();
                return _MetadataBlock.Value;
            }
        }

        EcmaReader CliReader()
            => Z0.EcmaReader.create(MetadataBlock);


        public void Dispose()
        {
            PE?.Dispose();
            Stream?.Dispose();
        }

        public CoffModule ModuleInfo()
            => new CoffModule(Source, ReadPeInfo(PE), ReadCoffInfo(PE), cor(PE.PEHeaders), headers(PE));

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        public CorHeader? CorHeader
        {
            [MethodImpl(Inline)]
            get => PeHeaders.CorHeader;
        }

        public ReadOnlySpan<MemberReferenceHandle> MemberRefHandles
            => MD.MemberReferences.ToArray();

        public PeDirectory ResourcesDirectory
            => PeHeaders.CorHeader.ResourcesDirectory;

        public PEMemoryBlock ReadSectionData(PeDirectory src)
            => PE.GetSectionData((int)src.Rva);

        /// <summary>
        /// Determines whether the source image is r2r
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <remarks>Taken from https://github.com/dotnet/runtime/blob/55e2378d86841ec766ee21d5e504d7724c39b53b/src/tasks/Crossgen2Tasks/PrepareForReadyToRunCompilation.cs</remarks>
        public bool IsReady2Run()
        {
            if (PeHeaders == null)
                return false;

            if (PeHeaders.CorHeader == null)
                return false;

            if ((PeHeaders.CorHeader.Flags & CorFlags.ILLibrary) == 0)
            {
                // This is likely a composite image, but those can't be re-r2r'd
                return false;
            }
            else
            {
                return PeHeaders.CorHeader.ManagedNativeHeaderDirectory.Size != 0;
            }
        }
    }
}