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
            public WfAppCmd WfCmd(IWfRuntime wf)
                => Service<WfAppCmd>(wf);

            public ProcessMemory ProcessMemory(IWfRuntime wf)                
                => Service<ProcessMemory>(wf);

            public MemoryChecks MemoryChecks(IWfRuntime wf)
                => Service<MemoryChecks>(wf); 

            public ApiPacks ApiPacks(IWfRuntime wf)
                => Service<ApiPacks>(wf);

            public IApiService CsGenCmd(IWfRuntime wf)
                => Service<CsGenCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IApiService CsGenCmd(this IWfRuntime wf)
            => Services.CsGenCmd(wf);

        public static MemoryChecks MemoryChecks(this IWfRuntime wf)
            => Services.MemoryChecks(wf);         

        public static ProcessMemory ProcessMemory(this IWfRuntime wf)
            => Services.ProcessMemory(wf);

        public static WfAppCmd WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);

        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Services.ApiPacks(wf);
    }
}