//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = XedLiterals;

    partial class XedLiterals
    {

    }

    partial class XedLiterals
    {
        [SymSource("xed"), DataWidth(2)]
        public enum XedVexKind : byte
        {
            [Symbol("", "VEX_PREFIX=0")]
            VNP = 0,

            [Symbol(N.V66, "VEX_PREFIX=1")]
            V66 = 1,

            [Symbol(N.VF2, "VEX_PREFIX=2")]
            VF2 = 2,

            [Symbol(N.VF3, "VEX_PREFIX=3")]
            VF3 = 3
        }
    }
}