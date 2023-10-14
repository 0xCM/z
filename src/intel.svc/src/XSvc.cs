//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0;

using Asm;

using static XedModels;

public static class XSvc
{
    sealed class ServiceCache : AppServices<ServiceCache>
    {
        public SdeCpuid CpuId(IWfRuntime wf)
            => Service<SdeCpuid>(wf);

        public IntelIntrinsics IntelInx(IWfRuntime wf)
            => Service<IntelIntrinsics>(wf);

        public SdeSvc SdeSvc(IWfRuntime wf)
            => Service<SdeSvc>(wf);

        public IntelSdm IntelSdm(IWfRuntime wf)
            => Service<IntelSdm>(wf);

        public XedDisasm XedDisasm(IWfRuntime wf)
            => Service<XedDisasm>(wf);

        public XedDisasmAnalyzer DisasmAnalyzer(IWfRuntime wf)
            => Service<XedDisasmAnalyzer>(wf);

        public IntelSdmPaths SdmPaths(IWfRuntime wf)
            => Service<IntelSdmPaths>(wf);

        public XedImport XedImport(IWfRuntime wf)
            => Service<XedImport>(wf);
    }

    static ServiceCache Services => ServiceCache.Instance;

    public static IntelIntrinsics IntelIntrinsics(this IWfRuntime wf)
        => Services.IntelInx(wf);

    public static SdeSvc SdeSvc(this IWfRuntime wf)
        => Services.SdeSvc(wf);

    public static IntelSdm IntelSdm(this IWfRuntime wf)
        => Services.IntelSdm(wf);

    public static XedDisasm XedDisasm(this IWfRuntime wf)
        => Services.XedDisasm(wf);

    public static XedDisasmAnalyzer DisasmAnalyser(this IWfRuntime wf)
        => Services.DisasmAnalyzer(wf);

    public static IntelSdmPaths SdmPaths(this IWfRuntime wf)
        => Services.SdmPaths(wf);

    public static SdeCpuid CpuId(this IWfRuntime wf)
        => Services.CpuId(wf);

    public static XedImport XedImport(this IWfRuntime wf)
        => Services.XedImport(wf);

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