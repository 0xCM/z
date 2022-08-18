//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(num5.Width)]
        public enum ErrorKind : byte
        {
            NONE,

            [Symbol("BUFFER_TOO_SHORT", "There were not enough bytes in the given buffer")]
            BUFFER_TOO_SHORT,

            [Symbol("GENERAL_ERROR", "XED could not decode the given instruction")]
            GENERAL_ERROR,

            [Symbol("INVALID_FOR_CHIP", "The instruciton is not valid for the specified chip")]
            INVALID_FOR_CHIP,

            [Symbol("BAD_REGISTER", "XED could not decode the given instruction because an invalid register encoding was used")]
            BAD_REGISTER,

            [Symbol("BAD_LOCK_PREFIX", "A lock prefix was found where none is allowed")]
            BAD_LOCK_PREFIX,

            [Symbol("BAD_REP_PREFIX", "An F2 or F3 prefix was found where none is allowed")]
            BAD_REP_PREFIX,

            [Symbol("BAD_LEGACY_PREFIX", "A 66, F2 or F3 prefix was found where none is allowed")]
            BAD_LEGACY_PREFIX,

            [Symbol("BAD_REX_PREFIX", "A REX prefix was found where none is allowed")]
            BAD_REX_PREFIX,

            [Symbol("BAD_EVEX_UBIT", "An illegal value for the EVEX.U bit was present in the instruction")]
            BAD_EVEX_UBIT,

            [Symbol("BAD_MAP", "An illegal value for the MAP field was detected in the instruction")]
            BAD_MAP,

            [Symbol("BAD_EVEX_V_PRIME","EVEX.V'=0 was detected in a non-64b mode instruction.")]
            BAD_EVEX_V_PRIME,

            [Symbol("BAD_EVEX_Z_NO_MASKING","EVEX.Z!=0 when EVEX.aaa==0")]
            BAD_EVEX_Z_NO_MASKING,

            [Symbol("NO_OUTPUT_POINTER","The output pointer for xed_agen was zero")]
            NO_OUTPUT_POINTER,

            [Symbol("NO_AGEN_CALL_BACK_REGISTERED","One or both of the callbacks for xed_agen were missing")]
            NO_AGEN_CALL_BACK_REGISTERED,

            [Symbol("BAD_MEMOP_INDEX", "Memop indices must be 0 or 1")]
            BAD_MEMOP_INDEX,

            [Symbol("CALLBACK_PROBLEM", "The register or segment callback for xed_agen experienced a problem")]
            CALLBACK_PROBLEM,

            [Symbol("GATHER_REGS", "The index, dest and mask regs for AVX2 gathers must be different")]
            GATHER_REGS,

            [Symbol("INSTR_TOO_LONG", "Full decode of instruction would exeed 15B")]
            INSTR_TOO_LONG,

            [Symbol("INVALID_MODE", "The instruction was not valid for the specified mode")]
            INVALID_MODE,

            [Symbol("BAD_EVEX_LL","EVEX.LL must not ==3 unless using embedded rounding")]
            BAD_EVEX_LL,

            BAD_REG_MATCH, // Source registers must not match the destination register for this instruction.
        }
    }
}