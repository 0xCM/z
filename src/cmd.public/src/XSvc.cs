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
            public CmdPublic CmdPublic(IWfRuntime wf)
                => Service(wf,nameof(CmdPublic), Z0.CmdPublic.factory);
        }

        static Svc Services => Svc.Instance;

        public static IAppCmdSvc CmdPublic(this IWfRuntime wf)
            => Services.CmdPublic(wf);
    }
}