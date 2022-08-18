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
            public DbCmd DbCmd(IWfRuntime wf)
                => Service<DbCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ICmdProvider DbCmd(this IWfRuntime wf)
            => Services.DbCmd(wf);
    }
}