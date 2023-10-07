//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static NumericBaseKind;

/// <summary>
/// Defines register codes 0 .. 31
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum RegIndexCode : byte
{
    [Symbol("r0")]
    r0 = 0b00000,

    [Symbol("r1")]
    r1 = 0b00001,

    [Symbol("r2")]
    r2 = 0b00010,

    [Symbol("r3")]
    r3 = 0b00011,

    [Symbol("r4")]
    r4 = 0b00100,

    [Symbol("r5")]
    r5 = 0b00101,

    [Symbol("r6")]
    r6 = 0b00110,

    [Symbol("r7")]
    r7 = 0b00111,

    [Symbol("r8")]
    r8 = 0b01000,

    [Symbol("r9")]
    r9 = 0b01001,

    [Symbol("r10")]
    r10 = 0b01010,

    [Symbol("r11")]
    r11 = 0b01011,

    [Symbol("r12")]
    r12 = 0b01100,

    [Symbol("r13")]
    r13 = 0b01101,

    [Symbol("r14")]
    r14 = 0b01110,

    [Symbol("r15")]
    r15 = 0b01111,

    [Symbol("r16")]
    r16 = 0b10000,

    [Symbol("r17")]
    r17 = 0b10001,

    [Symbol("r18")]
    r18 = 0b10010,

    [Symbol("r19")]
    r19 = 0b10011,

    [Symbol("r20")]
    r20 = 0b10100,

    [Symbol("r21")]
    r21 = 0b10101,

    [Symbol("r22")]
    r22 = 0b10110,

    [Symbol("r23")]
    r23 = 0b10111,

    [Symbol("r24")]
    r24 = 0b11000,

    [Symbol("r25")]
    r25 = 0b11001,

    [Symbol("r26")]
    r26 = 0b11010,

    [Symbol("r27")]
    r27 = 0b11011,

    [Symbol("r28")]
    r28 = 0b11100,

    [Symbol("r29")]
    r29 = 0b11101,

    [Symbol("r30")]
    r30 = 0b11110,

    [Symbol("r31")]
    r31 = 0b11111,
}
