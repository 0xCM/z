//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using E = ConditionTokens.Expressions;

using static ConditionTokens.Names;

public enum Jcc8Code : byte
{
    [Symbol(jo, "Jump short if overflow", E.O)]
    JO = 0x70,

    [Symbol(jno, "Jump short if not overflow", E.NO)]
    JNO = 0x71,

    [Symbol(jb, "Jump short if below", E.B)]
    JB = 0x72,

    [Symbol(jnae, "Jump short if not above or equal", E.NAE)]
    JNAE = 0x72,

    [Symbol(jnb, "Jump short if not below", E.NB)]
    JNB = 0x73,

    [Symbol(jae, "Jump short if above or equal", E.AE)]
    JAE = 0x73,

    [Symbol(jz, "Jump short if zero", E.Z)]
    JZ = 0x74,

    [Symbol(je, "Jump short if equal", E.E)]
    JE = 0x74,

    [Symbol(jnz, "Jump short if not zero", E.NZ)]
    JNZ = 0x75,

    [Symbol(jne, "Jump short if not equal", E.NE)]
    JNE = 0x75,

    [Symbol(jna, "Jump short if not above", E.NA)]
    JNA = 0x76,

    [Symbol(jbe, "Jump short if below or equal", E.BE)]
    JBE = 0x76,

    [Symbol(ja, "Jump short if above", E.A)]
    JA = 0x77,

    [Symbol(jnbe, "Jump short if not below or equal", E.NBE)]
    JNBE = 0x77,

    [Symbol(js, "Jump short if sign", E.S)]
    JS = 0x78,

    [Symbol(jns, "Jump short if not sign", E.NS)]
    JNS = 0x79,

    [Symbol(jpe, "Jump short if parity even", E.PE)]
    JPE = 0x7A,

    [Symbol(jp, "Jump short if parity", E.P)]
    JP = 0x7A,

    [Symbol(jpo, "Jump short if parity odd", E.PO)]
    JPO = 0x7B,

    [Symbol(jnp, "Jump short if not parity", E.NP)]
    JNP = 0x7B,

    [Symbol(jl, "Jump short if less", E.L)]
    JL = 0x7C,

    [Symbol(jnge, "Jump short if not greater or equal", E.NGE)]
    JNGE = 0x7C,

    [Symbol(jnl, "Jump short if not less", E.NL)]
    JNL = 0x7D,

    [Symbol(jge, "Jump short if greater or equal", E.GE)]
    JGE = 0x7D,

    [Symbol(jng, "Jump short if not greater", E.NG)]
    JNG = 0x7E,

    [Symbol(jle, "Jump short if less or equal", E.LE)]
    JLE = 0x7E,

    [Symbol(jnle, "Jump short if not less or equal", E.NLE)]
    JNLE = 0x7F,

    [Symbol(jg, "Jump short if greater", E.G)]
    JG = 0x7F
}
