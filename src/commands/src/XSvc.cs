//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {

             public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

             public ApiCmdServer ApiCmdServer(IWfRuntime wf)
                => Service<ApiCmdServer>(wf);

            public CsvTableGen CsvTableGen(IWfRuntime wf)
                => Service<CsvTableGen>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

        public static ApiCmdServer ApiCmdServer(this IWfRuntime wf)
            => Services.ApiCmdServer(wf);

        public static CsvTableGen CsvTableGen(this IWfRuntime wf)
            => Services.CsvTableGen(wf);
    }
}