//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfFlow<C,A,B> : IFlowCmd<A,B>, IWfCmd<C>
        where C : IWfCmd<C>, new()
    {
        IActor IFlowCmd.Actor 
            => new Actor("wf/module");
    }   
}