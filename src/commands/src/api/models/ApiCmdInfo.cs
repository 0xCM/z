//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public record struct ApiCmdInfo : IComparable<ApiCmdInfo>, IHashed, ISequential<ApiCmdInfo>
    {
        const string TableId = "cmd.catalog";

        [Render(8)]
        public uint Seq;

        [Render(32)]
        public @string Name;

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

        public int CompareTo(ApiCmdInfo src)
            => Name.CompareTo(src.Name);

        public override string ToString()
            => Uri.Format();
    }
}