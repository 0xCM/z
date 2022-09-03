//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [SymSource(xed), DataWidth(num3.Width)]
        public enum OpModKind : byte
        {
            [Symbol("")]
            None,

            ZEROSTR,

            ROUNDC,

            SAE,

            BCASTSTR,
        }
    }
}