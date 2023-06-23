//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm : WfSvc<XedDisasm>
    {
        XedRuntime XedRuntime => Wf.XedRuntime();        

        XedPaths XedPaths => XedRuntime.Paths;

        const string disasm = "xed.disasm";

    }
}