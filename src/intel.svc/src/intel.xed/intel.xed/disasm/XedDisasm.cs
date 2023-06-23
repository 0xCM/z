//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm : WfSvc<XedDisasm>
    {
        XedRuntime Xed => Wf.XedRuntime();        

        XedPaths XedPaths => Xed.Paths;

        const string disasm = "xed.disasm";

    }
}