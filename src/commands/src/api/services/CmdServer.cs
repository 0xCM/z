//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public sealed class CmdServer : AppService<CmdServer>, ICmdServer
    {
        public static EnvVars vars(params Pair<string>[] src)
            => src.Map(x => new EnvVar(x.Left,x.Right));

        public static ICmdRunner runner(IWfRuntime wf)
            => new Runner(wf);
        
        public static CmdHandlers handlers(ExecutionContext context)
        {
            var types = Assembly.GetExecutingAssembly().Types().Concrete().Tagged<CmdHandlerAttribute>();
            return new (types.Select(x => handler(context,x)).Map(x => (x.Route,x)).ToDictionary());
        }

        protected override void Initialized()
        {
            sys.require(AppData.Value(nameof(ApiContext), out ApiContext));
            Handlers = handlers(new ExecutionContext(Wf, Channel));            
        }

         Task<ExecToken> ICmdRunner.Start(string[] args)
            => runner(Wf).Start(args);

        ExecToken ICmdRunner.Run(string[] args)
            => runner(Wf).Run(args);

        IApiContext ApiContext;

        CmdHandlers Handlers;

        public CmdCatalog Commmands 
            => data("commands", () => ApiCmd.catalog(ApiContext.Dispatcher));

        public ICollection<CmdRoute> Routes 
            => Handlers.Routes;

        static ICmdHandler handler(ExecutionContext context, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(context);
            return handler;
        }

        class Runner : ICmdRunner
        {
            public Runner(IWfRuntime wf)
            {
                Channel = wf.Channel;
                Context = new ExecutionContext(wf, Channel);
                Handlers = CmdServer.handlers(Context);
            }

            readonly ExecutionContext Context;

            readonly IWfChannel Channel;

            public CmdHandlers Handlers {get;}

            Task<ExecToken> ICmdRunner.Start(string[] args)
                => sys.start(() => Run(args));

            ExecToken Run(string name, CmdArgs ops)
            {
                var token = ExecToken.Empty;
                var sw = Time.counter(true);
                var flow = Channel.Running($"Running {name}");
                try
                {
                    if(Handlers.Handler(name, out var handler))
                        token = handler.Handle(ops).Result;
                    else
                        Channel.Warn($"Handler for '{name}' not found");                    
                }
                catch(Exception e)
                {
                    Channel.Error(e);
                }

                token = Channel.Ran(flow, $"{name} execution completed in {sw.Elapsed()}");
                return token;
            }
            
            public ExecToken Run(string[] _args)
            {
                var token = ExecToken.Empty;
                var args = _args.ToSeq();
                if(args.IsEmpty)
                {
                    var dst = text.emitter();
                    Usage(dst);
                    Channel.Row(dst.Emit());
                }
                else
                {
                    token = Run(args[0],sys.mapi(sys.slice(args.View,1), (i,value) => new CmdArg($"{i}", value)));
                }
                return token;
            }

            void Usage(ITextEmitter dst)
            {
                dst.AppendLine("Usage: zfx <command> [args..]");
                dst.IndentLine(4, "<command> =");
                iter(Handlers.Routes, fx => dst.IndentLine(4,$"| {fx}"));
            }
        }
    }
}