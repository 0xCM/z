//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Roslyn;

    using R = Z0.Roslyn.Roslyn;

    public static partial class XTend
    {

    }

    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {
            public MsBuild BuildSvc(IWfRuntime wf)
                => Service<MsBuild>(wf);

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public RoslnCmd RoslynCmd(IWfRuntime wf)
                => Service<RoslnCmd>(wf);

            public R Roslyn(IWfRuntime wf)
                => Service<R>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static MsBuild BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);

       public static R Roslyn(this IWfRuntime wf)
            => Services.Roslyn(wf);

        public static RoslnCmd RoslynCmd(this IWfRuntime wf)
            => Services.RoslynCmd(wf);            

             
    }
}