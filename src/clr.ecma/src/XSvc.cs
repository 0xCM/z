//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Roslyn;

    using R = Z0.Roslyn.Roslyn;

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

            public RoslnCmd RoslynCmd(IWfRuntime wf)
                => Service<RoslnCmd>(wf);

            public R Roslyn(IWfRuntime wf)
                => Service<R>(wf);
        }

        static Svc Services => Svc.Instance;

        public static EcmaEmitter EcmaEmitter(this IWfRuntime wf)
            => Services.EcmaEmitter(wf);

        public static MsilSvc MsilSvc(this IWfRuntime wf)
            => Services.MsilSvc(wf);

        public static Ecma Ecma(this IWfRuntime wf)
            => Services.Ecma(wf);

        public static ICmdProvider EcmaCmd(this IWfRuntime wf)
            => Services.EcmaCmd(wf);

        public static R Roslyn(this IWfRuntime wf)
            => Services.Roslyn(wf);

        public static RoslnCmd RoslynCmd(this IWfRuntime wf)
            => Services.RoslynCmd(wf);            
    }
}