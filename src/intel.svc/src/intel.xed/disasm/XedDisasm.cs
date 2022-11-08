//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm : WfSvc<XedDisasm>
    {
        const string disasm = "xed.disasm";

        XedRuntime Xed;

        public XedDisasm With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }
    }
}