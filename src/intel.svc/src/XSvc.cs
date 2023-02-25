//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using Asm;
    
    using static XedImport;
    using static XedModels;

    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public IntelIntrinsics IntelInx(IWfRuntime wf)
                => Service<IntelIntrinsics>(wf);

            public IntelCmd IntelCmd(IWfRuntime wf)
                => Service<IntelCmd>(wf);

            public IntelCmd IntelInxCmd(IWfRuntime wf)
                => Service<IntelCmd>(wf);

            public SdeSvc SdeSvc(IWfRuntime wf)
                => Service<SdeSvc>(wf);

            public XedChecks XedChecks(IWfRuntime wf)
                => Service<XedChecks>(wf);

            public XedCmd XedCmd(IWfRuntime wf)
                => Service<XedCmd>(wf);

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

            public XedDocs XedDocs(IWfRuntime wf, XedRuntime xed)
                => Service<XedDocs>(wf).With(xed);

            public XedPaths XedPaths(IWfRuntime wf)
                => Z0.XedPaths.Service;

            public InstBlockImporter BlockImporter(IWfRuntime wf)
                => Service<InstBlockImporter>(wf);

            public XedDisasm.Analyzer DisasmAnalyzer(IWfRuntime wf)
                => Service<XedDisasm.Analyzer>(wf);

            public IntelSdmPaths SdmPaths(IWfRuntime wf)
                => Service<IntelSdmPaths>(wf);

            public XedToolCmd XedToolCmd(IWfRuntime wf)
                => Service<XedToolCmd>(wf);

            public IApiService SdmCmd(IWfRuntime wf)
                => Service<IntelSdmCmd>(wf);

            public Xed Xed(IWfRuntime wf)
                => Service<Xed>(wf);

            public XedProject XedProject(IWfRuntime wf)
                => Service<XedProject>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IntelIntrinsics IntelIntrinsics(this IWfRuntime wf)
            => Services.IntelInx(wf);

        public static IApiService IntelInxCmd(this IWfRuntime wf)
            => Services.IntelInxCmd(wf);

        public static SdeSvc SdeSvc(this IWfRuntime wf)
            => Services.SdeSvc(wf);

        public static XedChecks XedChecks(this IWfRuntime xed)
            => Services.XedChecks(xed);

        public static XedCmd XedCmd(this IWfRuntime xed)
            => Services.XedCmd(xed);

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

        public static XedDisasm.Analyzer DisasmAnalyser(this IWfRuntime wf)
            => Services.DisasmAnalyzer(wf);

        public static XedPaths XedPaths(this IWfRuntime wf)
            => Services.XedPaths(wf);

        public static IntelSdmPaths SdmPaths(this IWfRuntime wf)
            => Services.SdmPaths(wf);

        public static SdmCodeGen SdmCodeGen(this IWfRuntime wf)
            => Services.Service<SdmCodeGen>(wf);

        public static IApiService SdmCmd(this IWfRuntime wf)
            => Services.SdmCmd(wf);

        public static Xed Xed(this IWfRuntime wf)
            => Services.Xed(wf);

        public static XedToolCmd XedToolCmd(this IWfRuntime wf)
            => Services.XedToolCmd(wf);

        public static XedDisasmSvc XedDisasmSvc(this IWfRuntime wf)
            => GlobalServices.Instance.Service<XedRuntime>(wf).Disasm;
 
        public static IntelCmd IntelCmd(this IWfRuntime wf)
            => Services.IntelCmd(wf);

        public static XedProject XedProject(this IWfRuntime wf)
            => Services.XedProject(wf);

    }

    partial struct Msg
    {
        public static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        public static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

        public static MsgPattern<ApiHostUri> ParsingHostMembers => "Parsing {0} members";

        public static MsgPattern<Count,ApiHostUri> ParsedHostMembers => "Parsed {0} {1} members";

        public static MsgPattern<Count> ParsingHosts => "Parsing {0} hosts";

        public static MsgPattern<Count,Count> ParsedHosts => "Parsed {0} members from {1} hosts";

        public static RenderPattern<Count,FilePath> LoadedForms => "Loaded {0} forms from {1}";

        public static MsgPattern<string,string> ParseFailure => "Parsing {0} from '{1}' failed";

        public static MsgPattern CollectingEntryPoints => "Collecting entry points";

        public static MsgPattern<Count> CollectedEntryPoints => "Collecting {0} entry points";

        public static MsgPattern<string> NotFound => "'{0}' not found";

        public static MsgPattern<Fence<char>> OpCodeFenceNotFound => "Op code fence {0} not found";

    }
}