//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Reflection.Metadata;
    using System.Reflection.PortableExecutable;

    using static sys;

    [ApiHost]
    public readonly struct ClrModules
    {
        public static ReadOnlySeq<AssemblyRefInfo> refs(Assembly src)
        {
            var path = FS.path(src.Location);
            if(ClrModules.valid(path))
            {
                using var reader = PeReader.create(path);
                return reader.ReadAssemblyRefs();
            }
            else
                return ReadOnlySeq<AssemblyRefInfo>.Empty;
        }

        [Op]
        public static ClrModuleInfo describe(Assembly src)
        {
            var dst = new ClrModuleInfo();
            var adapted = Clr.adapt(src);
            dst.ImgPath = location(src);
            pdbpath(adapted, out dst.PdbPath);
            xmlpath(adapted, out dst.XmlPath);
            dst.MetadatSize = (ByteSize)adapted.RawMetadata.Length;
            return dst;
        }

        /// <summary>
        /// Loads an assembly + pdb
        /// </summary>
        /// <param name="image">The assembly path</param>
        /// <param name="pdb">The pdb path</param>
        [Op]
        public static Assembly load(FilePath image, FilePath pdb)
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
        public static uint describe(ReadOnlySpan<Assembly> src, Span<ClrModuleInfo> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = describe(skip(src,i));
            return count;
        }

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

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider ReaderProvider(Assembly src)
        {
            var metadata = Clr.metadata(src);
            return ReaderProvider(metadata.BaseAddress.Pointer<byte>(), metadata.Size);
        }

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider ReaderProvider(byte* pSrc, ByteSize size)
            => MetadataReaderProvider.FromMetadataImage(pSrc, size);

        [MethodImpl(Inline), Op]
        public static MetadataReaderProvider ReaderProvider(Stream stream, MetadataStreamOptions options = MetadataStreamOptions.Default)
            => MetadataReaderProvider.FromMetadataStream(stream, options);

        [MethodImpl(Inline), Op]
        public unsafe static MetadataReaderProvider PdbReaderProvider(byte* pSrc, ByteSize size)
            => MetadataReaderProvider.FromPortablePdbImage(pSrc, size);

        [MethodImpl(Inline), Op]
        public static MetadataReaderProvider PdbReaderProvider(Stream src, MetadataStreamOptions options = MetadataStreamOptions.Default)
            => MetadataReaderProvider.FromPortablePdbStream(src, options);
    }
}