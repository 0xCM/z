//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using S = AsmOpCodes.Literals;

[SymSource("asm.opcodes"), DataWidth(3)]
public enum EvexMapKind : byte
{
    [Symbol(S.E1, "MAP=1")]
    EVEX_MAP_0F=1,

    [Symbol(S.E2, "MAP=2")]
    EVEX_MAP_0F38=2,

    [Symbol(S.E3, "MAP=3")]
    EVEX_MAP_0F3A=3,

    [Symbol(S.E5)]
    EVEX_MAP_5 = 5,

    [Symbol(S.E6)]
    EVEX_MAP_6 = 6,
}
