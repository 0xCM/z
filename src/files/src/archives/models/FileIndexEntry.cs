//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName)]
    public record struct FileIndexEntry : ISequential<FileIndexEntry>, IComparable<FileIndexEntry>
    {
        const string TableName = "files.index";

        [Render(8)]
        public uint Seq;

        [Render(56)]
        public FileHash FileHash;

        [Render(1)]
        public FilePath Location;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Location.Hash;
        }

        public Hash128 ContentHash
        {
            [MethodImpl(Inline)]
            get => FileHash.ContentHash;
        }

        public Hash32 LocationHash
        {
            [MethodImpl(Inline)]
            get => FileHash.LocationHash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => ContentHash.Lo == 0 && ContentHash.Hi == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => ContentHash.Lo != 0 || ContentHash.Hi != 0;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(FileIndexEntry src)
            => Location.CompareTo(src.Location);

        public bool Equals(FileIndexEntry src)
            => Location.Equals(src.Location) && ContentHash == src.ContentHash && LocationHash == src.LocationHash;

        uint ISequential.Seq 
            { get => Seq; set => Seq = value; }

        public static FileIndexEntry Empty => new();
    }
}