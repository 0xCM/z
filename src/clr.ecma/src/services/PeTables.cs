//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class PeTables
    {
        public static PeTables load(FilePath path, PEReader reader)
        {
            var dst = new PeTables(path);
            var dirs = directories(reader);
            dst._PeInfo = peinfo(path, reader);
            dst._Directories = dirs;
            dst._SectionHeaders = sections(path,reader);
            dst._CoffHeader = coff(reader);        
            dst._CorHeader = cor(reader.PEHeaders);
            dst._DirectoryRows = rows(path.FileName, dst.Directories);
            return dst;
        }

        ReadOnlySeq<SectionHeaderRow> _SectionHeaders;
        
        CoffHeader _CoffHeader;

        CorHeader _CorHeader;

        PeFileInfo _PeInfo;

        PeDirectoryEntries _Directories;

        ReadOnlySeq<PeDirectoryRow> _DirectoryRows;

        public readonly FilePath Source;

        [MethodImpl(Inline)]
        public PeTables(FilePath path)
        {
            Source = path;
        }

        public ref readonly ReadOnlySeq<SectionHeaderRow> SectionHeaders 
            => ref _SectionHeaders;

        public ReadOnlySpan<PeDirectoryEntry> Directories 
            => sys.recover<PeDirectoryEntry>(sys.bytes(_Directories));
        
        public ref readonly ReadOnlySeq<PeDirectoryRow> DirectoryRows 
            => ref _DirectoryRows;
        
        public ref readonly CoffHeader CoffHeader 
            => ref _CoffHeader;

        public ref readonly CorHeader CorHeader 
            => ref _CorHeader;

        public ref readonly PeFileInfo PeInfo 
            => ref _PeInfo;

        static ReadOnlySeq<PeDirectoryRow> rows(FileName file,  ReadOnlySpan<PeDirectoryEntry> src)
        {
            var count = src.Length;
            var dst = alloc<PeDirectoryRow>(count);
            var i=0u;
            iter(src, entry => {
                seek(dst,i++) = new PeDirectoryRow{
                    File = file,
                    Kind = (PeDirectoryKind)i,
                    Rva = entry.Rva,
                    Size = entry.Size
                };
            });
            return dst;
        }

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

        static ReadOnlySeq<SectionHeaderRow> sections(FilePath src, PEReader reader)
        {
            var headers = reader.PEHeaders;
            var buffer = sys.empty<SectionHeaderRow>();
            if(headers != null)
            {
                var pe = headers.PEHeader;
                if(pe != null && headers.SectionHeaders != null)
                {
                    var sections = headers.SectionHeaders.AsSpan();
                    var count = sections.Length;
                    buffer = sys.alloc<SectionHeaderRow>(count);
                    for(var i=0u; i<count; i++)
                    {
                        ref readonly var section = ref skip(sections,i);
                        ref var dst = ref seek(buffer,i);
                        dst.Seq = i;
                        dst.File = src.FileName;
                        dst.SectionFlags = section.SectionCharacteristics;
                        dst.SectionName = section.Name;
                        dst.SectionBase = (Address32)section.PointerToRawData;
                        dst.SectionSize = (uint)section.SizeOfRawData;
                    }
                }
            }
            return buffer;
        }

        static CorHeader cor(PEHeaders src)
        {
            var cor = src.CorHeader;
            var dst = default(CorHeader);
            if(cor != null)
            {
                dst = new();
                dst.MajorRuntimeVersion = cor.MajorRuntimeVersion;
                dst.MinorRuntimeVersion = cor.MinorRuntimeVersion;
                dst.MetadataDirectory = cor.MetadataDirectory;
                dst.Flags = cor.Flags;
                dst.EntryPoint = cor.EntryPointTokenOrRelativeVirtualAddress;
                dst.ResourcesDirectory = cor.ResourcesDirectory;
                dst.StrongNameSignatureDirectory = cor.StrongNameSignatureDirectory;
                dst.CodeManagerTableDirectory = cor.CodeManagerTableDirectory;
                dst.VtableFixupsDirectory = cor.VtableFixupsDirectory;
                dst.ExportAddressTableJumpsDirectory = cor.ExportAddressTableJumpsDirectory;
                dst.ManagedNativeHeaderDirectory = cor.ManagedNativeHeaderDirectory;
            }
            return dst;
        }

        static PeFileInfo peinfo(FilePath src, PEReader reader)
        {
            var dst = new PeFileInfo();
            if(reader.PEHeaders != null)
            {            
                var coff = reader.PEHeaders.CoffHeader;
                dst.File = src.FileName;
                dst.Machine = coff.Machine;
                dst.Characteristics = coff.Characteristics;
                var pe = reader.PEHeaders.PEHeader;
                if(pe != null)
                {
                    dst.ImageBase = pe.ImageBase;
                    dst.EntryPointOffset = pe.AddressOfEntryPoint;
                    dst.CodeOffset = pe.BaseOfCode;
                    dst.CodeSize = (uint)pe.SizeOfCode;
                    dst.DataOffset = pe.BaseOfData;
                    dst.ImageSize = (uint)pe.SizeOfImage;
                }
            }
            return dst;
        }

        static PeDirectoryEntries directories(PEReader reader)
        {
            var dst = new PeDirectoryEntries();
            var pe = reader.PEHeaders.PEHeader;
            if(pe != null)
            {
                dst.ExportTable = pe.ExportTableDirectory;
                dst.ImportTable = pe.ImportTableDirectory;
                dst.ExceptionTable = pe.ExceptionTableDirectory;
                dst.CertificateTable = pe.CertificateTableDirectory;
                dst.GlobalPointerTable = pe.GlobalPointerTableDirectory;
                dst.TlsTable = pe.ThreadLocalStorageTableDirectory;
                dst.LoadConfigTable = pe.LoadConfigTableDirectory;
                dst.BoundImportTable = pe.BoundImportTableDirectory;
                dst.ResourceTable = pe.ResourceTableDirectory;
                dst.RelocationTable = pe.BaseRelocationTableDirectory;
                dst.ImportAddressTable = pe.ImportAddressTableDirectory;
                dst.DebugTable = pe.DebugTableDirectory;
                dst.CorHeader = pe.CorHeaderTableDirectory;
                dst.DelayImportTable = pe.DelayImportTableDirectory;
            }
            return dst;
        }
   }
}