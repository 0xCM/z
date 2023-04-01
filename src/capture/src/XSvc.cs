//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [ApiHost]
    public static class XSvc
    {
        sealed class ChannelCache : AppChannels<ChannelCache>
        {
            public ApiPacks ApiPacks(IWfChannel channel)
                => service<ApiPacks>(channel);
        }

        static ChannelCache Channels => ChannelCache.Instance;


        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Channels.ApiPacks(wf.Channel);

        public static ApiPacks ApiPacks(this IWfChannel channel)
            => Channels.ApiPacks(channel);

        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public CaptureWfCmd CaptureCmd(IWfRuntime wf)
                => Service<CaptureWfCmd>(wf);

            public CaptureWf CaptureWf(IWfRuntime wf)
                => Service<CaptureWf>(wf);
        }


        static ServiceCache Services => ServiceCache.Instance;

        public static CaptureWfCmd CaptureCmd(this IWfRuntime wf)
            => Services.CaptureCmd(wf);

        public static CaptureWf CaptureWf(this IWfRuntime wf)
            => Services.CaptureWf(wf);
    }
}