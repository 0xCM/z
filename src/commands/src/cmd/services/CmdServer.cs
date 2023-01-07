//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdServer : AppService<CmdServer>, ICmdServer
    {
        protected override void Initialized()
        {
            sys.require(AppData.Value(nameof(ApiContext), out ApiContext));
            Handlers = ApiCmd.handlers(new ExecutionContext(Wf, Channel));            
        }

         Task<ExecToken> IApiCmdRunner.Start(string[] args)
            => ApiCmd.runner(Wf).Start(args);

        ExecToken IApiCmdRunner.Run(string[] args)
            => ApiCmd.runner(Wf).Run(args);

        IApiContext ApiContext;

        CmdHandlers Handlers;

        public CmdCatalog Commmands 
            => data("commands", () => ApiCmd.catalog(ApiContext.Dispatcher));

        public ICollection<CmdRoute> Routes 
            => Handlers.Routes;

        internal static ICmdHandler handler(ExecutionContext context, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(context);
            return handler;
        }
    }
}