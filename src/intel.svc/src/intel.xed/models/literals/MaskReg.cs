//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedModels
{
    [SymSource(xed), DataWidth(num2.Width)]
    public enum MaskReg : byte
    {
        [Symbol("k0","MASK=0")]
        K0 = RegIndexCode.r0,

        [Symbol("k1","MASK=1")]
        K1 = RegIndexCode.r1,

        [Symbol("k2","MASK=2")]
        K2 = RegIndexCode.r2,

        [Symbol("k3","MASK=3")]
        K3 = RegIndexCode.r3,

        [Symbol("k4","MASK=4")]
        K4 = RegIndexCode.r4,

        [Symbol("k5","MASK=5")]
        K5 = RegIndexCode.r5,

        [Symbol("k6","MASK=6")]
        K6 = RegIndexCode.r6,

        [Symbol("k7","MASK=7")]
        K7 = RegIndexCode.r7,
    }
}
