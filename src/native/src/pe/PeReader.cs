//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    using I = System.Reflection.Metadata.Ecma335.TableIndex;

    public class PeReader : IDisposable
    {
        [Op]
        public static PeReader create(FilePath src)
            => new PeReader(src);

        public static bool create(FilePath src, out PeReader dst)
        {
            var stream = File.OpenRead(src.Name);
            try
            {                
                var reader = new PEReader(stream, PEStreamOptions.PrefetchMetadata);
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

        // public static PeFileInfo ReadPeInfo(PEReader src)
        // {
        //     var pe = src.PEHeaders.PEHeader;
        //     var coff = src.PEHeaders.CoffHeader;
        //     var dst = new PeFileInfo();
        //     dst.Machine = coff.Machine;
        //     dst.ImageBase = pe.ImageBase;
        //     dst.EntryPointOffset = pe.AddressOfEntryPoint;
        //     dst.CodeOffset = pe.BaseOfCode;
        //     dst.CodeSize = (uint)pe.SizeOfCode;
        //     dst.DataOffset = pe.BaseOfData;
        //     dst.ImageSize = (uint)pe.SizeOfImage;
        //     dst.ExportDir = pe.ExportTableDirectory;
        //     dst.ImportDir = pe.ImportTableDirectory;
        //     dst.ResourceDir = pe.ResourceTableDirectory;
        //     dst.RelocationDir = pe.BaseRelocationTableDirectory;
        //     dst.ImportAddressDir = pe.ImportAddressTableDirectory;
        //     dst.LoadConfigDir = pe.LoadConfigTableDirectory;
        //     dst.DebugDir = pe.DebugTableDirectory;
        //     dst.Characteristics = coff.Characteristics;
        //     return dst;
        // }

        // public static CoffHeader ReadCoffInfo(PEReader pe)
        // {
        //     var src = pe.PEHeaders.CoffHeader;
        //     var dst = new CoffHeader();
        //     dst.Characteristics = src.Characteristics;
        //     dst.Machine = src.Machine;
        //     dst.NumberOfSections = (ushort)src.NumberOfSections;
        //     dst.NumberOfSymbols = (uint)src.NumberOfSymbols;
        //     dst.PointerToSymbolTable = src.PointerToSymbolTable;
        //     dst.SizeOfOptionalHeader = (ushort)src.SizeOfOptionalHeader;
        //     dst.TimeDateStamp = (uint)src.TimeDateStamp;
        //     return dst;
        // }

        // public static CorHeaderInfo? cor(PEHeaders src)
        // {
        //     var cor = src.CorHeader;
        //     var dst = default(CorHeaderInfo);
        //     if(cor != null)
        //     {
        //         dst = new();
        //         dst.MajorRuntimeVersion = cor.MajorRuntimeVersion;
        //         dst.MinorRuntimeVersion = cor.MinorRuntimeVersion;
        //         dst.MetadataDirectory = cor.MetadataDirectory;
        //         dst.Flags = cor.Flags;
        //         dst.EntryPointTokenOrRelativeVirtualAddress = cor.EntryPointTokenOrRelativeVirtualAddress;
        //         dst.ResourcesDirectory = cor.ResourcesDirectory;
        //         dst.StrongNameSignatureDirectory = cor.StrongNameSignatureDirectory;
        //         dst.CodeManagerTableDirectory = cor.CodeManagerTableDirectory;
        //         dst.VtableFixupsDirectory = cor.VtableFixupsDirectory;
        //         dst.ExportAddressTableJumpsDirectory = cor.ExportAddressTableJumpsDirectory;
        //         dst.ManagedNativeHeaderDirectory = cor.ManagedNativeHeaderDirectory;
        //     }
        //     return dst;
        // }

        // public static ReadOnlySeq<PeSectionHeader> headers(PEReader src)
        // {
        //     var headers = src.PEHeaders;
        //     var pe = headers.PEHeader;
        //     var sections = src.PEHeaders.SectionHeaders.AsSpan();
        //     var count = sections.Length;
        //     var buffer = sys.alloc<PeSectionHeader>(count);
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var section = ref skip(sections,i);
        //         ref var dst = ref seek(buffer,i);
        //         dst.EntryPoint = (Address32)pe.AddressOfEntryPoint;
        //         dst.CodeBase = (Address32)pe.BaseOfCode;
        //         dst.GptRva = (Address32)pe.GlobalPointerTableDirectory.RelativeVirtualAddress;
        //         dst.GptSize = (ByteSize)pe.GlobalPointerTableDirectory.Size;
        //         dst.SectionFlags = section.SectionCharacteristics;
        //         dst.SectionName = section.Name;
        //         dst.RawDataAddress = (Address32)section.PointerToRawData;
        //         dst.RawDataSize = (uint)section.SizeOfRawData;
        //     }
        //     return buffer;
        // }

        public static void modules(IDbArchive src, Action<CoffModule> dst)
        {
            iter(src.Enumerate(true, FileKind.Exe, FileKind.Dll, FileKind.Obj, FileKind.Lib, FileKind.Sys), path => {
                using var reader = PeReader.create(path);
                dst(reader.ModuleInfo());
            }, true);
        }

        public static EcmaRowIndex index(in PeStream state, Handle handle)
            => new EcmaToken(state.Reader.GetToken(handle));

        [MethodImpl(Inline), Op]
        public static PeDirectoryEntry directory(Address32 rva, uint size)
        {
            var dst = new PeDirectoryEntry();
            dst.Rva = rva;
            dst.Size = size;
            return dst;
        }

        public ReadOnlySeq<PeSectionHeader> SectionHeaders()
            => Tables.SectionHeaders;

        PeReader(FilePath src, FileStream stream, PEReader reader)
        {
            ModulePath = src;
            Stream = stream;
            PE = reader;
        }

        PeReader(FilePath src)
        {
            ModulePath = src;
            Stream = File.OpenRead(src.Name);
            PE = new PEReader(Stream);     
            Tables = PeTables.load(this);
        }

        public readonly FilePath ModulePath;

        readonly FileStream Stream;

        internal readonly PEReader PE;

        public readonly PeTables Tables;

        public ReadOnlySpan<EcmaConstInfo> Constants(ref uint counter)
        {
            var reader = MD;
            var count = ConstantCount();
            var dst = sys.span<EcmaConstInfo>(count);
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

        [MethodImpl(Inline), Op]
        public ref MethodBodyBlock ReadMethodBody(Address32 address, ref MethodBodyBlock dst)
        {
            dst = PE.GetMethodBody((int)address);
            return ref dst;
        }

        MetadataReader _MD;

        //PEMemoryBlock? _MetadataBlock;

        // PEMemoryBlock MetadataBlock
        // {
        //     [MethodImpl(Inline)]
        //     get
        //     {
        //         if(!_MetadataBlock.HasValue)
        //             _MetadataBlock = PE.GetMetadata();
        //         return _MetadataBlock.Value;
        //     }
        // }

        // EcmaReader CliReader()
        //     => Z0.EcmaReader.create(MetadataBlock);


        public void Dispose()
        {
            PE?.Dispose();
            Stream?.Dispose();
        }

        public CoffModule ModuleInfo()
            => new CoffModule(ModulePath, Tables.PeInfo, Tables.CoffHeader, Tables.CorHeader, Tables.SectionHeaders);

        public PEHeaders PeHeaders
        {
            [MethodImpl(Inline)]
            get => PE.PEHeaders;
        }

        // public CorHeader? CorHeader
        // {
        //     [MethodImpl(Inline)]
        //     get => PeHeaders.CorHeader;
        // }

        public ReadOnlySpan<MemberReferenceHandle> MemberRefHandles
            => MD.MemberReferences.ToArray();

        // public PeDirectoryEntry ResourcesDirectory
        //     => PeHeaders.CorHeader.ResourcesDirectory;

        public PEMemoryBlock ReadSectionData(PeDirectoryEntry src)
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

        public ReadOnlySpan<MsilRow> ReadMsil()
        {
            var dst = list<MsilRow>();
            var types = MD.TypeDefinitions.ToArray();
            var typeCount = types.Length;
            for(var k=0u; k<typeCount; k++)
            {
                 var hType = skip(types, k);
                 var methods = MD.GetTypeDefinition(hType).GetMethods().Array();
                 var methodCount = methods.Length;
                 var definitions = map(methods, m=> MD.GetMethodDefinition(m));
                 for(var i=0u; i<methodCount; i++)
                 {
                    ref readonly var method = ref skip(methods,i);
                    ref readonly var definition = ref skip(definitions,i);
                    var rva = definition.RelativeVirtualAddress;
                    if(rva != 0)
                    {
                        var body = PE.GetMethodBody(rva);
                        dst.Add(new MsilRow
                        {
                            MethodRva = (Address32)rva,
                            Token = EcmaTokens.token(method),
                            ImageName = ModulePath.FileName.Format(),
                            BodySize = body.Size,
                            LocalInit = body.LocalVariablesInitialized,
                            MaxStack = body.MaxStack,
                            MethodName = Clr.membername(MD.GetString(definition.Name)),
                            Code = body.GetILBytes(),
                        });
                    }
                 }
            }
            return dst.ViewDeposited();
        }

        // [Op]
        // public unsafe bool FindResource(string name, out ResourceSeg dst)
        // {
        //     dst = default;
        //     var directory = ReadSectionData(ResourcesDirectory);
        //     var descriptions = CliReader().ReadResInfo();
        //     var count = descriptions.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var description = ref descriptions[i];
        //         if(description.Name.Equals(name))
        //         {
        //             var blobReader = directory.GetReader((int)description.Offset, directory.Length - (int)description.Offset);
        //             var length = blobReader.ReadUInt32();
        //             MemoryAddress address = blobReader.CurrentPointer;
        //             dst = new ResourceSeg(name, new MemorySeg(address,length));
        //             return true;
        //         }
        //     }
        //     return false;
        // }

        // [Op]
        // public unsafe ReadOnlySeq<ResourceSeg> ReadResSegments()
        // {
        //     var resources = CliReader().ReadResInfo();
        //     var count = resources.Length;
        //     var dst = sys.alloc<ResourceSeg>(count);
        //     for(var i=0u; i<count; i++)
        //     {
        //         ref readonly var res = ref resources[i];
        //         var resdir = ReadSectionData(ResourcesDirectory);
        //         var blobReader = resdir.GetReader((int)res.Offset, resdir.Length - (int)res.Offset);
        //         var length = blobReader.ReadUInt32();
        //         MemoryAddress address = blobReader.CurrentPointer;
        //         seek(dst,i) = new ResourceSeg(res.Name, new MemorySeg(address,length));
        //     }
        //     return dst;
        // }

        // public const string OffsetPatternText = "{0,-60} | {1,-16}";

        // [MethodImpl(Inline)]
        // static string[] labels(PeFieldOffset src)
        //     => typeof(PeFieldOffset).DeclaredInstanceFields().Select(x => x.Name);

        // [MethodImpl(Inline)]
        // static string format(PeFieldOffset src)
        //     => RP.format(OffsetPatternText, src.Name, src.Value);


        // [Op]
        // public static void emit(IWfChannel channel, ReadOnlySpan<PeFieldOffset> src, FilePath dst)
        // {
        //     var emitter = text.emitter();
        //     var l = labels(default(PeFieldOffset));
        //     emitter.WriteLine(RP.format(OffsetPatternText, l[0], l[1]));
        //     for(var i=0u; i<src.Length; i++)
        //         emitter.WriteLine(format(skip(src,i)));                
        //     channel.FileEmit(emitter.Emit(), dst);
        // }

    }
}