//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[DataWidth(num3.Width)]
public enum AsmVL : byte
{
    [Symbol("128", "Specifies a vector length of 128")]
    VL128 = 0,

    [Symbol("256", "Specifies a vector length of 256")]
    VL256 = 1,

    [Symbol("512", "Specifies a vector length of 512")]
    VL512 = 2,

    [Symbol("LLIG", "Indicates that the EVEX.W bit ignored")]
    LLIG = 3,

    Invalid = 0xFF,
}
