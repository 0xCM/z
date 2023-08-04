//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using S = AsmOpCodeMaps.Literals;

[SymSource("asm.opcodes"), DataWidth(4)]
public enum AsmOpCodeIndex : sbyte
{
    [Symbol(S.B0)]
    LegacyMap0 = 0,

    [Symbol(S.B1, "0x0F")]
    LegacyMap1 = 1,

    [Symbol(S.B2, "0x0F 0x38")]
    LegacyMap2 = 2,

    [Symbol(S.B3, "0x0F 0x3A")]
    LegacyMap3 = 3,

    [Symbol(S.D3, "0x0F 0x0F")]
    Amd3dNow = 4,

    [Symbol(S.X8)]
    Xop8 = 5,

    [Symbol(S.X9)]
    Xop9 = 6,

    [Symbol(S.XA)]
    XopA = 7,

    [Symbol(S.V1, "0x0F")]
    Vex0F = 8,

    [Symbol(S.V2, "0x0F 0x38")]
    Vex0F38 = 9,

    [Symbol(S.V3, "0x0F 0x3A")]
    Vex0F3A = 10,

    [Symbol(S.E1, "0x0F")]
    Evex0F = 11,

    [Symbol(S.E2, "0x0F 0x38")]
    Evex0F38 = 12,

    [Symbol(S.E3, "0x0F 0x3A")]
    Evex0F3A = 13,
}
