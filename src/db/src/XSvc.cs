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
             public IApiService ArchiveCmd(IWfRuntime wf)
                => Service<ArchiveCmd>(wf);

            public ArchiveRegistry ArchiveRegistry(IWfRuntime wf)
                => Service<ArchiveRegistry>(wf);            

            public IApiService DbCmd(IWfRuntime wf)
                => Service<DbCmd>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IApiService ArchiveCmd(this IWfRuntime wf)
            => Services.ArchiveCmd(wf);

        public static ArchiveRegistry ArchiveRegistry(this IWfRuntime wf)
            => Services.ArchiveRegistry(wf);

        public static IApiService DbCmd(this IWfRuntime wf)
            => Services.DbCmd(wf);

    }
}