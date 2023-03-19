
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdActorKind;

    public class ApiCmd : AppService<ApiCmd>, IApiService
    {                         
        // public static IApiCmdRunner runner(IWfRuntime wf, params Assembly[] src)
        //     => new ApiCmdRunner(wf, handlers(wf,src));

        // static ICmdHandler handler(IWfRuntime wf, Type tHandler)
        // {
        //     var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
        //     handler.Initialize(wf);
        //     return handler;
        // }

        // static CmdHandlers handlers(IWfRuntime wf, params Assembly[] src)
        // {
        //     var dst = src.Types().Concrete().Tagged<CmdHandlerAttribute>().Select(x => handler(wf,x)).Map(x => (x.Route,x)).ToDictionary();
        //     dst.TryAdd(Handlers.DevNul.Route, handler(wf, typeof(Handlers.DevNul)));
        //     return new (dst);
        // }

        public static Outcome exec(IWfChannel channel, CmdMethod effector, CmdArgs args)
        {
            var output = default(object);
            var result = Outcome.Success;
            try
            {
                switch(effector.Kind)
                {
                    case Pure:
                        effector.Definition.Invoke(effector.Host, new object[]{});
                        result = Outcome.Success;
                    break;
                    case Receiver:
                        effector.Definition.Invoke(effector.Host, new object[1]{args});
                        result = Outcome.Success;
                    break;
                    case CmdActorKind.Emitter:
                        output = effector.Definition.Invoke(effector.Host, new object[]{});
                    break;
                    case Func:
                        output = effector.Definition.Invoke(effector.Host, new object[1]{args});
                    break;
                    default:
                        result = new Outcome(false, $"Unsupported {effector.Definition}");
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
                var origin = AppMsg.orginate(effector.HostType.DisplayName(), effector.Definition.DisplayName(), 12);                
                var error = Events.error(e.ToString(), origin, effector.HostType);
                channel.Error(error);
                result = (e,error.Format());
            }

           return result;
        }

        public static ICmdDispatcher Dispatcher 
            => AppData.Value<ICmdDispatcher>(nameof(ICmdDispatcher));

        public Outcome RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Channel.Error(result.Message);
        }

        public void EmitCmdDefs(Assembly[] src, IDbArchive dst)
            => Cmd.emit(Channel, Cmd.defs(src), dst);

        public void RunCmd(IWfChannel channel, ApiCmdSpec cmd)
        {
            try
            {
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
        }

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
                            ApiCmd.Dispatcher.Dispatch(cmd.Name, cmd.Args);
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

        public void EmitApiCatalog()
            => EmitApiCatalog(Env.ShellData);
        
        public void EmitApiCatalog(CmdCatalog src, IDbArchive dst)
        {
            var data = src.Values;
            iter(data, x => Channel.Row(x.Uri.Name));
            Channel.TableEmit(data, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));
        }

        public void EmitApiCatalog(IDbArchive dst)
            => EmitApiCatalog(ApiServers.catalog(), dst);
    }
}