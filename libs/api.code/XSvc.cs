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

            public ApiResolver ApiResolver(IWfRuntime wf)
                => Service<ApiResolver>(wf);

            public ApiResProvider ApiResProvider(IWfRuntime wf)
                => Service<ApiResProvider>(wf);

            public ApiPacks ApiPacks(IWfRuntime wf)
                => Service<ApiPacks>(wf);

            public ApiCatalogs ApiCatalogs(IWfRuntime wf)
                => Service<ApiCatalogs>(wf);
        }

        static Svc Services => Svc.Instance;

        public static ApiCodeSvc ApiCode(this IWfRuntime wf)
            => Services.ApiCode(wf);

        public static ApiResolver ApiResolver(this IWfRuntime wf)
            => Services.ApiResolver(wf);

        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Services.ApiResProvider(wf);

        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Services.ApiPacks(wf);

        public static ApiCatalogs ApiCatalogs(this IWfRuntime wf)
            => Services.ApiCatalogs(wf);
   }
}