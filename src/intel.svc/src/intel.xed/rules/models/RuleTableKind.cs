//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [DataWidth(num2.Width)]
    public enum RuleTableKind : byte
    {
        None =0,

        [Symbol("ENC")]
        ENC = 1,

        [Symbol("DEC")]
        DEC = 2,
    }
}
