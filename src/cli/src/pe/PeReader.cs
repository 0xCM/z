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
        public static CliRowIndex index(in PeStream state, Handle handle)
            => new CliToken(state.Reader.GetToken(handle));

        [MethodImpl(Inline), Op]
        public static PeDirInfo directory(Address32 rva, uint size)
        {
            var dst = new PeDirInfo();
            dst.Rva = rva;
            dst.Size = size;
            return dst;
        }

        [Op]
        public static PeReader create(FilePath src)
            => new PeReader(src);

        readonly FilePath Source;

        readonly FileStream Stream;

        public ReadOnlySpan<ConstantFieldInfo> Constants(ref uint counter)
        {
            var reader = MD;
            var count = ConstantCount();
            var dst = core.span<ConstantFieldInfo>(count);
            for(var i=1u; i<=count; i++)
            {
                var k = MetadataTokens.ConstantHandle((int)i);
                var entry = reader.GetConstant(k);
                var parent = new CliRowIndex(MD.GetToken(entry.Parent));
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

        public PeReader(FilePath src)
        {
            Source = src;
            Stream = File.OpenRead(src.Name);
            PE = new PEReader(Stream);
        }

        public void Dispose()
        {
            PE?.Dispose();
            Stream?.Dispose();
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

        public static FileModuleInfo describe(PEReader reader)
            => new FileModuleInfo(ReadPeInfo(reader), ReadCoffInfo(reader), headers(reader, FilePath.Empty));

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        public CorHeader CorHeader
        {
            [MethodImpl(Inline)]
            get => PeHeaders.CorHeader;
        }

        ReadOnlySpan<SectionHeader> SectionHeaders
            => PeHeaders.SectionHeaders.ToReadOnlySpan();

        public ReadOnlySpan<MemberReferenceHandle> MemberRefHandles
            => MD.MemberReferences.ToArray();

        public DirectoryEntry ResourcesDirectory
            => CorHeader.ResourcesDirectory;

        public DirectoryEntry CodeManagerTableDirectory
            => CorHeader.CodeManagerTableDirectory;

        public DirectoryEntry ExportAddressTableJumpsDirectory
            => CorHeader.ExportAddressTableJumpsDirectory;

        public CorFlags Flags
            => CorHeader.Flags;

        public DirectoryEntry ManagedNativeHeaderDirectory
            => CorHeader.ManagedNativeHeaderDirectory;

        public DirectoryEntry MetadataDirectory
            => CorHeader.MetadataDirectory;

        public DirectoryEntry VtableFixupsDirectory
            => CorHeader.VtableFixupsDirectory;

        public PEMemoryBlock ReadSectionData(DirectoryEntry src)
            => PE.GetSectionData(src.RelativeVirtualAddress);
    }
}