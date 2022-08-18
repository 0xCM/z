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
            public Runtime Runtime(IWfRuntime wf)
                => Service<Runtime>(wf);

            public CoffServices CoffServices(IWfRuntime wf)
                => Service<CoffServices>(wf);

            public AsmObjects AsmObjects(IWfRuntime wf)
                => Service<AsmObjects>(wf);

            public DumpParser DumpParser(IWfRuntime wf)
                => Service<DumpParser>(wf);

            public RuntimeCmd RuntimeCmd(IWfRuntime wf)
                => Service<RuntimeCmd>(wf);

        }

        static Svc Services => Svc.Instance;

        public static Runtime Runtime(this IWfRuntime wf)
            => Services.Runtime(wf);

        public static CoffServices CoffServices(this IWfRuntime wf)
            => Services.CoffServices(wf);

        public static AsmObjects AsmObjects(this IWfRuntime wf)
            => Services.AsmObjects(wf);

        public static DumpParser DumpParser(this IWfRuntime wf)
            => Services.DumpParser(wf);

        public static ICmdProvider RuntimeCmd(this IWfRuntime wf)
            => Services.RuntimeCmd(wf);
    }
}