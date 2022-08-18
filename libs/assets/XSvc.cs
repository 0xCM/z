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
            public Assets Assets(IWfRuntime wf)
                => Service<Assets>(wf);
        }

        static Svc Services => Svc.Instance;

        public static Assets Assets(this IWfRuntime wf)
            => Services.Assets(wf);
    }
}