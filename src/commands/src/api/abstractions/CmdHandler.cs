//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdHandler]
    public abstract class CmdHandler : ICmdHandler
    {
        CmdRoute Route;

        protected AppSettings AppSettings => AppSettings.Default;
        
        protected IWfRuntime Wf {get; private set;}
    
        protected IWfChannel Channel {get; private set;}

        protected CmdServer Server => Wf.CmdServer();
        
        protected CmdHandler()
        {

        }

        public virtual ReadOnlySeq<@string> SubCommands {get;} 
            = sys.empty<@string>();

        CmdRoute ICmdHandler.Route
            => Route;        

        public abstract void Run(CmdArgs args);

        public virtual Task<ExecToken> Handle(CmdArgs args)
        {
            ExecToken Exec()
            {
                var flow = Channel.Running(Route);
                Run(args);
                return Channel.Ran(flow, Route);
            }
            return sys.start(Exec);
        }

        void ICmdHandler.Initialize(IExecutionContext context)
        {
            Wf = context.Wf;
            Channel = context.Channel;
            Route = Cmd.route(GetType());
        }
    }
}