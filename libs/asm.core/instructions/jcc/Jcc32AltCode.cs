//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using E = ConditionCodes.FlagExpressions;

    using static JccAltNames;

    [SymSource("asm.cc")]
    public enum Jcc32AltCode : byte
    {
        [Symbol(jo, "Jump near if overflow", E.O)]
        JO = 0x80,

        [Symbol(jno, "Jump near if not overflow", E.NO)]
        JNO = 0x81,

        [Symbol(jnae, "Jump near if not above or equal", E.NAE)]
        JNAE = 0x82,

        [Symbol(jae, "Jump near if above or equal", E.AE)]
        JAE = 0x83,

        [Symbol(je, "Jump near if equal", E.E)]
        JE = 0x84,

        [Symbol(jne, "Jump near if not equal", E.NE)]
        JNE = 0x85,

        [Symbol(jbe, "Jump near if below or equal", E.BE)]
        JBE = 0x86,

        [Symbol(jnbe, "Jump near if not below or equal", E.NBE)]
        JNBE = 0x87,

        [Symbol(js, "Jump near if sign", E.S)]
        JS = 0x88,

        [Symbol(jns, "Jump near if not sign", E.NS)]
        JNS = 0x89,

        [Symbol(jp, "Jump near if parity", E.P)]
        JP = 0x8A,

        [Symbol(jnp, "Jump near if not parity", E.NP)]
        JNP = 0x8B,

        [Symbol(jnge, "Jump near if not greater or equal", E.NGE)]
        JNGE = 0x8C,

        [Symbol(jge, "Jump near if greater or equal", E.GE)]
        JGE = 0x8D,

        [Symbol(jle, "Jump near if less or equal", E.LE)]
        JLE = 0x8E,

        [Symbol(jg, "Jump near if greater", E.G)]
        JG = 0x8F
    }
}