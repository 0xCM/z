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
            public ToolCmdSvc ToolCmd(IWfRuntime wf)
                => Service<ToolCmdSvc>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IAppCmdSvc ToolCmd(this IWfRuntime wf)
            => Services.ToolCmd(wf);
    }
}