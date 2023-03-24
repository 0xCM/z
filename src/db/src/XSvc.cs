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

            public ArchiveRegistry ArchiveRegistry(IWfRuntime wf)
                => Service<ArchiveRegistry>(wf);            
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ArchiveRegistry ArchiveRegistry(this IWfRuntime wf)
            => Services.ArchiveRegistry(wf);
    }
}