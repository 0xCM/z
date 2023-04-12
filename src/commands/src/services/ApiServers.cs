
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
        public static IApiShell app<T>(string[] args)
            where T : IApiShell,new()
        {
            var dst = new T();
            var wf = runtime();
            dst.Init(wf,args);
            return dst;
        }

        public static IApiShell shell(IWfRuntime wf, string[] args, params Assembly[] parts)
        {
            var shell = new ApiShell();
            shell.Init(wf, args, runner(wf, parts));
            return shell;
        }

        public static IApiShell shell(string[] args, params Assembly[] parts)
        {
            var wf = runtime(false);
            var shell = new ApiShell();
            shell.Init(wf, args, runner(wf, parts));
            return shell;
        }

        public static A shell<A>(string[] args, params Assembly[] parts)
            where A : IApiShell, new()
        {
            var wf = runtime();
            var shell = new A();
            shell.Init(wf, args, runner(wf, parts));
            return shell;
        }

        static IApiCmdRunner runner(IWfRuntime wf, params Assembly[] parts)
        {
            var _parts = parts.Length == 0 ? ApiAssemblies.Components : parts;
            var runner = (IApiCmdRunner)new ApiCmdRunner(wf.Channel, methods(wf, _parts), handlers(wf, _parts));
            AppData.Value(nameof(IApiCmdRunner), runner);
            return runner;
        }

        static CmdHandlers handlers(IWfRuntime wf, params Assembly[] src)
        {
            var dst = src.Types().Concrete().Tagged<CmdHandlerAttribute>().Select(x => handler(wf,x)).Map(x => (x.Route,x)).ToDictionary();
            dst.TryAdd(Handlers.DevNul.Route, handler(wf, typeof(Handlers.DevNul)));
            return new (dst);
        }

        static ICmdHandler handler(IWfRuntime wf, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(wf);
            return handler;
        }

        static ApiCmdMethods methods(IWfRuntime wf, Assembly[] parts)
        {
            var types = parts.Types().Concrete().Tagged<CmdProviderAttribute>();
            var dst = dict<string,ApiCmdMethod>();
            iter(types.Tagged<CmdProviderAttribute>().Concrete(), t => {
                var method = t.StaticMethods().Public().Where(m => m.Name == "create").First();
                var service = (IApiService)method.Invoke(null, new object[]{wf});
                iter(methods(service).Defs, m => dst.TryAdd(m.CmdName, m));
            });
            return new ApiCmdMethods(dst);
        }

        public override Type HostType 
            => typeof(ApiServers);

        public void EmitApiCatalog(IDbArchive dst)
        {
            var data = Runner.Catalog.Values;
            iter(data, x => Channel.Row(x.Uri.Name));
            Channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
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
            => emit(Channel, ApiCmd.defs(src), dst);

        static ReadOnlySeq<CmdFieldRow> fields(ReadOnlySpan<ApiCmdDef> src)
        {
            var count = src.Select(x => x.FieldCount).Sum();
            var dst = alloc<CmdFieldRow>(count);
            var k=0u;
            for(var i=0; i<src.Length; i++)
            {
                var type = Require.notnull(skip(src,i));
                var instance = Require.notnull(Activator.CreateInstance(type.Source));
                for(var j=0; j<type.FieldCount; j++,k++)
                {
                    ref var row = ref seek(dst,k);
                    ref readonly var field = ref type.Fields[j];
                    row.Route = type.Route;
                    row.Index = field.Index;
                    row.CmdType = type.Source.DisplayName();
                    row.Name = field.Name;
                    row.Expression = field.Description;
                    row.DataType = field.DataType;
                }
            }
            return dst;
        }

        static ExecToken emit(IWfChannel channel, ApiCmdDefs src, IDbArchive dst)
            => channel.TableEmit(fields(src.View), dst.Table<CmdFieldRow>());                

        public static IApiCmdRunner Runner 
            => AppData.Value<IApiCmdRunner>(nameof(IApiCmdRunner));

        public static ApiCmdCatalog catalog()
            => Runner.Catalog;

        static ApiCmdMethods methods(IApiService host)
        {
            var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = dict<string,ApiCmdMethod>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var mi = ref skip(src,i);
                var tag = mi.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.Name, new ApiCmdMethod(tag.Name, classify(mi),  mi, host));                
            }
            return new ApiCmdMethods(dst);
        }

        const string InitializingRuntime = "Initializing runtime";
        
        static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{0}";

        static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

        static RenderPattern<IWfEmissions> ConfiguredEmissionLogs => "Configured emisson logs:{0}";

        static ApiActorKind classify(MethodInfo src)
        {
            var dst = ApiActorKind.None;
            var arity = src.ArityValue();
            var @void = src.HasVoidReturn();
            switch(arity)
            {
                case 0:
                    switch(@void)
                    {
                        case false:
                            dst = ApiActorKind.Pure;
                        break;
                        case true:
                            dst = ApiActorKind.Emitter;
                        break;
                    }
                break;
                case 1:
                    switch(@void)
                    {
                        case true:
                            dst = ApiActorKind.Receiver;
                        break;
                        case false:
                            dst = ApiActorKind.Func;
                        break;
                    }
                break;
            }
            return dst;
        }
    }
}