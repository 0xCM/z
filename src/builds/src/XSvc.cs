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

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static MsBuild BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);
    }
}