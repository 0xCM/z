//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    public abstract class Executor<E, C> : Executor<E>, ICmdExecutor<E, C>
        where E : ICmdExecutor, new()
        where C : ICmd<C>, new()
    {
        public Task<ExecToken> Execute(IWfChannel channel, CmdContext context, C command)
        {
            return sys.start(() => Run(channel, context,command));
        }

        protected abstract ExecToken Run(IWfChannel channel, CmdContext context, C command);

        protected override Task<ExecToken> Execute(IWfChannel channel, CmdContext context, ICmd command)
            => Execute(channel, context, (C)command);
    }
}