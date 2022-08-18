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
        sealed class ServiceCache : AppServices<ServiceCache>
        {

            public MsBuild BuildSvc(IWfRuntime wf)
                => Service<MsBuild>(wf);

            public BuildCmd BuildCmd(IWfRuntime wf)
                => Service<BuildCmd>(wf);
        }


        static ServiceCache Services => ServiceCache.Instance;

        public static MsBuild BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);

        public static IAppCmdSvc BuildCmd(this IWfRuntime wf)
            => Services.BuildCmd(wf);
    }
}