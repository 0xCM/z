//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdExecutor]
    public abstract class Executor : ICmdExecutor
    {
        protected IWfRuntime Wf;

        protected IWfChannel Channel;

        protected abstract Task<ExecToken> Execute(CmdContext context, ICmd command);

        Task<ExecToken> ICmdExecutor.Execute(CmdContext context, ICmd command)
            => Execute(context,command);
    }
}