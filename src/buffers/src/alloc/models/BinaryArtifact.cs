//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public unsafe readonly record struct BinaryArtifact : IComparable<BinaryArtifact>
    {
        readonly StringRef _Path;

        readonly MemorySeg Data;

        public BinaryArtifact(StringRef path, MemorySeg data)
        {
            _Path = path;
            Data = data;
        }
       
        public MemoryAddress BaseAddress 
            => Data.BaseAddress;

        public ByteSize Size
            => Data.Size;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public FilePath Path 
            => FS.path(_Path.Format());

        public int CompareTo(BinaryArtifact src)
            => Path.CompareTo(src.Path);
    }
}