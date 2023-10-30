//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static Pow2x8;

[SymSource]
public enum ImmKind : byte
{
    None = 0,

    [Symbol("imm8")]
    Imm8u = 8,

    [Symbol("imm8i")]
    Imm8i = 8 | P2ᐞ07,

    [Symbol("imm16")]
    Imm16u = 16,

    [Symbol("imm16i")]
    Imm16i = 16 | P2ᐞ07,

    [Symbol("imm32")]
    Imm32u = 32,

    [Symbol("imm32i")]
    Imm32i = 32 | P2ᐞ07,

    [Symbol("imm64")]
    Imm64u = 64,

    [Symbol("imm64i")]
    Imm64i = 64 | P2ᐞ07
}
