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
            public Machines Machines(IWfRuntime wf)
                => Service<Machines>(wf);
        }

        static Svc Services => Svc.Instance;

        public static Machines Machines(this IWfRuntime wf)
            => Services.Machines(wf);
    }
}