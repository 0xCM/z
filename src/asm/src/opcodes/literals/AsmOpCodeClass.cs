//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using N = AsmOpCodes.Literals;

[SymSource("asm.opcodes"), DataWidth(5)]
public enum AsmOpCodeClass : byte
{
    [Symbol(N.BaseClassName)]
    Legacy = 1,

    [Symbol(N.XopClassName)]
    Xop = 2,

    [Symbol(N.VexClassName)]
    Vex = 4,

    [Symbol(N.EvexClassName)]
    Evex = 8,
}