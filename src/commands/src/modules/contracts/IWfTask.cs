//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfTask
    {
        CmdUri TaskName {get;}
    }

    public interface IWfTask<C> : IWfTask
        where C : IWfCmd<C>, new()
    {
        C Command {get;}
    }
}