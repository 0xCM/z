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


            public Dev Dev(IWfRuntime wf)
                => Service<Dev>(wf);

            public DevPacks DevPacks(IWfRuntime wf)
                => Service<DevPacks>(wf);

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

            public DbCmd DbCmd(IWfRuntime wf)
                => Service<DbCmd>(wf);

            public DevCmd DevCmd(IWfRuntime wf)
                => Service<DevCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ICmdProvider DbCmd(this IWfRuntime wf)
            => Services.DbCmd(wf);

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

        public static MsBuild BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);

       public static Dev Dev(this IWfRuntime wf)
            => Services.Dev(wf);

        public static DevPacks DevPacks(this IWfRuntime wf)
            => Services.DevPacks(wf);

        public static IAppCmdSvc BuildCmd(this IWfRuntime wf)
            => Services.BuildCmd(wf);

        public static IAppCmdSvc DevCmd(this IWfRuntime wf)
            => Services.DevCmd(wf);
    }
}