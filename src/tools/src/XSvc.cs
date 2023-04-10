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
            public Tooling Tooling(IWfRuntime wf) 
                => Service<Tooling>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);
    }
}