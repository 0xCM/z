//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed), DataWidth(2)]
        public enum ASZ : byte
        {
            [Symbol("0")]
            None = 0,

            [Symbol("a16")]
            a16 = 1,

            [Symbol("a32")]
            a32 = 2,

            [Symbol("a64")]
            a64 = 3,
        }
    }
}