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

            public IApiService ProjectCmd(IWfRuntime wf)
                => Service<ProjectServices.ProjectCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IApiService ProjectCmd(this IWfRuntime wf)
            => Services.ProjectCmd(wf);
    }
}
