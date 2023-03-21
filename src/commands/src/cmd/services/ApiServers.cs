
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public class ApiServers : AppService
    {
        public override Type HostType 
            => typeof(ApiServers);

        public static AppCmdProviders providers(params Assembly[] src)
            => src.Types().Tagged<CmdProviderAttribute>().Concrete().Map(x => new AppCmdProvider(x));

        public static CmdMethods methods(IApiService host)
        {
            var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = dict<string,CmdMethod>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var mi = ref skip(src,i);
                var tag = mi.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.Name, new CmdMethod(tag.Name, classify(mi),  mi, host));                
            }
            return new CmdMethods(dst);
        }


        public static CmdMethods methods(IWfRuntime wf, params Assembly[] src)
        {            
            var providers = ApiServers.providers(src.Length == 0 ? ApiAssemblies.Components : src);
            var types = providers.ServiceTypes();
            var dst = dict<string,CmdMethod>();
            iter(types, t => {
                var method = t.StaticMethods().Public().Where(m => m.Name == "create").First();
                var service = (IApiService)method.Invoke(null, new object[]{wf});
                iter(methods(service).Defs, m => dst.TryAdd(m.CmdName, m));
            });

            return new (dst);
        }

        public static IApiCmdRunner runner(IWfRuntime wf, params Assembly[] src)
            => new ApiCmdRunner(wf, handlers(wf,src));

        public static CmdCatalog catalog()
            => catalog(ApiCmd.Dispatcher);

        public static CmdCatalog catalog(ICmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(entries(dst));
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

        public static IWfRuntime runtime(bool verbose = true)
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
                dst.LogConfig = Loggers.configure(id, AppSettings.Default.Logs());
                dst.LogConfig.ErrorPath.CreateParentIfMissing();
                dst.LogConfig.StatusPath.CreateParentIfMissing();

                if(verbose)
                    term.emit(Events.babble(factory, ConfiguredAppLogs.Format(dst.LogConfig)));

                dst.Tokens = TokenDispenser.Service;
                dst.EventBroker = Events.broker(dst.LogConfig);
                
                if(verbose)
                    term.emit(Events.babble(factory, "Created event broker"));

                dst.Host = typeof(WfRuntime);
                
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
        
        public static ApiShell shell(IWfRuntime wf)
            => shell(wf.Channel, methods(wf));
            
        public static ApiShell shell(IWfChannel channel, CmdMethods methods)
            => new ApiShell(channel, new ApiDispatcher(channel, methods));

        public static A shell<A>(string[] args, IWfRuntime wf, IApiContext context, bool verbose = false)
            where A : IAppShell, new()
        {            
            var app = new A();
            app.Init(wf, context);
            return app;
        }

        public static A shell<A>()
            where A : IAppShell, new()
        {
            var wf = runtime();
            var app = new A();
            app.Init(wf);
            return app;
        }

        public static A shell<A,C>(Func<IWfRuntime,ReadOnlySeq<IApiService>> factory, bool verbose = false)
            where A : IAppShell, new()
            where C : IApiService, new()
        {
            var wf = runtime();
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

        public static IApiContext context<C>(IWfRuntime wf, Func<ReadOnlySeq<IApiService>> factory, bool verbose = false)
            where C : IApiService, new()
                => context<C>(wf, wf.Channel, factory(), verbose);

        static IApiContext context<C>(IWfRuntime wf, IWfChannel channel, ReadOnlySeq<IApiService> providers, bool verbose = false)
            where C : IApiService, new()
        {
            var service = new C();                        
            service.Init(wf);
            return new ApiContext(service, channel, dispatcher(service, channel, providers, verbose));            
        }

        static ICmdDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<IApiService> providers, bool verbose = false)
            where T : IApiService
        {
            if(verbose)
                channel.Babble($"Discovering {service} dispatchers");

            var dst = dict<string,CmdMethod>();
            //iter(effectors(service), r => dst.TryAdd(r.CmdName, r));
            iter(providers, p => iter(effectors(p), r => dst.TryAdd(r.CmdName, r)));
            var dispatcher = new ApiDispatcher(channel, new CmdMethods(dst));
            AppData.Value(nameof(ICmdDispatcher), dispatcher);
            return dispatcher;
        }    

        const string InitializingRuntime = "Initializing runtime";
        
        static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{0}";

        static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

        static RenderPattern<IWfEmissions> ConfiguredEmissionLogs => "Configured emisson logs:{0}";

        static ICmdHandler handler(IWfRuntime wf, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(wf);
            return handler;
        }

        static CmdHandlers handlers(IWfRuntime wf, params Assembly[] src)
        {
            var dst = src.Types().Concrete().Tagged<CmdHandlerAttribute>().Select(x => handler(wf,x)).Map(x => (x.Route,x)).ToDictionary();
            dst.TryAdd(Handlers.DevNul.Route, handler(wf, typeof(Handlers.DevNul)));
            return new (dst);
        }

        static ReadOnlySeq<ApiCmdInfo> entries(ReadOnlySeq<CmdUri> src)    
        {
            var entries = alloc<ApiCmdInfo>(src.Count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var uri = ref src[i];
                ref var entry = ref seek(entries,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            return entries.Sort().Resequence();        
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