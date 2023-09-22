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
    public enum Jcc32Code : byte
    {
        [Symbol(jo, $"Jump near if overflow:{E.O}")]
        JO = 0x80,

        [Symbol(jno, $"Jump near if not overflow:{E.NO}")]
        JNO = 0x81,

        [Symbol(jb, $"Jump near if below:{E.B}")]
        JB = 0x82,

        [Symbol(jnb, $"Jump near if not below:{E.NB}")]
        JNB = 0x83,

        [Symbol(jz, $"Jump near if zero:{E.Z}")]
        JZ = 0x84,

        [Symbol(jnz, $"Jump near if not zero:{E.NZ}")]
        JNZ = 0x85,

        [Symbol(jna, $"Jump near if not above:{E.NA}")]
        JNA = 0x86,

        [Symbol(ja, $"Jump near if above:{E.A}")]
        JA = 0x87,

        [Symbol(js, $"Jump near if sign:{E.S}")]
        JS = 0x88,

        [Symbol(jns, $"Jump near if not sign:{E.NS}")]
        JNS = 0x89,

        [Symbol(jpe, $"Jump near if parity even:{E.PE}")]
        JPE = 0x8A,

        [Symbol(jpo, $"Jump near if parity odd:{E.PO}")]
        JPO = 0x8B,

        [Symbol(jl, $"Jump near if less:{E.L}")]
        JL = 0x8C,

        [Symbol(jnl, $"Jump near if not less:{E.NL}")]
        JNL = 0x8D,

        [Symbol(jng, $"Jump near if not greater:{E.NG}")]
        JNG = 0x8E,

        [Symbol(jnle, $"Jump near if not less or equal:{E.NLE}")]
        JNLE = 0x8F,
    }
}