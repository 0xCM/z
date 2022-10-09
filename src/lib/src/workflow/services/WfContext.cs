//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class WfContext : IWfContext
    {
        public readonly IWfChannel Channel;

        public readonly IWfRuntime Runtime;

        IWfChannel IWfContext.Channel
            => Channel;

        IWfRuntime IWfContext.Runtime
            => Runtime;

        public WfContext(IWfChannel channel, IWfRuntime wf)
        {
            Channel = channel;
            Runtime = wf;
        }
    }
}