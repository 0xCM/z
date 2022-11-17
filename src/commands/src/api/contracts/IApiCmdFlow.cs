//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiCmdFlow<C,A,B> : IFlowCmd<A,B>, IApiCmd<C>
        where C : IApiCmd<C>, new()
    {
        IActor IFlowCmd.Actor 
            => new Actor("wf/module");
    }   
}