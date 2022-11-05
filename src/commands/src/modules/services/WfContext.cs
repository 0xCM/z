//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class WfContext : IWfContext
    {
        public readonly IWfChannel Channel;

        public readonly IWfRuntime Runtime;

        public readonly IWfDispatcher Dispatcher;

        public readonly IAppCmdSvc Commander;

        public WfContext(IAppCmdSvc commander, IWfChannel channel, IWfRuntime wf, IWfDispatcher dispatcher)
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

        IWfDispatcher IWfContext.Dispatcher 
            => Dispatcher;

        IAppCmdSvc IWfContext.Commander 
            => Commander;
    }
}