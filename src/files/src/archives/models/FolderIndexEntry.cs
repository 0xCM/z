//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName)]
    public record class FolderIndexEntry : ISequential<FolderIndexEntry>, IComparable<FolderIndexEntry>
    {
        const string TableName = "folders.index";

        [Render(8)]
        public uint Seq;

        [Render(1)]
        public FolderPath Path;

        uint ISequential.Seq { get => Seq; set => Seq = value; }

        public int CompareTo(FolderIndexEntry src)
            => Path.CompareTo(src.Path);
    }
}

