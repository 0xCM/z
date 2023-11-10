//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [DataWidth(num2.Width)]
    public enum LogicKind : byte
    {
        None = 0,

        Antecedant = 1,

        Operator = 2,

        Consequent = 3,
    }
}
