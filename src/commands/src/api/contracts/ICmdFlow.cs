//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdFlow<C,A,B> : IFlowCmd<A,B>, ICmd<C>
        where C : ICmd<C>, new()
    {
        IActor IFlowCmd.Actor 
            => new Actor("wf/module");
    }   
}