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


            public CoffServices CoffServices(IWfRuntime wf)
                => Service<CoffServices>(wf);

            public WinSdk WinSdk(IWfRuntime wf)
                => Service<WinSdk>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;


        public static CoffServices CoffServices(this IWfRuntime wf)
            => Services.CoffServices(wf);

        public static AsmObjects AsmObjects(this IWfRuntime wf)
            => Services.AsmObjects(wf);

        public static WinSdk WinSdk(this IWfRuntime wf)
            => Services.WinSdk(wf);
             
    }
}