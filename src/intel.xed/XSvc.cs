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
        public XedDisasm XedDisasm(IWfRuntime wf)
            => Service<XedDisasm>(wf);

        public XedDisasmAnalyzer DisasmAnalyzer(IWfRuntime wf)
            => Service<XedDisasmAnalyzer>(wf);

        public XedImport XedImport(IWfRuntime wf)
            => Service<XedImport>(wf);

    }

    public static XedDisasm XedDisasm(this IWfRuntime wf)
        => Services.XedDisasm(wf);

    public static XedDisasmAnalyzer DisasmAnalyser(this IWfRuntime wf)
        => Services.DisasmAnalyzer(wf);


    public static XedImport XedImport(this IWfRuntime wf)
        => Services.XedImport(wf);
        
    static ServiceCache Services => ServiceCache.Instance;

}


partial struct Msg
{
    public static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

    public static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

    public static MsgPattern<string,string> ParseFailure => "Parsing {0} from '{1}' failed";


}