//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Executor<E, C, P> : Executor<E>//, IToolExecutor<C, P>
        where E : Executor<E, C, P>, new()
        where C : IApiCmd<C>, new()
        where P : INullity, new()
    {
        protected abstract P Run(ToolContext context, C command);

        protected override Task<ExecToken> Execute(ToolContext context, ICmd command)
        {
            async Task<ExecToken> Exec()
                => await Execute(context,command);

            return Exec();
        }

        public Task<CmdResult<C,P>> Execute(ToolContext context, C command)
        {
            CmdResult<C,P> Exec()
            {
                var flow = Channel.Executing(command);
                try
                {
                    var payload = Run(context,command);
                    return new CmdResult<C, P>(command, Channel.Ran(flow), true, payload);
                }
                catch(Exception e)
                {
                    Channel.Error(e);
                    return new CmdResult<C, P>(command, Channel.Ran(flow), false, new P());
                }
            }
            return sys.start(Exec);            
        }
    }
}