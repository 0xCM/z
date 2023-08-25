//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Defines the bitfield index of the flags defined by <see cref='RFlagBits'/>
/// </summary>
public enum RFlagIndex : byte
{
    [Symbol("cf", "Carry Flag; Enabled if an arithmetic operation generates a carry or a borrow out of the most-significant bit of the result; cleared otherwise. This flag indicates an overflow condition for unsigned-integer arithmetic. It is also used in multiple-precision arithmetic")]
    CF = 0,

    [Symbol("pf", "Parity Flag; Enabled if the least-significant byte of the result contains an even number of 1 bits; cleared otherwise")]
    PF = 2,

    [Symbol("af", "Auxillary Carry Flag; Enabled if an arithmetic operation generates a carry or a borrow out of bit 3 of the result; cleared otherwise.")]
    AF = 4,

    [Symbol("zf", "Zero Flag; Enabled if the result is zero; cleared otherwise")]
    ZF = 6,

    [Symbol("sf", "Sign Flag; Set equal to the most-significant bit of the result, which is the sign bit of a signed integer. (0 indicates a positive value and 1 indicates a negative value.)")]
    SF = 7,

    [Symbol("tf", "Trap Flag; Enabled to enable single-step mode for debugging; cleared to disable single-step mode.")]
    TF = 8,

    [Symbol("if", "Interupt Flag")]
    IF = 9,

    [Symbol("df", "Direction Flag")]
    DF = 10,

    [Symbol("of", "Overflow Flag; Enabled if the integer result is too large a positive number or too small a negative number (excluding the sign-bit) to fit in the destination operand; cleared otherwise. This flag indicates an overflow condition for signed-integer (two’s complement) arithmetic.")]
    OF = 11,

    [Symbol("rf", "Resume Flag")]
    RF = 16,

    [Symbol("vm", "Virtual 8086 Mode")]
    VM = 17,

    [Symbol("ac", "Alignment Check")]
    AC = 18,

    [Symbol("vif", "Virtual Interrupt Flag")]
    VIF = 19,

    [Symbol("vip", "Virtual Interrupt Pending")]
    VIP = 20,

    [Symbol("id", "Enabled to indicate CPUID-capability")]
    ID = 21,
}
