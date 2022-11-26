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

            public DumpParser DumpParser(IWfRuntime wf)
                => Service<DumpParser>(wf);

            public ProcessCmd RuntimeCmd(IWfRuntime wf)
                => Service<ProcessCmd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static Runtime Runtime(this IWfRuntime wf)
            => Services.Runtime(wf);

        public static DumpParser DumpParser(this IWfRuntime wf)
            => Services.DumpParser(wf);

        public static IApiService RuntimeCmd(this IWfRuntime wf)
            => Services.RuntimeCmd(wf);
    }
}