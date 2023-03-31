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

            public ApiServers ApiServers(IWfRuntime wf)
                => Service<ApiServers>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;
        
        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

        public static ApiServers ApiServers(this IWfRuntime wf)
            => Services.ApiServers(wf);

    }
}