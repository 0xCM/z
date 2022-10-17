//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static partial class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            public DbArchives DbArchives(IWfRuntime wf)
                => Service<DbArchives>(wf);
        }


        static ServiceCache Services => ServiceCache.Instance;


        public static DbArchives DbArchive(this IWfRuntime wf)
            => Services.DbArchives(wf);
    }
}