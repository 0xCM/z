//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using E = ConditionTokens.Expressions;

using static ConditionTokens.AltNames;

partial class ConditionTokens
{
    [SymSource("asm.cc")]
    public enum Jcc8AltCode : byte
    {
        [Symbol(jo, "Jump short if overflow", E.O)]
        JO = 0x70,

        [Symbol(jno, "Jump short if not overflow", E.NO)]
        JNO = 0x71,

        [Symbol(jnae, "Jump short if not above or equal", E.NAE)]
        JNAE = 0x72,

        [Symbol(jae, "Jump short if above or equal", E.AE)]
        JAE = 0x73,

        [Symbol(je, "Jump short if equal", E.E)]
        JE = 0x74,

        [Symbol(jne, "Jump short if not equal", E.NE)]
        JNE = 0x75,

        [Symbol(jbe, "Jump short if below or equal", E.BE)]
        JBE = 0x76,

        [Symbol(jnbe, "Jump short if not below or equal", E.NBE)]
        JNBE = 0x77,

        [Symbol(js, "Jump short if sign", E.S)]
        JS = 0x78,

        [Symbol(jns, "Jump short if not sign", E.NS)]
        JNS = 0x79,

        [Symbol(jp, "Jump short if parity", E.P)]
        JP = 0x7A,

        [Symbol(jnp, "Jump short if not parity", E.NP)]
        JNP = 0x7B,

        [Symbol(jnge, "Jump short if not greater or equal", E.NGE)]
        JNGE = 0x7C,

        [Symbol(jge, "Jump short if greater or equal", E.GE)]
        JGE = 0x7D,

        [Symbol(jle, "Jump short if less or equal", E.LE)]
        JLE = 0x7E,

        [Symbol(jg, "Jump short if greater", E.G)]
        JG = 0x7F
    }
}