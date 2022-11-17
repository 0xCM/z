//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using Microsoft.DiaSymReader;
namespace Z0
{
    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {

            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);

            public XmlComments ApiComments(IWfRuntime wf)
                => Service<XmlComments>(wf);

            public PdbIndexBuilder PdbIndexBuilder(IWfRuntime wf)
                => Service<PdbIndexBuilder>(wf);

            public PdbSvc PdbSvc(IWfRuntime wf)
                => Service<PdbSvc>(wf);

            public SosCmd SosCmd(IWfRuntime wf)
                => Service<SosCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static XmlComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static ApiMd ApiMd(this IWfRuntime wf)
            => Services.ApiMetadata(wf);            

        public static SosCmd SosCmd(this IWfRuntime wf)
            => Services.SosCmd(wf);

        public static PdbIndexBuilder PdbIndexBuilder(this IWfRuntime wf)
            => Services.PdbIndexBuilder(wf);

        public static PdbSvc PdbSvc(this IWfRuntime wf)
            => Services.PdbSvc(wf);
    }
}