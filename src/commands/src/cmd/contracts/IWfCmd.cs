//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfCmd : ICmd
    {

    }

    public interface IWfCmd<C> : IWfCmd, ICmd<C>
        where C : ICmd<C>, new()
    {

    }

    public interface IWfFlow<C,A,B> : IFlowCmd<A,B>, IWfCmd<C>
        where C : ICmd<C>, new()
    {
        IActor IFlowCmd.Actor 
            => default;
    }
}