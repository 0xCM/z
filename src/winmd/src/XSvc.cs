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
            public IApiService WinMdCmd(IWfRuntime wf)
                => Service<WinMdCmd>(wf);

        }

        static Svc Services => Svc.Instance;

        public static IApiService WinMdCmd(this IWfRuntime wf)
            => Services.WinMdCmd(wf);
    }
}