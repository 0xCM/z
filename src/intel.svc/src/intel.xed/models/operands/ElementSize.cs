//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed), DataWidth(3)]
        public enum ElementSize : byte
        {
            [Symbol("0")]
            None = 0,

            [Symbol("8")]
            W8 = 1,

            [Symbol("16")]
            W16 = 2,

            [Symbol("32")]
            W32 = 3,

            [Symbol("64")]
            W64 = 4,
        }
    }
}