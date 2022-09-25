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
            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public ProjectScripts ProjectScripts(IWfRuntime wf)
                => Service<ProjectScripts>(wf);

            public WsRegistry WsRegistry(IWfRuntime wf)
                => Service<WsRegistry>(wf);


        }

        static ServiceCache Services => ServiceCache.Instance;

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);

        public static WsRegistry WsRegistry(this IWfRuntime wf)
            => Services.WsRegistry(wf);
    }
}