//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {

            public CpuIdSvc CpuId(IWfRuntime wf)
                => Service<CpuIdSvc>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static CpuIdSvc CpuId(this IWfRuntime wf)
            => Services.CpuId(wf);
    }
}
