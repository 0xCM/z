//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdHandler]
    public abstract class CmdHandler : ICmdHandler
    {
        ApiCmdRoute Route;

        protected static AppSettings AppSettings => AppSettings.Default;
        
        protected static IEnvDb EnvDb => AppSettings.EnvDb();
        
        protected IWfRuntime Wf {get; private set;}
    
        protected IWfChannel Channel {get; private set;}

        protected CmdHandler()
        {

        }

        Seq<ApiCmdRoute> _Routes;

        public virtual ReadOnlySeq<@string> SubCommands {get;} 
            = sys.empty<@string>();

        ApiCmdRoute ICmdEffector.Route
            => Route;        

        public abstract void Run(CmdArgs args);

        public virtual Task<ExecToken> Start(CmdArgs args)
        {
            ExecToken<ApiCmdRoute> Exec()
            {
                var flow = Channel.Running(Route);
                Run(args);
                return Channel.Ran(flow, Route);
            }
            return sys.start(() => Exec().Token);
        }

        void ICmdHandler.Initialize(IWfRuntime wf)
        {
            Wf = wf;
            Channel = wf.Channel;
            Route = ApiCmd.route(GetType());
            _Routes = sys.alloc<ApiCmdRoute>(SubCommands.Count);
            var j=0;
            sys.iter(SubCommands, sub => _Routes[j++] = Route.Refine(sub));
        }
    }
}