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
             public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

             public IApiService EnvCmd(IWfRuntime wf)
                => Service<EnvCmd>(wf);

            public CsvTableGen CsvTableGen(IWfRuntime wf)
                => Service<CsvTableGen>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

        public static IApiService EnvCmd(this IWfRuntime wf)
            => Services.EnvCmd(wf);

        public static CsvTableGen CsvTableGen(this IWfRuntime wf)
            => Services.CsvTableGen(wf);
    }
}