//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using static XedImport;

    [ApiHost]
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public AsmCheckCmd AsmCheckCmd(IWfRuntime wf)
                => Service<AsmCheckCmd>(wf);

            public IntelSdm IntelSdm(IWfRuntime wf)
                => Service<IntelSdm>(wf);

            public XedImport XedImport(IWfRuntime wf, XedRuntime xed)
                => Service<XedImport>(wf).With(xed);

            public XedRules XedRules(IWfRuntime wf, XedRuntime xed)
                => Service<XedRules>(wf).With(xed);

            public XedOps XedOps(IWfRuntime wf, XedRuntime xed)
                => Service<XedOps>(wf).With(xed);

            public XedDb XedDb(IWfRuntime wf, XedRuntime xed)
                => Service<XedDb>(wf).With(xed);

            public XedDisasmSvc XedDisasm(IWfRuntime wf, XedRuntime xed)
                => Service<XedDisasmSvc>(wf).With(xed);

            public XedDisasm XedDisasm2(IWfRuntime wf, XedRuntime xed)
                => Service<XedDisasm>(wf).With(xed);

            public XedDocs XedDocs(IWfRuntime wf, XedRuntime xed)
                => Service<XedDocs>(wf).With(xed);

            public AsmTables AsmTables(IWfRuntime wf)
                => Service<AsmTables>(wf);

            public XedPaths XedPaths(IWfRuntime wf)
                => Z0.XedPaths.Service;

            public CpuIdSvc CpuId(IWfRuntime wf)
                => Service<CpuIdSvc>(wf);

            public InstBlockImporter BlockImporter(IWfRuntime wf)
                => Service<InstBlockImporter>(wf);

            public XedDisasm.Analyzer DisasmAnalyzer(IWfRuntime wf)
                => Service<XedDisasm.Analyzer>(wf);

            public AsmCoreCmd AsmCoreCmd(IWfRuntime wf)
                => Service<AsmCoreCmd>(wf);

            public StanfordAsmCatalog StanfordCatalog(IWfRuntime wf)
                => Service<StanfordAsmCatalog>(wf);

            public Parsers Parsers(IWfRuntime wf)
                => Service<Parsers>(wf);

            public CharMapper CharMapper(IWfRuntime wf)
                => Service<CharMapper>(wf);

            public AsmDocs AsmDocs(IWfRuntime wf)
                => Service<AsmDocs>(wf);

            public IntelSdmPaths SdmPaths(IWfRuntime wf)
                => Service<IntelSdmPaths>(wf);

            public XedToolCmd XedToolCmd(IWfRuntime wf)
                => Service<XedToolCmd>(wf);

            public CultProcessor CultProcessor(IWfRuntime wf)
                => Service<CultProcessor>(wf);
 
            public AsmFlowCmd AsmFlowCmd(IWfRuntime wf)
                => Service<AsmFlowCmd>(wf);

        }

        static Svc Services => Svc.Instance;

        public static AsmCoreCmd AsmCoreCmd(this IWfRuntime wf)
            => Services.AsmCoreCmd(wf);

        public static AsmCheckCmd AsmChecks(this IWfRuntime wf)
            => Services.AsmCheckCmd(wf);

        public static IntelSdm IntelSdm(this IWfRuntime wf)
            => Services.IntelSdm(wf);

        public static XedRuntime XedRuntime(this IWfRuntime wf)
            => GlobalServices.Instance.Service<XedRuntime>(wf);

        public static XedImport XedImport(this IWfRuntime wf, XedRuntime xed)
            => Services.XedImport(wf, xed);

        public static XedRules XedRules(this IWfRuntime wf, XedRuntime xed)
            => Services.XedRules(wf, xed);

        public static XedOps XedOps(this IWfRuntime wf, XedRuntime xed)
            => Services.XedOps(wf, xed);

        public static XedDb XedDb(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDb(wf, xed);

        public static XedDisasmSvc XedDisasm(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDisasm(wf, xed);

        public static XedDocs XedDocs(this IWfRuntime wf, XedRuntime xed)
            => Services.XedDocs(wf, xed);

        public static InstBlockImporter BlockImporter(this IWfRuntime wf)
            => Services.BlockImporter(wf);

        public static AsmTables AsmTables(this IWfRuntime wf)
            => Services.AsmTables(wf);

        public static XedDisasm.Analyzer DisasmAnalyser(this IWfRuntime wf)
            => Services.DisasmAnalyzer(wf);

        public static XedPaths XedPaths(this IWfRuntime wf)
            => Services.XedPaths(wf);

        public static CpuIdSvc CpuId(this IWfRuntime wf)
            => Services.CpuId(wf);

        public static SdmCodeGen SdmCodeGen(this IWfRuntime wf)
            => Services.Service<SdmCodeGen>(wf);

        public static StanfordAsmCatalog StanfordCatalog(this IWfRuntime wf)
            => Services.StanfordCatalog(wf);

        public static Parsers Parsers(this IWfRuntime wf)
            => Services.Parsers(wf);

        public static AsmDocs AsmDocs(this IWfRuntime wf)
            => Services.AsmDocs(wf);

        public static CharMapper CharMapper(this IWfRuntime wf)
            => Services.CharMapper(wf);

        public static IntelSdmPaths SdmPaths(this IWfRuntime wf)
            => Services.SdmPaths(wf);

        public static XedToolCmd XedToolCmd(this IWfRuntime wf)
            => Services.XedToolCmd(wf);

         public static AsmFlowCmd AsmFlowCmd(this IWfRuntime wf)
           => Services.AsmFlowCmd(wf);

         public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Services.CultProcessor(wf);

    }
}