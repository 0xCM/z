//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.disasm
{
    using static ApiAtomic;

    [SymSource(llvm_mc)]
    public enum DisassemblerMode  : byte
    {
        [Symbol("16","real mode")]
        MODE_16BIT,

        [Symbol("32","IA-32e")]
        MODE_32BIT,

        [Symbol("64","IA-32e in 64-bit mode")]
        MODE_64BIT
    };
}