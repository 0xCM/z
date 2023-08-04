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
        }

        static ServiceCache Services => ServiceCache.Instance;

        static ChannelCache Channels => ChannelCache.Instance;

    }
}