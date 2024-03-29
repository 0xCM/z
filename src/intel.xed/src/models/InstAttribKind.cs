//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(8)]
    public enum InstAttribKind : byte
    {
        INVALID,

        AMDONLY,

        ATT_OPERAND_ORDER_EXCEPTION,

        BROADCAST_ENABLED,

        BYTEOP,

        DISP8_EIGHTHMEM,

        DISP8_FULL,

        DISP8_FULLMEM,

        DISP8_GPR_READER,

        DISP8_GPR_READER_BYTE,

        DISP8_GPR_READER_WORD,

        DISP8_GPR_WRITER_LDOP_D,

        DISP8_GPR_WRITER_LDOP_Q,

        DISP8_GPR_WRITER_STORE,

        DISP8_GPR_WRITER_STORE_BYTE,

        DISP8_GPR_WRITER_STORE_WORD,

        DISP8_GSCAT,

        DISP8_HALF,

        DISP8_HALFMEM,

        DISP8_MEM128,

        DISP8_MOVDDUP,

        DISP8_QUARTERMEM,

        DISP8_SCALAR,

        DISP8_TUPLE1,

        DISP8_TUPLE1_4X,

        DISP8_TUPLE1_BYTE,

        DISP8_TUPLE1_WORD,

        DISP8_TUPLE2,

        DISP8_TUPLE4,

        DISP8_TUPLE8,

        DOUBLE_WIDE_MEMOP,

        DOUBLE_WIDE_OUTPUT,

        DWORD_INDICES,

        ELEMENT_SIZE_D,

        ELEMENT_SIZE_Q,

        EXCEPTION_BR,

        FAR_XFER,

        FIXED_BASE0,

        FIXED_BASE1,

        GATHER,

        HALF_WIDE_OUTPUT,

        HLE_ACQ_ABLE,

        HLE_REL_ABLE,

        IGNORES_OSFXSR,

        IMPLICIT_ONE,

        INDEX_REG_IS_POINTER,

        INDIRECT_BRANCH,

        KMASK,

        LOCKABLE,

        LOCKED,

        MASKOP,

        MASKOP_EVEX,

        MASK_AS_CONTROL,

        MASK_VARIABLE_MEMOP,

        MEMORY_FAULT_SUPPRESSION,

        MMX_EXCEPT,

        MPX_PREFIX_ABLE,

        MULTIDEST2,

        MULTISOURCE4,

        MXCSR,

        MXCSR_RD,

        NONTEMPORAL,

        NOP,

        NOTSX,

        NOTSX_COND,

        NO_RIP_REL,

        PREFETCH,

        PROTECTED_MODE,

        QWORD_INDICES,

        REP,

        REQUIRES_ALIGNMENT,

        RING0,

        SCALABLE,

        SCATTER,

        SIMD_SCALAR,

        SKIPLOW32,

        SKIPLOW64,

        SPECIAL_AGEN_REQUIRED,

        STACKPOP0,

        STACKPOP1,

        STACKPUSH0,

        STACKPUSH1,

        X87_CONTROL,

        X87_MMX_STATE_CW,

        X87_MMX_STATE_R,

        X87_MMX_STATE_W,

        X87_NOWAIT,

        XMM_STATE_CW,

        XMM_STATE_R,

        XMM_STATE_W,
    }
}
