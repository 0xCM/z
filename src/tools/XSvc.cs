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
            public ToolCmd ToolCmd(IWfRuntime wf)
                => Service<ToolCmd>(wf);


            public MsBuild BuildSvc(IWfRuntime wf)
                => Service<MsBuild>(wf);

            public BuildCmd BuildCmd(IWfRuntime wf)
                => Service<BuildCmd>(wf);

            public WfCmd WfCmd(IWfRuntime wf)
                => Service<WfCmd>(wf);

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public WsRegistry WsRegistry(IWfRuntime wf)
                => Service<WsRegistry>(wf);

            public ProjectScripts ProjectScripts(IWfRuntime wf)
                => Service<ProjectScripts>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

            public ToolScripts ToolScripts(IWfRuntime wf)
                => Service<ToolScripts>(wf);

            public DevOpsSvc DevOps(IWfRuntime wf)
                => Service<DevOpsSvc>(wf);

            public DbCmd DbCmd(IWfRuntime wf)
                => Service<DbCmd>(wf);
        }

        public static ICmdProvider DbCmd(this IWfRuntime wf)
            => Services.DbCmd(wf);


        static ServiceCache Services => ServiceCache.Instance;

        public static IAppCmdSvc ToolCmd(this IWfRuntime wf)
            => Services.ToolCmd(wf);

        public static WfCmd WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static WsRegistry WsRegistry(this IWfRuntime wf)
            => Services.WsRegistry(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);             

        public static ToolScripts ToolScripts(this IWfRuntime wf)
            => Services.ToolScripts(wf);

        public static DevOpsSvc DevOps(this IWfRuntime wf)
                => Services.DevOps(wf);            

        public static MsBuild BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);

        public static IAppCmdSvc BuildCmd(this IWfRuntime wf)
            => Services.BuildCmd(wf);
    }
}