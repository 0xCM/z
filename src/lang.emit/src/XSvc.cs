//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsLang;

    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public CsLang CsLang(IWfRuntime wf)
                => Service<CsLang>(wf);

            public StringLitEmitter GenLiterals(IWfRuntime wf)
                => Service<StringLitEmitter>(wf);

            public GAsciLookup GenAsciLookups(IWfRuntime wf)
                => Service<GAsciLookup>(wf);

            public GLiteralProvider GenLitProviders(IWfRuntime wf)
                => Service<GLiteralProvider>(wf);

            public SymbolFactories SymbolFactories(IWfRuntime wf)
                => Service<SymbolFactories>(wf);

            public CsGenCmd CsGenCmd(IWfRuntime wf)
                => Service<CsGenCmd>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static CsLang CsLang(this IWfRuntime wf)
            => Services.CsLang(wf);

        public static StringLitEmitter GenLiterals(this IWfRuntime wf)
            => Services.GenLiterals(wf);

        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => Services.GenAsciLookups(wf);

        public static GLiteralProvider GenLitProviders(this IWfRuntime wf)
            => Services.GenLitProviders(wf);

        public static SymbolFactories SymbolFactories(this IWfRuntime wf)
            => Services.SymbolFactories(wf);

       public static CsGenCmd CsGenCmd(this IWfRuntime wf)
            => Services.CsGenCmd(wf);
    }
}