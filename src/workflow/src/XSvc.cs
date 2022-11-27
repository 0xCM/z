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

            public ArchiveRegistry ArchiveRegistry(IWfRuntime wf)
                => Service<ArchiveRegistry>(wf);            

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

            public CsvTableGen CsvTableGen(IWfRuntime wf)
                => Service<CsvTableGen>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static CsvTableGen CsvTableGen(this IWfRuntime wf)
            => Services.CsvTableGen(wf);

        public static MemoryChecks MemoryChecks(this IWfRuntime wf)
            => Services.MemoryChecks(wf);         

        public static ProcessMemory ProcessMemory(this IWfRuntime wf)
            => Services.ProcessMemory(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);

        public static ArchiveRegistry ArchiveRegistry(this IWfRuntime wf)
            => Services.ArchiveRegistry(wf);
 
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