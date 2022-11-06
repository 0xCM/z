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

        public static IEnumerable<FileUri> valid(DbArchive src, FileKind kind)
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
        public static ref readonly FilePath xmlpath(ClrAssembly src, out FilePath dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Xml.Name));
            dst = candidate.Exists ? candidate : FilePath.Empty;
            return ref dst;
        }

        [Op]
        public static ref readonly FilePath pdbpath(ClrAssembly src, out FilePath dst)
        {
            var candidate = FS.path(Path.ChangeExtension(src.Definition.Location, FS.Pdb.Name));
            dst = candidate.Exists ? candidate : FilePath.Empty;
            return ref dst;
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

        public static bool file(FilePath src, out EcmaFile dst)
        {
            var result = false;
            dst = EcmaFile.Empty;
            try
            {
                var stream = File.OpenRead(src.Name);
                var reader = new PEReader(stream);
                result = reader.HasMetadata;
                if(result)
                {
                    dst = new EcmaFile(src, stream, reader);
                }
                else
                {
                    stream.Dispose();
                    reader.Dispose();
                }
                
            }
            catch(Exception)
            {
                
            }
            return result;
        }        

        public static unsafe PEReader pe(MemorySeg src)
            => new PEReader(src.BaseAddress.Pointer<byte>(), src.Size);

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
    }
}