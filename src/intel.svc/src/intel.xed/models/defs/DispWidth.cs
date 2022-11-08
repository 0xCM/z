//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum DispWidth : byte
        {
            [Symbol("0")]
            None = 0,

            [Symbol("8")]
            DW8 = 8,

            [Symbol("16")]
            DW16 = 16,

            [Symbol("32")]
            DW32 = 32,

            [Symbol("64")]
            DW64 = 64,
        }
    }
}