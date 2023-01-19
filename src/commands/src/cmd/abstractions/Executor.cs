//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdExecutor]
    public abstract class Executor : IToolExecutor
    {
        public static ReadOnlySeq<IToolExecutor> discover(params Assembly[] src)
            => src.Types().Tagged<CmdExecutorAttribute>().Concrete().Map(x => (IToolExecutor)Activator.CreateInstance(x));

        protected IWfRuntime Wf;

        protected IWfChannel Channel;

        protected abstract Task<ExecToken> Execute(ToolContext context, ICmd command);

        Task<ExecToken> IToolExecutor.Execute(ToolContext context, ICmd command)
            => Execute(context,command);
    }
}