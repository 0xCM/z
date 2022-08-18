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
        public enum FpuRegId : byte
        {
            [Symbol("ST(0)")]
            ST0 = (byte)XedRegId.ST0,

            [Symbol("ST(1)")]
            ST1 = (byte)XedRegId.ST1,

            [Symbol("ST(2)")]
            ST2 = (byte)XedRegId.ST2,

            [Symbol("ST(3)")]
            ST3 = (byte)XedRegId.ST3,

            [Symbol("ST(4)")]
            ST4 = (byte)XedRegId.ST4,

            [Symbol("ST(5)")]
            ST5 = (byte)XedRegId.ST5,

            [Symbol("ST(6)")]
            ST6 = (byte)XedRegId.ST6,

            [Symbol("ST(7)")]
            ST7 = (byte)XedRegId.ST7,
        }
    }
}