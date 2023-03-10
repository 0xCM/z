//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class PeTables
    {
        public static PeTables load(PeReader src)
        {
            var dst = new PeTables();
            dst._Directories = directories(src.PE);
            dst._SectionHeaders = sections(src);
            dst._CoffHeader = coff(src.PE);
            dst._CorHeader = cor(src.PE.PEHeaders);
            dst._PeInfo = peinfo(src.PE);
            return dst;
        }

        ReadOnlySeq<PeSectionHeader> _SectionHeaders;
        
        CoffHeader _CoffHeader;

        CorHeaderInfo _CorHeader;

        PeFileInfo _PeInfo;

        ConstLookup<PeDirectoryKind,PeDirectoryEntry> _Directories;


        [MethodImpl(Inline)]
        public PeTables()
        {
            
        }

        public ref readonly ReadOnlySeq<PeSectionHeader> SectionHeaders => ref _SectionHeaders;

        public ref readonly ConstLookup<PeDirectoryKind,PeDirectoryEntry> Directories => ref _Directories;

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
            var buffer = sys.empty<PeSectionHeader>();
            if(headers != null)
            {
                var pe = headers.PEHeader;
                if(pe != null && headers.SectionHeaders != null)
                {
                    var sections = headers.SectionHeaders.AsSpan();
                    var count = sections.Length;
                    buffer = sys.alloc<PeSectionHeader>(count);
                    for(var i=0u; i<count; i++)
                    {
                        ref readonly var section = ref skip(sections,i);
                        ref var dst = ref seek(buffer,i);
                        dst.Seq = i;
                        dst.SectionFlags = section.SectionCharacteristics;
                        dst.SectionName = section.Name;
                        dst.RawDataAddress = (Address32)section.PointerToRawData;
                        dst.RawDataSize = (uint)section.SizeOfRawData;
                    }
                }
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

        static void entry(PeDirectoryKind kind, DirectoryEntry src, Dictionary<PeDirectoryKind,PeDirectoryEntry> dst) 
            => dst[kind] = src.WithKind(kind);

        static ConstLookup<PeDirectoryKind,PeDirectoryEntry> directories(PEReader src)
        {
            var dst = dict<PeDirectoryKind,PeDirectoryEntry>();
            if(src.PEHeaders != null)
            {
                var pe = src.PEHeaders.PEHeader;
                if(pe != null)
                {
                    entry(PeDirectoryKind.BaseRelocationTable, pe.BaseRelocationTableDirectory, dst);
                    entry(PeDirectoryKind.BoundImportTable, pe.BoundImportTableDirectory, dst);
                    entry(PeDirectoryKind.CertificateTable, pe.CertificateTableDirectory, dst);
                    entry(PeDirectoryKind.CorHeaderTable, pe.CorHeaderTableDirectory, dst);
                    entry(PeDirectoryKind.DebugTable, pe.DebugTableDirectory, dst);
                    entry(PeDirectoryKind.DelayImportTable, pe.DelayImportTableDirectory, dst);
                    entry(PeDirectoryKind.ExceptionTable, pe.ExceptionTableDirectory, dst);
                    entry(PeDirectoryKind.ExceptionTable, pe.ExportTableDirectory, dst);
                    entry(PeDirectoryKind.GlobalPointerTable, pe.GlobalPointerTableDirectory, dst);
                    entry(PeDirectoryKind.ImportAddressTable, pe.ImportAddressTableDirectory, dst);
                    entry(PeDirectoryKind.ImportTable, pe.ImportTableDirectory, dst);
                    entry(PeDirectoryKind.LoadConfigTable, pe.LoadConfigTableDirectory, dst);
                    entry(PeDirectoryKind.ResourceTable, pe.ResourceTableDirectory, dst);
                    entry(PeDirectoryKind.ThreadLocalStorageTable, pe.ThreadLocalStorageTableDirectory, dst);
                }

                var cor = src.PEHeaders.CorHeader;
                if(cor != null)
                {
                    entry(PeDirectoryKind.CodeManagerTable, cor.CodeManagerTableDirectory,dst);
                    entry(PeDirectoryKind.VtableFixups, cor.VtableFixupsDirectory,dst);
                    entry(PeDirectoryKind.ExportAddressTableJumps, cor.ExportAddressTableJumpsDirectory,dst);
                    entry(PeDirectoryKind.ManagedNativeHeader, cor.ManagedNativeHeaderDirectory,dst);
                    entry(PeDirectoryKind.MetadataTable, cor.MetadataDirectory,dst);
                    entry(PeDirectoryKind.StrongNameSignature, cor.StrongNameSignatureDirectory,dst);
                }
            }
            return dst;
        }
        static PeFileInfo peinfo(PEReader src)
        {
            var dst = new PeFileInfo();
            if(src.PEHeaders != null)
            {            
                var pe = src.PEHeaders.PEHeader;
                var coff = src.PEHeaders.CoffHeader;
                dst.Machine = coff.Machine;
                dst.Characteristics = coff.Characteristics;
                if(pe != null)
                {
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
                }
            }
            return dst;
        }
   }

   partial class XTend
   {
        public static PeDirectoryEntry WithKind(this DirectoryEntry src, PeDirectoryKind kind)
            => new PeDirectoryEntry(src.RelativeVirtualAddress, (uint)src.Size, kind);
   }
}