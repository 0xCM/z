
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiServers : AppService
    {
        public override Type HostType 
            => typeof(ApiServers);

        const string InitializingRuntime = "Initializing runtime";
        
        static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{0}";

        static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

        static RenderPattern<IWfEmissions> ConfiguredEmissionLogs => "Configured emisson logs:{0}";

        public static ICmdServer cmd(IExecutionContext ec, IApiContext apictx, params Assembly[] components)
        {
            var state = new CmdServerState{
                Handlers = handlers(ec, components),
                ExecContext = ec,
                ApiContext = apictx,
                Runner = runner(ec.Wf, components)
            };
            return CmdServer.create(ec, components, state);
        }

        internal static ICmdHandler handler(IExecutionContext context, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(context);
            return handler;
        }

        public static IApiCmdRunner runner(IWfRuntime wf, params Assembly[] components)        
        {
            var context = new ExecutionContext(wf, wf.Channel);
            return new ApiCmdRunner(context, handlers(context, components));
        }

        static Type[] HandlerTypes(params Assembly[] src)
            => src.Types().Concrete().Tagged<CmdHandlerAttribute>();

        public static CmdHandlers handlers(IExecutionContext context, params Assembly[] components)
        {
            var data = HandlerTypes(components).Select(x => handler(context,x)).Map(x => (x.Route,x)).ToDictionary();
            data.TryAdd(Handlers.DevNul.Route, handler(context, typeof(Handlers.DevNul)));
            return new (data);
        }
        
        public static ReadOnlySeq<ServiceSpec> services(Assembly[] src)
        {
            var dst = list<ServiceSpec>();
            var types = src.Types().Tagged<ServiceCacheAttribute>().Concrete().ToSeq();
            for(var i=0; i<types.Count; i++)
            {
                ref readonly var type = ref types[i];
                var factories = type.PublicInstanceMethods().Concrete().Where(m => m.ReturnType.Reifies<IAppService>());
                if(factories.Length != 0)
                    dst.Add(new AppServiceSpec(type,factories));
            }

            return dst.Array();
        }

        public static IWfRuntime runtime(string[] args, bool verbose = true)
        {
            var factory = typeof(ApiServers);
            try
            {
                var ts = now();
                var clock = Time.counter(true);
                if(verbose)
                    term.emit(Events.running(factory, InitializingRuntime));
                var control = ExecutingPart.Assembly;
                var id = control.Id();
                var dst = new WfInit();
                dst.Verbosity = verbose ? LogLevel.Babble : LogLevel.Status;
                dst.Args = args;
                dst.LogConfig = Loggers.configure(id, AppSettings.Default.Logs());
                dst.LogConfig.ErrorPath.CreateParentIfMissing();
                dst.LogConfig.StatusPath.CreateParentIfMissing();

                if(verbose)
                    term.emit(Events.babble(factory, ConfiguredAppLogs.Format(dst.LogConfig)));

                dst.Tokens = TokenDispenser.Service;
                dst.EventBroker = Events.broker(dst.LogConfig);
                
                if(verbose)
                    term.emit(Events.babble(factory, "Created event broker"));

                dst.Host = new AppEventSource(typeof(WfRuntime));
                
                if(verbose)
                    term.emit(Events.babble(factory, "Created host"));

                dst.EmissionLog = Loggers.emission(control, timestamp());

                if(verbose)
                    term.emit(Events.babble(factory, ConfiguredEmissionLogs.Format(dst.EmissionLog)));

                var wf = new WfRuntime(dst);
                if(verbose)
                    term.emit(Events.ran(factory, AppMsg.status(InitializedRuntime.Format(clock.Elapsed()))));
                return wf;
            }
            catch(Exception e)
            {
                term.emit(Events.error(factory, e));
                throw;
            }
        }
        
        public static A shell<A>(string[] args, IWfRuntime wf, IApiContext context, bool verbose = false)
            where A : IAppShell, new()
        {            
            var app = new A();
            app.Init(wf, context);
            return app;
        }

        public static A shell<A>(bool catalog, params string[] args)
            where A : IAppShell, new()
        {
            var wf = runtime(args);
            var app = new A();
            app.Init(wf);
            return app;
        }

        public static A shell<A,C>(bool catalog, string[] args, Func<IWfRuntime,ReadOnlySeq<IApiCmdProvider>> factory, bool verbose = false)
            where A : IAppShell, new()
            where C : IApiService, new()
        {
            var wf = runtime(args);
            var channel = wf.Channel;
            if(verbose)
                channel.Babble("Creating api server");

            var app = new A();
            var providers = factory(wf);
            app.Init(wf, context<C>(wf, channel, providers));

            if(verbose)
                channel.Babble($"Created {providers.Length} command providers");
            return app;
        }

        public static IApiContext context<C>(IWfRuntime wf, Func<ReadOnlySeq<IApiCmdProvider>> factory, bool verbose = false)
            where C : IApiService, new()
                => context<C>(wf, wf.Channel, factory(), verbose);

        static IApiContext context<C>(IWfRuntime wf, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers, bool verbose = false)
            where C : IApiService, new()
        {
            var service = new C();                        
            service.Init(wf);
            return new ApiContext(service, channel, dispatcher(service, channel, providers, verbose));            
        }

        static ICmdDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<IApiCmdProvider> providers, bool verbose = false)
        {
            if(verbose)
                channel.Babble($"Discovering {service} dispatchers");

            var dst = dict<string,CmdMethod>();
            iter(effectors(service), r => dst.TryAdd(r.CmdName, r));
            iter(providers, p => iter(effectors(p), r => dst.TryAdd(r.CmdName, r)));
            var dispatcher = new ApiDispatcher(channel, new CmdMethods(dst));
            AppData.Value(nameof(ICmdDispatcher), dispatcher);
            return dispatcher;
        }    

        [Op]
        static ReadOnlySeq<CmdMethod> effectors(object host)
        {
            var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = alloc<CmdMethod>(src.Length);
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var mi = ref skip(src,i);
                var tag = mi.Tag<CmdOpAttribute>().Require();
                seek(dst,i) = new CmdMethod(tag.Name, classify(mi),  mi, host);
            }
            return dst;
        }

        static CmdActorKind classify(MethodInfo src)
        {
            var dst = CmdActorKind.None;
            var arity = src.ArityValue();
            var @void = src.HasVoidReturn();
            switch(arity)
            {
                case 0:
                    switch(@void)
                    {
                        case false:
                            dst = CmdActorKind.Pure;
                        break;
                        case true:
                            dst = CmdActorKind.Emitter;
                        break;
                    }
                break;
                case 1:
                    switch(@void)
                    {
                        case true:
                            dst = CmdActorKind.Receiver;
                        break;
                        case false:
                            dst = CmdActorKind.Func;
                        break;
                    }
                break;
            }
            return dst;
        }
    }
}