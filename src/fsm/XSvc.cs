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
            public IAppCmdSvc FsmCmd(IWfRuntime wf)
                => Service<FsmCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IAppCmdSvc FsmCmd(this IWfRuntime wf)
            => Services.FsmCmd(wf);
    }
}
