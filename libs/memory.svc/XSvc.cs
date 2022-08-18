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


            public MemCmd MemCmd(IWfRuntime wf)
                => Service<MemCmd>(wf);

            public MemoryChecks MemoryChecks(IWfRuntime wf)
                => Service<MemoryChecks>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ImageRegions ImageRegions(this IWfRuntime wf)
            => Services.ImageRegions(wf);

        public static MemCmd MemCmd(this IWfRuntime wf)
            => Services.MemCmd(wf);

       public static MemoryChecks MemoryChecks(this IWfRuntime wf)
            => Services.MemoryChecks(wf);
    }
}