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
             public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

            public WfAppCmd WfCmd(IWfRuntime wf)
                => Service<WfAppCmd>(wf);

            public WfScripts ToolScripts(IWfRuntime wf)                
                => Service<WfScripts>(wf);

            public ProcessMemory ProcessMemory(IWfRuntime wf)                
                => Service<ProcessMemory>(wf);

            public MemoryChecks MemoryChecks(IWfRuntime wf)
                => Service<MemoryChecks>(wf); 

            public ApiPacks ApiPacks(IWfRuntime wf)
                => Service<ApiPacks>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static MemoryChecks MemoryChecks(this IWfRuntime wf)
            => Services.MemoryChecks(wf);         

        public static ProcessMemory ProcessMemory(this IWfRuntime wf)
            => Services.ProcessMemory(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);             

        public static WfAppCmd WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);

        public static WfScripts ToolScripts(this IWfRuntime wf)
            => Services.ToolScripts(wf);

        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Services.ApiPacks(wf);
    }
}