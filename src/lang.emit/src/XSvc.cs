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
            public CsGenCmd CsGenCmd(IWfRuntime wf)
                => Service<CsGenCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static CsGenCmd CsGenCmd(this IWfRuntime wf)
            => Services.CsGenCmd(wf);
    }
}