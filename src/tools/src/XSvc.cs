//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Tools;
    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            public Tooling Tooling(IWfRuntime wf) 
                => Service<Tooling>(wf);

            public CMakeTool CMake(IWfRuntime wf)
                => Service<CMakeTool>(wf);

            public Python Python(IWfRuntime wf)
                => Service<Python>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);

        public static CMakeTool CMake(this IWfRuntime wf)
            => Services.CMake(wf);

        public static Python Python(this IWfRuntime wf)
            => Services.Python(wf);             
    }
}