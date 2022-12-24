//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Executor<E, C, P> : Executor<E>, ICmdExecutor<C, P>
        where E : Executor<E, C, P>, new()
        where C : IWfCmd<C>, new()
        where P : INullity, new()
    {
        protected abstract P Run(CmdContext context, C command);

        protected override Task<ExecToken> Execute(CmdContext context, ICmd command)
        {
            async Task<ExecToken> Exec()
            {
                var result = await Execute(context,command);
                return result;
            }

            return Exec();
        }

        public Task<CmdResult<C,P>> Execute(CmdContext context, C command)
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