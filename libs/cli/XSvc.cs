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
            public CliEmitter CliEmitter(IWfRuntime wf)
                => Service<CliEmitter>(wf);

            public Cli Cli(IWfRuntime wf)
                => Service<Cli>(wf);

            public MsilPipe MsilSvc(IWfRuntime wf)
                => Service<MsilPipe>(wf);

            public EcmaCmd CliCmd(IWfRuntime wf)
                => Service<EcmaCmd>(wf);

            public RoslnCmd RoslynCmd(IWfRuntime wf)
                => Service<RoslnCmd>(wf);

            public R Roslyn(IWfRuntime wf)
                => Service<R>(wf);
        }

        static Svc Services => Svc.Instance;

        public static CliEmitter CliEmitter(this IWfRuntime wf)
            => Services.CliEmitter(wf);

        public static MsilPipe MsilSvc(this IWfRuntime wf)
            => Services.MsilSvc(wf);

        public static Cli Cli(this IWfRuntime wf)
            => Services.Cli(wf);

        public static ICmdProvider CliCmd(this IWfRuntime wf)
            => Services.CliCmd(wf);

        public static R Roslyn(this IWfRuntime wf)
            => Services.Roslyn(wf);

        public static RoslnCmd RoslynCmd(this IWfRuntime wf)
            => Services.RoslynCmd(wf);            
    }
}