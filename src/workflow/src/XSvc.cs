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
            public ProcessMemory ProcessMemory(IWfChannel channel)                
                => service<ProcessMemory>(channel);
        }

        class ServiceCache : AppServices<ServiceCache>
        {
        }

        static ServiceCache Services => ServiceCache.Instance;

        static ChannelCache Channels => ChannelCache.Instance;


        public static ProcessMemory ProcessMemory(this IWfRuntime wf)
            => Channels.ProcessMemory(wf.Channel);
    }
}