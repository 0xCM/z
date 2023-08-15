//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XSvc
    {
        internal partial class ChannelCache : AppChannels<ChannelCache>
        {
        }

        internal partial class ServiceCache : AppServices<ServiceCache>
        {
            public ApiServer ApiServer(IWfRuntime wf)
                => Service<ApiServer>(wf);            
        
        }

        static ServiceCache Services => ServiceCache.Instance;

        static ChannelCache Channels => ChannelCache.Instance;

        public static ApiServer ApiServer(this IWfRuntime wf)
            => Services.ApiServer(wf);

    }
}