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
             public IApiService EnvCmd(IWfRuntime wf)
                => Service<EnvFlows>(wf);

            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

            public ProjectScripts ProjectScripts(IWfRuntime wf)
                => Service<ProjectScripts>(wf);

            public ApiServers ApiServers(IWfRuntime wf)
                => Service<ApiServers>(wf);

             public IApiService ArchiveCmd(IWfRuntime wf)
                => Service<ArchiveFlows>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;
        
        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

        public static ApiServers ApiServers(this IWfRuntime wf)
            => Services.ApiServers(wf);

        public static IApiService EnvCmd(this IWfRuntime wf)
            => Services.EnvCmd(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);

        public static IApiService ArchiveCmd(this IWfRuntime wf)
            => Services.ArchiveCmd(wf);
    }
}