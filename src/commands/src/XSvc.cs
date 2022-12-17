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

            public CsvTableGen CsvTableGen(IWfRuntime wf)
                => Service<CsvTableGen>(wf);

            public Cmd Cmd(IWfRuntime wf)
                => Service<Cmd>(wf);

            public ProjectScripts ProjectScripts(IWfRuntime wf)
                => Service<ProjectScripts>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static Cmd Cmd(this IWfRuntime wf)
            => Services.Cmd(wf);

        public static IApiService EnvCmd(this IWfRuntime wf)
            => Services.EnvCmd(wf);

        public static CsvTableGen CsvTableGen(this IWfRuntime wf)
            => Services.CsvTableGen(wf);

        public static ProjectScripts ProjectScripts(this IWfRuntime wf)
            => Services.ProjectScripts(wf);            
    }
}