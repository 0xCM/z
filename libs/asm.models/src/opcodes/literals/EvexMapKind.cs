//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = AsmOpCodeMaps.Literals;

    partial class XedLiterals
    {

    }

    [SymSource("asm.opcodes"), DataWidth(2)]
    public enum EvexMapKind : byte
    {
        [Symbol(N.E1, "MAP=1")]
        EVEX_MAP_0F=1,

        [Symbol(N.E2, "MAP=2")]
        EVEX_MAP_0F38=2,

        [Symbol(N.E3, "MAP=3")]
        EVEX_MAP_0F3A=3,
    }
}