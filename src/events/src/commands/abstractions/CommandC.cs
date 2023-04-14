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
            => ApiCmdSpec.format((C)this);

        public static C Empty => new();
    }        
}