//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public static class XSvc
    {
        sealed class ChannelCache : AppChannels<ChannelCache>
        {
            public ApiPacks ApiPacks(IWfChannel channel)
                => service<ApiPacks>(channel);
        }

        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public ApiCodeSvc ApiCode(IWfRuntime wf)
                => Service<ApiCodeSvc>(wf);

            public ApiResProvider ApiResProvider(IWfRuntime wf)
                => Service<ApiResProvider>(wf);

            public AsmDecoder AsmDecoder(IWfRuntime wf)
                => Service<AsmDecoder>(wf);

            public ApiCapture ApiCapture(IWfRuntime wf)
                => Service<ApiCapture>(wf);


            public CaptureWf CaptureWf(IWfRuntime wf)
                => Service<CaptureWf>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        static ChannelCache Channels => ChannelCache.Instance;

        public static ApiCodeSvc ApiCode(this IWfRuntime wf)
            => Services.ApiCode(wf);

        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Services.ApiResProvider(wf);

        public static AsmDecoder AsmDecoder(this IWfRuntime wf)
            => Services.AsmDecoder(wf);

       public static ApiCapture ApiCapture(this IWfRuntime wf)
            => Services.ApiCapture(wf);


        public static CaptureWf CaptureWf(this IWfRuntime wf)
            => Services.CaptureWf(wf);

        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Channels.ApiPacks(wf.Channel);

        public static ApiPacks ApiPacks(this IWfChannel channel)
            => Channels.ApiPacks(channel);
   }
}