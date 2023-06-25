//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ApiActorKind;

    public class ApiCmdRunner : IApiCmdRunner
    {
        public static IApiCmdRunner Service()
            => AppService.AppData.Value<IApiCmdRunner>(nameof(IApiCmdRunner));

        static Outcome run(IWfChannel channel, ICmdHandler handler, CmdArgs args)
        {
            var token = ExecToken.Empty;
            var sw = Time.counter(true);
            var flow = channel.Running($"Running {handler.Route}");
            var result = Outcome.Success;

            try
            {
                token = handler.Start(args).Result;
            }
            catch(Exception e)
            {
                channel.Error(e);
                token = TokenDispenser.close(flow,false);
            }

            token = channel.Ran(flow, $"{handler.Route} execution completed in {sw.Elapsed()}");
            return result;
        }

        static Outcome run(IWfChannel channel, ApiCmdMethod method, CmdArgs args)
        {
            var output = default(object);
            var result = Outcome.Success;
            var context = new ApiContext(method) as IApiContext;
            var host = method.Host;
            try
            {
                switch(method.Kind)
                {
                    case Pure:
                        method.Definition.Invoke(host, new object[]{});
                    break;
                    case Receiver:
                        method.Definition.Invoke(host, new object[1]{args});
                    break;
                    case ApiActorKind.Emitter:
                        output = method.Definition.Invoke(host, new object[]{});
                    break;
                    case Func:
                        output = method.Definition.Invoke(host, new object[1]{args});
                    break;
                    case ContextReceiver:
                        method.Definition.Invoke(host, new object[2]{context, args});
                    break;
                    case ContextFunc:
                        output = method.Definition.Invoke(host, new object[2]{context,args});
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

        readonly IWfChannel Channel;

        readonly ICmdEffectors Effectors;

        ApiCmdCatalog IApiCmdRunner.CmdCatalog
            => Effectors.Catalog;

        [MethodImpl(Inline)]
        public ApiCmdRunner(IWfChannel channel, ICmdEffectors effectors)
        {
            Channel = channel;
            Effectors = effectors;
        }

        public ExecToken RunScript(FilePath src)
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
                    var script = ApiCmd.script(src);
                    ref readonly var commands = ref script.Commands;
                    Channel.Babble($"Dispatching {commands.Count} from {src}");
                    iter(script.Commands, cmd => {
                        try
                        {
                            RunCommand(cmd);
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

        public ExecToken RunCommand(ApiCmdSpec spec)
        {
            var token = TokenDispenser.open();
            var result = Outcome.Success;
            try
            {
                if(Effectors.Handler(spec.Route, out var handler))
                    result = run(Channel, handler, spec.Args);
                else if(Effectors.Method(spec.Route.Format(), out var fx))
                    result = run(Channel, fx, spec.Args);            
                else
                    result = (false,string.Format("Command '{0}' unrecognized", spec.Route));
                token = TokenDispenser.close(token, result);
            }
            catch(Exception e)
            {
                result = (false, e.ToString());
                token = TokenDispenser.close(token, false);
            }
            if(result.Fail)
                Channel.Error(result.Message);
            return token;            
        }

        public ExecToken RunCommand(string action)
            => RunCommand(new ApiCmdSpec(action, CmdArgs.Empty));
    }
}