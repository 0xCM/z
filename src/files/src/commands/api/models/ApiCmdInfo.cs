//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class Command<C> : Command, IApiCmd<C>
        where C : Command<C>, new()
    {        
        public override CmdId CmdId 
            => CmdId.identify<C>();
        
        public override string Format()
            => Cmd.format((C)this);

        public static C Empty => new();
    }
        
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