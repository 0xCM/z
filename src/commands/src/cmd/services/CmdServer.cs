//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // class CmdServerState
    // {
    //     public IApiContext ApiContext;

    //     public CmdHandlers Handlers;

    //     public IExecutionContext ExecContext;

    //     public IApiCmdRunner Runner;
    // }

    public sealed class CmdServer : AppService<CmdServer>, ICmdServer
    {
        Task<ExecToken> IApiCmdRunner.Start(string[] args)
            => Runner.Start(args);

        ExecToken IApiCmdRunner.Run(string[] args)
            => Runner.Run(args);

        IApiContext ApiContext;

        CmdHandlers Handlers;

        IExecutionContext ExecContext;

        IApiCmdRunner Runner;

        public CmdCatalog Commmands 
            => data("commands", () => ApiServers.catalog(ApiContext.Dispatcher));

        public ICollection<CmdRoute> Routes 
            => Handlers.Routes;

        IExecutionContext IContextual<IExecutionContext>.Context 
            => ExecContext;

        CmdHandlers IApiCmdRunner.Handlers 
            => Handlers;
    }
}