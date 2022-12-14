//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasmSvc : WfSvc<XedDisasmSvc>
    {
        const string disasm = "xed.disasm";

        XedPaths XedPaths => Xed.Paths;

        XedRuntime Xed;

        public XedDisasmSvc With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }
    }
}