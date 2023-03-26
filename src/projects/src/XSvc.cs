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

            public ProjectServices ProjectServices(IWfRuntime wf)
                => Service<ProjectServices>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IApiService ProjectCmd(this IWfRuntime wf)
            => Services.ProjectCmd(wf);

        public static ProjectServices ProjectServices(this IWfRuntime wf)
            => Services.ProjectServices(wf);
    }
}
