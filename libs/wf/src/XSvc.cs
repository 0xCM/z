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
            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public WsRegistry WsRegistry(IWfRuntime wf)
                => Service<WsRegistry>(wf);

            public WfCmd WfCmd(IWfRuntime wf)
                => Service<WfCmd>(wf);

            public ArchiveCmd ArchiveCmd(IWfRuntime wf)
                => Service<ArchiveCmd>(wf);

            public ProjectScripts ProjectScripts(IWfRuntime wf)
                => Service<ProjectScripts>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

            public ToolScripts ToolScripts(IWfRuntime wf)
                => Service<ToolScripts>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static WsRegistry WsRegistry(this IWfRuntime wf)
            => Services.WsRegistry(wf);

        public static WfCmd WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);

        public static ICmdProvider ArchiveCmd(this IWfRuntime wf)
            => Services.ArchiveCmd(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);             

        public static ToolScripts ToolScripts(this IWfRuntime wf)
            => Services.ToolScripts(wf);

    }
}