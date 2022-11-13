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

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static ApiMd ApiMd(this IWfRuntime wf)
            => Services.ApiMetadata(wf);            
    }
}