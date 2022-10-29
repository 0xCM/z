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

            public ImageRegions ImageRegions(IWfRuntime wf)
                => Service<ImageRegions>(wf);


        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ImageRegions ImageRegions(this IWfRuntime wf)
            => Services.ImageRegions(wf);
    }
}