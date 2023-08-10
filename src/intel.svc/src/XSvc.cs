//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0;

using Asm;

using static XedFlows;
using static XedModels;

public static class XSvc
{
    sealed class ChannelCache : AppChannels<ChannelCache>
    {
        public XedTables XedViews(IWfChannel channel)
            => service<XedTables>(channel);
    }

    sealed class ServiceCache : AppServices<ServiceCache>
    {
        public SdeCpuid CpuId(IWfRuntime wf)
            => Service<SdeCpuid>(wf);

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

        public IntelSdm IntelSdm(IWfRuntime wf)
            => Service<IntelSdm>(wf);

        public XedFlows XedFlows(IWfRuntime wf)
            => Service<XedFlows>(wf);

        public XedRules XedRules(IWfRuntime wf)
            => Service<XedRules>(wf);

        public XedOps XedOps(IWfRuntime wf)
            => Service<XedOps>(wf);

        public XedDb XedDb(IWfRuntime wf)
            => Service<XedDb>(wf);

        public XedDisasm XedDisasm(IWfRuntime wf)
            => Service<XedDisasm>(wf);

        public XedDocs XedDocs(IWfRuntime wf)
            => Service<XedDocs>(wf);

        public XedPaths XedPaths(IWfRuntime wf)
            => Z0.XedPaths.Service;

        public XedDisasmAnalyzer DisasmAnalyzer(IWfRuntime wf)
            => Service<XedDisasmAnalyzer>(wf);

        public IntelSdmPaths SdmPaths(IWfRuntime wf)
            => Service<IntelSdmPaths>(wf);

        public XedToolCmd XedToolCmd(IWfRuntime wf)
            => Service<XedToolCmd>(wf);

        public Xed Xed(IWfRuntime wf)
            => Service<Xed>(wf);

        public XedRuntime XedRuntime(IWfRuntime wf)
            => Service<XedRuntime>(wf);
    }

    static ServiceCache Services => ServiceCache.Instance;

    static ChannelCache Channeled => ChannelCache.Instance;

    public static IntelIntrinsics IntelIntrinsics(this IWfRuntime wf)
        => Services.IntelInx(wf);

    public static IApiService IntelInxCmd(this IWfRuntime wf)
        => Services.IntelInxCmd(wf);

    public static SdeSvc SdeSvc(this IWfRuntime wf)
        => Services.SdeSvc(wf);

    public static XedChecks XedChecks(this IWfRuntime xed)
        => Services.XedChecks(xed);

    public static IntelSdm IntelSdm(this IWfRuntime wf)
        => Services.IntelSdm(wf);

    public static XedRuntime XedRuntime(this IWfRuntime wf)
        => Services.XedRuntime(wf);

    public static XedFlows XedFlows(this IWfRuntime wf)
        => Services.XedFlows(wf);

    public static XedRules XedRules(this IWfRuntime wf)
        => Services.XedRules(wf);

    public static XedOps XedOps(this IWfRuntime wf)
        => Services.XedOps(wf);

    public static XedDb XedDb(this IWfRuntime wf)
        => Services.XedDb(wf);

    public static XedDisasm XedDisasm(this IWfRuntime wf)
        => Services.XedDisasm(wf);

    public static XedDocs XedDocs(this IWfRuntime wf)
        => Services.XedDocs(wf);

    public static XedDisasmAnalyzer DisasmAnalyser(this IWfRuntime wf)
        => Services.DisasmAnalyzer(wf);

    public static XedPaths XedPaths(this IWfRuntime wf)
        => Services.XedPaths(wf);

    public static IntelSdmPaths SdmPaths(this IWfRuntime wf)
        => Services.SdmPaths(wf);

    public static Xed Xed(this IWfRuntime wf)
        => Services.Xed(wf);

    public static XedToolCmd XedToolCmd(this IWfRuntime wf)
        => Services.XedToolCmd(wf);

    public static IntelCmd IntelCmd(this IWfRuntime wf)
        => Services.IntelCmd(wf);

    public static XedTables XedViews(this IWfChannel channel)
        => Channeled.XedViews(channel);

    public static SdeCpuid CpuId(this IWfRuntime wf)
        => Services.CpuId(wf);
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
