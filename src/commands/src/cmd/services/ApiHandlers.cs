
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiHandlers
    {
        static ICmdHandler handler(IExecutionContext context, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(context);
            return handler;
        }

        static Type[] HandlerTypes(params Assembly[] src)
            => src.Types().Concrete().Tagged<CmdHandlerAttribute>();

        static CmdHandlers handlers(IExecutionContext context, params Assembly[] components)
        {
            var data = HandlerTypes(components).Select(x => handler(context,x)).Map(x => (x.Route,x)).ToDictionary();
            data.TryAdd(Handlers.DevNul.Route, handler(context, typeof(Handlers.DevNul)));
            return new (data);
        }

        public static IApiCmdRunner runner(IWfRuntime wf, params Assembly[] components)        
        {
            var context = new ExecutionContext(wf, wf.Channel);
            return new ApiCmdRunner(context, handlers(context, components));
        }

        public static ICmdServer server(IExecutionContext ec, IApiContext apictx, params Assembly[] components)
        {
            var state = new CmdServerState{
                Handlers = handlers(ec, components),
                ExecContext = ec,
                ApiContext = apictx,
                Runner = runner(ec.Wf, components)
            };
            return CmdServer.create(ec, components, state);
        }
    }
}