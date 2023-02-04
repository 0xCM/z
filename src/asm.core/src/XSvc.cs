//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [ApiHost]
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public AsmTables AsmTables(IWfRuntime wf)
                => Service<AsmTables>(wf);

            public AsmCoreCmd AsmCoreCmd(IWfRuntime wf)
                => Service<AsmCoreCmd>(wf);

            public StanfordAsmCatalog StanfordCatalog(IWfRuntime wf)
                => Service<StanfordAsmCatalog>(wf);

            public AsmDocs AsmDocs(IWfRuntime wf)
                => Service<AsmDocs>(wf);

            public CultProcessor CultProcessor(IWfRuntime wf)
                => Service<CultProcessor>(wf);
 
            public AsmFlowCmd AsmFlowCmd(IWfRuntime wf)
                => Service<AsmFlowCmd>(wf);

            public AsmDbCmd AsmDbCmd(IWfRuntime wf)
                => Service<AsmDbCmd>(wf);

            public NasmCatalog NasmCatalog(IWfRuntime wf)
                => Service<NasmCatalog>(wf);

            public AsmGenCmd AsmGenCmd(IWfRuntime wf)
                => Service<AsmGenCmd>(wf);

        }

        static Svc Services => Svc.Instance;

        public static AsmCoreCmd AsmCoreCmd(this IWfRuntime wf)
            => Services.AsmCoreCmd(wf);

        public static AsmTables AsmTables(this IWfRuntime wf)
            => Services.AsmTables(wf);

         public static StanfordAsmCatalog StanfordCatalog(this IWfRuntime wf)
            => Services.StanfordCatalog(wf);

         public static AsmDocs AsmDocs(this IWfRuntime wf)
            => Services.AsmDocs(wf);

         public static AsmFlowCmd AsmFlowCmd(this IWfRuntime wf)
           => Services.AsmFlowCmd(wf);

         public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Services.CultProcessor(wf);

         public static AsmDbCmd AsmDbCmd(this IWfRuntime wf)
            => Services.AsmDbCmd(wf);

         public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Services.NasmCatalog(wf);

        public static AsmGenCmd AsmGenCmd(this IWfRuntime wf)
            => Services.AsmGenCmd(wf);             
    }
}