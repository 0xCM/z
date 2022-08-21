//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.disasm
{
    using static ApiAtomic;

    [SymSource(llvm_mc)]
    public enum OperandType : byte
    {
        [Symbol("")]
        TYPE_NONE,

        [Symbol("rel")]
        TYPE_REL,

        [Symbol("r8", "1-byte register operand")]
        TYPE_R8,

        [Symbol("r16", "2-byte")]
        TYPE_R16,

        [Symbol("r32", "4-byte")]
        TYPE_R32,

        [Symbol("r64", "8-byte")]
        TYPE_R64,

        [Symbol("imm", "immediate operand")]
        TYPE_IMM,

        [Symbol("imm8u", "1-byte unsigned immediate operand")]
        TYPE_UIMM8,

        [Symbol("mem", "Memory operand")]
        TYPE_M,

        [Symbol("msib", "Memory operand force sib encoding")]
        TYPE_MSIB,

        [Symbol("mvsibx","Memory operand using XMM index")]
        TYPE_MVSIBX,

        [Symbol("", "Memory operand using YMM index")]
        TYPE_MVSIBY,

        [Symbol("mvsibz", "Memory operand using ZMM index")]
        TYPE_MVSIBZ,

        [Symbol("srcix", "memory at source index")]
        TYPE_SRCIDX,

        [Symbol("dstix", "memory at destination index")]
        TYPE_DSTIDX,

        [Symbol("moffs", "memory offset (relative to segment base)")]
        TYPE_MOFFS,

        [Symbol("st", "Position on the floating-point stack")]
        TYPE_ST,

        [Symbol("mmx", "8-byte MMX register")]
        TYPE_MM64,

        [Symbol("xmm", "16-byte")]
        TYPE_XMM,

        [Symbol("ymm", "32-byte")]
        TYPE_YMM,

        [Symbol("zmm", "64-byte")]
        TYPE_ZMM,

        [Symbol("k", "mask register")]
        TYPE_VK,

        [Symbol("k1/k2", "mask register pair")]
        TYPE_VK_PAIR,

        [Symbol("tile", "tile")]
        TYPE_TMM,

        [Symbol("sreg", "Segment register operand")]
        TYPE_SEGMENTREG,

        [Symbol("dr", "Debug register operand")]
        TYPE_DEBUGREG,

        [Symbol("cr", "Control register operand")]
        TYPE_CONTROLREG,

        [Symbol("bnd", "MPX bounds register")]
        TYPE_BNDR,

        [Symbol("Rv", "Register operand of operand size")]
        TYPE_Rv,

        [Symbol("", "Immediate address of operand size")]
        TYPE_RELv,

        [Symbol("", "Duplicate of operand 0")]
        TYPE_DUP0,

        [Symbol("", "operand 1")]
        TYPE_DUP1,

        [Symbol("", "operand 2")]
        TYPE_DUP2,

        [Symbol("", "operand 3")]
        TYPE_DUP3,

        [Symbol("", "operand 4")]
        TYPE_DUP4,
    }
}