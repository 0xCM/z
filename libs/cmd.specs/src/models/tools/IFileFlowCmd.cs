//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolFlowCmd : ICmd, IFlowCmd<FS.FilePath,FS.FilePath>
    {


    }

    [Free]
    public interface IToolFlowCmd<C> : IToolFlowCmd, ICmd<C>, IFlowCmd<C>
        where C : struct, IToolFlowCmd<C>

    {
    }

    [Free]
    public interface IToolFlowCmd<C,T> : IToolFlowCmd<C>, IToolFlowCmd<C,T,FS.FilePath,FS.FilePath>
        where C : struct, IToolFlowCmd<C,T>
        where T : ITool, new()
    {
        IActor IFlowCmd.Actor
            => Tool;
    }
}