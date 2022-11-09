//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            public AsmCheckCmd AsmChecks(IWfRuntime wf)
                => Service<AsmCheckCmd>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static AsmCheckCmd AsmCheckCmd(this IWfRuntime wf)
            => Services.AsmChecks(wf);
    }
}