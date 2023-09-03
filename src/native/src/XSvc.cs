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
            public ApiCatalog ApiCatalog(IWfRuntime wf)
                => Service<ApiCatalog>(wf);

        
        }

        static ServiceCache Services => ServiceCache.Instance;


        public static ApiCatalog ApiCatalog(this IWfRuntime wf)            
            => Services.ApiCatalog(wf);


    }
}