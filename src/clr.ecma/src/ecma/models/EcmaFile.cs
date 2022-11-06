//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe class EcmaFile : IDisposable
    {
        public readonly FileUri Uri;

        public readonly MemoryAddress ImageBase;

        public readonly MemoryAddress MetaBase;

        readonly FileStream Stream;

        internal readonly PEReader PeReader;

        internal readonly PEMemoryBlock ImageBlock;

        internal readonly PEMemoryBlock MetaBlock;

        internal readonly MetadataReader MetadataReader;

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