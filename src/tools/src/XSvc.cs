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
            public ProjectTools Dev(IWfRuntime wf)
                => Service<ProjectTools>(wf);

            public BuildCmd BuildCmd(IWfRuntime wf)
                => Service<BuildCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ProjectTools Dev(this IWfRuntime wf)
            => Services.Dev(wf);

        public static IApiService BuildCmd(this IWfRuntime wf)
            => Services.BuildCmd(wf);
    }
}