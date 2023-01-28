//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XTend
    {

    }

    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            public MsBuild BuildSvc(IWfRuntime wf)
                => Service<MsBuild>(wf);

            public MsBuildLoader MsBuildLoader(IWfRuntime wf)
                => Service<MsBuildLoader>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;


        public static MsBuild BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);

        public static MsBuildLoader MsBuildLoader(this IWfRuntime wf)
            => Services.MsBuildLoader(wf);

        
    }
}