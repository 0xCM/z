//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe class EcmaFile : IDisposable
    {
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

        public readonly FilePath Path;

        public readonly MemoryAddress ImageBase;

        public readonly MemoryAddress MetaBase;

        readonly FileStream Stream;

        public readonly PEReader PeReader;

        public readonly PEMemoryBlock ImageBlock;

        public readonly ByteSize ImageSize;

        public readonly PEMemoryBlock MetaBlock;

        public readonly MetadataReader MdReader;

        public EcmaFile(FilePath file, FileStream stream, PEReader pe)
        {
            Path = file;
            Stream = stream;
            PeReader = pe;
            ImageBlock = pe.GetEntireImage();            
            ImageBase = ImageBlock.Pointer;
            MetaBlock = pe.GetMetadata();
            MetaBase = MetaBlock.Pointer;
            MdReader = pe.GetMetadataReader();
            ImageSize = ImageBlock.Length;
        }

        public ReadOnlySpan<byte> ImageData
        {
            [MethodImpl(Inline)]
            get => sys.cover(ImageBase.Pointer<byte>(), ImageSize);
        }

        public MethodBodyBlock MethodBody(Address32 rva)
            => PeReader.GetMethodBody((int)rva);

        public string Format()
            => Path.Format();

        public void Dispose()
        {
            PeReader?.Dispose();
            Stream?.Dispose();            
        }

        public AssemblyFile AssemblyFile()
            => new AssemblyFile(Path, MdReader.GetAssemblyDefinition().GetAssemblyName().GetVersionedName());
    }
}