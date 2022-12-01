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
            public DumpParser DumpParser(IWfRuntime wf)
                => Service<DumpParser>(wf);

            public ContextCmd ContextCmd(IWfRuntime wf)
                => Service<ContextCmd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static DumpParser DumpParser(this IWfRuntime wf)
            => Services.DumpParser(wf);

        public static IApiService ContextCmd(this IWfRuntime wf)
            => Services.ContextCmd(wf);
    }
}