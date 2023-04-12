//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        class ChannelCache : AppChannels<ChannelCache>
        {
            public ProcessTracer ProcessMonitor(IWfChannel channel)
                => service<ProcessTracer>(channel);
        }

        class ServiceCache : AppServices<ServiceCache>
        {
        }

        static ServiceCache Services => ServiceCache.Instance;

        static ChannelCache Channels => ChannelCache.Instance;

        public static ProcessTracer ProcessMonitor(this IWfChannel channel)
            => Channels.ProcessMonitor(channel);
    }
}