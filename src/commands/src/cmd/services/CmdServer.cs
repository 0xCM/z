//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CmdServer : AppService<CmdServer>, ICmdServer
    {
        public static CmdServer create(IExecutionContext context, params Assembly[] components)
        {
            var dst = create(context.Wf);
            dst.Handlers = ApiCmd.handlers(context, components);
            dst.ExecContext = context;
            sys.require(AppData.Value(nameof(ApiContext), out dst.ApiContext));
            dst.Runner = ApiCmd.runner(context.Wf, components);
            return dst;
        }
        
        Task<ExecToken> IApiCmdRunner.Start(string[] args)
            => Runner.Start(args);

        ExecToken IApiCmdRunner.Run(string[] args)
            => Runner.Run(args);

        IApiContext ApiContext;

        CmdHandlers Handlers;

        IExecutionContext ExecContext;

        IApiCmdRunner Runner;

        public CmdCatalog Commmands 
            => data("commands", () => ApiCmd.catalog(ApiContext.Dispatcher));

        public ICollection<CmdRoute> Routes 
            => Handlers.Routes;

        IExecutionContext IContextual<IExecutionContext>.Context 
            => ExecContext;

        CmdHandlers IApiCmdRunner.Handlers 
            => Handlers;
    }
}