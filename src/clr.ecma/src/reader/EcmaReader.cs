//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;

    [ApiHost]
    public unsafe partial class EcmaReader
    {
        public static AssemblyFiles assemblies(IWfChannel channel, IDbArchive src)
        {
            var dst = bag<AssemblyFile>();
            var counter = 0u;
            var running = channel.Running($"Searching {src.Root} for assemlies");
            iter(src.Enumerate(true, FileKind.Dll, FileKind.Exe), path => {
                try
                {
                    using var ecma = EcmaFile.open(path);
                    var reader = ecma.Reader(); 
                    var def = reader.ReadAssemblyDef();                    
                    dst.Add(new AssemblyFile(path, def.GetAssemblyName()));
                    if(math.mod(inc(ref counter),1000) == 0)
                        channel.Babble($"Found {counter} assemblies");
                }
                catch(Exception)
                {
                    
                }
            }
            );
            channel.Ran(running, $"Found {counter} assemblies");
            return dst.Array();
        }

        public static void stats(ReadOnlySpan<Assembly> src, ConcurrentBag<EcmaRowStats> dst)
            => iter(src, a => stats(a,dst), true);

        public static void stats(Assembly src, ConcurrentBag<EcmaRowStats> dst)
            => stats(EcmaReader.create(src), dst);

        public static IEnumerable<AssemblyRefInfo> refs(IEnumerable<AssemblyFile> src)
        {
            foreach(var file in src.AsParallel())
            {
                using var ecma = EcmaFile.open(file.Path);
                var reader = EcmaReader.create(ecma);
                var refs = reader.ReadAssemblyRefs().Storage;
                foreach(var r in refs)
                    yield return r;                
            }
        }

        public ByteSize CalcTableSize(TableIndex table)
            => MD.GetTableRowCount(table)*MD.GetTableRowSize(table);

        public static ReadOnlySeq<EcmaRowStats> stats(EcmaReader reader)
        {
            var dst = bag<EcmaRowStats>();
            stats(reader,dst);
            return dst.Array().Sort();
        }

        [Op]
        public static void stats(EcmaReader reader, ConcurrentBag<EcmaRowStats> dst)
        {
            var indicies = Symbols.values<TableIndex,byte>();
            var counts = reader.GetRowCounts(indicies);
            var offsets = reader.GetTableOffsets(indicies);
            var sizes = reader.GetRowSizes(indicies);            
            var name = reader._AssemblyName;
            for(byte j=0; j<counts.Count; j++)
            {
                var table = (TableIndex)j;
                var rowcount = counts[table];
                var rowsize = sizes[table];
                if(rowcount != 0)
                {
                    var entry = new EcmaRowStats();
                    entry.AssemblyName = name;
                    entry.TableName = table.ToString();
                    entry.TableOffset = offsets[table];
                    entry.TableIndex = j;
                    entry.RowCount = rowcount;
                    entry.RowSize = rowsize;
                    entry.TableSize = rowcount*rowsize;
                    dst.Add(entry);
                }
            }
        }

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider provider(Assembly src)
        {
            var metadata = ClrAssembly.metadata(src);
            return provider(metadata.BaseAddress.Pointer<byte>(), metadata.Size);
        }

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider provider(byte* pSrc, ByteSize size)
            => MetadataReaderProvider.FromMetadataImage(pSrc, size);

        [MethodImpl(Inline), Op]
        public static MetadataReaderProvider provider(Stream stream, MetadataStreamOptions options = MetadataStreamOptions.Default)
            => MetadataReaderProvider.FromMetadataStream(stream, options);

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider pdbProvider(byte* pSrc, ByteSize size)
            => MetadataReaderProvider.FromPortablePdbImage(pSrc, size);

        [MethodImpl(Inline), Op]
        public static MetadataReaderProvider pdbProvider(Stream src, MetadataStreamOptions options = MetadataStreamOptions.Default)
            => MetadataReaderProvider.FromPortablePdbStream(src, options);

        public static IEnumerable<FilePath> valid(DbArchive src, FileKind kind)
            => from file in src.Enumerate($"*.{kind.Ext()}") where EcmaReader.valid(file) select file;                        

        [Op]
        public static bool valid(FilePath src)
        {
            try
            {
                using var stream = File.OpenRead(src.Name);
                using var reader = new PEReader(stream);
                return reader.HasMetadata;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Loads an assembly + pdb
        /// </summary>
        /// <param name="image">The assembly path</param>
        /// <param name="pdb">The pdb path</param>
        [Op]
        public static Assembly assembly(FilePath image, FilePath pdb)
            => Assembly.Load(image.ReadBytes(), pdb.ReadBytes());

        [MethodImpl(Inline), Op]
        public static FilePath location(ClrAssembly src)
            => FS.path(src.Definition.Location);

        [Op]
        public static FileUri xmlpath(ClrAssembly src, out FileUri dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Xml.Name));
            dst = candidate.Exists ? candidate : FilePath.Empty;
            return dst;
        }

        [Op]
        public static FileUri pdbpath(ClrAssembly src, out FileUri dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Pdb.Name));
            dst = candidate.Exists ? candidate : FilePath.Empty;
            return dst;
        }

        [Op]
        public static EcmaModuleInfo describe(Assembly src)
        {
            var dst = new EcmaModuleInfo();
            var adapted = Clr.adapt(src);
            dst.ImgPath = location(src);
            pdbpath(adapted, out dst.PdbPath);
            xmlpath(adapted, out dst.XmlPath);
            dst.MetadatSize = (ByteSize)adapted.RawMetadata.Length;
            return dst;
        }

        [Op]
        public static uint describe(ReadOnlySpan<Assembly> src, Span<EcmaModuleInfo> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = describe(skip(src,i));
            return count;
        }

        public static unsafe EcmaReader create(MemoryAddress @base, ByteSize size)
            => new (new PEReader(@base.Pointer<byte>(), size).GetMetadata());

        public static EcmaReader create(EcmaFile src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(Assembly src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(MetadataReader src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(MemorySeg src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(PEMemoryBlock src)
            => new EcmaReader(src);

        readonly MetadataReader MD;

        public ref readonly MetadataReader MetadataReader
        {
            
            [MethodImpl(Inline)]
            get => ref MD;
        }

        readonly MemorySeg Segment;

        GenericSignatureTypeProvider GSTP = new GenericSignatureTypeProvider();

        [MethodImpl(Inline)]
        public EcmaReader(Assembly src)
        {
            Segment = ClrAssembly.metadata(src);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public EcmaReader(MemorySeg src)
        {
            Segment = src;
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);            
        }

        [MethodImpl(Inline)]
        public EcmaReader(PEMemoryBlock src)
        {
            Segment = MemorySegs.define(src.Pointer, src.Length);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);        
        }

        [MethodImpl(Inline)]
        public EcmaReader(MetadataReader src)
        {
            Segment = MemorySegs.define(src.MetadataPointer, src.MetadataLength);
            MD = src;
        }

        [MethodImpl(Inline)]
        public EcmaReader(EcmaFile src)
        {
            Segment = MemorySegs.define(src.MetadataReader.MetadataPointer, src.MetadataReader.MetadataLength);
            MD = src.MetadataReader;
        }

        public ByteSize MetaSize
        {
            [MethodImpl(Inline)]
            get => Segment.Size;
        }

        public ReadOnlySpan<byte> MetaBytes
        {
            [MethodImpl(Inline)]
            get => MemorySegs.view<byte>(Segment);
        }

        public string _AssemblyName
            => String(ReadAssemblyDef().Name);        
    }
}