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

        }

        static Svc Services => Svc.Instance;

        public static DumpParser DumpParser(this IWfRuntime wf)
            => Services.DumpParser(wf);
    }
}