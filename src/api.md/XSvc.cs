//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public IAppCmdSvc ApiCmd(IWfRuntime wf)
                => Service<ApiMdCmd>(wf);

            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static ApiMd ApiMd(this IWfRuntime wf)
            => Services.ApiMetadata(wf);

        public static IAppCmdSvc ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);
    }
}