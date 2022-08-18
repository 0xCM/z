//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [SymSource("asm.regs.flags")]
    public enum RFlagKind : byte
    {
        None = 0,

        [Symbol("cf", "Carry Flag; Enabled if an arithmetic operation generates a carry or a borrow out of the most-significant bit of the result; cleared otherwise. This flag indicates an overflow condition for unsigned-integer arithmetic. It is also used in multiple-precision arithmetic")]
        CF=1,

        [Symbol("pf", "Parity Flag; Enabled if the least-significant byte of the result contains an even number of 1 bits; cleared otherwise")]
        PF=2,

        [Symbol("af", "Auxillary Carry Flag; Enabled if an arithmetic operation generates a carry or a borrow out of bit 3 of the result; cleared otherwise.")]
        AF=3,

        [Symbol("zf", "Zero Flag; Enabled if the result is zero; cleared otherwise")]
        ZF=4,

        [Symbol("sf", "Sign Flag; Set equal to the most-significant bit of the result, which is the sign bit of a signed integer. (0 indicates a positive value and 1 indicates a negative value.)")]
        SF,

        [Symbol("tf", "Trap Flag; Enabled to enable single-step mode for debugging; cleared to disable single-step mode.")]
        TF,

        [Symbol("if", "Interupt Flag")]
        IF,

        [Symbol("df", "Direction Flag")]
        DF,

        [Symbol("of", "Overflow Flag; Enabled if the integer result is too large a positive number or too small a negative number (excluding the sign-bit) to fit in the destination operand; cleared otherwise. This flag indicates an overflow condition for signed-integer (two’s complement) arithmetic.")]
        OF,

        [Symbol("rf", "Resume Flag")]
        RF,

        [Symbol("vm", "Virtual 8086 Mode")]
        VM,

        [Symbol("ac", "Alignment Check")]
        AC,

        [Symbol("vif", "Virtual Interrupt Flag")]
        VIF,

        [Symbol("vip", "Virtual Interrupt Pending")]
        VIP,

        [Symbol("id", "Enabled to indicate CPUID-capability")]
        ID
    }
}