//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe class EcmaFile : IDisposable
    {

        public static bool load(FilePath src, out EcmaFile dst)
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

        public readonly FileUri Uri;

        public readonly MemoryAddress ImageBase;

        public readonly MemoryAddress MetaBase;

        readonly FileStream Stream;

        readonly PEReader PeReader;

        readonly PEMemoryBlock ImageBlock;

        readonly PEMemoryBlock MetaBlock;

        readonly MetadataReader MetadataReader;

        internal EcmaFile(FileUri file)
        {
            Uri = file;
        }

        internal EcmaFile(FileUri file, FileStream stream, PEReader pe)
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

        public bool IsEmpty
        {
            get => Stream == null || PeReader == null;
        }

        public bool IsNonEmpty
        {
            get => Stream != null && PeReader != null;
        }

        public static EcmaFile Empty => new EcmaFile(FileUri.Empty);       
    }
}