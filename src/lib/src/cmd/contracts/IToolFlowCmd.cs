//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolFlowCmd<C,T,A,B> : IFlowCmd<A,B>
        where C : struct, IToolFlowCmd<C,T,A,B>
        where T : ITool, new()
    {
        T Tool {get;}

        IActor IFlowCmd.Actor
            => Tool;
    }
}