
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;
    using static CmdActorKind;

    public class ApiServers : AppService
    {        
        public static IApiShell shell(IWfRuntime wf, string[] args, params Assembly[] parts)
        {
            var shell = new ApiShell();
            shell.Init(wf, args,dispatcher(wf, parts));
            return shell;
        }

        public static IApiShell shell(string[] args, params Assembly[] parts)
        {
            var wf = runtime(false);
            var shell = new ApiShell();
            shell.Init(wf, args, dispatcher(wf, parts));
            return shell;
        }

        public static A shell<A>(string[] args, params Assembly[] parts)
            where A : IApiShell, new()
        {
            var wf = runtime();
            var shell = new A();
            shell.Init(wf, args, dispatcher(wf, parts));
            //app.Init(wf);
            return shell;
        }

        public static Outcome exec(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);
            
        public override Type HostType 
            => typeof(ApiServers);

        public static AppCmdProviders providers(params Assembly[] src)
            => new (src.Types().Tagged<CmdProviderAttribute>().Concrete());

        public void EmitApiCatalog(IDbArchive dst)
        {
            var data = catalog().Values;
            iter(data, x => Channel.Row(x.Uri.Name));
            Channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
        }

        public static IApiCmdRunner runner(IWfRuntime wf, params Assembly[] src)
            => new ApiCmdRunner(wf, handlers(wf,src));

        public static CmdCatalog catalog()
            => catalog(Dispatcher);

        public static CmdCatalog catalog(ICmdDispatcher src)
        {
            var defs = src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<ApiCmdInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var uri = ref defs[i].Uri;
                ref var entry = ref seek(dst,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }

            return new CmdCatalog(dst);
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

        public void EmitCmdDefs(Assembly[] src, IDbArchive dst)
            => Cmd.emit(Channel, Cmd.defs(src), dst);

        public ExecToken RunCmdScripts(FilePath src)
        {
            ExecToken Exec()
            {
                var running = Channel.Running($"Executing script {src}");
                if(src.Missing)
                {
                    Channel.Error(AppMsg.FileMissing.Format(src));
                }
                else
                {
                    var script = ApiCmdScript.Empty;
                    Cmd.parse(src, out script);
                    ref readonly var commands = ref script.Commands;
                    Channel.Babble($"Dispatching {commands.Count} from {src}");
                    iter(script.Commands, cmd => {
                        try
                        {
                            Dispatcher.Dispatch(cmd.Name, cmd.Args);
                        }
                        catch(Exception e)
                        {
                            Channel.Error(e);
                        }
                    });
                }
                return Channel.Ran(running);
            }
            return sys.start(Exec).Result;        
        }

        internal static ICmdDispatcher Dispatcher 
            => AppData.Value<ICmdDispatcher>(nameof(ICmdDispatcher));

        internal static Outcome exec(IWfChannel channel, CmdMethod method, CmdArgs args)
        {
            var output = default(object);
            var result = Outcome.Success;
            try
            {
                switch(method.Kind)
                {
                    case Pure:
                        method.Definition.Invoke(method.Host, new object[]{});
                        result = Outcome.Success;
                    break;
                    case Receiver:
                        method.Definition.Invoke(method.Host, new object[1]{args});
                        result = Outcome.Success;
                    break;
                    case CmdActorKind.Emitter:
                        output = method.Definition.Invoke(method.Host, new object[]{});
                    break;
                    case Func:
                        output = method.Definition.Invoke(method.Host, new object[1]{args});
                    break;
                    default:
                        result = new Outcome(false, $"Unsupported {method.Definition}");
                    break;
                }

                if(output != null)
                {
                    if(output is bool x)
                        result = Outcome.define(x, output, x ? "Win" : "Fail");
                    else if(output is Outcome y)
                    {
                        result = Outcome.success(y.Data, y.Message);
                        if(sys.nonempty(y.Message))
                        {
                            if(y.Fail)
                                channel.Error(y.Message);
                            else
                                channel.Babble(y.Message);
                        }
                    }
                    else
                        result = Outcome.success(output);
                }
            }
            catch(Exception e)
            {
                var origin = AppMsg.orginate(method.HostType.DisplayName(), method.Definition.DisplayName(), 12);                
                var error = Events.error(e.ToString(), origin, method.HostType);
                channel.Error(error);
                result = (e,error.Format());
            }

           return result;
        }

        static ICmdDispatcher dispatcher(IWfRuntime wf, params Assembly[] parts)
        {
            var providers = ApiServers.providers(parts.Length == 0 ? ApiAssemblies.Components : parts);
            var types = providers.ServiceTypes();
            var dst = dict<string,CmdMethod>();
            iter(types, t => {
                var method = t.StaticMethods().Public().Where(m => m.Name == "create").First();
                var service = (IApiService)method.Invoke(null, new object[]{wf});
                iter(methods(service).Defs, m => dst.TryAdd(m.CmdName, m));
            });

            ICmdDispatcher dispatcher = new ApiDispatcher(wf.Channel, new CmdMethods(dst));
            AppData.Value(nameof(ICmdDispatcher), dispatcher);
            return dispatcher;
        }

        static CmdMethods methods(IApiService host)
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

        // static IApiContext context<C>(IWfRuntime wf, IWfChannel channel, ReadOnlySeq<IApiService> providers, bool verbose = false)
        //     where C : IApiService, new()
        // {
        //     var service = new C();                        
        //     service.Init(wf);
        //     return new ApiContext(service, channel, dispatcher(service, channel, providers, verbose));            
        // }

        // static ICmdDispatcher dispatcher<T>(T service, IWfChannel channel, ReadOnlySeq<IApiService> providers, bool verbose = false)
        //     where T : IApiService
        // {
        //     if(verbose)
        //         channel.Babble($"Discovering {service} dispatchers");

        //     var dst = dict<string,CmdMethod>();
        //     iter(providers, p => iter(effectors(p), r => dst.TryAdd(r.CmdName, r)));
        //     var dispatcher = new ApiDispatcher(channel, new CmdMethods(dst));
        //     AppData.Value(nameof(ICmdDispatcher), dispatcher);
        //     return dispatcher;
        // }    

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

        // static ReadOnlySeq<ApiCmdInfo> entries(ReadOnlySeq<CmdUri> src)    
        // {
        //     var entries = alloc<ApiCmdInfo>(src.Count);
        //     for(var i=0; i<src.Count; i++)
        //     {
        //         ref readonly var uri = ref src[i];
        //         ref var entry = ref seek(entries,i);
        //         entry.Uri = uri;
        //         entry.Hash = uri.Hash;
        //         entry.Name = uri.Name;
        //     }
        //     return entries.Sort().Resequence();        
        // }        

        // [Op]
        // static ReadOnlySeq<CmdMethod> effectors(object host)
        // {
        //     var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
        //     var dst = alloc<CmdMethod>(src.Length);
        //     var count = src.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var mi = ref skip(src,i);
        //         var tag = mi.Tag<CmdOpAttribute>().Require();
        //         seek(dst,i) = new CmdMethod(tag.Name, classify(mi),  mi, host);
        //     }
        //     return dst;
        // }

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