//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using S = AsmOpCodes.Literals;

[SymSource("asm.opcodes"), DataWidth(4)]
public enum AsmOpCodeIndex : sbyte
{
    [Symbol(S.B0)]
    LegacyMap0,

    [Symbol(S.B1, "0x0F")]
    LegacyMap1,

    [Symbol(S.B2, "0x0F 0x38")]
    LegacyMap2,

    [Symbol(S.B3, "0x0F 0x3A")]
    LegacyMap3,

    [Symbol(S.D3, "0x0F 0x0F")]
    Amd3dNow,

    [Symbol(S.X8)]
    Xop8,

    [Symbol(S.X9)]
    Xop9,

    [Symbol(S.XA)]
    XopA,

    [Symbol(S.V1, "0x0F")]
    Vex0F,

    [Symbol(S.V2, "0x0F 0x38")]
    Vex0F38,

    [Symbol(S.V3, "0x0F 0x3A")]
    Vex0F3A,

    [Symbol(S.E1, "0x0F")]
    Evex0F,

    [Symbol(S.E2, "0x0F 0x38")]
    Evex0F38,

    [Symbol(S.E3, "0x0F 0x3A")]
    Evex0F3A,

    [Symbol(S.E5)]
    Evex5,

    [Symbol(S.E6)]
    Evex6
}
