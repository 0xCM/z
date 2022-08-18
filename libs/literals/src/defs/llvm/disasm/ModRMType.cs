//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.disasm
{
    using static ApiAtomic;

    [SymSource(llvm_mc)]
    public enum ModRMType : byte
    {
        [Symbol("","No matter what the value of the ModR/M byte is, the decoded instruction is the same.")]
        MODRM_ONEENTRY,

        [Symbol("","If the ModR/M byte is between 0x00 and 0xbf, the opcode corresponds to one instruction; otherwise, it corresponds to  a different instruction.")]
        MODRM_SPLITRM,

        [Symbol("","If the ModR/M byte is between 0x00 and 0xbf, ModR/M byte divided by 8 is used to select instruction; otherwise, each value of the ModR/M byte could correspond to a different instruction.")]
        MODRM_SPLITMISC,

        [Symbol("","ModR/M byte divided by 8 is used to select instruction. This corresponds to instructions that use reg field as opcode")]
        MODRM_SPLITREG,

        [Symbol("","Potentially, each value of the ModR/M byte could correspond to a different instruction.")]
        MODRM_FULL
    }
}