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
            public ImageRegions ImageRegions(IWfRuntime wf)
                => Service<ImageRegions>(wf);
        
            public MemoryChecks MemoryChecks(IWfRuntime wf)
                => Service<MemoryChecks>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ImageRegions ImageRegions(this IWfRuntime wf)
            => Services.ImageRegions(wf);

        public static MemoryChecks MemoryChecks(this IWfRuntime wf)
            => Services.MemoryChecks(wf);
    }
}