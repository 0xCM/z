//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdExecutor]
    public abstract class Executor : ICmdExecutor
    {
        protected abstract Task<ExecToken> Execute(IWfChannel channel, CmdContext context, ICmd command);

        Task<ExecToken> ICmdExecutor.Execute(IWfChannel channel, CmdContext context, ICmd command)
            => Execute(channel,context,command);
    }

    public abstract class Executor<E> : Executor
        where E : ICmdExecutor, new()
    {
        public static E create()
            => new E();
    }
}