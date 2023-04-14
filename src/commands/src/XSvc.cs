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
            public ApiCmdSvc ApiCmd(IWfRuntime wf)
                => Service<ApiCmdSvc>(wf);

            public ApiServers ApiServers(IWfRuntime wf)
                => Service<ApiServers>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;        
    }
}