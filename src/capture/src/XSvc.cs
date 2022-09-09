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