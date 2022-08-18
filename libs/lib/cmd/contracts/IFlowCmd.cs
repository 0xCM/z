//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFlowCmd
    {
        IActor Actor {get;}
    }

    [Free]
    public interface IFlowCmd<C> : IFlowCmd
        where C : IFlowCmd<C>, new()
    {
        IActor IFlowCmd.Actor
            => new Tool(typeof(C).Tag<CmdAttribute>().MapValueOrDefault(x => x.Name, GetType().Name));
    }

    [Free]
    public interface IFlowCmd<A,B> : IFlowCmd
    {
        A Source {get;}

        B Target {get;}
    }
}