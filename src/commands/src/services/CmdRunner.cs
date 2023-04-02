//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdActorKind;

    class CmdRunner : ICmdRunner
    {
        readonly ICmdMethods Methods;

        readonly IWfChannel Channel;

        readonly CmdHandlers Handlers;
        
        readonly CmdCatalog CmdCatalog;

        [MethodImpl(Inline)]
        public CmdRunner(IWfChannel channel, ICmdMethods methods, CmdHandlers handlers)
        {
            Methods = methods;
            Channel = channel;
            Handlers = handlers;
            CmdCatalog = catalog(methods);
        }

        CmdCatalog ICmdRunner.Catalog 
            => CmdCatalog;

        static CmdCatalog catalog(ICmdMethods methods)
        {
            var defs = methods.Defs;
            var count = defs.Count;
            var dst = sys.alloc<ApiCmdInfo>(count);
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

        public ExecToken RunCommand(string[] _args)
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
                token = RunCommand(args[0], sys.mapi(sys.slice(args.View,1), (i,value) => Cmd.arg(value)));
            }
            return token;
        }

        void Usage(ITextEmitter dst)
        {
            var host = sys.controller().GetSimpleName();
            dst.AppendLine($"Usage: {host} <command> [args..]");
            dst.IndentLine(4, "<command> =");
            iter(Handlers.Routes, fx => dst.IndentLine(4,$"| {fx}"));
        }
 
        public ExecToken RunCommandScript(FilePath src)
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
                            RunCommand(cmd.Name, cmd.Args);
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

        public ExecToken RunCommand(string route, CmdArgs args)
        {
            var token = TokenDispenser.open();
            var result = Outcome.Success;
            try
            {
                if(Handlers.Handler(route, out var handler))
                    result = Run(handler,args);
                else if(Methods.Find(route, out var fx))
                    result = Run(fx, args);            
                else
                    result = (false,string.Format("Command '{0}' unrecognized", route));
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
            => RunCommand(action, CmdArgs.Empty);

        Outcome Run(ICmdHandler handler, CmdArgs args)
        {
            var token = ExecToken.Empty;
            var sw = Time.counter(true);
            var flow = Channel.Running($"Running {handler.Route}");
            var result = Outcome.Success;

            try
            {
                token = handler.Start(args).Result;
            }
            catch(Exception e)
            {
                Channel.Error(e);
                token = TokenDispenser.close(flow,false);
            }

            token = Channel.Ran(flow, $"{handler.Route} execution completed in {sw.Elapsed()}");
            return result;
        }

        Outcome Run(CmdMethod method, CmdArgs args)
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
                                Channel.Error(y.Message);
                            else
                                Channel.Babble(y.Message);
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
                Channel.Error(error);
                result = (e,error.Format());
            }

           return result;
        }
    }
}