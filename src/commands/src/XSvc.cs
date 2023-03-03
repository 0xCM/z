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
                => Service<EnvCmd>(wf);

            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

            public ProjectScripts ProjectScripts(IWfRuntime wf)
                => Service<ProjectScripts>(wf);

            public ProjectManager ProjectManager(IWfRuntime wf)
                => Service<ProjectManager>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;
        
        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

        public static IApiService EnvCmd(this IWfRuntime wf)
            => Services.EnvCmd(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);

        public static ProjectManager ProjectManager(this IWfRuntime wf)
            => Services.ProjectManager(wf);

        // public static CmdServer CmdServer(this IWfRuntime wf)
        //     => Services.CmdServer(wf);            
    }
}