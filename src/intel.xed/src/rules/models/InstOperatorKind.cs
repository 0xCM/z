//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using O = XedRules.InstOperator;

partial class XedRules
{
    [SymSource(xed), DataWidth(O.Width)]
    public enum InstOperatorKind : byte
    {
        [Symbol("")]
        None,

        [Symbol(O.EqSym)]
        Eq,

        [Symbol(O.NeSym)]
        Ne,
    }
}
