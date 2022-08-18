//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x8;

    [Flags,SymSource("asm")]
    public enum AsmOpClass : byte
    {
        None = 0,

        [Symbol("reg", "Classifies a register operand")]
        Reg = P2ᐞ00,

        [Symbol("mem", "Classifies a memory operand")]
        Mem = P2ᐞ01,

        [Symbol("imm", "Classifies an immediate operand")]
        Imm = P2ᐞ02,

        [Symbol("mask", "Classifies a regmask operand")]
        RegMask = P2ᐞ03,

        [Symbol("disp", "Classifies a displacement operand")]
        Disp = P2ᐞ04,

        [Symbol("rel", "Classifies an IP-relative operand")]
        Rel = P2ᐞ05,
    }
}