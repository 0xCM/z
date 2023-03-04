//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class PeTables
    {
        ReadOnlySeq<PeSectionHeader> _SectionHeaders;
        
        CoffHeader _CoffHeader;

        CorHeaderInfo _CorHeader;

        PeFileInfo _PeInfo;

        public static PeTables load(PeReader src)
        {
            var dst = new PeTables();
            dst._SectionHeaders = sections(src);
            dst._CoffHeader = coff(src.PE);
            dst._CorHeader = cor(src.PE.PEHeaders);
            dst._PeInfo = peinfo(src.PE);
            return dst;
        }

        [MethodImpl(Inline)]
        public PeTables()
        {
            
        }

        public ref readonly ReadOnlySeq<PeSectionHeader> SectionHeaders => ref _SectionHeaders;

        public ref readonly CoffHeader CoffHeader => ref _CoffHeader;

        public ref readonly CorHeaderInfo CorHeader => ref _CorHeader;

        public ref readonly PeFileInfo PeInfo => ref _PeInfo;

        static CoffHeader coff(PEReader pe)
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

        static ReadOnlySeq<PeSectionHeader> sections(PeReader src)
        {
            var headers = src.PE.PEHeaders;
            var pe = headers.PEHeader;
            var sections = headers.SectionHeaders.AsSpan();
            var count = sections.Length;
            var buffer = sys.alloc<PeSectionHeader>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var section = ref skip(sections,i);
                ref var dst = ref seek(buffer,i);
                dst.ModuleName = src.ModulePath.FileName;
                dst.EntryPoint = (Address32)pe.AddressOfEntryPoint;
                dst.CodeBase = (Address32)pe.BaseOfCode;
                dst.GptRva = (Address32)pe.GlobalPointerTableDirectory.RelativeVirtualAddress;
                dst.GptSize = (ByteSize)pe.GlobalPointerTableDirectory.Size;
                dst.SectionFlags = section.SectionCharacteristics;
                dst.SectionName = section.Name;
                dst.RawDataAddress = (Address32)section.PointerToRawData;
                dst.RawDataSize = (uint)section.SizeOfRawData;
                dst.ModulePath = src.ModulePath;
            }
            return buffer;
        }

        static CorHeaderInfo? cor(PEHeaders src)
        {
            var cor = src.CorHeader;
            var dst = default(CorHeaderInfo);
            if(cor != null)
            {
                dst = new();
                dst.MajorRuntimeVersion = cor.MajorRuntimeVersion;
                dst.MinorRuntimeVersion = cor.MinorRuntimeVersion;
                dst.MetadataDirectory = cor.MetadataDirectory.WithKind(PeDirectoryKind.MetadataTable);
                dst.Flags = cor.Flags;
                dst.EntryPointTokenOrRelativeVirtualAddress = cor.EntryPointTokenOrRelativeVirtualAddress;
                dst.ResourcesDirectory = cor.ResourcesDirectory.WithKind(PeDirectoryKind.ResourceTable);
                dst.StrongNameSignatureDirectory = cor.StrongNameSignatureDirectory.WithKind(PeDirectoryKind.StrongNameSignature);
                dst.CodeManagerTableDirectory = cor.CodeManagerTableDirectory.WithKind(PeDirectoryKind.CodeManagerTable);
                dst.VtableFixupsDirectory = cor.VtableFixupsDirectory.WithKind(PeDirectoryKind.VtableFixups);
                dst.ExportAddressTableJumpsDirectory = cor.ExportAddressTableJumpsDirectory.WithKind(PeDirectoryKind.ExportAddressTableJumps);
                dst.ManagedNativeHeaderDirectory = cor.ManagedNativeHeaderDirectory.WithKind(PeDirectoryKind.ManagedNativeHeader);
            }
            return dst;
        }

        static PeFileInfo peinfo(PEReader src)
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
            dst.ExportDir = pe.ExportTableDirectory.WithKind(PeDirectoryKind.ExportTable);
            dst.ImportDir = pe.ImportTableDirectory.WithKind(PeDirectoryKind.ImportTable);
            dst.ResourceDir = pe.ResourceTableDirectory.WithKind(PeDirectoryKind.ResourceTable);
            dst.RelocationDir = pe.BaseRelocationTableDirectory.WithKind(PeDirectoryKind.BaseRelocationTable);
            dst.ImportAddressDir = pe.ImportAddressTableDirectory.WithKind(PeDirectoryKind.ImportAddressTable);
            dst.LoadConfigDir = pe.LoadConfigTableDirectory.WithKind(PeDirectoryKind.LoadConfigTable);
            dst.DebugDir = pe.DebugTableDirectory.WithKind(PeDirectoryKind.DebugTable);
            dst.Characteristics = coff.Characteristics;
            return dst;
        }
   }

   partial class XTend
   {
        public static PeDirectoryEntry WithKind(this DirectoryEntry src, PeDirectoryKind kind)
            => new PeDirectoryEntry(src.RelativeVirtualAddress, (uint)src.Size, kind);
   }
}