//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using E = ConditionTokens.Expressions;

using static ConditionTokens.Names;
partial class ConditionTokens
{
    [SymSource("asm.cc")]
    public enum Jcc8Code : byte
    {
        [Symbol(jo, "Jump short if overflow", E.O)]
        JO = 0x70,

        [Symbol(jno, "Jump short if not overflow", E.NO)]
        JNO = 0x71,

        [Symbol(jb, "Jump short if below", E.B)]
        JB = 0x72,

        [Symbol(jnb, "Jump short if not below", E.NB)]
        JNB = 0x73,

        [Symbol(jz, "Jump short if zero", E.Z)]
        JZ = 0x74,

        [Symbol(jnz, "Jump short if not zero", E.NZ)]
        JNZ = 0x75,

        [Symbol(jna, "Jump short if not above", E.NA)]
        JNA = 0x76,

        [Symbol(ja, "Jump short if above", E.A)]
        JA = 0x77,

        [Symbol(js, "Jump short if sign", E.S)]
        JS = 0x78,

        [Symbol(jns, "Jump short if not sign", E.NS)]
        JNS = 0x79,

        [Symbol(jpe, "Jump short if parity even", E.PE)]
        JPE = 0x7A,

        [Symbol(jpo, "Jump short if parity odd", E.PO)]
        JPO = 0x7B,

        [Symbol(jl, "Jump short if less", E.L)]
        JL = 0x7C,

        [Symbol(jnl, "Jump short if not less", E.NL)]
        JNL = 0x7D,

        [Symbol(jng, "Jump short if not greater", E.NG)]
        JNG = 0x7E,

        [Symbol(jnle, "Jump short if not less or equal", E.NLE)]
        JNLE = 0x7F,
    }
}