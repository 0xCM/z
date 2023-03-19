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

            public ImageRegions ImageRegions(IWfRuntime wf)
                => Service<ImageRegions>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public ImageCmd ImageCmd(IWfRuntime wf)
                => Service<ImageCmd>(wf);

            public WfScripts ToolScripts(IWfRuntime wf)                
                => Service<WfScripts>(wf);

             public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static WfScripts ToolScripts(this IWfRuntime wf)
            => Services.ToolScripts(wf);

        public static ImageRegions ImageRegions(this IWfRuntime wf)
            => Services.ImageRegions(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static IApiService ImageCmd(this IWfRuntime wf)
            => Services.ImageCmd(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);             
             
    }
}