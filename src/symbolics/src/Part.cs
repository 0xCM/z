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

            public GAsciLookup GenAsciLookups(IWfRuntime wf)
                => Service<GAsciLookup>(wf);

            public StringLitEmitter GenLiterals(IWfRuntime wf)
                => Service<StringLitEmitter>(wf);

            public CsLang CsLang(IWfRuntime wf)
                => Service<CsLang>(wf);


            public GLiteralProvider GenLitProviders(IWfRuntime wf)
                => Service<GLiteralProvider>(wf);

            public SymbolFactories SymbolFactories(IWfRuntime wf)
                => Service<SymbolFactories>(wf);


        }


        public static SymbolFactories SymbolFactories(this IWfRuntime wf)
            => Services.SymbolFactories(wf);


        static ServiceCache Services = ServiceCache.Instance;

        public static GLiteralProvider GenLitProviders(this IWfRuntime wf)
            => Services.GenLitProviders(wf);


        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => Services.GenAsciLookups(wf);

        public static StringLitEmitter GenLiterals(this IWfRuntime wf)
            => Services.GenLiterals(wf);

        public static CsLang CsLang(this IWfRuntime wf)
            => Services.CsLang(wf);
    }
}