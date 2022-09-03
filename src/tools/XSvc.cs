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
            public ToolCmd ToolCmd(IWfRuntime wf)
                => Service<ToolCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IAppCmdSvc ToolCmd(this IWfRuntime wf)
            => Services.ToolCmd(wf);
    }
}