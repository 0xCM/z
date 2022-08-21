//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdProvider]
    public abstract class AppCmdService<T> : CmdService<T>, IAppCmdSvc
        where T : AppCmdService<T>, new()
    {
        protected virtual void PublishCommands()
        {

        }

        public static T create(IWfRuntime wf, ICmdProvider[] src)
        {
            var service = new T();            
            var emitter = wf.Emitter(service.GetType());
            wf.Babble($"Created emitter");
            var dispatcher = Cmd.dispatcher(service, emitter, src);
            ApiGlobals.Instance.Inject(dispatcher);
            wf.Babble($"Injected dispatcher");
            service.Init(wf);
            wf.Babble($"Initialized application command service");
            service.PublishCommands();
            wf.Babble($"Published commands");
            return service;
        }

        public static new T create(IWfRuntime wf)
        {
            var service = new T();            
            var emitter = wf.Emitter(service.GetType());
            var dispatcher = Cmd.dispatcher(service, emitter, sys.empty<ICmdProvider>());
            ApiGlobals.Instance.Inject(dispatcher);
            service.AppInit(wf);
            service.PublishCommands();            
            return service;
        }

        protected AppCmdService()
        {
            PromptTitle = "cmd";
        }

        public override IAppCmdDispatcher Dispatcher => ApiGlobals.Instance.Injected<AppCmdDispatcher>();

        [CmdOp("jobs/run")]
        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
        }

        public virtual void RunJobs(string match)
        {
            var paths = AppDb.Service.Jobs().Files();
            var counter = 0u;
            for(var i=0; i<paths.Count; i++)
            {
                ref readonly var path = ref paths[i];
                if(path.FileName.Format().StartsWith(match))
                {
                    var dispatching = Running(string.Format("Dispatching job {0} defined by {1}", counter, path.ToUri()));
                    DispatchJobs(path);
                    Ran(dispatching, string.Format("Dispatched job {0}", counter));
                    counter++;
                }
            }

            if(counter == 0)
                Warn($"No jobs identified by '{match}'");
        }

        protected virtual string PromptTitle {get;}

        string Prompt()
            => string.Format("{0}> ", PromptTitle);

        AppCmdSpec Next()
        {
            var input = term.prompt(Prompt());
            if(Cmd.parse(input, out AppCmdSpec cmd))
            {
                return cmd;
            }
            else
            {
                Error($"ParseFailure:{input}");
                return AppCmdSpec.Empty;
            }
            //return ShellCmd.parse(input);
        }

        public virtual void Run()
        {
            var input = Next();
            while(input.Name != ".exit")
            {
                if(input.IsNonEmpty)
                    Dispatch(input);
                input = Next();
            }
        }
   }
}