//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    internal class ApiCmdRunner : IApiCmdRunner
    {
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