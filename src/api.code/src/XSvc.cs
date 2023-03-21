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
            public ApiCodeSvc ApiCode(IWfRuntime wf)
                => Service<ApiCodeSvc>(wf);

            public ApiResProvider ApiResProvider(IWfRuntime wf)
                => Service<ApiResProvider>(wf);
        }

        static Svc Services => Svc.Instance;


        public static ApiCodeSvc ApiCode(this IWfRuntime wf)
            => Services.ApiCode(wf);

        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Services.ApiResProvider(wf);
   }
}