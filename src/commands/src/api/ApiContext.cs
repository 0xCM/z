//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiContext : IWfContext
    {
        public readonly IWfChannel Channel;

        public readonly IWfRuntime Runtime;

        public readonly IApiDispatcher Dispatcher;

        public readonly IApiCmdSvc Commander;

        public ApiContext(IApiCmdSvc commander, IWfChannel channel, IWfRuntime wf, IApiDispatcher dispatcher)
        {
            Commander = commander;
            Channel = channel;
            Runtime = wf;
            Dispatcher = dispatcher;
        }

        IWfChannel IWfContext.Channel
            => Channel;

        IWfRuntime IWfContext.Runtime
            => Runtime;

        IApiDispatcher IWfContext.Dispatcher 
            => Dispatcher;

        IApiCmdSvc IWfContext.Commander 
            => Commander;
    }
}