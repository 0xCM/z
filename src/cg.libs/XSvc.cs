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
            public IApiCmdSvc CgTestCmd(IWfRuntime wf)
                => Service<CgTestCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IApiCmdSvc CgChecks(this IWfRuntime wf)
            => Services.CgTestCmd(wf);
    }
}
