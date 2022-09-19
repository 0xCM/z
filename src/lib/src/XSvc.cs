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
            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public DbArchives DbArchives(IWfRuntime wf)
                => Service<DbArchives>(wf);
        }


        static ServiceCache Services => ServiceCache.Instance;


        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static DbArchives DbArchive(this IWfRuntime wf)
            => Services.DbArchives(wf);
    }
}