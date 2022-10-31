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
            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static ApiMd ApiMd(this IWfRuntime wf)
            => Services.ApiMetadata(wf);
    }
}