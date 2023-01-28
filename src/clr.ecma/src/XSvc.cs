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
            public EcmaEmitter EcmaEmitter(IWfRuntime wf)
                => Service<EcmaEmitter>(wf);

            public Ecma Ecma(IWfRuntime wf)
                => Service<Ecma>(wf);

            public MsilSvc MsilSvc(IWfRuntime wf)
                => Service<MsilSvc>(wf);

            public EcmaCmd EcmaCmd(IWfRuntime wf)
                => Service<EcmaCmd>(wf);

            public ClrCmd ClrCmd(IWfRuntime wf)
                => Service<ClrCmd>(wf);

            public ClrSvc ClrServices(IWfRuntime wf)
                => Service<ClrSvc>(wf);
        }

        static Svc Services => Svc.Instance;

        public static EcmaEmitter EcmaEmitter(this IWfRuntime wf)
            => Services.EcmaEmitter(wf);

        public static MsilSvc MsilSvc(this IWfRuntime wf)
            => Services.MsilSvc(wf);

        public static Ecma Ecma(this IWfRuntime wf)
            => Services.Ecma(wf);

        public static IApiService EcmaCmd(this IWfRuntime wf)
            => Services.EcmaCmd(wf);

        public static IApiService ClrCmd(this IWfRuntime wf)
            => Services.ClrCmd(wf);

        public static ClrSvc ClrSvc(this IWfRuntime wf)
            => Services.ClrServices(wf);
    }
}