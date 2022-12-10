//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolFlowCmd : ICmd, IFlowCmd<FilePath,FilePath>
    {


    }

    [Free]
    public interface IToolFlowCmd<C> : IToolFlowCmd, IApiCmd<C>, IFlowCmd<C>
        where C : struct, IToolFlowCmd<C>

    {
    }

    [Free]
    public interface IToolFlowCmd<C,T> : IToolFlowCmd<C>, IToolFlowCmd<C,T,FilePath,FilePath>
        where C : struct, IToolFlowCmd<C,T>
        where T : ITool, new()
    {
        IActor IFlowCmd.Actor
            => Tool;
    }
}