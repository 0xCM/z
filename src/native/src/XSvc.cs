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

            public AsmObjects AsmObjects(IWfRuntime wf)
                => Service<AsmObjects>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public CoffServices CoffServices(IWfRuntime wf)
                => Service<CoffServices>(wf);

            public CpuIdSvc CpuId(IWfRuntime wf)
                => Service<CpuIdSvc>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;


        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static CoffServices CoffServices(this IWfRuntime wf)
            => Services.CoffServices(wf);

        public static AsmObjects AsmObjects(this IWfRuntime wf)
            => Services.AsmObjects(wf);

        public static CpuIdSvc CpuId(this IWfRuntime wf)
            => Services.CpuId(wf);
    }
}