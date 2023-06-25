
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiServers : AppService
    {        
        public static ApiCmdCatalog catalog()
            => ApiCmdRunner.Service().CmdCatalog;

        public static IApiShell app<T>(string[] args)
            where T : IApiShell,new()
        {
            var dst = new T();
            var wf = runtime();
            dst.Init(wf, args);
            return dst;
        }

        public static IApiShell shell(IWfRuntime wf, string[] args, params Assembly[] parts)
        {
            var shell = new ApiShell();
            shell.Init(wf, args, ApiCmd.runner(wf, parts));
            return shell;
        }

        public static IApiShell shell(string[] args, params Assembly[] parts)
        {
            var wf = runtime(false);
            var shell = new ApiShell();
            shell.Init(wf, args, ApiCmd.runner(wf, parts));
            return shell;
        }

        public static A shell<A>(string[] args, params Assembly[] parts)
            where A : IApiShell, new()
        {
            var wf = runtime();
            var shell = new A();
            shell.Init(wf, args, ApiCmd.runner(wf, parts));
            return shell;
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
                term.announce($"ClrVersion: {FileVersionInfo.GetVersionInfo(typeof(object).Assembly.Location).ProductVersion}");

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
 
        const string InitializingRuntime = "Initializing runtime";
        
        static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{0}";

        static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

        static RenderPattern<IWfEmissions> ConfiguredEmissionLogs => "Configured emisson logs:{0}";

     }

    partial class XSvc
    {
        partial class ServiceCache
        {
            public ApiServers ApiServers(IWfRuntime wf)
                => Service<ApiServers>(wf);            
        }

        public static ApiServers ApiServers(this IWfRuntime wf)
            => Services.ApiServers(wf);
    }
}