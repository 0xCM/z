//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [DataWidth(num9.Width)]
    public enum RuleName : ushort
    {
        None = 0,

        A_GPR_B = 1,

        A_GPR_R = 2,

        Ar10 = 3,

        Ar11 = 4,

        Ar12 = 5,

        Ar13 = 6,

        Ar14 = 7,

        Ar15 = 8,

        Ar8 = 9,

        Ar9 = 10,

        ArAX = 11,

        ArBP = 12,

        ArBX = 13,

        ArCX = 14,

        ArDI = 15,

        ArDX = 16,

        ArSI = 17,

        ArSP = 18,

        ASZ_NONTERM = 19,

        AVX_INSTRUCTIONS = 20,

        AVX_SPLITTER = 21,

        AVX512_EVEX_BYTE3_ENC = 22,

        AVX512_EVEX_BYTE3_ENC_BIND = 23,

        AVX512_ROUND = 24,

        BND_B = 25,

        BND_B_CHECK = 26,

        BND_R = 27,

        BND_R_CHECK = 28,

        BRANCH_HINT = 29,

        BRDISP32 = 30,

        BRDISP8 = 31,

        BRDISPz = 32,

        CET_NO_TRACK = 33,

        CR_B = 34,

        CR_R = 35,

        CR_WIDTH = 36,

        DF64 = 37,

        DISP_NT = 38,

        DISP_WIDTH_0 = 39,

        DISP_WIDTH_0_8_16 = 40,

        DISP_WIDTH_0_8_32 = 41,

        DISP_WIDTH_16 = 42,

        DISP_WIDTH_32 = 43,

        DISP_WIDTH_8 = 44,

        DISP_WIDTH_8_32 = 45,

        DR_R = 46,

        ERROR = 47,

        ESIZE_1_BITS = 48,

        ESIZE_128_BITS = 49,

        ESIZE_16_BITS = 50,

        ESIZE_2_BITS = 51,

        ESIZE_32_BITS = 52,

        ESIZE_4_BITS = 53,

        ESIZE_64_BITS = 54,

        ESIZE_8_BITS = 55,

        EVEX_62_REXR_ENC = 56,

        EVEX_62_REXR_ENC_BIND = 57,

        EVEX_ENC = 58,

        EVEX_INSTRUCTIONS = 59,

        EVEX_LL_ENC = 60,

        EVEX_LL_ENC_BIND = 61,

        EVEX_MAP_ENC = 62,

        EVEX_MAP_ENC_BIND = 63,

        EVEX_REXB_ENC = 64,

        EVEX_REXB_ENC_BIND = 65,

        EVEX_REXRR_ENC = 66,

        EVEX_REXRR_ENC_BIND = 67,

        EVEX_REXW_VVVV_ENC = 68,

        EVEX_REXW_VVVV_ENC_BIND = 69,

        EVEX_REXX_ENC = 70,

        EVEX_REXX_ENC_BIND = 71,

        EVEX_SPLITTER = 72,

        EVEX_UPP_ENC = 73,

        EVEX_UPP_ENC_BIND = 74,

        FINAL_DSEG = 75,

        FINAL_DSEG_MODE64 = 76,

        FINAL_DSEG_NOT64 = 77,

        FINAL_DSEG1 = 78,

        FINAL_DSEG1_MODE64 = 79,

        FINAL_DSEG1_NOT64 = 80,

        FINAL_ESEG = 81,

        FINAL_ESEG1 = 82,

        FINAL_SSEG = 83,

        FINAL_SSEG_MODE64 = 84,

        FINAL_SSEG_NOT64 = 85,

        FINAL_SSEG0 = 86,

        FINAL_SSEG1 = 87,

        FIX_ROUND_LEN128 = 88,

        FIX_ROUND_LEN512 = 89,

        FIXUP_EASZ_ENC = 90,

        FIXUP_EOSZ_ENC = 91,

        FIXUP_SMODE_ENC = 92,

        FORCE64 = 93,

        GPR16_B = 94,

        GPR16_R = 95,

        GPR16_SB = 96,

        GPR16e = 97,

        GPR32_B = 98,

        GPR32_R = 99,

        GPR32_SB = 100,

        GPR32_X = 101,

        GPR32e = 102,

        GPR32e_m32 = 103,

        GPR32e_m64 = 104,

        GPR64_B = 105,

        GPR64_R = 106,

        GPR64_SB = 107,

        GPR64_X = 108,

        GPR64e = 109,

        GPR8_B = 110,

        GPR8_R = 111,

        GPR8_SB = 112,

        GPRv_B = 113,

        GPRv_R = 114,

        GPRv_SB = 115,

        GPRy_B = 116,

        GPRy_R = 117,

        GPRz_B = 118,

        GPRz_R = 119,

        IGNORE66 = 120,

        IMMUNE_REXW = 121,

        IMMUNE66 = 122,

        IMMUNE66_LOOP64 = 123,

        INSTRUCTIONS = 124,

        ISA = 125,

        MASK_B = 126,

        MASK_N = 127,

        MASK_N32 = 128,

        MASK_N64 = 129,

        MASK_R = 130,

        MASK1 = 131,

        MASKNOT0 = 132,

        MEMDISP = 133,

        MEMDISP16 = 134,

        MEMDISP32 = 135,

        MEMDISP8 = 136,

        MEMDISPv = 137,

        MMX_B = 138,

        MMX_R = 139,

        MODRM = 140,

        MODRM_MOD_EA16_DISP0 = 141,

        MODRM_MOD_EA16_DISP16 = 142,

        MODRM_MOD_EA16_DISP8 = 143,

        MODRM_MOD_EA32_DISP0 = 144,

        MODRM_MOD_EA32_DISP32 = 145,

        MODRM_MOD_EA32_DISP8 = 146,

        MODRM_MOD_EA64_DISP0 = 147,

        MODRM_MOD_EA64_DISP32 = 148,

        MODRM_MOD_EA64_DISP8 = 149,

        MODRM_MOD_ENCODE = 150,

        MODRM_RM_ENCODE = 151,

        MODRM_RM_ENCODE_EA16_SIB0 = 152,

        MODRM_RM_ENCODE_EA32_SIB0 = 153,

        MODRM_RM_ENCODE_EA64_SIB0 = 154,

        MODRM_RM_ENCODE_EANOT16_SIB1 = 155,

        MODRM16 = 156,

        MODRM32 = 157,

        MODRM64alt32 = 158,

        UISA_ENC_INDEX_XMM = 159,

        NELEM_EIGHTHMEM = 160,

        NELEM_FULL = 161,

        NELEM_FULLMEM = 162,

        NELEM_GPR_READER = 163,

        NELEM_GPR_READER_BYTE = 164,

        NELEM_GPR_READER_SUBDWORD = 165,

        NELEM_GPR_READER_WORD = 166,

        NELEM_GPR_WRITER_LDOP = 167,

        NELEM_GPR_WRITER_LDOP_D = 168,

        NELEM_GPR_WRITER_LDOP_Q = 169,

        NELEM_GPR_WRITER_STORE = 170,

        NELEM_GPR_WRITER_STORE_BYTE = 171,

        NELEM_GPR_WRITER_STORE_SUBDWORD = 172,

        NELEM_GPR_WRITER_STORE_WORD = 173,

        NELEM_GSCAT = 174,

        NELEM_HALF = 175,

        NELEM_HALFMEM = 176,

        NELEM_MEM128 = 177,

        NELEM_MOVDDUP = 178,

        NELEM_QUARTERMEM = 179,

        NELEM_SCALAR = 180,

        NELEM_TUPLE1 = 181,

        NELEM_TUPLE1_4X = 182,

        NELEM_TUPLE1_BYTE = 183,

        NELEM_TUPLE1_SUBDWORD = 184,

        NELEM_TUPLE1_WORD = 185,

        NELEM_TUPLE2 = 186,

        NELEM_TUPLE4 = 187,

        NELEM_TUPLE8 = 188,

        NEWVEX_ENC = 189,

        OeAX = 190,

        ONE = 191,

        OrAX = 192,

        OrBP = 193,

        OrBX = 194,

        OrCX = 195,

        OrDX = 196,

        OrSP = 197,

        OSZ_NONTERM = 198,

        OSZ_NONTERM_ENC = 199,

        OVERRIDE_SEG0 = 200,

        OVERRIDE_SEG1 = 201,

        PREFIX_ENC = 202,

        PREFIXES = 203,

        REFINING66 = 204,

        REMOVE_SEGMENT = 205,

        REMOVE_SEGMENT_AGEN1 = 206,

        REX_PREFIX_ENC = 207,

        rFLAGS = 208,

        rIP = 209,

        rIPa = 210,

        SAE = 211,

        SE_IMM8 = 212,

        SEG = 213,

        SEG_MOV = 214,

        SEGe = 215,

        SEGMENT_DEFAULT_ENCODE = 216,

        SEGMENT_ENCODE = 217,

        SIB = 218,

        SIB_BASE0 = 219,

        SIB_NT = 220,

        SIB_REQUIRED_ENCODE = 221,

        SIBBASE_ENCODE = 222,

        SIBBASE_ENCODE_SIB1 = 223,

        SIBINDEX_ENCODE = 224,

        SIBINDEX_ENCODE_SIB1 = 225,

        SIBSCALE_ENCODE = 226,

        SIMM8 = 227,

        SIMMz = 228,

        SrBP = 229,

        SRBP = 230,

        SrSP = 231,

        SRSP = 232,

        TMM_B = 233,

        TMM_N = 234,

        TMM_R = 235,

        UIMM16 = 236,

        UIMM32 = 237,

        UIMM8 = 238,

        UIMM8_1 = 239,

        UIMMv = 240,

        UISA_ENC_INDEX_YMM = 241,

        UISA_ENC_INDEX_ZMM = 242,

        UISA_VMODRM_XMM = 243,

        UISA_VMODRM_YMM = 244,

        UISA_VMODRM_ZMM = 245,

        UISA_VSIB_BASE = 246,

        UISA_VSIB_INDEX_XMM = 247,

        UISA_VSIB_INDEX_YMM = 248,

        UISA_VSIB_INDEX_ZMM = 249,

        UISA_VSIB_XMM = 250,

        UISA_VSIB_YMM = 251,

        UISA_VSIB_ZMM = 252,

        VEX_ESCVL_ENC = 253,

        VEX_MAP_ENC = 254,

        VEX_REG_ENC = 255,

        VEX_REXR_ENC = 256,

        VEX_REXXB_ENC = 257,

        VEX_TYPE_ENC = 258,

        VEXED_REX = 259,

        VGPR32_B = 260,

        VGPR32_B_32 = 261,

        VGPR32_B_64 = 262,

        VGPR32_N = 263,

        VGPR32_N_32 = 264,

        VGPR32_N_64 = 265,

        VGPR32_R = 266,

        VGPR32_R_32 = 267,

        VGPR32_R_64 = 268,

        VGPR64_B = 269,

        VGPR64_N = 270,

        VGPR64_R = 271,

        VGPRy_B = 272,

        VGPRy_N = 273,

        VGPRy_R = 274,

        VMODRM_MOD_ENCODE = 275,

        VMODRM_XMM = 276,

        VMODRM_YMM = 277,

        VSIB_BASE = 278,

        VSIB_ENC = 279,

        VSIB_ENC_BASE = 280,

        VSIB_ENC_INDEX_XMM = 281,

        VSIB_ENC_INDEX_YMM = 282,

        VSIB_ENC_SCALE = 283,

        VSIB_INDEX_XMM = 284,

        VSIB_INDEX_YMM = 285,

        VSIB_XMM = 286,

        VSIB_YMM = 287,

        X87 = 288,

        XMM_B = 289,

        XMM_B_32 = 290,

        XMM_B_64 = 291,

        XMM_B3 = 292,

        XMM_B3_32 = 293,

        XMM_B3_64 = 294,

        XMM_N = 295,

        XMM_N_32 = 296,

        XMM_N_64 = 297,

        XMM_N3 = 298,

        XMM_N3_32 = 299,

        XMM_N3_64 = 300,

        XMM_R = 301,

        XMM_R_32 = 302,

        XMM_R_64 = 303,

        XMM_R3 = 304,

        XMM_R3_32 = 305,

        XMM_R3_64 = 306,

        XMM_SE = 307,

        XMM_SE32 = 308,

        XMM_SE64 = 309,

        XOP_ENC = 310,

        XOP_INSTRUCTIONS = 311,

        XOP_MAP_ENC = 312,

        XOP_REXXB_ENC = 313,

        XOP_TYPE_ENC = 314,

        YMM_B = 315,

        YMM_B_32 = 316,

        YMM_B_64 = 317,

        YMM_B3 = 318,

        YMM_B3_32 = 319,

        YMM_B3_64 = 320,

        YMM_N = 321,

        YMM_N_32 = 322,

        YMM_N_64 = 323,

        YMM_N3 = 324,

        YMM_N3_32 = 325,

        YMM_N3_64 = 326,

        YMM_R = 327,

        YMM_R_32 = 328,

        YMM_R_64 = 329,

        YMM_R3 = 330,

        YMM_R3_32 = 331,

        YMM_R3_64 = 332,

        YMM_SE = 333,

        YMM_SE32 = 334,

        YMM_SE64 = 335,

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
