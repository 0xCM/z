//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public Index<XedDisasmDoc> CalcDocs(ProjectContext context)
            => Data(nameof(CalcDocs), () => XedDisasm.docs(context));
    }
}