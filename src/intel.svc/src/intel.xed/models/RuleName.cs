//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public enum RuleName : ushort
    {
        None,

        A_GPR_B,

        A_GPR_R,

        Ar10,

        Ar11,

        Ar12,

        Ar13,

        Ar14,

        Ar15,

        Ar8,

        Ar9,

        ArAX,

        ArBP,

        ArBX,

        ArCX,

        ArDI,

        ArDX,

        ArSI,

        ArSP,

        ASZ_NONTERM,

        ASZ_NONTERM_BIND,

        AVX_INSTRUCTIONS,

        AVX_SPLITTER,

        AVX512_EVEX_BYTE3_ENC,

        AVX512_EVEX_BYTE3_ENC_BIND,

        AVX512_ROUND,

        BND_B,

        BND_B_CHECK,

        BND_R,

        BND_R_CHECK,

        BRANCH_HINT,

        BRDISP32,

        BRDISP8,

        BRDISPz,

        CET_NO_TRACK,

        CR_B,

        CR_R,

        CR_WIDTH,

        DF64,

        DISP_NT,

        DISP_NT_EMIT,

        UISA_ENC_INDEX_YMM_BIND,

        DISP_WIDTH_0,

        DISP_WIDTH_0_8_16,

        DISP_WIDTH_0_8_32,

        DISP_WIDTH_16,

        DISP_WIDTH_32,

        DISP_WIDTH_8,

        DISP_WIDTH_8_32,

        DR_R,

        ERROR,

        ESIZE_1_BITS,

        ESIZE_128_BITS,

        ESIZE_16_BITS,

        ESIZE_2_BITS,

        ESIZE_32_BITS,

        ESIZE_4_BITS,

        ESIZE_64_BITS,

        ESIZE_8_BITS,

        EVEX_62_REXR_ENC,

        EVEX_62_EXR_ENC_BIND,

        EVEX_62_REXR_ENC_EMIT,

        EVEX_REXX_ENC_EMIT,
        
        EVEX_REXB_ENC_EMIT,
        
        EVEX_REXRR_ENC_EMIT,
        
        EVEX_MAP_ENC_EMIT,
        
        EVEX_REXW_VVVV_ENC_EMIT,
        
        EVEX_UPP_ENC_EMIT,
        
        EVEX_LL_ENC_EMIT,
        
        AVX512_EVEX_BYTE3_ENC_EMIT,

        EVEX_ENC,

        EVEX_INSTRUCTIONS,

        EVEX_LL_ENC,

        EVEX_LL_ENC_BIND,

        EVEX_U_ENC,

        EVEX_PP_ENC,

        EVEX_MAP_ENC,

        EVEX_MAP_ENC_BIND,

        EVEX_REXB_ENC,

        EVEX_REXB_ENC_BIND,

        EVEX_REXRR_ENC,

        EVEX_REXRR_ENC_BIND,

        EVEX_REXW_VVVV_ENC,

        EVEX_REXW_VVVV_ENC_BIND,

        EVEX_REXX_ENC,

        EVEX_REXX_ENC_BIND,

        EVEX_SPLITTER,

        EVEX_UPP_ENC,

        EVEX_UPP_ENC_BIND,

        EVEX_62_REXR_ENC_BIND,

        FINAL_DSEG,

        FINAL_DSEG_MODE64,

        FINAL_DSEG_NOT64,

        FINAL_DSEG1,

        FINAL_DSEG1_MODE64,

        FINAL_DSEG1_NOT64,

        FINAL_ESEG,

        FINAL_ESEG1,

        FINAL_SSEG,

        FINAL_SSEG_MODE64,

        FINAL_SSEG_NOT64,

        FINAL_SSEG0,

        FINAL_SSEG1,

        FIX_ROUND_LEN128,

        FIX_ROUND_LEN512,

        FIXUP_EASZ_ENC,

        FIXUP_EOSZ_ENC,

        FIXUP_EOSZ_ENC_BIND,

        FIXUP_EASZ_ENC_BIND,

        FIXUP_SMODE_ENC,

        FORCE64,

        GPR16_B,

        GPR16_R,

        GPR16_SB,

        GPR16e,

        GPR32_B,

        GPR32_R,

        GPR32_SB,

        GPR32_X,

        GPR32e,

        GPR32e_m32,

        GPR32e_m64,

        GPR64_B,

        GPR64_R,

        GPR64_SB,

        GPR64_X,

        GPR64e,

        GPR8_B,

        GPR8_R,

        GPR8_SB,

        GPRv_B,

        GPRv_R,

        GPRv_SB,

        GPRy_B,

        GPRy_R,

        GPRz_B,

        GPRz_R,

        IGNORE66,

        IMMUNE_REXW,

        IMMUNE66,

        IMMUNE66_LOOP64,

        INSTRUCTIONS,

        INSTRUCTIONS_BIND,

        INSTRUCTIONS_EMIT,

        OSZ_NONTERM_ENC_BIND,

        PREFIX_ENC_BIND,

        VEXED_REX_BIND,

        ISA,

        MASK_B,

        MASK_N,

        MASK_N32,

        MASK_N64,

        MASK_R,

        MASK1,

        MASKNOT0,

        MEMDISP,

        MEMDISP16,

        MEMDISP32,

        MEMDISP8,

        MEMDISPv,

        MMX_B,

        MMX_R,

        MODRM,

        MODRM_MOD_EA16_DISP0,

        MODRM_MOD_EA16_DISP16,

        MODRM_MOD_EA16_DISP8,

        MODRM_MOD_EA32_DISP0,

        MODRM_MOD_EA32_DISP32,

        MODRM_MOD_EA32_DISP8,

        MODRM_MOD_EA64_DISP0,

        MODRM_MOD_EA64_DISP32,

        MODRM_MOD_EA64_DISP8,

        MODRM_MOD_ENCODE,

        MODRM_RM_ENCODE,

        MODRM_RM_ENCODE_EA16_SIB0,

        MODRM_RM_ENCODE_EA32_SIB0,

        MODRM_RM_ENCODE_EA64_SIB0,

        MODRM_RM_ENCODE_EANOT16_SIB1,

        MODRM16,

        MODRM32,

        MODRM64alt32,

        UISA_ENC_INDEX_XMM,

        NELEM_EIGHTHMEM,

        NELEM_FULL,

        NELEM_FULLMEM,

        NELEM_GPR_READER,

        NELEM_GPR_READER_BYTE,

        NELEM_GPR_READER_SUBDWORD,

        NELEM_GPR_READER_WORD,

        NELEM_GPR_WRITER_LDOP,

        NELEM_GPR_WRITER_LDOP_D,

        NELEM_GPR_WRITER_LDOP_Q,

        NELEM_GPR_WRITER_STORE,

        NELEM_GPR_WRITER_STORE_BYTE,

        NELEM_GPR_WRITER_STORE_SUBDWORD,

        NELEM_GPR_WRITER_STORE_WORD,

        NELEM_GSCAT,

        NELEM_HALF,

        NELEM_HALFMEM,

        NELEM_MEM128,

        NELEM_MOVDDUP,

        NELEM_QUARTERMEM,

        NELEM_SCALAR,

        NELEM_TUPLE1,

        NELEM_TUPLE1_4X,

        NELEM_TUPLE1_BYTE,

        NELEM_TUPLE1_SUBDWORD,

        NELEM_TUPLE1_WORD,

        NELEM_TUPLE2,

        NELEM_TUPLE4,

        NELEM_TUPLE8,

        NEWVEX_ENC,

        OeAX,

        ONE,

        OrAX,

        OrBP,

        OrBX,

        OrCX,

        OrDX,

        OrSP,

        OSZ_NONTERM,

        OSZ_NONTERM_ENC,

        OVERRIDE_SEG0,

        OVERRIDE_SEG1,

        PREFIX_ENC,

        PREFIX_ENC_EMIT,

        PREFIXES,

        REFINING66,

        REMOVE_SEGMENT,

        REMOVE_SEGMENT_AGEN1,

        REX_PREFIX_ENC,

        rFLAGS,

        rIP,

        rIPa,

        SAE,

        SE_IMM8,

        SEG,

        SEG_MOV,

        SEGe,

        SEGMENT_DEFAULT_ENCODE,

        SEGMENT_ENCODE,

        SIB,

        SIB_BASE0,

        SIB_NT,

        SIB_NT_EMIT,

        SIB_REQUIRED_ENCODE,

        SIB_REQUIRED_ENCODE_BIND,

        SIBBASE_ENCODE,

        SIBBASE_ENCODE_BIND,

        SIBINDEX_ENCODE_BIND,

        SIBBASE_ENCODE_SIB1,

        SIBINDEX_ENCODE,

        SIBINDEX_ENCODE_SIB1,

        SIBSCALE_ENCODE,

        SIBSCALE_ENCODE_BIND,


        SIMM8,

        SIMMz,

        SrBP,

        SRBP,

        SrSP,

        SRSP,

        TMM_B,

        TMM_N,

        TMM_R,

        UIMM16,

        UIMM32,

        UIMM8,

        UIMM8_1,

        UIMMv,

        UISA_ENC_INDEX_YMM,

        UISA_ENC_INDEX_ZMM,

        UISA_VMODRM_XMM,

        UISA_VMODRM_YMM,

        UISA_VMODRM_ZMM,

        UISA_VSIB_BASE,

        UISA_VSIB_INDEX_XMM,

        UISA_VSIB_INDEX_YMM,

        UISA_VSIB_INDEX_ZMM,

        UISA_VSIB_XMM,

        UISA_VSIB_YMM,

        UISA_VSIB_ZMM,

        VEX_ESCVL_ENC,

        VEX_MAP_ENC,

        VEX_REG_ENC,

        VEX_REXR_ENC,

        VEX_REXXB_ENC,

        VEX_TYPE_ENC,

        VEXED_REX,

        VEXED_REX_EMIT,

        VEX_TYPE_ENC_BIND,

        VEX_REXR_ENC_BIND,

        VEX_REXXB_ENC_BIND,

        VEX_MAP_ENC_BIND,

        VEX_REG_ENC_BIND,

        VEX_ESCVL_ENC_BIND,

        VEX_TYPE_ENC_EMIT,
        
        VEX_REXR_ENC_EMIT,
        
        VEX_REXXB_ENC_EMIT,
        
        VEX_MAP_ENC_EMIT,
        
        VEX_REG_ENC_EMIT,
        
        VEX_ESCVL_ENC_EMIT,

        VSIB_ENC_EMIT,

        VGPR32_B,

        VGPR32_B_32,

        VGPR32_B_64,

        VGPR32_N,

        VGPR32_N_32,

        VGPR32_N_64,

        VGPR32_R,

        VGPR32_R_32,

        VGPR32_R_64,

        VGPR64_B,

        VGPR64_N,

        VGPR64_R,

        VGPRy_B,

        VGPRy_N,

        VGPRy_R,

        VMODRM_MOD_ENCODE,

        VMODRM_MOD_ENCODE_BIND,

        VSIB_ENC_INDEX_XMM_BIND,

        VSIB_ENC_BASE_BIND,
        
        UISA_ENC_INDEX_XMM_BIND,
        
        VSIB_ENC_SCALE_BIND,
        
        UISA_ENC_INDEX_ZMM_BIND,
        
        VSIB_ENC_BIND,

        VSIB_ENC_INDEX_YMM_BIND,

        VMODRM_XMM,

        VMODRM_YMM,

        VSIB_BASE,

        VSIB_ENC,

        VSIB_ENC_BASE,

        VSIB_ENC_INDEX_XMM,

        VSIB_ENC_INDEX_YMM,

        VSIB_ENC_SCALE,

        VSIB_INDEX_XMM,

        VSIB_INDEX_YMM,

        VSIB_XMM,

        VSIB_YMM,

        X87,

        XMM_B,

        XMM_B_32,

        XMM_B_64,

        XMM_B3,

        XMM_B3_32,

        XMM_B3_64,

        XMM_N,

        XMM_N_32,

        XMM_N_64,

        XMM_N3,

        XMM_N3_32,

        XMM_N3_64,

        XMM_R,

        XMM_R_32,

        XMM_R_64,

        XMM_R3,

        XMM_R3_32,

        XMM_R3_64,

        XMM_SE,

        XMM_SE32,

        XMM_SE64,

        XOP_ENC,

        XOP_INSTRUCTIONS,

        XOP_MAP_ENC,

        XOP_REXXB_ENC,

        XOP_TYPE_ENC,

        YMM_B,

        YMM_B_32,

        YMM_B_64,

        YMM_B3,

        YMM_B3_32,

        YMM_B3_64,

        YMM_N,

        YMM_N_32,

        YMM_N_64,

        YMM_N3,

        YMM_N3_32,

        YMM_N3_64,

        YMM_R,

        YMM_R_32,

        YMM_R_64,

        YMM_R3,

        YMM_R3_32,

        YMM_R3_64,

        YMM_SE,

        YMM_SE32,

        YMM_SE64,

        ZMM_B3,

        ZMM_B3_32,

        ZMM_B3_64,

        ZMM_N3,

        ZMM_N3_32,

        ZMM_N3_64,

        ZMM_R3,

        ZMM_R3_32,

        ZMM_R3_64,

        XSAVE,

        NELEM_QUARTER,
    }
}
