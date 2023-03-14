//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.CSharp;
global using Microsoft.CodeAnalysis.Emit;
[assembly: PartId(PartId.Symbolics)]
namespace Z0.Parts
{
    public sealed class Symbolics : Part<Symbolics>
    {

    }
}

namespace Z0
{
    public static partial class XTend
    {

    }

    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {

            public CsLang CsLang(IWfRuntime wf)
                => Service<CsLang>(wf);

            public IApiService CsGenCmd(IWfRuntime wf)
                => Service<CsGenCmd>(wf);
        }


        static ServiceCache Services = ServiceCache.Instance;


        public static CsLang CsLang(this IWfRuntime wf)
            => Services.CsLang(wf);

        public static IApiService CsGenCmd(this IWfRuntime wf)
            => Services.CsGenCmd(wf);
    }
}