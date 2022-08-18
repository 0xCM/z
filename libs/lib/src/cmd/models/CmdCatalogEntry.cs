//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public record struct CmdCatalogEntry : IComparable<CmdCatalogEntry>, IHashed, ISequential<CmdCatalogEntry>
    {
        const string TableId = "cmd.catalog";

        [Render(8)]
        public uint Seq;

        [Render(32)]
        public Name Name;

        [Render(16)]
        public Hash32 Hash;

        [Render(1)]
        public CmdUri Uri;

        Hash32 IHashed.Hash
            => Hash;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        public int CompareTo(CmdCatalogEntry src)
            => Name.CompareTo(src.Name);
    }
}