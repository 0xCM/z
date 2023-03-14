//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;

    [ApiHost]
    public unsafe partial class EcmaReader : IEcmaReader
    {
        [MethodImpl(Inline), Op]
        public string String(EcmaStringIndex index)
            => MD.GetString(index);

        [MethodImpl(Inline), Op]
        public Guid Guid(EcmaGuidIndex index)
            => MD.GetGuid(index);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Blob(EcmaBlobIndex index)
            => MD.GetBlobBytes(index);

        [MethodImpl(Inline), Op]
        public byte[] BlobArray(EcmaBlobIndex index)
            => MD.GetBlobBytes(index);

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

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, UserStringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        public static AssemblyFiles assemblies(IWfChannel channel, IDbArchive src)
        {
            var dst = bag<AssemblyFile>();
            var counter = 0u;
            var running = channel.Running($"Searching {src.Root} for assemlies");
            iter(src.Enumerate(true, FileKind.Dll, FileKind.Exe), path => {
                try
                {
                    using var ecma = Ecma.file(path);
                    var reader = ecma.EcmaReader(); 
                    var def = reader.ReadAssemblyDef();                   
                    var kind = FileModuleKind.Managed;
                    if(path.Is(FileKind.Exe)) 
                        kind |= FileModuleKind.Exe;
                    else
                        kind |= FileModuleKind.Dll;
                    dst.Add(new AssemblyFile(path, def.GetAssemblyName()));
                    if(math.mod(inc(ref counter),1000) == 0)
                        channel.Babble($"Found {counter} assemblies");
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
            }
            );
            channel.Ran(running, $"Found {counter} assemblies");
            return dst.Array();
        }
        
        public static IEnumerable<EcmaTables.AssemblyRef> refs(IEnumerable<AssemblyFile> src)
        {
            foreach(var file in src.AsParallel())
            {
                using var ecma = Ecma.file(file.Path);
                var reader = Ecma.reader(ecma);
                var refs = reader.ReadAssemblyRefRows().Storage;
                foreach(var r in refs)
                    yield return r;                
            }
        }

        public ByteSize CalcTableSize(TableIndex table)
            => MD.GetTableRowCount(table)*MD.GetTableRowSize(table);

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
            => from file in src.Enumerate(true, $"*.{kind.Ext()}") where EcmaReader.valid(file) select file;                        

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
            Segment = MemorySegs.define(src.MdReader.MetadataPointer, src.MdReader.MetadataLength);
            MD = src.MdReader;
        }

        [MethodImpl(Inline)]
        public MetadataMemory Memory(uint offset = 0)
            => new MetadataMemory(Segment, offset);

            //var header = Memory.Read<MetadataHeader>();
 
        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Segment.BaseAddress;
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