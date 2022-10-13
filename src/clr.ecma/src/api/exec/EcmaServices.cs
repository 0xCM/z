//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EcmaServices : WfSvc<EcmaServices>
    {
        public static ExecResult exec<C>(IWfContext context, C cmd, Func<IWfContext,C,Outcome> actor)
            where C : ICmd<C>, new()
        {
            var result = ExecResult.Empty;
            var outcome = Outcome.Success;
            var running = context.Channel.Running($"{cmd.CmdId}");
            try
            {
                outcome = actor(context,cmd);
            }
            catch(Exception e)
            {
                outcome = e;
            }

            return new(context.Channel.Ran(running, result),outcome);
        }

        static Outcome exec(IWfContext channel, CatalogAssemblies cmd)
        {
            var result = Outcome.Success;
            var src = cmd.Source.DbArchive();
            var dst = cmd.Target.DbArchive();
            return result;
        }
        
        public Task<ExecResult> Start(CatalogAssemblies cmd)
            => sys.start(() => exec(Context, cmd, exec));
    }
}
