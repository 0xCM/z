//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.disasm
{
    using static ApiAtomic;

    [SymSource(llvm_mc)]
    public enum EncodingType : byte
    {
        [Symbol("")]
        ENCODING_NONE,

        [Symbol("reg","Register operand in ModR/M byte")]
        ENCODING_REG,

        [Symbol("rm","R/M operand in ModR/M byte.")]
        ENCODING_RM,

        [Symbol("rm/cd2","R/M operand with CDisp scaling of 2")]
        ENCODING_RM_CD2,

        [Symbol("rm/cd4","R/M operand with CDisp scaling of 4")]
        ENCODING_RM_CD4,

        [Symbol("rm/cd8","R/M operand with CDisp scaling of 8")]
        ENCODING_RM_CD8,

        [Symbol("rm/cd16","R/M operand with CDisp scaling of 16")]
        ENCODING_RM_CD16,

        [Symbol("rm/cd32","R/M operand with CDisp scaling of 32")]
        ENCODING_RM_CD32,

        [Symbol("rm/cd64","R/M operand with CDisp scaling of 64")]
        ENCODING_RM_CD64,

        [Symbol("sib","Force SIB operand in ModR/M byte.")]
        ENCODING_SIB,

        [Symbol("vsib","VSIB operand in ModR/M byte.")]
        ENCODING_VSIB,

        [Symbol("vsib/cd2","VSIB operand with CDisp scaling of 2")]
        ENCODING_VSIB_CD2,

        [Symbol("vsib/cd4","VSIB operand with CDisp scaling of 4")]
        ENCODING_VSIB_CD4,

        [Symbol("vsib/cd8","VSIB operand with CDisp scaling of 8")]
        ENCODING_VSIB_CD8,

        [Symbol("vsib/cd16","VSIB operand with CDisp scaling of 16")]
        ENCODING_VSIB_CD16,

        [Symbol("vsib/cd32","VSIB operand with CDisp scaling of 32")]
        ENCODING_VSIB_CD32,

        [Symbol("vsib/cd64","VSIB operand with CDisp scaling of 64")]
        ENCODING_VSIB_CD64,

        [Symbol("vvvv","Register operand in VEX.vvvv byte")]
        ENCODING_VVVV,

        [Symbol("{k}","Register operand in EVEX.aaa byte.")]
        ENCODING_WRITEMASK,

        [Symbol("ib","1-byte immediate")]
        ENCODING_IB,

        [Symbol("iw","2-byte")]
        ENCODING_IW,

        [Symbol("id","4-byte")]
        ENCODING_ID,

        [Symbol("io","8-byte")]
        ENCODING_IO,

        [Symbol("rb","(AL..DIL, R8B..R15B) Register code added to the opcode byte")]
        ENCODING_RB,

        [Symbol("rw","(AX..DI, R8W..R15W)")]
        ENCODING_RW,

        [Symbol("rd","(EAX..EDI, R8D..R15D)")]
        ENCODING_RD,

        [Symbol("ro","(RAX..RDI, R8..R15)")]
        ENCODING_RO,

        [Symbol("fp","Position on floating-point stack in ModR/M byte")]
        ENCODING_FP,

        [Symbol("Iv","Immediate of operand size")]
        ENCODING_Iv,

        [Symbol("Ia","Immediate of address size")]
        ENCODING_Ia,

        [Symbol("IRC","Immediate for static rounding control")]
        ENCODING_IRC,

        [Symbol("Rv","Register code of operand size added to the opcode byte")]
        ENCODING_Rv,

        [Symbol("cc","Condition code encoded in opcode")]
        ENCODING_CC,

        [Symbol("dupe", "Duplicate of another operand; ID is encoded in type ")]
        ENCODING_DUP,

        [Symbol("srcix", "Source index; encoded in OpSize/Adsize prefix")]
        ENCODING_SI,

        [Symbol("dstix", "Destination index; encoded in prefixes")]
        ENCODING_DI,
    }
}