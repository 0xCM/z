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
            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);

            public XmlComments ApiComments(IWfRuntime wf)
                => Service<XmlComments>(wf);

            public ApiCatalog ApiCatalog(IWfRuntime wf)
                => Service<ApiCatalog>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static XmlComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static ApiCatalog ApiCatalog(this IWfRuntime wf)            
            => Services.ApiCatalog(wf);

        public static ApiMd ApiMd(this IWfRuntime wf)
            => Services.ApiMetadata(wf);            
    }
}