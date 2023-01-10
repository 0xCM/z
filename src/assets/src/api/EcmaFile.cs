//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe class EcmaFile : IDisposable
    {
        public static void use(FilePath src, Action<EcmaFile> user, Action<Exception> error)
        {
            try
            {
                var stream = File.OpenRead(src.Name);
                var reader = new PEReader(stream, PEStreamOptions.PrefetchMetadata);
                using var file = new EcmaFile(src, stream, reader);
                user(file);
            }
            catch(Exception e)
            {
                error(e);
            }
        }

        public static EcmaFile open(FilePath src)
        {            
            var stream = File.OpenRead(src.Name);
            var reader = new PEReader(stream);
            var result = reader.HasMetadata;
            if(result)
                return new EcmaFile(src, stream, reader);
            else
            {
                stream.Dispose();
                reader.Dispose();
                throw Errors.Originate($"Unable to load metadata from {src}");
            }                
        }

        public readonly FileUri Uri;

        public readonly MemoryAddress ImageBase;

        public readonly MemoryAddress MetaBase;

        readonly FileStream Stream;

        public readonly PEReader PeReader;

        public readonly PEMemoryBlock ImageBlock;

        public readonly PEMemoryBlock MetaBlock;

        public readonly MetadataReader MetadataReader;

        public EcmaFile(FileUri file, FileStream stream, PEReader pe)
        {
            Uri = file;
            Stream = stream;
            PeReader = pe;
            ImageBlock = pe.GetEntireImage();            
            ImageBase = ImageBlock.Pointer;
            MetaBlock = pe.GetMetadata();
            MetaBase = MetaBlock.Pointer;
            MetadataReader = pe.GetMetadataReader();
        }

        public string Format()
            => Uri.Format();

        public void Dispose()
        {
            PeReader?.Dispose();
            Stream?.Dispose();            
        }
    }
}