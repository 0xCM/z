//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource("xed"),DataWidth(3)]
        public enum ModKind : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("<error>")]
            ANY,

            [Symbol("00")]
            MOD0,

            [Symbol("01")]
            MOD1,

            [Symbol("10")]
            MOD2,

            [Symbol("mm")]
            NE3,

            [Symbol("11")]
            MOD3,
        }
    }
}