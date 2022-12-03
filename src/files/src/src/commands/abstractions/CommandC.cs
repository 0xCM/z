//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    [Cmd]
    public abstract record class Command : ICmd
    {
        public abstract CmdId CmdId {get;}

        public abstract string Format();

        public sealed override string ToString()
            => Format();
    }

    public abstract record class Command<C> : Command, ICmd<C>
        where C : Command<C>, new()
    {
        
        public static C Empty => new();
        public override CmdId CmdId 
            => CmdId.identify<C>();
        
        public override string Format()
            => Commands.format((C)this);
    }
}