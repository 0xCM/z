//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static IntelInx;

    using I=IntelInx;

    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public IntelInx IntelInx(IWfRuntime wf)
                => Service<IntelInx>(wf);

            public IntelInxCmd IntelInxCmd(IWfRuntime wf)
                => Service<IntelInxCmd>(wf);

            public I.Checks Checks(IWfRuntime wf)
                => Service<I.Checks>(wf);

            public SdeSvc SdeSvc(IWfRuntime wf)
                => Service<SdeSvc>(wf);

            public XedChecks XedChecks(IWfRuntime wf)
                => Service<XedChecks>(wf);

            public XedCmd XedCmd(IWfRuntime wf)
                => Service<XedCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IntelInx IntelIntrinsics(this IWfRuntime wf)
            => Services.IntelInx(wf);

        public static IAppCmdSvc IntelInxCmd(this IWfRuntime wf)
            => Services.IntelInxCmd(wf);

        public static I.Checks Checks(this IWfRuntime wf)
            => Services.Checks(wf);

        public static SdeSvc SdeSvc(this IWfRuntime wf)
            => Services.SdeSvc(wf);

        public static XedChecks XedChecks(this IWfRuntime xed)
            => Services.XedChecks(xed);

        public static XedCmd XedCmd(this IWfRuntime xed)
            => Services.XedCmd(xed);
    }
}