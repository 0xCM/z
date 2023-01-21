//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdActorKind;

    internal class ApiCmdRunner : IApiCmdRunner
    {
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
                var msg = AppMsg.format($"{effector.Uri} invocation error", e);
                var origin = AppMsg.orginate(effector.HostType.DisplayName(), effector.Definition.DisplayName(), 12);
                var error = Events.error(msg, origin, effector.HostType);
                channel.Error(error);
                result = (e,msg);
            }

           return result;
        }
         
        public ApiCmdRunner(IExecutionContext context, CmdHandlers handlers)
        {
            Context = context;
            Channel = context.Channel;
            Handlers = handlers;
        }

        readonly IExecutionContext Context;

        readonly IWfChannel Channel;

        public CmdHandlers Handlers {get;}

        IExecutionContext IContextual<IExecutionContext>.Context 
            => Context;

        Task<ExecToken> IApiCmdRunner.Start(string[] args)
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
                token = Run(args[0],sys.mapi(sys.slice(args.View,1), (i,value) => Cmd.arg(value)));
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