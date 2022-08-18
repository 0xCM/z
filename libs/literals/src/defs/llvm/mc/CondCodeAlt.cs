//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.mc
{
    using static CondCode;
    using static ApiAtomic;

    [SymSource(llvm_mc)]
    public enum CondCodeAlt : byte
    {
        COND_C = COND_B,

        COND_NC = COND_AE,

        COND_Z = COND_E,

        COND_NZ = COND_NE,

        COND_NA = COND_BE,

        COND_NBE = COND_A,

        COND_PE = COND_P,

        COND_PO = COND_NP,

        COND_NGE = COND_L,

        COND_NL = COND_GE,

        COND_NG = COND_LE,

        COND_NLE = COND_G,
    }
}