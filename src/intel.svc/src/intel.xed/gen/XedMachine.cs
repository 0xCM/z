namespace Z0;

using static sys;
using static XedModels;
using static XedRules;
using static XedMachines;

partial class XedCmd
{
    [CmdOp("xed/run")]
    void Run()
    {
        var context = XedMachines.context(rule => Channel.Row($"{rule} activated"));
        var machine = new XedMachine(context);
        var rules = context.RuleNames;
        foreach(var name in rules)
        {
            machine.Rule(name)();
        }
    }
}

public class XedMachine
{
    public XedFieldState FieldState;

    readonly MachineContext Context;

    Seq<Action> Rules;

    [MethodImpl(Inline)]
    public ref readonly Action Rule(RuleIdentity id)
        => ref Rules[key(id)];

    public XedMachine(MachineContext context)
    {
        Context = context;
        FieldState = XedFieldState.Empty;
        Rules = sys.alloc<Action>(2048);

        Rules[0x0401] = A_GPR_B_DEC;
        Rules[0x0402] = A_GPR_R_DEC;
        Rules[0x0403] = Ar10_DEC;
        Rules[0x0404] = Ar11_DEC;
        Rules[0x0405] = Ar12_DEC;
        Rules[0x0406] = Ar13_DEC;
        Rules[0x0407] = Ar14_DEC;
        Rules[0x0408] = Ar15_DEC;
        Rules[0x0409] = Ar8_DEC;
        Rules[0x040a] = Ar9_DEC;
        Rules[0x040b] = ArAX_DEC;
        Rules[0x040c] = ArBP_DEC;
        Rules[0x040d] = ArBX_DEC;
        Rules[0x040e] = ArCX_DEC;
        Rules[0x040f] = ArDI_DEC;
        Rules[0x0410] = ArDX_DEC;
        Rules[0x0411] = ArSI_DEC;
        Rules[0x0412] = ArSP_DEC;
        Rules[0x0413] = ASZ_NONTERM_DEC;
        Rules[0x0416] = AVX_SPLITTER_DEC;
        Rules[0x0217] = AVX512_EVEX_BYTE3_ENC_ENC;
        Rules[0x0419] = AVX512_ROUND_DEC;
        Rules[0x0219] = AVX512_ROUND_ENC;
        Rules[0x041a] = BND_B_DEC;
        Rules[0x041b] = BND_B_CHECK_DEC;
        Rules[0x021b] = BND_B_CHECK_ENC;
        Rules[0x041c] = BND_R_DEC;
        Rules[0x041d] = BND_R_CHECK_DEC;
        Rules[0x021d] = BND_R_CHECK_ENC;
        Rules[0x041e] = BRANCH_HINT_DEC;
        Rules[0x021e] = BRANCH_HINT_ENC;
        Rules[0x041f] = BRDISP32_DEC;
        Rules[0x0420] = BRDISP8_DEC;
        Rules[0x0421] = BRDISPz_DEC;
        Rules[0x0422] = CET_NO_TRACK_DEC;
        Rules[0x0222] = CET_NO_TRACK_ENC;
        Rules[0x0423] = CR_B_DEC;
        Rules[0x0424] = CR_R_DEC;
        Rules[0x0425] = CR_WIDTH_DEC;
        Rules[0x0225] = CR_WIDTH_ENC;
        Rules[0x0426] = DF64_DEC;
        Rules[0x0226] = DF64_ENC;
        Rules[0x0227] = DISP_NT_ENC;
        Rules[0x022a] = DISP_WIDTH_0_ENC;
        Rules[0x022b] = DISP_WIDTH_0_8_16_ENC;
        Rules[0x022c] = DISP_WIDTH_0_8_32_ENC;
        Rules[0x022d] = DISP_WIDTH_16_ENC;
        Rules[0x022e] = DISP_WIDTH_32_ENC;
        Rules[0x022f] = DISP_WIDTH_8_ENC;
        Rules[0x0230] = DISP_WIDTH_8_32_ENC;
        Rules[0x0431] = DR_R_DEC;
        Rules[0x0232] = ERROR_ENC;
        Rules[0x0433] = ESIZE_1_BITS_DEC;
        Rules[0x0233] = ESIZE_1_BITS_ENC;
        Rules[0x0434] = ESIZE_128_BITS_DEC;
        Rules[0x0234] = ESIZE_128_BITS_ENC;
        Rules[0x0435] = ESIZE_16_BITS_DEC;
        Rules[0x0235] = ESIZE_16_BITS_ENC;
        Rules[0x0436] = ESIZE_2_BITS_DEC;
        Rules[0x0236] = ESIZE_2_BITS_ENC;
        Rules[0x0437] = ESIZE_32_BITS_DEC;
        Rules[0x0237] = ESIZE_32_BITS_ENC;
        Rules[0x0438] = ESIZE_4_BITS_DEC;
        Rules[0x0238] = ESIZE_4_BITS_ENC;
        Rules[0x0439] = ESIZE_64_BITS_DEC;
        Rules[0x0239] = ESIZE_64_BITS_ENC;
        Rules[0x043a] = ESIZE_8_BITS_DEC;
        Rules[0x023a] = ESIZE_8_BITS_ENC;
        Rules[0x023b] = EVEX_62_REXR_ENC_ENC;
        Rules[0x0246] = EVEX_LL_ENC_ENC;
        Rules[0x0248] = EVEX_U_ENC_ENC;
        Rules[0x0249] = EVEX_PP_ENC_ENC;
        Rules[0x024a] = EVEX_MAP_ENC_ENC;
        Rules[0x024b] = EVEX_REXB_ENC_ENC;
        Rules[0x024c] = EVEX_REXRR_ENC_ENC;
        Rules[0x024d] = EVEX_REXW_VVVV_ENC_ENC;
        Rules[0x024e] = EVEX_REXX_ENC_ENC;
        Rules[0x0450] = EVEX_SPLITTER_DEC;
        Rules[0x0454] = FINAL_DSEG_DEC;
        Rules[0x0455] = FINAL_DSEG_MODE64_DEC;
        Rules[0x0456] = FINAL_DSEG_NOT64_DEC;
        Rules[0x0457] = FINAL_DSEG1_DEC;
        Rules[0x0458] = FINAL_DSEG1_MODE64_DEC;
        Rules[0x0459] = FINAL_DSEG1_NOT64_DEC;
        Rules[0x045a] = FINAL_ESEG_DEC;
        Rules[0x045b] = FINAL_ESEG1_DEC;
        Rules[0x045c] = FINAL_SSEG_DEC;
        Rules[0x045d] = FINAL_SSEG_MODE64_DEC;
        Rules[0x045e] = FINAL_SSEG_NOT64_DEC;
        Rules[0x045f] = FINAL_SSEG0_DEC;
        Rules[0x0460] = FINAL_SSEG1_DEC;
        Rules[0x0461] = FIX_ROUND_LEN128_DEC;
        Rules[0x0261] = FIX_ROUND_LEN128_ENC;
        Rules[0x0462] = FIX_ROUND_LEN512_DEC;
        Rules[0x0262] = FIX_ROUND_LEN512_ENC;
        Rules[0x0263] = FIXUP_EASZ_ENC_ENC;
        Rules[0x0264] = FIXUP_EOSZ_ENC_ENC;
        Rules[0x0265] = FIXUP_SMODE_ENC_ENC;
        Rules[0x0466] = FORCE64_DEC;
        Rules[0x0266] = FORCE64_ENC;
        Rules[0x0467] = GPR16_B_DEC;
        Rules[0x0468] = GPR16_R_DEC;
        Rules[0x0469] = GPR16_SB_DEC;
        Rules[0x026a] = GPR16e_ENC;
        Rules[0x046b] = GPR32_B_DEC;
        Rules[0x046c] = GPR32_R_DEC;
        Rules[0x046d] = GPR32_SB_DEC;
        Rules[0x046e] = GPR32_X_DEC;
        Rules[0x026f] = GPR32e_ENC;
        Rules[0x0270] = GPR32e_m32_ENC;
        Rules[0x0271] = GPR32e_m64_ENC;
        Rules[0x0472] = GPR64_B_DEC;
        Rules[0x0473] = GPR64_R_DEC;
        Rules[0x0474] = GPR64_SB_DEC;
        Rules[0x0475] = GPR64_X_DEC;
        Rules[0x0276] = GPR64e_ENC;
        Rules[0x0477] = GPR8_B_DEC;
        Rules[0x0277] = GPR8_B_ENC;
        Rules[0x0478] = GPR8_R_DEC;
        Rules[0x0278] = GPR8_R_ENC;
        Rules[0x0479] = GPR8_SB_DEC;
        Rules[0x0279] = GPR8_SB_ENC;
        Rules[0x047a] = GPRv_B_DEC;
        Rules[0x047b] = GPRv_R_DEC;
        Rules[0x047c] = GPRv_SB_DEC;
        Rules[0x047d] = GPRy_B_DEC;
        Rules[0x047e] = GPRy_R_DEC;
        Rules[0x047f] = GPRz_B_DEC;
        Rules[0x0480] = GPRz_R_DEC;
        Rules[0x0481] = IGNORE66_DEC;
        Rules[0x0281] = IGNORE66_ENC;
        Rules[0x0482] = IMMUNE_REXW_DEC;
        Rules[0x0282] = IMMUNE_REXW_ENC;
        Rules[0x0483] = IMMUNE66_DEC;
        Rules[0x0283] = IMMUNE66_ENC;
        Rules[0x0484] = IMMUNE66_LOOP64_DEC;
        Rules[0x0284] = IMMUNE66_LOOP64_ENC;
        Rules[0x048c] = MASK_B_DEC;
        Rules[0x048d] = MASK_N_DEC;
        Rules[0x048e] = MASK_N32_DEC;
        Rules[0x048f] = MASK_N64_DEC;
        Rules[0x0490] = MASK_R_DEC;
        Rules[0x0491] = MASK1_DEC;
        Rules[0x0492] = MASKNOT0_DEC;
        Rules[0x0493] = MEMDISP_DEC;
        Rules[0x0494] = MEMDISP16_DEC;
        Rules[0x0495] = MEMDISP32_DEC;
        Rules[0x0496] = MEMDISP8_DEC;
        Rules[0x0497] = MEMDISPv_DEC;
        Rules[0x0498] = MMX_B_DEC;
        Rules[0x0499] = MMX_R_DEC;
        Rules[0x049a] = MODRM_DEC;
        Rules[0x029b] = MODRM_MOD_EA16_DISP0_ENC;
        Rules[0x029c] = MODRM_MOD_EA16_DISP16_ENC;
        Rules[0x029d] = MODRM_MOD_EA16_DISP8_ENC;
        Rules[0x029e] = MODRM_MOD_EA32_DISP0_ENC;
        Rules[0x029f] = MODRM_MOD_EA32_DISP32_ENC;
        Rules[0x02a0] = MODRM_MOD_EA32_DISP8_ENC;
        Rules[0x02a1] = MODRM_MOD_EA64_DISP0_ENC;
        Rules[0x02a2] = MODRM_MOD_EA64_DISP32_ENC;
        Rules[0x02a3] = MODRM_MOD_EA64_DISP8_ENC;
        Rules[0x02a4] = MODRM_MOD_ENCODE_ENC;
        Rules[0x02a5] = MODRM_RM_ENCODE_ENC;
        Rules[0x02a6] = MODRM_RM_ENCODE_EA16_SIB0_ENC;
        Rules[0x02a7] = MODRM_RM_ENCODE_EA32_SIB0_ENC;
        Rules[0x02a8] = MODRM_RM_ENCODE_EA64_SIB0_ENC;
        Rules[0x02a9] = MODRM_RM_ENCODE_EANOT16_SIB1_ENC;
        Rules[0x04aa] = MODRM16_DEC;
        Rules[0x04ab] = MODRM32_DEC;
        Rules[0x04ac] = MODRM64alt32_DEC;
        Rules[0x02ad] = UISA_ENC_INDEX_XMM_ENC;
        Rules[0x04ae] = NELEM_EIGHTHMEM_DEC;
        Rules[0x02ae] = NELEM_EIGHTHMEM_ENC;
        Rules[0x04af] = NELEM_FULL_DEC;
        Rules[0x02af] = NELEM_FULL_ENC;
        Rules[0x04b0] = NELEM_FULLMEM_DEC;
        Rules[0x02b0] = NELEM_FULLMEM_ENC;
        Rules[0x04b1] = NELEM_GPR_READER_DEC;
        Rules[0x02b1] = NELEM_GPR_READER_ENC;
        Rules[0x04b2] = NELEM_GPR_READER_BYTE_DEC;
        Rules[0x02b2] = NELEM_GPR_READER_BYTE_ENC;
        Rules[0x04b3] = NELEM_GPR_READER_SUBDWORD_DEC;
        Rules[0x02b3] = NELEM_GPR_READER_SUBDWORD_ENC;
        Rules[0x04b4] = NELEM_GPR_READER_WORD_DEC;
        Rules[0x02b4] = NELEM_GPR_READER_WORD_ENC;
        Rules[0x04b5] = NELEM_GPR_WRITER_LDOP_DEC;
        Rules[0x02b5] = NELEM_GPR_WRITER_LDOP_ENC;
        Rules[0x04b6] = NELEM_GPR_WRITER_LDOP_D_DEC;
        Rules[0x02b6] = NELEM_GPR_WRITER_LDOP_D_ENC;
        Rules[0x04b7] = NELEM_GPR_WRITER_LDOP_Q_DEC;
        Rules[0x02b7] = NELEM_GPR_WRITER_LDOP_Q_ENC;
        Rules[0x04b8] = NELEM_GPR_WRITER_STORE_DEC;
        Rules[0x02b8] = NELEM_GPR_WRITER_STORE_ENC;
        Rules[0x04b9] = NELEM_GPR_WRITER_STORE_BYTE_DEC;
        Rules[0x02b9] = NELEM_GPR_WRITER_STORE_BYTE_ENC;
        Rules[0x04ba] = NELEM_GPR_WRITER_STORE_SUBDWORD_DEC;
        Rules[0x02ba] = NELEM_GPR_WRITER_STORE_SUBDWORD_ENC;
        Rules[0x04bb] = NELEM_GPR_WRITER_STORE_WORD_DEC;
        Rules[0x02bb] = NELEM_GPR_WRITER_STORE_WORD_ENC;
        Rules[0x04bc] = NELEM_GSCAT_DEC;
        Rules[0x02bc] = NELEM_GSCAT_ENC;
        Rules[0x04bd] = NELEM_HALF_DEC;
        Rules[0x02bd] = NELEM_HALF_ENC;
        Rules[0x04be] = NELEM_HALFMEM_DEC;
        Rules[0x02be] = NELEM_HALFMEM_ENC;
        Rules[0x04bf] = NELEM_MEM128_DEC;
        Rules[0x02bf] = NELEM_MEM128_ENC;
        Rules[0x04c0] = NELEM_MOVDDUP_DEC;
        Rules[0x02c0] = NELEM_MOVDDUP_ENC;
        Rules[0x04c1] = NELEM_QUARTERMEM_DEC;
        Rules[0x02c1] = NELEM_QUARTERMEM_ENC;
        Rules[0x04c2] = NELEM_SCALAR_DEC;
        Rules[0x02c2] = NELEM_SCALAR_ENC;
        Rules[0x04c3] = NELEM_TUPLE1_DEC;
        Rules[0x02c3] = NELEM_TUPLE1_ENC;
        Rules[0x04c4] = NELEM_TUPLE1_4X_DEC;
        Rules[0x02c4] = NELEM_TUPLE1_4X_ENC;
        Rules[0x04c5] = NELEM_TUPLE1_BYTE_DEC;
        Rules[0x02c5] = NELEM_TUPLE1_BYTE_ENC;
        Rules[0x04c6] = NELEM_TUPLE1_SUBDWORD_DEC;
        Rules[0x02c6] = NELEM_TUPLE1_SUBDWORD_ENC;
        Rules[0x04c7] = NELEM_TUPLE1_WORD_DEC;
        Rules[0x02c7] = NELEM_TUPLE1_WORD_ENC;
        Rules[0x04c8] = NELEM_TUPLE2_DEC;
        Rules[0x02c8] = NELEM_TUPLE2_ENC;
        Rules[0x04c9] = NELEM_TUPLE4_DEC;
        Rules[0x02c9] = NELEM_TUPLE4_ENC;
        Rules[0x04ca] = NELEM_TUPLE8_DEC;
        Rules[0x02ca] = NELEM_TUPLE8_ENC;
        Rules[0x04cc] = OeAX_DEC;
        Rules[0x04cd] = ONE_DEC;
        Rules[0x04ce] = OrAX_DEC;
        Rules[0x04cf] = OrBP_DEC;
        Rules[0x04d0] = OrBX_DEC;
        Rules[0x04d1] = OrCX_DEC;
        Rules[0x04d2] = OrDX_DEC;
        Rules[0x04d3] = OrSP_DEC;
        Rules[0x04d4] = OSZ_NONTERM_DEC;
        Rules[0x02d5] = OSZ_NONTERM_ENC_ENC;
        Rules[0x04d6] = OVERRIDE_SEG0_DEC;
        Rules[0x02d6] = OVERRIDE_SEG0_ENC;
        Rules[0x04d7] = OVERRIDE_SEG1_DEC;
        Rules[0x02d7] = OVERRIDE_SEG1_ENC;
        Rules[0x02d8] = PREFIX_ENC_ENC;
        Rules[0x04da] = PREFIXES_DEC;
        Rules[0x04db] = REFINING66_DEC;
        Rules[0x02db] = REFINING66_ENC;
        Rules[0x04dc] = REMOVE_SEGMENT_DEC;
        Rules[0x02dc] = REMOVE_SEGMENT_ENC;
        Rules[0x02dd] = REMOVE_SEGMENT_AGEN1_ENC;
        Rules[0x02de] = REX_PREFIX_ENC_ENC;
        Rules[0x04df] = rFLAGS_DEC;
        Rules[0x04e0] = rIP_DEC;
        Rules[0x04e1] = rIPa_DEC;
        Rules[0x04e2] = SAE_DEC;
        Rules[0x02e2] = SAE_ENC;
        Rules[0x04e3] = SE_IMM8_DEC;
        Rules[0x02e3] = SE_IMM8_ENC;
        Rules[0x04e4] = SEG_DEC;
        Rules[0x04e5] = SEG_MOV_DEC;
        Rules[0x02e6] = SEGe_ENC;
        Rules[0x02e7] = SEGMENT_DEFAULT_ENCODE_ENC;
        Rules[0x02e8] = SEGMENT_ENCODE_ENC;
        Rules[0x04e9] = SIB_DEC;
        Rules[0x04ea] = SIB_BASE0_DEC;
        Rules[0x02eb] = SIB_NT_ENC;
        Rules[0x02ed] = SIB_REQUIRED_ENCODE_ENC;
        Rules[0x02ee] = SIBBASE_ENCODE_ENC;
        Rules[0x02ef] = SIBBASE_ENCODE_SIB1_ENC;
        Rules[0x02f0] = SIBINDEX_ENCODE_ENC;
        Rules[0x02f1] = SIBINDEX_ENCODE_SIB1_ENC;
        Rules[0x02f2] = SIBSCALE_ENCODE_ENC;
        Rules[0x04f3] = SIMM8_DEC;
        Rules[0x04f4] = SIMMz_DEC;
        Rules[0x04f5] = SrBP_DEC;
        Rules[0x04f7] = SrSP_DEC;
        Rules[0x04f9] = TMM_B_DEC;
        Rules[0x04fa] = TMM_N_DEC;
        Rules[0x04fb] = TMM_R_DEC;
        Rules[0x04fc] = UIMM16_DEC;
        Rules[0x04fd] = UIMM32_DEC;
        Rules[0x04fe] = UIMM8_DEC;
        Rules[0x04ff] = UIMM8_1_DEC;
        Rules[0x0500] = UIMMv_DEC;
        Rules[0x0301] = UISA_ENC_INDEX_YMM_ENC;
        Rules[0x0302] = UISA_ENC_INDEX_ZMM_ENC;
        Rules[0x0503] = UISA_VMODRM_XMM_DEC;
        Rules[0x0504] = UISA_VMODRM_YMM_DEC;
        Rules[0x0505] = UISA_VMODRM_ZMM_DEC;
        Rules[0x0506] = UISA_VSIB_BASE_DEC;
        Rules[0x0507] = UISA_VSIB_INDEX_XMM_DEC;
        Rules[0x0508] = UISA_VSIB_INDEX_YMM_DEC;
        Rules[0x0509] = UISA_VSIB_INDEX_ZMM_DEC;
        Rules[0x050a] = UISA_VSIB_XMM_DEC;
        Rules[0x050b] = UISA_VSIB_YMM_DEC;
        Rules[0x050c] = UISA_VSIB_ZMM_DEC;
        Rules[0x030d] = VEX_ESCVL_ENC_ENC;
        Rules[0x030e] = VEX_MAP_ENC_ENC;
        Rules[0x030f] = VEX_REG_ENC_ENC;
        Rules[0x0310] = VEX_REXR_ENC_ENC;
        Rules[0x0311] = VEX_REXXB_ENC_ENC;
        Rules[0x0312] = VEX_TYPE_ENC_ENC;
        Rules[0x0313] = VEXED_REX_ENC;
        Rules[0x051c] = VGPR32_B_DEC;
        Rules[0x051d] = VGPR32_B_32_DEC;
        Rules[0x051e] = VGPR32_B_64_DEC;
        Rules[0x051f] = VGPR32_N_DEC;
        Rules[0x0520] = VGPR32_N_32_DEC;
        Rules[0x0521] = VGPR32_N_64_DEC;
        Rules[0x0522] = VGPR32_R_DEC;
        Rules[0x0523] = VGPR32_R_32_DEC;
        Rules[0x0524] = VGPR32_R_64_DEC;
        Rules[0x0525] = VGPR64_B_DEC;
        Rules[0x0526] = VGPR64_N_DEC;
        Rules[0x0527] = VGPR64_R_DEC;
        Rules[0x0528] = VGPRy_B_DEC;
        Rules[0x0529] = VGPRy_N_DEC;
        Rules[0x052a] = VGPRy_R_DEC;
        Rules[0x032b] = VMODRM_MOD_ENCODE_ENC;
        Rules[0x052c] = VMODRM_XMM_DEC;
        Rules[0x052d] = VMODRM_YMM_DEC;
        Rules[0x052e] = VSIB_BASE_DEC;
        Rules[0x032f] = VSIB_ENC_ENC;
        Rules[0x0330] = VSIB_ENC_BASE_ENC;
        Rules[0x0331] = VSIB_ENC_INDEX_XMM_ENC;
        Rules[0x0332] = VSIB_ENC_INDEX_YMM_ENC;
        Rules[0x0333] = VSIB_ENC_SCALE_ENC;
        Rules[0x0534] = VSIB_INDEX_XMM_DEC;
        Rules[0x0535] = VSIB_INDEX_YMM_DEC;
        Rules[0x0536] = VSIB_XMM_DEC;
        Rules[0x0537] = VSIB_YMM_DEC;
        Rules[0x0538] = X87_DEC;
        Rules[0x0539] = XMM_B_DEC;
        Rules[0x053a] = XMM_B_32_DEC;
        Rules[0x053b] = XMM_B_64_DEC;
        Rules[0x053c] = XMM_B3_DEC;
        Rules[0x053d] = XMM_B3_32_DEC;
        Rules[0x053e] = XMM_B3_64_DEC;
        Rules[0x053f] = XMM_N_DEC;
        Rules[0x0540] = XMM_N_32_DEC;
        Rules[0x0541] = XMM_N_64_DEC;
        Rules[0x0542] = XMM_N3_DEC;
        Rules[0x0543] = XMM_N3_32_DEC;
        Rules[0x0544] = XMM_N3_64_DEC;
        Rules[0x0545] = XMM_R_DEC;
        Rules[0x0546] = XMM_R_32_DEC;
        Rules[0x0547] = XMM_R_64_DEC;
        Rules[0x0548] = XMM_R3_DEC;
        Rules[0x0549] = XMM_R3_32_DEC;
        Rules[0x054a] = XMM_R3_64_DEC;
        Rules[0x054b] = XMM_SE_DEC;
        Rules[0x054c] = XMM_SE32_DEC;
        Rules[0x054d] = XMM_SE64_DEC;
        Rules[0x0350] = XOP_MAP_ENC_ENC;
        Rules[0x0351] = XOP_REXXB_ENC_ENC;
        Rules[0x0352] = XOP_TYPE_ENC_ENC;
        Rules[0x0553] = YMM_B_DEC;
        Rules[0x0554] = YMM_B_32_DEC;
        Rules[0x0555] = YMM_B_64_DEC;
        Rules[0x0556] = YMM_B3_DEC;
        Rules[0x0557] = YMM_B3_32_DEC;
        Rules[0x0558] = YMM_B3_64_DEC;
        Rules[0x0559] = YMM_N_DEC;
        Rules[0x055a] = YMM_N_32_DEC;
        Rules[0x055b] = YMM_N_64_DEC;
        Rules[0x055c] = YMM_N3_DEC;
        Rules[0x055d] = YMM_N3_32_DEC;
        Rules[0x055e] = YMM_N3_64_DEC;
        Rules[0x055f] = YMM_R_DEC;
        Rules[0x0560] = YMM_R_32_DEC;
        Rules[0x0561] = YMM_R_64_DEC;
        Rules[0x0562] = YMM_R3_DEC;
        Rules[0x0563] = YMM_R3_32_DEC;
        Rules[0x0564] = YMM_R3_64_DEC;
        Rules[0x0565] = YMM_SE_DEC;
        Rules[0x0566] = YMM_SE32_DEC;
        Rules[0x0567] = YMM_SE64_DEC;
        Rules[0x0568] = ZMM_B3_DEC;
        Rules[0x0569] = ZMM_B3_32_DEC;
        Rules[0x056a] = ZMM_B3_64_DEC;
        Rules[0x056b] = ZMM_N3_DEC;
        Rules[0x056c] = ZMM_N3_32_DEC;
        Rules[0x056d] = ZMM_N3_64_DEC;
        Rules[0x056e] = ZMM_R3_DEC;
        Rules[0x056f] = ZMM_R3_32_DEC;
        Rules[0x0570] = ZMM_R3_64_DEC;
        Rules[0x0571] = XSAVE_DEC;
        Rules[0x0371] = XSAVE_ENC;

    }
    public void A_GPR_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=ArAX()
        // REXB=0 RM=1 => OUTREG=ArCX()
        // REXB=0 RM=2 => OUTREG=ArDX()
        // REXB=0 RM=3 => OUTREG=ArBX()
        // REXB=0 RM=4 => OUTREG=ArSP()
        // REXB=0 RM=5 => OUTREG=ArBP()
        // REXB=0 RM=6 => OUTREG=ArSI()
        // REXB=0 RM=7 => OUTREG=ArDI()
        // REXB=1 RM=0 => OUTREG=Ar8()
        // REXB=1 RM=1 => OUTREG=Ar9()
        // REXB=1 RM=2 => OUTREG=Ar10()
        // REXB=1 RM=3 => OUTREG=Ar11()
        // REXB=1 RM=4 => OUTREG=Ar12()
        // REXB=1 RM=5 => OUTREG=Ar13()
        // REXB=1 RM=6 => OUTREG=Ar14()
        // REXB=1 RM=7 => OUTREG=Ar15()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.A_GPR_B));
    }

    public void A_GPR_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=ArAX()
        // REXR=0 REG=1 => OUTREG=ArCX()
        // REXR=0 REG=2 => OUTREG=ArDX()
        // REXR=0 REG=3 => OUTREG=ArBX()
        // REXR=0 REG=4 => OUTREG=ArSP()
        // REXR=0 REG=5 => OUTREG=ArBP()
        // REXR=0 REG=6 => OUTREG=ArSI()
        // REXR=0 REG=7 => OUTREG=ArDI()
        // REXR=1 REG=0 => OUTREG=Ar8()
        // REXR=1 REG=1 => OUTREG=Ar9()
        // REXR=1 REG=2 => OUTREG=Ar10()
        // REXR=1 REG=3 => OUTREG=Ar11()
        // REXR=1 REG=4 => OUTREG=Ar12()
        // REXR=1 REG=5 => OUTREG=Ar13()
        // REXR=1 REG=6 => OUTREG=Ar14()
        // REXR=1 REG=7 => OUTREG=Ar15()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.A_GPR_R));
    }

    public void Ar10_DEC()
    {
        // EASZ=1 => OUTREG=R10W
        // EASZ=2 => OUTREG=R10D
        // EASZ=3 => OUTREG=R10
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar10));
    }

    public void Ar11_DEC()
    {
        // EASZ=1 => OUTREG=R11W
        // EASZ=2 => OUTREG=R11D
        // EASZ=3 => OUTREG=R11
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar11));
    }

    public void Ar12_DEC()
    {
        // EASZ=1 => OUTREG=R12W
        // EASZ=2 => OUTREG=R12D
        // EASZ=3 => OUTREG=R12
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar12));
    }

    public void Ar13_DEC()
    {
        // EASZ=1 => OUTREG=R13W
        // EASZ=2 => OUTREG=R13D
        // EASZ=3 => OUTREG=R13
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar13));
    }

    public void Ar14_DEC()
    {
        // EASZ=1 => OUTREG=R14W
        // EASZ=2 => OUTREG=R14D
        // EASZ=3 => OUTREG=R14
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar14));
    }

    public void Ar15_DEC()
    {
        // EASZ=1 => OUTREG=R15W
        // EASZ=2 => OUTREG=R15D
        // EASZ=3 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar15));
    }

    public void Ar8_DEC()
    {
        // EASZ=1 => OUTREG=R8W
        // EASZ=2 => OUTREG=R8D
        // EASZ=3 => OUTREG=R8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar8));
    }

    public void Ar9_DEC()
    {
        // EASZ=1 => OUTREG=R9W
        // EASZ=2 => OUTREG=R9D
        // EASZ=3 => OUTREG=R9
        Context.RuleActivated((RuleTableKind.DEC,RuleName.Ar9));
    }

    public void ArAX_DEC()
    {
        // EASZ=1 => OUTREG=AX
        // EASZ=2 => OUTREG=EAX
        // EASZ=3 => OUTREG=RAX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArAX));
    }

    public void ArBP_DEC()
    {
        // EASZ=1 => OUTREG=BP
        // EASZ=2 => OUTREG=EBP
        // EASZ=3 => OUTREG=RBP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArBP));
    }

    public void ArBX_DEC()
    {
        // EASZ=1 => OUTREG=BX
        // EASZ=2 => OUTREG=EBX
        // EASZ=3 => OUTREG=RBX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArBX));
    }

    public void ArCX_DEC()
    {
        // EASZ=1 => OUTREG=CX
        // EASZ=2 => OUTREG=ECX
        // EASZ=3 => OUTREG=RCX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArCX));
    }

    public void ArDI_DEC()
    {
        // EASZ=1 => OUTREG=DI
        // EASZ=2 => OUTREG=EDI
        // EASZ=3 => OUTREG=RDI
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArDI));
    }

    public void ArDX_DEC()
    {
        // EASZ=1 => OUTREG=DX
        // EASZ=2 => OUTREG=EDX
        // EASZ=3 => OUTREG=RDX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArDX));
    }

    public void ArSI_DEC()
    {
        // EASZ=1 => OUTREG=SI
        // EASZ=2 => OUTREG=ESI
        // EASZ=3 => OUTREG=RSI
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArSI));
    }

    public void ArSP_DEC()
    {
        // EASZ=1 => OUTREG=SP
        // EASZ=2 => OUTREG=ESP
        // EASZ=3 => OUTREG=RSP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ArSP));
    }

    public void ASZ_NONTERM_DEC()
    {
        // MODE=0 ASZ=0 => EASZ=1
        // MODE=0 ASZ=1 => EASZ=2
        // MODE=1 ASZ=0 => EASZ=2
        // MODE=1 ASZ=1 => EASZ=1
        // MODE=2 ASZ=0 => EASZ=3
        // MODE=2 ASZ=1 => EASZ=2
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ASZ_NONTERM));
    }

    public void AVX_SPLITTER_DEC()
    {
        // VEXVALID=3 XOP_INSTRUCTIONS() => VEXVALID=3 XOP_INSTRUCTIONS() =>
        // VEXVALID=0 INSTRUCTIONS() => VEXVALID=0 INSTRUCTIONS() =>
        // VEXVALID=1 AVX_INSTRUCTIONS() => VEXVALID=1 AVX_INSTRUCTIONS() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.AVX_SPLITTER));
    }

    public void AVX512_EVEX_BYTE3_ENC_ENC()
    {
        // ZEROING[z] LLRC[nn] BCRC[b] VEXDEST4=0 MASK[aaa] => z_nn_b 0b0000_1 aaa
        // ZEROING[z] LLRC[nn] BCRC[b] VEXDEST4=1 MASK[aaa] => z_nn_b 0b0000_0 aaa
        Context.RuleActivated((RuleTableKind.ENC,RuleName.AVX512_EVEX_BYTE3_ENC));
    }

    public void AVX512_ROUND_DEC()
    {
        // LLRC=0 => ROUNDC=1 SAE=1
        // LLRC=1 => ROUNDC=2 SAE=1
        // LLRC=2 => ROUNDC=3 SAE=1
        // LLRC=3 => ROUNDC=4 SAE=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.AVX512_ROUND));
    }

    public void AVX512_ROUND_ENC()
    {
        // ROUNDC=1 => LLRC=0 BCRC=1
        // ROUNDC=2 => LLRC=1 BCRC=1
        // ROUNDC=3 => LLRC=2 BCRC=1
        // ROUNDC=4 => LLRC=3 BCRC=1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.AVX512_ROUND));
    }

    public void BND_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=BND0
        // REXB=0 RM=1 => OUTREG=BND1
        // REXB=0 RM=2 => OUTREG=BND2
        // REXB=0 RM=3 => OUTREG=BND3
        // REXB=0 RM=4 => OUTREG=ERROR ENCODER_PREFERRED=1
        // REXB=0 RM=5 => OUTREG=ERROR
        // REXB=0 RM=6 => OUTREG=ERROR
        // REXB=0 RM=7 => OUTREG=ERROR
        // REXB=1 RM=0 => OUTREG=ERROR
        // REXB=1 RM=1 => OUTREG=ERROR
        // REXB=1 RM=2 => OUTREG=ERROR
        // REXB=1 RM=3 => OUTREG=ERROR
        // REXB=1 RM=4 => OUTREG=ERROR
        // REXB=1 RM=5 => OUTREG=ERROR
        // REXB=1 RM=6 => OUTREG=ERROR
        // REXB=1 RM=7 => OUTREG=ERROR
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BND_B));
    }

    public void BND_B_CHECK_DEC()
    {
        // REXB=0 RM=0 => REXB=0 RM=0 =>
        // REXB=0 RM=1 => REXB=0 RM=1 =>
        // REXB=0 RM=2 => REXB=0 RM=2 =>
        // REXB=0 RM=3 => REXB=0 RM=3 =>
        // REXB=0 RM=4 => error
        // REXB=0 RM=5 => error
        // REXB=0 RM=6 => error
        // REXB=0 RM=7 => error
        // REXB=1 RM=0 => error
        // REXB=1 RM=1 => error
        // REXB=1 RM=2 => error
        // REXB=1 RM=3 => error
        // REXB=1 RM=4 => error
        // REXB=1 RM=5 => error
        // REXB=1 RM=6 => error
        // REXB=1 RM=7 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BND_B_CHECK));
    }

    public void BND_B_CHECK_ENC()
    {
        // REXB=0 RM=0 => null
        // REXB=0 RM=1 => null
        // REXB=0 RM=2 => null
        // REXB=0 RM=3 => null
        // REXB=0 RM=4 => error
        // REXB=0 RM=5 => error
        // REXB=0 RM=6 => error
        // REXB=0 RM=7 => error
        // REXB=1 RM=0 => error
        // REXB=1 RM=1 => error
        // REXB=1 RM=2 => error
        // REXB=1 RM=3 => error
        // REXB=1 RM=4 => error
        // REXB=1 RM=5 => error
        // REXB=1 RM=6 => error
        // REXB=1 RM=7 => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.BND_B_CHECK));
    }

    public void BND_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=BND0
        // REXR=0 REG=1 => OUTREG=BND1
        // REXR=0 REG=2 => OUTREG=BND2
        // REXR=0 REG=3 => OUTREG=BND3
        // REXR=0 REG=4 => OUTREG=ERROR ENCODER_PREFERRED=1
        // REXR=0 REG=5 => OUTREG=ERROR
        // REXR=0 REG=6 => OUTREG=ERROR
        // REXR=0 REG=7 => OUTREG=ERROR
        // REXR=1 REG=0 => OUTREG=ERROR
        // REXR=1 REG=1 => OUTREG=ERROR
        // REXR=1 REG=2 => OUTREG=ERROR
        // REXR=1 REG=3 => OUTREG=ERROR
        // REXR=1 REG=4 => OUTREG=ERROR
        // REXR=1 REG=5 => OUTREG=ERROR
        // REXR=1 REG=6 => OUTREG=ERROR
        // REXR=1 REG=7 => OUTREG=ERROR
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BND_R));
    }

    public void BND_R_CHECK_DEC()
    {
        // REXR=0 REG=0 => REXR=0 REG=0 =>
        // REXR=0 REG=1 => REXR=0 REG=1 =>
        // REXR=0 REG=2 => REXR=0 REG=2 =>
        // REXR=0 REG=3 => REXR=0 REG=3 =>
        // REXR=0 REG=4 => error
        // REXR=0 REG=5 => error
        // REXR=0 REG=6 => error
        // REXR=0 REG=7 => error
        // REXR=1 REG=0 => error
        // REXR=1 REG=1 => error
        // REXR=1 REG=2 => error
        // REXR=1 REG=3 => error
        // REXR=1 REG=4 => error
        // REXR=1 REG=5 => error
        // REXR=1 REG=6 => error
        // REXR=1 REG=7 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BND_R_CHECK));
    }

    public void BND_R_CHECK_ENC()
    {
        // REXR=0 REG=0 => null
        // REXR=0 REG=1 => null
        // REXR=0 REG=2 => null
        // REXR=0 REG=3 => null
        // REXR=0 REG=4 => error
        // REXR=0 REG=5 => error
        // REXR=0 REG=6 => error
        // REXR=0 REG=7 => error
        // REXR=1 REG=0 => error
        // REXR=1 REG=1 => error
        // REXR=1 REG=2 => error
        // REXR=1 REG=3 => error
        // REXR=1 REG=4 => error
        // REXR=1 REG=5 => error
        // REXR=1 REG=6 => error
        // REXR=1 REG=7 => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.BND_R_CHECK));
    }

    public void BRANCH_HINT_DEC()
    {
        // HINT=0 => HINT=0 =>
        // HINT=1 => HINT=3
        // HINT=2 => HINT=4
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BRANCH_HINT));
    }

    public void BRANCH_HINT_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.BRANCH_HINT));
    }

    public void BRDISP32_DEC()
    {
        // d/32 => BRDISP_WIDTH=32
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BRDISP32));
    }

    public void BRDISP8_DEC()
    {
        // d/8 => BRDISP_WIDTH=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BRDISP8));
    }

    public void BRDISPz_DEC()
    {
        // EOSZ=1 d/16 => BRDISP_WIDTH=16
        // EOSZ=2 d/32 => BRDISP_WIDTH=32
        // EOSZ=3 d/32 => BRDISP_WIDTH=32
        Context.RuleActivated((RuleTableKind.DEC,RuleName.BRDISPz));
    }

    public void CET_NO_TRACK_DEC()
    {
        // HINT=0 => HINT=0 =>
        // HINT=1 => HINT=1 =>
        // HINT=2 => HINT=5
        Context.RuleActivated((RuleTableKind.DEC,RuleName.CET_NO_TRACK));
    }

    public void CET_NO_TRACK_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.CET_NO_TRACK));
    }

    public void CR_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=CR0
        // REXB=0 RM=1 => OUTREG=ERROR ENCODER_PREFERRED=1
        // REXB=0 RM=2 => OUTREG=CR2
        // REXB=0 RM=3 => OUTREG=CR3
        // REXB=0 RM=4 => OUTREG=CR4
        // REXB=0 RM=5 => OUTREG=ERROR
        // REXB=0 RM=6 => OUTREG=ERROR
        // REXB=0 RM=7 => OUTREG=ERROR
        // REXB=1 RM=0 => OUTREG=CR8
        // REXB=1 RM=1 => OUTREG=ERROR
        // REXB=1 RM=2 => OUTREG=ERROR
        // REXB=1 RM=3 => OUTREG=ERROR
        // REXB=1 RM=4 => OUTREG=ERROR
        // REXB=1 RM=5 => OUTREG=ERROR
        // REXB=1 RM=6 => OUTREG=ERROR
        // REXB=1 RM=7 => OUTREG=ERROR
        Context.RuleActivated((RuleTableKind.DEC,RuleName.CR_B));
    }

    public void CR_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=CR0
        // REXR=0 REG=1 => OUTREG=ERROR ENCODER_PREFERRED=1
        // REXR=0 REG=2 => OUTREG=CR2
        // REXR=0 REG=3 => OUTREG=CR3
        // REXR=0 REG=4 => OUTREG=CR4
        // REXR=0 REG=5 => OUTREG=ERROR
        // REXR=0 REG=6 => OUTREG=ERROR
        // REXR=0 REG=7 => OUTREG=ERROR
        // REXR=1 REG=0 => OUTREG=CR8
        // REXR=1 REG=1 => OUTREG=ERROR
        // REXR=1 REG=2 => OUTREG=ERROR
        // REXR=1 REG=3 => OUTREG=ERROR
        // REXR=1 REG=4 => OUTREG=ERROR
        // REXR=1 REG=5 => OUTREG=ERROR
        // REXR=1 REG=6 => OUTREG=ERROR
        // REXR=1 REG=7 => OUTREG=ERROR
        Context.RuleActivated((RuleTableKind.DEC,RuleName.CR_R));
    }

    public void CR_WIDTH_DEC()
    {
        // MODE=0 => EOSZ=2 DF32=1 OSZ=0
        // MODE=1 => EOSZ=2 DF32=1 OSZ=0
        // MODE=2 => EOSZ=3 DF64=1 OSZ=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.CR_WIDTH));
    }

    public void CR_WIDTH_ENC()
    {
        // MODE=0 => DF32=1 EOSZ=2
        // MODE=1 => null
        // MODE=2 => DF64=1 EOSZ=3
        Context.RuleActivated((RuleTableKind.ENC,RuleName.CR_WIDTH));
    }

    public void DF64_DEC()
    {
        // MODE=0 => MODE=0 =>
        // MODE=1 => MODE=1 =>
        // MODE=2 OSZ=1 REXW=0 => EOSZ=1 DF64=1
        // MODE=2 OSZ=0 REXW=0 => EOSZ=3 DF64=1
        // MODE=2 OSZ=1 REXW=1 => EOSZ=3 DF64=1
        // MODE=2 OSZ=0 REXW=1 => EOSZ=3 DF64=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.DF64));
    }

    public void DF64_ENC()
    {
        // MODE=0 => null
        // MODE=1 => null
        // MODE=2 => DF64=1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DF64));
    }

    public void DISP_NT_ENC()
    {
        // DISP_WIDTH=8 d/8 => d/8
        // DISP_WIDTH=16 d/16 => d/16
        // DISP_WIDTH=32 d/32 => d/32
        // DISP_WIDTH=64 d/64 => d/64
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_NT));
    }

    public void DISP_WIDTH_0_ENC()
    {
        // DISP_WIDTH=0 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_WIDTH_0));
    }

    public void DISP_WIDTH_0_8_16_ENC()
    {
        // DISP_WIDTH=0 => null
        // DISP_WIDTH=8 => null
        // DISP_WIDTH=16 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_WIDTH_0_8_16));
    }

    public void DISP_WIDTH_0_8_32_ENC()
    {
        // DISP_WIDTH=0 => null
        // DISP_WIDTH=8 => null
        // DISP_WIDTH=32 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_WIDTH_0_8_32));
    }

    public void DISP_WIDTH_16_ENC()
    {
        // DISP_WIDTH=16 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_WIDTH_16));
    }

    public void DISP_WIDTH_32_ENC()
    {
        // DISP_WIDTH=32 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_WIDTH_32));
    }

    public void DISP_WIDTH_8_ENC()
    {
        // DISP_WIDTH=8 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_WIDTH_8));
    }

    public void DISP_WIDTH_8_32_ENC()
    {
        // DISP_WIDTH=8 => null
        // DISP_WIDTH=32 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.DISP_WIDTH_8_32));
    }

    public void DR_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=DR0
        // REXR=0 REG=1 => OUTREG=DR1
        // REXR=0 REG=2 => OUTREG=DR2
        // REXR=0 REG=3 => OUTREG=DR3
        // REXR=0 REG=4 => OUTREG=DR4
        // REXR=0 REG=5 => OUTREG=DR5
        // REXR=0 REG=6 => OUTREG=DR6
        // REXR=0 REG=7 => OUTREG=DR7
        // REXR=1 REG=0 => OUTREG=ERROR ENCODER_PREFERRED=1
        // REXR=1 REG=1 => OUTREG=ERROR
        // REXR=1 REG=2 => OUTREG=ERROR
        // REXR=1 REG=3 => OUTREG=ERROR
        // REXR=1 REG=4 => OUTREG=ERROR
        // REXR=1 REG=5 => OUTREG=ERROR
        // REXR=1 REG=6 => OUTREG=ERROR
        // REXR=1 REG=7 => OUTREG=ERROR
        Context.RuleActivated((RuleTableKind.DEC,RuleName.DR_R));
    }

    public void ERROR_ENC()
    {
        // else => ERROR=
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ERROR));
    }

    public void ESIZE_1_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_1_BITS));
    }

    public void ESIZE_1_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_1_BITS));
    }

    public void ESIZE_128_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=128
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_128_BITS));
    }

    public void ESIZE_128_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_128_BITS));
    }

    public void ESIZE_16_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=16
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_16_BITS));
    }

    public void ESIZE_16_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_16_BITS));
    }

    public void ESIZE_2_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=2
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_2_BITS));
    }

    public void ESIZE_2_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_2_BITS));
    }

    public void ESIZE_32_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=32
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_32_BITS));
    }

    public void ESIZE_32_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_32_BITS));
    }

    public void ESIZE_4_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=4
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_4_BITS));
    }

    public void ESIZE_4_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_4_BITS));
    }

    public void ESIZE_64_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=64
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_64_BITS));
    }

    public void ESIZE_64_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_64_BITS));
    }

    public void ESIZE_8_BITS_DEC()
    {
        // REX=0 => ELEMENT_SIZE=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ESIZE_8_BITS));
    }

    public void ESIZE_8_BITS_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.ESIZE_8_BITS));
    }

    public void EVEX_62_REXR_ENC_ENC()
    {
        // MODE=2 REXR=1 => 0x62 0b0000_0
        // MODE=2 REXR=0 => 0x62 0b0000_1
        // MODE=1 REXR=1 => error
        // MODE=1 REXR=0 => 0x62 0b0000_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_62_REXR_ENC));
    }

    public void EVEX_LL_ENC_ENC()
    {
        // ROUNDC=0 SAE=0 VL=0 => LLRC=0
        // ROUNDC=0 SAE=0 VL=1 => LLRC=1
        // ROUNDC=0 SAE=0 VL=2 => LLRC=2
        // ROUNDC=0 SAE=1 VL=0 => LLRC=0 BCRC=1
        // ROUNDC=1 SAE=1 VL=0 => LLRC=0 BCRC=1
        // ROUNDC=2 SAE=1 VL=0 => LLRC=1 BCRC=1
        // ROUNDC=3 SAE=1 VL=0 => LLRC=2 BCRC=1
        // ROUNDC=4 SAE=1 VL=0 => LLRC=3 BCRC=1
        // ROUNDC=0 SAE=1 VL=2 => LLRC=0 BCRC=1
        // ROUNDC=1 SAE=1 VL=2 => LLRC=0 BCRC=1
        // ROUNDC=2 SAE=1 VL=2 => LLRC=1 BCRC=1
        // ROUNDC=3 SAE=1 VL=2 => LLRC=2 BCRC=1
        // ROUNDC=4 SAE=1 VL=2 => LLRC=3 BCRC=1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_LL_ENC));
    }

    public void EVEX_U_ENC_ENC()
    {
        // false => UBIT=1 0b0000_1
        // else => UBIT=1 0b0000_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_U_ENC));
    }

    public void EVEX_PP_ENC_ENC()
    {
        // VEX_PREFIX=0 => 0b0000_0
        // VEX_PREFIX=1 => 0b0000_1
        // VEX_PREFIX=3 => 0b0001_0
        // VEX_PREFIX=2 => 0b0001_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_PP_ENC));
    }

    public void EVEX_MAP_ENC_ENC()
    {
        // MAP=0 => 0b0000_0
        // MAP=1 => 0b0000_1
        // MAP=2 => 0b0001_0
        // MAP=3 => 0b0001_1
        // MAP=4 => error
        // MAP=5 => 0b0010_1
        // MAP=6 => 0b0011_0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_MAP_ENC));
    }

    public void EVEX_REXB_ENC_ENC()
    {
        // MODE=2 REXB=1 => 0b0000_0
        // MODE=2 REXB=0 => 0b0000_1
        // MODE=1 REXB=1 => error
        // MODE=1 REXB=0 => 0b0000_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_REXB_ENC));
    }

    public void EVEX_REXRR_ENC_ENC()
    {
        // MODE=2 REXRR=1 => 0b0000_0
        // MODE=2 REXRR=0 => 0b0000_1
        // MODE=1 REXRR=1 => error
        // MODE=1 REXRR=0 => 0b0000_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_REXRR_ENC));
    }

    public void EVEX_REXW_VVVV_ENC_ENC()
    {
        // DUMMY=0 REXW[w] VEXDEST3[u] VEXDEST210[ddd] => w u_ddd
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_REXW_VVVV_ENC));
    }

    public void EVEX_REXX_ENC_ENC()
    {
        // MODE=2 REXX=1 => 0b0000_0
        // MODE=2 REXX=0 => 0b0000_1
        // MODE=1 REXX=1 => error
        // MODE=1 REXX=0 => 0b0000_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.EVEX_REXX_ENC));
    }

    public void EVEX_SPLITTER_DEC()
    {
        // VEXVALID=3 XOP_INSTRUCTIONS() => VEXVALID=3 XOP_INSTRUCTIONS() =>
        // VEXVALID=0 INSTRUCTIONS() => VEXVALID=0 INSTRUCTIONS() =>
        // VEXVALID=1 AVX_INSTRUCTIONS() => VEXVALID=1 AVX_INSTRUCTIONS() =>
        // VEXVALID=2 EVEX_INSTRUCTIONS() => VEXVALID=2 EVEX_INSTRUCTIONS() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.EVEX_SPLITTER));
    }

    public void FINAL_DSEG_DEC()
    {
        // MODE=0 => OUTREG=FINAL_DSEG_NOT64()
        // MODE=1 => OUTREG=FINAL_DSEG_NOT64()
        // MODE=2 => OUTREG=FINAL_DSEG_MODE64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_DSEG));
    }

    public void FINAL_DSEG_MODE64_DEC()
    {
        // SEG_OVD=0 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1 ENCODER_PREFERRED=1
        // SEG_OVD=1 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        // SEG_OVD=2 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        // SEG_OVD=3 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        // SEG_OVD=4 => OUTREG=FS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=5 => OUTREG=GS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=6 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_DSEG_MODE64));
    }

    public void FINAL_DSEG_NOT64_DEC()
    {
        // SEG_OVD=0 => OUTREG=DS USING_DEFAULT_SEGMENT0=1 ENCODER_PREFERRED=1
        // SEG_OVD=1 => OUTREG=CS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=2 => OUTREG=DS USING_DEFAULT_SEGMENT0=1
        // SEG_OVD=3 => OUTREG=ES USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=4 => OUTREG=FS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=5 => OUTREG=GS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=6 => OUTREG=SS USING_DEFAULT_SEGMENT0=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_DSEG_NOT64));
    }

    public void FINAL_DSEG1_DEC()
    {
        // MODE=0 => OUTREG=FINAL_DSEG1_NOT64()
        // MODE=1 => OUTREG=FINAL_DSEG1_NOT64()
        // MODE=2 => OUTREG=FINAL_DSEG1_MODE64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_DSEG1));
    }

    public void FINAL_DSEG1_MODE64_DEC()
    {
        // SEG_OVD=0 => OUTREG=INVALID USING_DEFAULT_SEGMENT1=1 ENCODER_PREFERRED=1
        // SEG_OVD=1 => OUTREG=INVALID USING_DEFAULT_SEGMENT1=1
        // SEG_OVD=2 => OUTREG=INVALID USING_DEFAULT_SEGMENT1=1
        // SEG_OVD=3 => OUTREG=INVALID USING_DEFAULT_SEGMENT1=1
        // SEG_OVD=4 => OUTREG=FS USING_DEFAULT_SEGMENT1=0
        // SEG_OVD=5 => OUTREG=GS USING_DEFAULT_SEGMENT1=0
        // SEG_OVD=6 => OUTREG=INVALID USING_DEFAULT_SEGMENT1=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_DSEG1_MODE64));
    }

    public void FINAL_DSEG1_NOT64_DEC()
    {
        // SEG_OVD=0 => OUTREG=DS USING_DEFAULT_SEGMENT1=1 ENCODER_PREFERRED=1
        // SEG_OVD=1 => OUTREG=CS USING_DEFAULT_SEGMENT1=0
        // SEG_OVD=2 => OUTREG=DS USING_DEFAULT_SEGMENT1=1
        // SEG_OVD=3 => OUTREG=ES USING_DEFAULT_SEGMENT1=0
        // SEG_OVD=4 => OUTREG=FS USING_DEFAULT_SEGMENT1=0
        // SEG_OVD=5 => OUTREG=GS USING_DEFAULT_SEGMENT1=0
        // SEG_OVD=6 => OUTREG=SS USING_DEFAULT_SEGMENT1=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_DSEG1_NOT64));
    }

    public void FINAL_ESEG_DEC()
    {
        // MODE=0 => OUTREG=ES USING_DEFAULT_SEGMENT0=1
        // MODE=1 => OUTREG=ES USING_DEFAULT_SEGMENT0=1
        // MODE=2 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_ESEG));
    }

    public void FINAL_ESEG1_DEC()
    {
        // MODE=0 => OUTREG=ES USING_DEFAULT_SEGMENT1=1
        // MODE=1 => OUTREG=ES USING_DEFAULT_SEGMENT1=1
        // MODE=2 => OUTREG=INVALID USING_DEFAULT_SEGMENT1=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_ESEG1));
    }

    public void FINAL_SSEG_DEC()
    {
        // MODE=0 => OUTREG=FINAL_SSEG_NOT64()
        // MODE=1 => OUTREG=FINAL_SSEG_NOT64()
        // MODE=2 => OUTREG=FINAL_SSEG_MODE64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_SSEG));
    }

    public void FINAL_SSEG_MODE64_DEC()
    {
        // SEG_OVD=0 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1 ENCODER_PREFERRED=1
        // SEG_OVD=1 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        // SEG_OVD=2 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        // SEG_OVD=3 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        // SEG_OVD=4 => OUTREG=FS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=5 => OUTREG=GS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=6 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_SSEG_MODE64));
    }

    public void FINAL_SSEG_NOT64_DEC()
    {
        // SEG_OVD=0 => OUTREG=SS USING_DEFAULT_SEGMENT0=1 ENCODER_PREFERRED=1
        // SEG_OVD=1 => OUTREG=CS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=2 => OUTREG=DS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=3 => OUTREG=ES USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=4 => OUTREG=FS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=5 => OUTREG=GS USING_DEFAULT_SEGMENT0=0
        // SEG_OVD=6 => OUTREG=SS USING_DEFAULT_SEGMENT0=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_SSEG_NOT64));
    }

    public void FINAL_SSEG0_DEC()
    {
        // MODE=0 => OUTREG=SS USING_DEFAULT_SEGMENT0=1
        // MODE=1 => OUTREG=SS USING_DEFAULT_SEGMENT0=1
        // MODE=2 => OUTREG=INVALID USING_DEFAULT_SEGMENT0=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_SSEG0));
    }

    public void FINAL_SSEG1_DEC()
    {
        // MODE=0 => OUTREG=SS USING_DEFAULT_SEGMENT1=1
        // MODE=1 => OUTREG=SS USING_DEFAULT_SEGMENT1=1
        // MODE=2 => OUTREG=INVALID USING_DEFAULT_SEGMENT1=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FINAL_SSEG1));
    }

    public void FIX_ROUND_LEN128_DEC()
    {
        // MODE=0 => VL=0
        // MODE=1 => VL=0
        // MODE=2 => VL=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FIX_ROUND_LEN128));
    }

    public void FIX_ROUND_LEN128_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.FIX_ROUND_LEN128));
    }

    public void FIX_ROUND_LEN512_DEC()
    {
        // MODE=0 => VL=2
        // MODE=1 => VL=2
        // MODE=2 => VL=2
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FIX_ROUND_LEN512));
    }

    public void FIX_ROUND_LEN512_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.FIX_ROUND_LEN512));
    }

    public void FIXUP_EASZ_ENC_ENC()
    {
        // MODE=0 EASZ=0 => EASZ=1
        // MODE=1 EASZ=0 => EASZ=2
        // MODE=2 EASZ=0 => EASZ=3
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.FIXUP_EASZ_ENC));
    }

    public void FIXUP_EOSZ_ENC_ENC()
    {
        // MODE=0 EOSZ=0 => EOSZ=1
        // MODE=1 EOSZ=0 => EOSZ=2
        // MODE=2 EOSZ=0 => EOSZ=2
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.FIXUP_EOSZ_ENC));
    }

    public void FIXUP_SMODE_ENC_ENC()
    {
        // MODE=2 SMODE=0 => SMODE=2
        // MODE=2 SMODE=1 => error
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.FIXUP_SMODE_ENC));
    }

    public void FORCE64_DEC()
    {
        // MODE=2 => EOSZ=3 OSZ=0
        // else => else =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.FORCE64));
    }

    public void FORCE64_ENC()
    {
        // else => DF64=1 EOSZ=3
        Context.RuleActivated((RuleTableKind.ENC,RuleName.FORCE64));
    }

    public void GPR16_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=AX
        // REXB=0 RM=1 => OUTREG=CX
        // REXB=0 RM=2 => OUTREG=DX
        // REXB=0 RM=3 => OUTREG=BX
        // REXB=0 RM=4 => OUTREG=SP
        // REXB=0 RM=5 => OUTREG=BP
        // REXB=0 RM=6 => OUTREG=SI
        // REXB=0 RM=7 => OUTREG=DI
        // REXB=1 RM=0 => OUTREG=R8W
        // REXB=1 RM=1 => OUTREG=R9W
        // REXB=1 RM=2 => OUTREG=R10W
        // REXB=1 RM=3 => OUTREG=R11W
        // REXB=1 RM=4 => OUTREG=R12W
        // REXB=1 RM=5 => OUTREG=R13W
        // REXB=1 RM=6 => OUTREG=R14W
        // REXB=1 RM=7 => OUTREG=R15W
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR16_B));
    }

    public void GPR16_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=AX
        // REXR=0 REG=1 => OUTREG=CX
        // REXR=0 REG=2 => OUTREG=DX
        // REXR=0 REG=3 => OUTREG=BX
        // REXR=0 REG=4 => OUTREG=SP
        // REXR=0 REG=5 => OUTREG=BP
        // REXR=0 REG=6 => OUTREG=SI
        // REXR=0 REG=7 => OUTREG=DI
        // REXR=1 REG=0 => OUTREG=R8W
        // REXR=1 REG=1 => OUTREG=R9W
        // REXR=1 REG=2 => OUTREG=R10W
        // REXR=1 REG=3 => OUTREG=R11W
        // REXR=1 REG=4 => OUTREG=R12W
        // REXR=1 REG=5 => OUTREG=R13W
        // REXR=1 REG=6 => OUTREG=R14W
        // REXR=1 REG=7 => OUTREG=R15W
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR16_R));
    }

    public void GPR16_SB_DEC()
    {
        // REXB=0 SRM=0 => OUTREG=AX
        // REXB=0 SRM=1 => OUTREG=CX
        // REXB=0 SRM=2 => OUTREG=DX
        // REXB=0 SRM=3 => OUTREG=BX
        // REXB=0 SRM=4 => OUTREG=SP
        // REXB=0 SRM=5 => OUTREG=BP
        // REXB=0 SRM=6 => OUTREG=SI
        // REXB=0 SRM=7 => OUTREG=DI
        // REXB=1 SRM=0 => OUTREG=R8W
        // REXB=1 SRM=1 => OUTREG=R9W
        // REXB=1 SRM=2 => OUTREG=R10W
        // REXB=1 SRM=3 => OUTREG=R11W
        // REXB=1 SRM=4 => OUTREG=R12W
        // REXB=1 SRM=5 => OUTREG=R13W
        // REXB=1 SRM=6 => OUTREG=R14W
        // REXB=1 SRM=7 => OUTREG=R15W
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR16_SB));
    }

    public void GPR16e_ENC()
    {
        // OUTREG=AX => null
        // OUTREG=BX => null
        // OUTREG=CX => null
        // OUTREG=DX => null
        // OUTREG=SP => null
        // OUTREG=BP => null
        // OUTREG=SI => null
        // OUTREG=DI => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR16e));
    }

    public void GPR32_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=EAX
        // REXB=0 RM=1 => OUTREG=ECX
        // REXB=0 RM=2 => OUTREG=EDX
        // REXB=0 RM=3 => OUTREG=EBX
        // REXB=0 RM=4 => OUTREG=ESP
        // REXB=0 RM=5 => OUTREG=EBP
        // REXB=0 RM=6 => OUTREG=ESI
        // REXB=0 RM=7 => OUTREG=EDI
        // REXB=1 RM=0 => OUTREG=R8D
        // REXB=1 RM=1 => OUTREG=R9D
        // REXB=1 RM=2 => OUTREG=R10D
        // REXB=1 RM=3 => OUTREG=R11D
        // REXB=1 RM=4 => OUTREG=R12D
        // REXB=1 RM=5 => OUTREG=R13D
        // REXB=1 RM=6 => OUTREG=R14D
        // REXB=1 RM=7 => OUTREG=R15D
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR32_B));
    }

    public void GPR32_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=EAX
        // REXR=0 REG=1 => OUTREG=ECX
        // REXR=0 REG=2 => OUTREG=EDX
        // REXR=0 REG=3 => OUTREG=EBX
        // REXR=0 REG=4 => OUTREG=ESP
        // REXR=0 REG=5 => OUTREG=EBP
        // REXR=0 REG=6 => OUTREG=ESI
        // REXR=0 REG=7 => OUTREG=EDI
        // REXR=1 REG=0 => OUTREG=R8D
        // REXR=1 REG=1 => OUTREG=R9D
        // REXR=1 REG=2 => OUTREG=R10D
        // REXR=1 REG=3 => OUTREG=R11D
        // REXR=1 REG=4 => OUTREG=R12D
        // REXR=1 REG=5 => OUTREG=R13D
        // REXR=1 REG=6 => OUTREG=R14D
        // REXR=1 REG=7 => OUTREG=R15D
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR32_R));
    }

    public void GPR32_SB_DEC()
    {
        // REXB=0 SRM=0 => OUTREG=EAX
        // REXB=0 SRM=1 => OUTREG=ECX
        // REXB=0 SRM=2 => OUTREG=EDX
        // REXB=0 SRM=3 => OUTREG=EBX
        // REXB=0 SRM=4 => OUTREG=ESP
        // REXB=0 SRM=5 => OUTREG=EBP
        // REXB=0 SRM=6 => OUTREG=ESI
        // REXB=0 SRM=7 => OUTREG=EDI
        // REXB=1 SRM=0 => OUTREG=R8D
        // REXB=1 SRM=1 => OUTREG=R9D
        // REXB=1 SRM=2 => OUTREG=R10D
        // REXB=1 SRM=3 => OUTREG=R11D
        // REXB=1 SRM=4 => OUTREG=R12D
        // REXB=1 SRM=5 => OUTREG=R13D
        // REXB=1 SRM=6 => OUTREG=R14D
        // REXB=1 SRM=7 => OUTREG=R15D
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR32_SB));
    }

    public void GPR32_X_DEC()
    {
        // REXX=0 SIBINDEX=0 => OUTREG=EAX
        // REXX=0 SIBINDEX=1 => OUTREG=ECX
        // REXX=0 SIBINDEX=2 => OUTREG=EDX
        // REXX=0 SIBINDEX=3 => OUTREG=EBX
        // REXX=0 SIBINDEX=4 => OUTREG=INVALID
        // REXX=0 SIBINDEX=5 => OUTREG=EBP
        // REXX=0 SIBINDEX=6 => OUTREG=ESI
        // REXX=0 SIBINDEX=7 => OUTREG=EDI
        // REXX=1 SIBINDEX=0 => OUTREG=R8D
        // REXX=1 SIBINDEX=1 => OUTREG=R9D
        // REXX=1 SIBINDEX=2 => OUTREG=R10D
        // REXX=1 SIBINDEX=3 => OUTREG=R11D
        // REXX=1 SIBINDEX=4 => OUTREG=R12D
        // REXX=1 SIBINDEX=5 => OUTREG=R13D
        // REXX=1 SIBINDEX=6 => OUTREG=R14D
        // REXX=1 SIBINDEX=7 => OUTREG=R15D
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR32_X));
    }

    public void GPR32e_ENC()
    {
        // MODE=1 OUTREG=GPR32e_m32() => null
        // MODE=2 OUTREG=GPR32e_m64() => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR32e));
    }

    public void GPR32e_m32_ENC()
    {
        // OUTREG=EAX => null
        // OUTREG=EBX => null
        // OUTREG=ECX => null
        // OUTREG=EDX => null
        // OUTREG=ESP => null
        // OUTREG=EBP => null
        // OUTREG=ESI => null
        // OUTREG=EDI => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR32e_m32));
    }

    public void GPR32e_m64_ENC()
    {
        // OUTREG=EAX => null
        // OUTREG=EBX => null
        // OUTREG=ECX => null
        // OUTREG=EDX => null
        // OUTREG=ESP => null
        // OUTREG=EBP => null
        // OUTREG=ESI => null
        // OUTREG=EDI => null
        // OUTREG=R8D => null
        // OUTREG=R9D => null
        // OUTREG=R10D => null
        // OUTREG=R11D => null
        // OUTREG=R12D => null
        // OUTREG=R13D => null
        // OUTREG=R14D => null
        // OUTREG=R15D => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR32e_m64));
    }

    public void GPR64_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=RAX
        // REXB=0 RM=1 => OUTREG=RCX
        // REXB=0 RM=2 => OUTREG=RDX
        // REXB=0 RM=3 => OUTREG=RBX
        // REXB=0 RM=4 => OUTREG=RSP
        // REXB=0 RM=5 => OUTREG=RBP
        // REXB=0 RM=6 => OUTREG=RSI
        // REXB=0 RM=7 => OUTREG=RDI
        // REXB=1 RM=0 => OUTREG=R8
        // REXB=1 RM=1 => OUTREG=R9
        // REXB=1 RM=2 => OUTREG=R10
        // REXB=1 RM=3 => OUTREG=R11
        // REXB=1 RM=4 => OUTREG=R12
        // REXB=1 RM=5 => OUTREG=R13
        // REXB=1 RM=6 => OUTREG=R14
        // REXB=1 RM=7 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR64_B));
    }

    public void GPR64_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=RAX
        // REXR=0 REG=1 => OUTREG=RCX
        // REXR=0 REG=2 => OUTREG=RDX
        // REXR=0 REG=3 => OUTREG=RBX
        // REXR=0 REG=4 => OUTREG=RSP
        // REXR=0 REG=5 => OUTREG=RBP
        // REXR=0 REG=6 => OUTREG=RSI
        // REXR=0 REG=7 => OUTREG=RDI
        // REXR=1 REG=0 => OUTREG=R8
        // REXR=1 REG=1 => OUTREG=R9
        // REXR=1 REG=2 => OUTREG=R10
        // REXR=1 REG=3 => OUTREG=R11
        // REXR=1 REG=4 => OUTREG=R12
        // REXR=1 REG=5 => OUTREG=R13
        // REXR=1 REG=6 => OUTREG=R14
        // REXR=1 REG=7 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR64_R));
    }

    public void GPR64_SB_DEC()
    {
        // REXB=0 SRM=0 => OUTREG=RAX
        // REXB=0 SRM=1 => OUTREG=RCX
        // REXB=0 SRM=2 => OUTREG=RDX
        // REXB=0 SRM=3 => OUTREG=RBX
        // REXB=0 SRM=4 => OUTREG=RSP
        // REXB=0 SRM=5 => OUTREG=RBP
        // REXB=0 SRM=6 => OUTREG=RSI
        // REXB=0 SRM=7 => OUTREG=RDI
        // REXB=1 SRM=0 => OUTREG=R8
        // REXB=1 SRM=1 => OUTREG=R9
        // REXB=1 SRM=2 => OUTREG=R10
        // REXB=1 SRM=3 => OUTREG=R11
        // REXB=1 SRM=4 => OUTREG=R12
        // REXB=1 SRM=5 => OUTREG=R13
        // REXB=1 SRM=6 => OUTREG=R14
        // REXB=1 SRM=7 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR64_SB));
    }

    public void GPR64_X_DEC()
    {
        // REXX=0 SIBINDEX=0 => OUTREG=RAX
        // REXX=0 SIBINDEX=1 => OUTREG=RCX
        // REXX=0 SIBINDEX=2 => OUTREG=RDX
        // REXX=0 SIBINDEX=3 => OUTREG=RBX
        // REXX=0 SIBINDEX=4 => OUTREG=INVALID
        // REXX=0 SIBINDEX=5 => OUTREG=RBP
        // REXX=0 SIBINDEX=6 => OUTREG=RSI
        // REXX=0 SIBINDEX=7 => OUTREG=RDI
        // REXX=1 SIBINDEX=0 => OUTREG=R8
        // REXX=1 SIBINDEX=1 => OUTREG=R9
        // REXX=1 SIBINDEX=2 => OUTREG=R10
        // REXX=1 SIBINDEX=3 => OUTREG=R11
        // REXX=1 SIBINDEX=4 => OUTREG=R12
        // REXX=1 SIBINDEX=5 => OUTREG=R13
        // REXX=1 SIBINDEX=6 => OUTREG=R14
        // REXX=1 SIBINDEX=7 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR64_X));
    }

    public void GPR64e_ENC()
    {
        // OUTREG=RAX => null
        // OUTREG=RBX => null
        // OUTREG=RCX => null
        // OUTREG=RDX => null
        // OUTREG=RSP => null
        // OUTREG=RBP => null
        // OUTREG=RSI => null
        // OUTREG=RDI => null
        // OUTREG=R8 => null
        // OUTREG=R9 => null
        // OUTREG=R10 => null
        // OUTREG=R11 => null
        // OUTREG=R12 => null
        // OUTREG=R13 => null
        // OUTREG=R14 => null
        // OUTREG=R15 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR64e));
    }

    public void GPR8_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=AL
        // REXB=0 RM=1 => OUTREG=CL
        // REXB=0 RM=2 => OUTREG=DL
        // REXB=0 RM=3 => OUTREG=BL
        // REXB=0 RM=4 REX=0 => OUTREG=AH
        // REXB=0 RM=5 REX=0 => OUTREG=CH
        // REXB=0 RM=6 REX=0 => OUTREG=DH
        // REXB=0 RM=7 REX=0 => OUTREG=BH
        // REXB=0 RM=4 REX=1 => OUTREG=SPL
        // REXB=0 RM=5 REX=1 => OUTREG=BPL
        // REXB=0 RM=6 REX=1 => OUTREG=SIL
        // REXB=0 RM=7 REX=1 => OUTREG=DIL
        // REXB=1 RM=0 => OUTREG=R8B
        // REXB=1 RM=1 => OUTREG=R9B
        // REXB=1 RM=2 => OUTREG=R10B
        // REXB=1 RM=3 => OUTREG=R11B
        // REXB=1 RM=4 => OUTREG=R12B
        // REXB=1 RM=5 => OUTREG=R13B
        // REXB=1 RM=6 => OUTREG=R14B
        // REXB=1 RM=7 => OUTREG=R15B
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR8_B));
    }

    public void GPR8_B_ENC()
    {
        // OUTREG=AL => RM=0
        // OUTREG=CL => RM=1
        // OUTREG=DL => RM=2
        // OUTREG=BL => RM=3
        // OUTREG=AH => RM=4 NOREX=1
        // OUTREG=CH => RM=5 NOREX=1
        // OUTREG=DH => RM=6 NOREX=1
        // OUTREG=BH => RM=7 NOREX=1
        // OUTREG=SPL => RM=4 NEEDREX=1
        // OUTREG=BPL => RM=5 NEEDREX=1
        // OUTREG=SIL => RM=6 NEEDREX=1
        // OUTREG=DIL => RM=7 NEEDREX=1
        // OUTREG=R8B => REXB=1 RM=0
        // OUTREG=R9B => REXB=1 RM=1
        // OUTREG=R10B => REXB=1 RM=2
        // OUTREG=R11B => REXB=1 RM=3
        // OUTREG=R12B => REXB=1 RM=4
        // OUTREG=R13B => REXB=1 RM=5
        // OUTREG=R14B => REXB=1 RM=6
        // OUTREG=R15B => REXB=1 RM=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR8_B));
    }

    public void GPR8_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=AL
        // REXR=0 REG=1 => OUTREG=CL
        // REXR=0 REG=2 => OUTREG=DL
        // REXR=0 REG=3 => OUTREG=BL
        // REXR=0 REG=4 REX=0 => OUTREG=AH
        // REXR=0 REG=5 REX=0 => OUTREG=CH
        // REXR=0 REG=6 REX=0 => OUTREG=DH
        // REXR=0 REG=7 REX=0 => OUTREG=BH
        // REXR=0 REG=4 REX=1 => OUTREG=SPL
        // REXR=0 REG=5 REX=1 => OUTREG=BPL
        // REXR=0 REG=6 REX=1 => OUTREG=SIL
        // REXR=0 REG=7 REX=1 => OUTREG=DIL
        // REXR=1 REG=0 => OUTREG=R8B
        // REXR=1 REG=1 => OUTREG=R9B
        // REXR=1 REG=2 => OUTREG=R10B
        // REXR=1 REG=3 => OUTREG=R11B
        // REXR=1 REG=4 => OUTREG=R12B
        // REXR=1 REG=5 => OUTREG=R13B
        // REXR=1 REG=6 => OUTREG=R14B
        // REXR=1 REG=7 => OUTREG=R15B
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR8_R));
    }

    public void GPR8_R_ENC()
    {
        // OUTREG=AL => REG=0
        // OUTREG=CL => REG=1
        // OUTREG=DL => REG=2
        // OUTREG=BL => REG=3
        // OUTREG=AH => REG=4 NOREX=1
        // OUTREG=CH => REG=5 NOREX=1
        // OUTREG=DH => REG=6 NOREX=1
        // OUTREG=BH => REG=7 NOREX=1
        // OUTREG=SPL => REG=4 NEEDREX=1
        // OUTREG=BPL => REG=5 NEEDREX=1
        // OUTREG=SIL => REG=6 NEEDREX=1
        // OUTREG=DIL => REG=7 NEEDREX=1
        // OUTREG=R8B => REXR=1 REG=0
        // OUTREG=R9B => REXR=1 REG=1
        // OUTREG=R10B => REXR=1 REG=2
        // OUTREG=R11B => REXR=1 REG=3
        // OUTREG=R12B => REXR=1 REG=4
        // OUTREG=R13B => REXR=1 REG=5
        // OUTREG=R14B => REXR=1 REG=6
        // OUTREG=R15B => REXR=1 REG=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR8_R));
    }

    public void GPR8_SB_DEC()
    {
        // REXB=0 SRM=0 => OUTREG=AL
        // REXB=0 SRM=1 => OUTREG=CL
        // REXB=0 SRM=2 => OUTREG=DL
        // REXB=0 SRM=3 => OUTREG=BL
        // REXB=0 SRM=4 REX=0 => OUTREG=AH
        // REXB=0 SRM=5 REX=0 => OUTREG=CH
        // REXB=0 SRM=6 REX=0 => OUTREG=DH
        // REXB=0 SRM=7 REX=0 => OUTREG=BH
        // REXB=0 SRM=4 REX=1 => OUTREG=SPL
        // REXB=0 SRM=5 REX=1 => OUTREG=BPL
        // REXB=0 SRM=6 REX=1 => OUTREG=SIL
        // REXB=0 SRM=7 REX=1 => OUTREG=DIL
        // REXB=1 SRM=0 => OUTREG=R8B
        // REXB=1 SRM=1 => OUTREG=R9B
        // REXB=1 SRM=2 => OUTREG=R10B
        // REXB=1 SRM=3 => OUTREG=R11B
        // REXB=1 SRM=4 => OUTREG=R12B
        // REXB=1 SRM=5 => OUTREG=R13B
        // REXB=1 SRM=6 => OUTREG=R14B
        // REXB=1 SRM=7 => OUTREG=R15B
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPR8_SB));
    }

    public void GPR8_SB_ENC()
    {
        // OUTREG=AL => SRM=0
        // OUTREG=CL => SRM=1
        // OUTREG=DL => SRM=2
        // OUTREG=BL => SRM=3
        // OUTREG=AH => SRM=4 NOREX=1
        // OUTREG=CH => SRM=5 NOREX=1
        // OUTREG=DH => SRM=6 NOREX=1
        // OUTREG=BH => SRM=7 NOREX=1
        // OUTREG=SPL => SRM=4 NEEDREX=1
        // OUTREG=BPL => SRM=5 NEEDREX=1
        // OUTREG=SIL => SRM=6 NEEDREX=1
        // OUTREG=DIL => SRM=7 NEEDREX=1
        // OUTREG=R8B => REXB=1 SRM=0
        // OUTREG=R9B => REXB=1 SRM=1
        // OUTREG=R10B => REXB=1 SRM=2
        // OUTREG=R11B => REXB=1 SRM=3
        // OUTREG=R12B => REXB=1 SRM=4
        // OUTREG=R13B => REXB=1 SRM=5
        // OUTREG=R14B => REXB=1 SRM=6
        // OUTREG=R15B => REXB=1 SRM=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.GPR8_SB));
    }

    public void GPRv_B_DEC()
    {
        // EOSZ=3 => OUTREG=GPR64_B()
        // EOSZ=2 => OUTREG=GPR32_B()
        // EOSZ=1 => OUTREG=GPR16_B()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPRv_B));
    }

    public void GPRv_R_DEC()
    {
        // EOSZ=3 => OUTREG=GPR64_R()
        // EOSZ=2 => OUTREG=GPR32_R()
        // EOSZ=1 => OUTREG=GPR16_R()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPRv_R));
    }

    public void GPRv_SB_DEC()
    {
        // EOSZ=3 => OUTREG=GPR64_SB()
        // EOSZ=2 => OUTREG=GPR32_SB()
        // EOSZ=1 => OUTREG=GPR16_SB()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPRv_SB));
    }

    public void GPRy_B_DEC()
    {
        // EOSZ=3 => OUTREG=GPR64_B()
        // EOSZ=2 => OUTREG=GPR32_B()
        // EOSZ=1 => OUTREG=GPR32_B()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPRy_B));
    }

    public void GPRy_R_DEC()
    {
        // EOSZ=3 => OUTREG=GPR64_R()
        // EOSZ=2 => OUTREG=GPR32_R()
        // EOSZ=1 => OUTREG=GPR32_R()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPRy_R));
    }

    public void GPRz_B_DEC()
    {
        // EOSZ=3 => OUTREG=GPR32_B()
        // EOSZ=2 => OUTREG=GPR32_B()
        // EOSZ=1 => OUTREG=GPR16_B()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPRz_B));
    }

    public void GPRz_R_DEC()
    {
        // EOSZ=3 => OUTREG=GPR32_R()
        // EOSZ=2 => OUTREG=GPR32_R()
        // EOSZ=1 => OUTREG=GPR16_R()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.GPRz_R));
    }

    public void IGNORE66_DEC()
    {
        // MODE=0 => EOSZ=1 OSZ=0
        // MODE=1 => EOSZ=2 OSZ=0
        // MODE=2 REXW=0 => EOSZ=2 OSZ=0
        // MODE=2 REXW=1 => EOSZ=3 OSZ=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.IGNORE66));
    }

    public void IGNORE66_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.IGNORE66));
    }

    public void IMMUNE_REXW_DEC()
    {
        // MODE=0 => MODE=0 =>
        // MODE=1 => MODE=1 =>
        // MODE=2 OSZ=0 => EOSZ=2
        // MODE=2 OSZ=1 REXW=1 => EOSZ=2
        // MODE=2 OSZ=1 REXW=0 => EOSZ=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.IMMUNE_REXW));
    }

    public void IMMUNE_REXW_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.IMMUNE_REXW));
    }

    public void IMMUNE66_DEC()
    {
        // MODE=0 => EOSZ=2 OSZ=0
        // MODE=1 => EOSZ=2 OSZ=0
        // MODE=2 REXW=0 => EOSZ=2 OSZ=0
        // MODE=2 REXW=1 => EOSZ=3 OSZ=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.IMMUNE66));
    }

    public void IMMUNE66_ENC()
    {
        // MODE=0 => EOSZ=2 DF32=1
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.IMMUNE66));
    }

    public void IMMUNE66_LOOP64_DEC()
    {
        // MODE=0 => MODE=0 =>
        // MODE=1 => MODE=1 =>
        // MODE=2 => EOSZ=3 OSZ=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.IMMUNE66_LOOP64));
    }

    public void IMMUNE66_LOOP64_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.IMMUNE66_LOOP64));
    }

    public void MASK_B_DEC()
    {
        // RM=0 => OUTREG=K0
        // RM=1 => OUTREG=K1
        // RM=2 => OUTREG=K2
        // RM=3 => OUTREG=K3
        // RM=4 => OUTREG=K4
        // RM=5 => OUTREG=K5
        // RM=6 => OUTREG=K6
        // RM=7 => OUTREG=K7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MASK_B));
    }

    public void MASK_N_DEC()
    {
        // MODE=2 => OUTREG=MASK_N64()
        // MODE=1 => OUTREG=MASK_N32()
        // MODE=0 => OUTREG=MASK_N32()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MASK_N));
    }

    public void MASK_N32_DEC()
    {
        // VEXDEST210=0 => OUTREG=K7
        // VEXDEST210=1 => OUTREG=K6
        // VEXDEST210=2 => OUTREG=K5
        // VEXDEST210=3 => OUTREG=K4
        // VEXDEST210=4 => OUTREG=K3
        // VEXDEST210=5 => OUTREG=K2
        // VEXDEST210=6 => OUTREG=K1
        // VEXDEST210=7 => OUTREG=K0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MASK_N32));
    }

    public void MASK_N64_DEC()
    {
        // VEXDEST3=1 VEXDEST210=0 => OUTREG=K7
        // VEXDEST3=1 VEXDEST210=1 => OUTREG=K6
        // VEXDEST3=1 VEXDEST210=2 => OUTREG=K5
        // VEXDEST3=1 VEXDEST210=3 => OUTREG=K4
        // VEXDEST3=1 VEXDEST210=4 => OUTREG=K3
        // VEXDEST3=1 VEXDEST210=5 => OUTREG=K2
        // VEXDEST3=1 VEXDEST210=6 => OUTREG=K1
        // VEXDEST3=1 VEXDEST210=7 => OUTREG=K0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MASK_N64));
    }

    public void MASK_R_DEC()
    {
        // REXRR=0 REXR=0 REG=0 => OUTREG=K0
        // REXRR=0 REXR=0 REG=1 => OUTREG=K1
        // REXRR=0 REXR=0 REG=2 => OUTREG=K2
        // REXRR=0 REXR=0 REG=3 => OUTREG=K3
        // REXRR=0 REXR=0 REG=4 => OUTREG=K4
        // REXRR=0 REXR=0 REG=5 => OUTREG=K5
        // REXRR=0 REXR=0 REG=6 => OUTREG=K6
        // REXRR=0 REXR=0 REG=7 => OUTREG=K7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MASK_R));
    }

    public void MASK1_DEC()
    {
        // MASK=0 => OUTREG=K0
        // MASK=1 => OUTREG=K1
        // MASK=2 => OUTREG=K2
        // MASK=3 => OUTREG=K3
        // MASK=4 => OUTREG=K4
        // MASK=5 => OUTREG=K5
        // MASK=6 => OUTREG=K6
        // MASK=7 => OUTREG=K7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MASK1));
    }

    public void MASKNOT0_DEC()
    {
        // MASK=0 => OUTREG=ERROR
        // MASK=1 => OUTREG=K1
        // MASK=2 => OUTREG=K2
        // MASK=3 => OUTREG=K3
        // MASK=4 => OUTREG=K4
        // MASK=5 => OUTREG=K5
        // MASK=6 => OUTREG=K6
        // MASK=7 => OUTREG=K7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MASKNOT0));
    }

    public void MEMDISP_DEC()
    {
        // NEED_MEMDISP=0 => DISP_WIDTH=0
        // NEED_MEMDISP=1 a/8 => DISP_WIDTH=8
        // NEED_MEMDISP=1 a/16 => DISP_WIDTH=16
        // NEED_MEMDISP=1 a/32 => DISP_WIDTH=32
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MEMDISP));
    }

    public void MEMDISP16_DEC()
    {
        // a/16 => DISP_WIDTH=16
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MEMDISP16));
    }

    public void MEMDISP32_DEC()
    {
        // a/32 => DISP_WIDTH=32
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MEMDISP32));
    }

    public void MEMDISP8_DEC()
    {
        // a/8 => DISP_WIDTH=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MEMDISP8));
    }

    public void MEMDISPv_DEC()
    {
        // EASZ=1 a/16 => DISP_WIDTH=16
        // EASZ=2 a/32 => DISP_WIDTH=32
        // EASZ=3 a/64 => DISP_WIDTH=64
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MEMDISPv));
    }

    public void MMX_B_DEC()
    {
        // RM=0 => OUTREG=MMX0
        // RM=1 => OUTREG=MMX1
        // RM=2 => OUTREG=MMX2
        // RM=3 => OUTREG=MMX3
        // RM=4 => OUTREG=MMX4
        // RM=5 => OUTREG=MMX5
        // RM=6 => OUTREG=MMX6
        // RM=7 => OUTREG=MMX7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MMX_B));
    }

    public void MMX_R_DEC()
    {
        // REG=0 => OUTREG=MMX0
        // REG=1 => OUTREG=MMX1
        // REG=2 => OUTREG=MMX2
        // REG=3 => OUTREG=MMX3
        // REG=4 => OUTREG=MMX4
        // REG=5 => OUTREG=MMX5
        // REG=6 => OUTREG=MMX6
        // REG=7 => OUTREG=MMX7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MMX_R));
    }

    public void MODRM_DEC()
    {
        // MODE=2 EASZ=3 MODRM64alt32() MEMDISP() => MODE=2 EASZ=3 MODRM64alt32() MEMDISP() =>
        // MODE=2 EASZ=2 MODRM64alt32() MEMDISP() => MODE=2 EASZ=2 MODRM64alt32() MEMDISP() =>
        // MODE=1 EASZ=2 MODRM32() MEMDISP() => MODE=1 EASZ=2 MODRM32() MEMDISP() =>
        // MODE=1 EASZ=1 MODRM16() MEMDISP() => MODE=1 EASZ=1 MODRM16() MEMDISP() =>
        // MODE=0 EASZ=2 MODRM32() MEMDISP() => MODE=0 EASZ=2 MODRM32() MEMDISP() =>
        // MODE=0 EASZ=1 MODRM16() MEMDISP() => MODE=0 EASZ=1 MODRM16() MEMDISP() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MODRM));
    }

    public void MODRM_MOD_EA16_DISP0_ENC()
    {
        // BASE0=BX INDEX=@ => MOD=0
        // BASE0=SI INDEX=@ => MOD=0
        // BASE0=DI INDEX=@ => MOD=0
        // BASE0=BP INDEX=@ => MOD=1 DISP_WIDTH=8 DISP=0x0
        // BASE0=BP INDEX=SI => MOD=0
        // BASE0=BP INDEX=DI => MOD=0
        // BASE0=BX INDEX=SI => MOD=0
        // BASE0=BX INDEX=DI => MOD=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA16_DISP0));
    }

    public void MODRM_MOD_EA16_DISP16_ENC()
    {
        // BASE0=@ INDEX=@ => MOD=0
        // BASE0=BX INDEX=@ => MOD=2
        // BASE0=SI INDEX=@ => MOD=2
        // BASE0=DI INDEX=@ => MOD=2
        // BASE0=BP INDEX=@ => MOD=2
        // BASE0=BP INDEX=SI => MOD=2
        // BASE0=BP INDEX=DI => MOD=2
        // BASE0=BX INDEX=SI => MOD=2
        // BASE0=BX INDEX=DI => MOD=2
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA16_DISP16));
    }

    public void MODRM_MOD_EA16_DISP8_ENC()
    {
        // BASE0=BX INDEX=@ => MOD=1
        // BASE0=SI INDEX=@ => MOD=1
        // BASE0=DI INDEX=@ => MOD=1
        // BASE0=BP INDEX=@ => MOD=1
        // BASE0=BP INDEX=SI => MOD=1
        // BASE0=BP INDEX=DI => MOD=1
        // BASE0=BX INDEX=SI => MOD=1
        // BASE0=BX INDEX=DI => MOD=1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA16_DISP8));
    }

    public void MODRM_MOD_EA32_DISP0_ENC()
    {
        // BASE0=EBP MODE=1 => MOD=1 DISP_WIDTH=8 DISP=0x0
        // BASE0=EBP MODE=2 => MOD=1 DISP_WIDTH=8 DISP=0x0
        // BASE0=R13D MODE=2 => MOD=1 DISP_WIDTH=8 DISP=0x0
        // BASE0=EAX MODE=1 => MOD=0
        // BASE0=EBX MODE=1 => MOD=0
        // BASE0=ECX MODE=1 => MOD=0
        // BASE0=EDX MODE=1 => MOD=0
        // BASE0=ESI MODE=1 => MOD=0
        // BASE0=EDI MODE=1 => MOD=0
        // BASE0=ESP MODE=1 => MOD=0
        // BASE0=EAX MODE=2 => MOD=0
        // BASE0=EBX MODE=2 => MOD=0
        // BASE0=ECX MODE=2 => MOD=0
        // BASE0=EDX MODE=2 => MOD=0
        // BASE0=ESI MODE=2 => MOD=0
        // BASE0=EDI MODE=2 => MOD=0
        // BASE0=ESP MODE=2 => MOD=0
        // BASE0=R8D MODE=2 => MOD=0
        // BASE0=R9D MODE=2 => MOD=0
        // BASE0=R10D MODE=2 => MOD=0
        // BASE0=R11D MODE=2 => MOD=0
        // BASE0=R12D MODE=2 => MOD=0
        // BASE0=R14D MODE=2 => MOD=0
        // BASE0=R15D MODE=2 => MOD=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA32_DISP0));
    }

    public void MODRM_MOD_EA32_DISP32_ENC()
    {
        // BASE0=@ => MOD=0
        // BASE0=GPR32e() => MOD=2
        // BASE0=rIPa() MODE=2 => MOD=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA32_DISP32));
    }

    public void MODRM_MOD_EA32_DISP8_ENC()
    {
        // else => MOD=1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA32_DISP8));
    }

    public void MODRM_MOD_EA64_DISP0_ENC()
    {
        // BASE0=EIP => MOD=0 DISP_WIDTH=32 DISP=0x0
        // BASE0=RIP => MOD=0 DISP_WIDTH=32 DISP=0x0
        // BASE0=RBP => MOD=1 DISP_WIDTH=8 DISP=0x0
        // BASE0=R13 => MOD=1 DISP_WIDTH=8 DISP=0x0
        // BASE0=RAX => MOD=0
        // BASE0=RBX => MOD=0
        // BASE0=RCX => MOD=0
        // BASE0=RDX => MOD=0
        // BASE0=RSI => MOD=0
        // BASE0=RDI => MOD=0
        // BASE0=RSP => MOD=0
        // BASE0=R8 => MOD=0
        // BASE0=R9 => MOD=0
        // BASE0=R10 => MOD=0
        // BASE0=R11 => MOD=0
        // BASE0=R12 => MOD=0
        // BASE0=R14 => MOD=0
        // BASE0=R15 => MOD=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA64_DISP0));
    }

    public void MODRM_MOD_EA64_DISP32_ENC()
    {
        // BASE0=@ => MOD=0
        // BASE0=EIP => MOD=0
        // BASE0=RIP => MOD=0
        // BASE0=RAX => MOD=2
        // BASE0=RBX => MOD=2
        // BASE0=RCX => MOD=2
        // BASE0=RDX => MOD=2
        // BASE0=RSI => MOD=2
        // BASE0=RDI => MOD=2
        // BASE0=RSP => MOD=2
        // BASE0=RBP => MOD=2
        // BASE0=R8 => MOD=2
        // BASE0=R9 => MOD=2
        // BASE0=R10 => MOD=2
        // BASE0=R11 => MOD=2
        // BASE0=R12 => MOD=2
        // BASE0=R13 => MOD=2
        // BASE0=R14 => MOD=2
        // BASE0=R15 => MOD=2
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA64_DISP32));
    }

    public void MODRM_MOD_EA64_DISP8_ENC()
    {
        // BASE0=GPR64e() => MOD=1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_EA64_DISP8));
    }

    public void MODRM_MOD_ENCODE_ENC()
    {
        // EASZ=1 DISP_WIDTH=0 => MODRM_MOD_EA16_DISP0()
        // EASZ=1 DISP_WIDTH=8 => MODRM_MOD_EA16_DISP8()
        // EASZ=1 DISP_WIDTH=16 => MODRM_MOD_EA16_DISP16()
        // EASZ=1 DISP_WIDTH=32 => ERROR()
        // EASZ=1 DISP_WIDTH=64 => ERROR()
        // EASZ=2 DISP_WIDTH=0 => MODRM_MOD_EA32_DISP0()
        // EASZ=2 DISP_WIDTH=8 => MODRM_MOD_EA32_DISP8()
        // EASZ=2 DISP_WIDTH=16 => ERROR()
        // EASZ=2 DISP_WIDTH=32 => MODRM_MOD_EA32_DISP32()
        // EASZ=2 DISP_WIDTH=64 => ERROR()
        // EASZ=3 DISP_WIDTH=0 => MODRM_MOD_EA64_DISP0()
        // EASZ=3 DISP_WIDTH=8 => MODRM_MOD_EA64_DISP8()
        // EASZ=3 DISP_WIDTH=16 => ERROR()
        // EASZ=3 DISP_WIDTH=32 => MODRM_MOD_EA64_DISP32()
        // EASZ=3 DISP_WIDTH=64 => ERROR()
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_MOD_ENCODE));
    }

    public void MODRM_RM_ENCODE_ENC()
    {
        // EASZ=1 NEED_SIB=0 => MODRM_RM_ENCODE_EA16_SIB0()
        // EASZ=2 NEED_SIB=0 => MODRM_RM_ENCODE_EA32_SIB0()
        // EASZ=3 NEED_SIB=0 => MODRM_RM_ENCODE_EA64_SIB0()
        // EASZ=4 NEED_SIB=1 => MODRM_RM_ENCODE_EANOT16_SIB1()
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_RM_ENCODE));
    }

    public void MODRM_RM_ENCODE_EA16_SIB0_ENC()
    {
        // BASE0=BX INDEX=SI => RM=0
        // BASE0=BX INDEX=DI => RM=1
        // BASE0=BP INDEX=SI => RM=2
        // BASE0=BP INDEX=DI => RM=3
        // BASE0=SI INDEX=@ => RM=4
        // BASE0=DI INDEX=@ => RM=5
        // BASE0=@ INDEX=@ => DISP_WIDTH_16() RM=6
        // BASE0=BP INDEX=@ => DISP_WIDTH_0_8_16() RM=6
        // BASE0=BX INDEX=@ => RM=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_RM_ENCODE_EA16_SIB0));
    }

    public void MODRM_RM_ENCODE_EA32_SIB0_ENC()
    {
        // BASE0=EAX => RM=0 REXB=0
        // BASE0=R8D => RM=0 REXB=1
        // BASE0=ECX => RM=1 REXB=0
        // BASE0=R9D => RM=1 REXB=1
        // BASE0=EDX => RM=2 REXB=0
        // BASE0=R10D => RM=2 REXB=1
        // BASE0=EBX => RM=3 REXB=0
        // BASE0=R11D => RM=3 REXB=1
        // BASE0=ESI => RM=6 REXB=0
        // BASE0=R14D => RM=6 REXB=1
        // BASE0=EDI => RM=7 REXB=0
        // BASE0=R15D => RM=7 REXB=1
        // BASE0=@ => DISP_WIDTH_32() RM=5
        // BASE0=EBP => DISP_WIDTH_0_8_32() RM=5 REXB=0
        // BASE0=R13D => DISP_WIDTH_0_8_32() RM=5 REXB=1
        // BASE0=RIP MODE=2 => RM=5
        // BASE0=EIP MODE=2 => RM=5
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_RM_ENCODE_EA32_SIB0));
    }

    public void MODRM_RM_ENCODE_EA64_SIB0_ENC()
    {
        // BASE0=RAX => RM=0 REXB=0
        // BASE0=R8 => RM=0 REXB=1
        // BASE0=RCX => RM=1 REXB=0
        // BASE0=R9 => RM=1 REXB=1
        // BASE0=RDX => RM=2 REXB=0
        // BASE0=R10 => RM=2 REXB=1
        // BASE0=RBX => RM=3 REXB=0
        // BASE0=R11 => RM=3 REXB=1
        // BASE0=RSI => RM=6 REXB=0
        // BASE0=R14 => RM=6 REXB=1
        // BASE0=RDI => RM=7 REXB=0
        // BASE0=R15 => RM=7 REXB=1
        // BASE0=@ => DISP_WIDTH_32() RM=5
        // BASE0=RBP => DISP_WIDTH_0_8_32() RM=5 REXB=0
        // BASE0=RIP => RM=5
        // BASE0=EIP => RM=5
        // BASE0=R13 => DISP_WIDTH_0_8_32() RM=5 REXB=1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_RM_ENCODE_EA64_SIB0));
    }

    public void MODRM_RM_ENCODE_EANOT16_SIB1_ENC()
    {
        // else => RM=4
        Context.RuleActivated((RuleTableKind.ENC,RuleName.MODRM_RM_ENCODE_EANOT16_SIB1));
    }

    public void MODRM16_DEC()
    {
        // MOD=0 RM=0 => BASE0=BX SEG0=FINAL_DSEG() INDEX=SI SCALE=1
        // MOD=0 RM=1 => BASE0=BX SEG0=FINAL_DSEG() INDEX=DI SCALE=1
        // MOD=0 RM=2 => BASE0=BP SEG0=FINAL_SSEG() INDEX=SI SCALE=1
        // MOD=0 RM=3 => BASE0=BP SEG0=FINAL_SSEG() INDEX=DI SCALE=1
        // MOD=0 RM=4 => BASE0=SI SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=0 RM=5 => BASE0=DI SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=0 RM=6 => NEED_MEMDISP=1 BASE0=INVALID SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=0 RM=7 => BASE0=BX SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=1 RM=0 => NEED_MEMDISP=1 BASE0=BX SEG0=FINAL_DSEG() INDEX=SI SCALE=1
        // MOD=1 RM=1 => NEED_MEMDISP=1 BASE0=BX SEG0=FINAL_DSEG() INDEX=DI SCALE=1
        // MOD=1 RM=2 => NEED_MEMDISP=1 BASE0=BP SEG0=FINAL_SSEG() INDEX=SI SCALE=1
        // MOD=1 RM=3 => NEED_MEMDISP=1 BASE0=BP SEG0=FINAL_SSEG() INDEX=DI SCALE=1
        // MOD=1 RM=4 => NEED_MEMDISP=1 BASE0=SI SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=1 RM=5 => NEED_MEMDISP=1 BASE0=DI SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=1 RM=6 => NEED_MEMDISP=1 BASE0=BP SEG0=FINAL_SSEG() INDEX=INVALID
        // MOD=1 RM=7 => NEED_MEMDISP=1 BASE0=BX SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=2 RM=0 => NEED_MEMDISP=1 BASE0=BX SEG0=FINAL_DSEG() INDEX=SI SCALE=1
        // MOD=2 RM=1 => NEED_MEMDISP=1 BASE0=BX SEG0=FINAL_DSEG() INDEX=DI SCALE=1
        // MOD=2 RM=2 => NEED_MEMDISP=1 BASE0=BP SEG0=FINAL_SSEG() INDEX=SI SCALE=1
        // MOD=2 RM=3 => NEED_MEMDISP=1 BASE0=BP SEG0=FINAL_SSEG() INDEX=DI SCALE=1
        // MOD=2 RM=4 => NEED_MEMDISP=1 BASE0=SI SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=2 RM=5 => NEED_MEMDISP=1 BASE0=DI SEG0=FINAL_DSEG() INDEX=INVALID
        // MOD=2 RM=6 => NEED_MEMDISP=1 BASE0=BP SEG0=FINAL_SSEG() INDEX=INVALID
        // MOD=2 RM=7 => NEED_MEMDISP=1 BASE0=BX SEG0=FINAL_DSEG() INDEX=INVALID
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MODRM16));
    }

    public void MODRM32_DEC()
    {
        // MOD=0 RM=0 => BASE0=EAX SEG0=FINAL_DSEG()
        // MOD=0 RM=1 => BASE0=ECX SEG0=FINAL_DSEG()
        // MOD=0 RM=2 => BASE0=EDX SEG0=FINAL_DSEG()
        // MOD=0 RM=3 => BASE0=EBX SEG0=FINAL_DSEG()
        // MOD=0 RM=4 SIB() => MOD=0 RM=4 SIB() =>
        // MOD=0 RM=5 => NEED_MEMDISP=1 SEG0=FINAL_DSEG()
        // MOD=0 RM=6 => BASE0=ESI SEG0=FINAL_DSEG()
        // MOD=0 RM=7 => BASE0=EDI SEG0=FINAL_DSEG()
        // MOD=1 RM=0 => NEED_MEMDISP=1 BASE0=EAX SEG0=FINAL_DSEG()
        // MOD=1 RM=1 => NEED_MEMDISP=1 BASE0=ECX SEG0=FINAL_DSEG()
        // MOD=1 RM=2 => NEED_MEMDISP=1 BASE0=EDX SEG0=FINAL_DSEG()
        // MOD=1 RM=3 => NEED_MEMDISP=1 BASE0=EBX SEG0=FINAL_DSEG()
        // MOD=1 RM=4 SIB() => NEED_MEMDISP=1
        // MOD=1 RM=5 => NEED_MEMDISP=1 BASE0=EBP SEG0=FINAL_SSEG()
        // MOD=1 RM=6 => NEED_MEMDISP=1 BASE0=ESI SEG0=FINAL_DSEG()
        // MOD=1 RM=7 => NEED_MEMDISP=1 BASE0=EDI SEG0=FINAL_DSEG()
        // MOD=2 RM=0 => NEED_MEMDISP=1 BASE0=EAX SEG0=FINAL_DSEG()
        // MOD=2 RM=1 => NEED_MEMDISP=1 BASE0=ECX SEG0=FINAL_DSEG()
        // MOD=2 RM=2 => NEED_MEMDISP=1 BASE0=EDX SEG0=FINAL_DSEG()
        // MOD=2 RM=3 => NEED_MEMDISP=1 BASE0=EBX SEG0=FINAL_DSEG()
        // MOD=2 RM=4 SIB() => NEED_MEMDISP=1
        // MOD=2 RM=5 => NEED_MEMDISP=1 BASE0=EBP SEG0=FINAL_SSEG()
        // MOD=2 RM=6 => NEED_MEMDISP=1 BASE0=ESI SEG0=FINAL_DSEG()
        // MOD=2 RM=7 => NEED_MEMDISP=1 BASE0=EDI SEG0=FINAL_DSEG()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MODRM32));
    }

    public void MODRM64alt32_DEC()
    {
        // REXB=0 MOD=0 RM=0 => BASE0=ArAX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=0 RM=0 => BASE0=Ar8() SEG0=FINAL_DSEG()
        // REXB=0 MOD=0 RM=1 => BASE0=ArCX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=0 RM=1 => BASE0=Ar9() SEG0=FINAL_DSEG()
        // REXB=0 MOD=0 RM=2 => BASE0=ArDX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=0 RM=2 => BASE0=Ar10() SEG0=FINAL_DSEG()
        // REXB=0 MOD=0 RM=3 => BASE0=ArBX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=0 RM=3 => BASE0=Ar11() SEG0=FINAL_DSEG()
        // REXB=0 MOD=0 RM=4 SIB() => REXB=0 MOD=0 RM=4 SIB() =>
        // REXB=1 MOD=0 RM=4 SIB() => REXB=1 MOD=0 RM=4 SIB() =>
        // REXB=0 MOD=0 RM=5 => NEED_MEMDISP=1 BASE0=rIPa() SEG0=FINAL_DSEG() ENCODER_PREFERRED=1
        // REXB=1 MOD=0 RM=5 => NEED_MEMDISP=1 BASE0=rIPa() SEG0=FINAL_DSEG()
        // REXB=0 MOD=0 RM=6 => BASE0=ArSI() SEG0=FINAL_DSEG()
        // REXB=1 MOD=0 RM=6 => BASE0=Ar14() SEG0=FINAL_DSEG()
        // REXB=0 MOD=0 RM=7 => BASE0=ArDI() SEG0=FINAL_DSEG()
        // REXB=1 MOD=0 RM=7 => BASE0=Ar15() SEG0=FINAL_DSEG()
        // REXB=0 MOD=1 RM=0 => NEED_MEMDISP=1 BASE0=ArAX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=1 RM=0 => NEED_MEMDISP=1 BASE0=Ar8() SEG0=FINAL_DSEG()
        // REXB=0 MOD=1 RM=1 => NEED_MEMDISP=1 BASE0=ArCX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=1 RM=1 => NEED_MEMDISP=1 BASE0=Ar9() SEG0=FINAL_DSEG()
        // REXB=0 MOD=1 RM=2 => NEED_MEMDISP=1 BASE0=ArDX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=1 RM=2 => NEED_MEMDISP=1 BASE0=Ar10() SEG0=FINAL_DSEG()
        // REXB=0 MOD=1 RM=3 => NEED_MEMDISP=1 BASE0=ArBX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=1 RM=3 => NEED_MEMDISP=1 BASE0=Ar11() SEG0=FINAL_DSEG()
        // REXB=0 MOD=1 RM=4 SIB() => NEED_MEMDISP=1
        // REXB=1 MOD=1 RM=4 SIB() => NEED_MEMDISP=1
        // REXB=0 MOD=1 RM=5 => NEED_MEMDISP=1 BASE0=ArBP() SEG0=FINAL_SSEG()
        // REXB=1 MOD=1 RM=5 => NEED_MEMDISP=1 BASE0=Ar13() SEG0=FINAL_DSEG()
        // REXB=0 MOD=1 RM=6 => NEED_MEMDISP=1 BASE0=ArSI() SEG0=FINAL_DSEG()
        // REXB=1 MOD=1 RM=6 => NEED_MEMDISP=1 BASE0=Ar14() SEG0=FINAL_DSEG()
        // REXB=0 MOD=1 RM=7 => NEED_MEMDISP=1 BASE0=ArDI() SEG0=FINAL_DSEG()
        // REXB=1 MOD=1 RM=7 => NEED_MEMDISP=1 BASE0=Ar15() SEG0=FINAL_DSEG()
        // REXB=0 MOD=2 RM=0 => NEED_MEMDISP=1 BASE0=ArAX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=2 RM=0 => NEED_MEMDISP=1 BASE0=Ar8() SEG0=FINAL_DSEG()
        // REXB=0 MOD=2 RM=1 => NEED_MEMDISP=1 BASE0=ArCX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=2 RM=1 => NEED_MEMDISP=1 BASE0=Ar9() SEG0=FINAL_DSEG()
        // REXB=0 MOD=2 RM=2 => NEED_MEMDISP=1 BASE0=ArDX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=2 RM=2 => NEED_MEMDISP=1 BASE0=Ar10() SEG0=FINAL_DSEG()
        // REXB=0 MOD=2 RM=3 => NEED_MEMDISP=1 BASE0=ArBX() SEG0=FINAL_DSEG()
        // REXB=1 MOD=2 RM=3 => NEED_MEMDISP=1 BASE0=Ar11() SEG0=FINAL_DSEG()
        // REXB=0 MOD=2 RM=4 SIB() => NEED_MEMDISP=1
        // REXB=1 MOD=2 RM=4 SIB() => NEED_MEMDISP=1
        // REXB=0 MOD=2 RM=5 => NEED_MEMDISP=1 BASE0=ArBP() SEG0=FINAL_SSEG()
        // REXB=1 MOD=2 RM=5 => NEED_MEMDISP=1 BASE0=Ar13() SEG0=FINAL_DSEG()
        // REXB=0 MOD=2 RM=6 => NEED_MEMDISP=1 BASE0=ArSI() SEG0=FINAL_DSEG()
        // REXB=1 MOD=2 RM=6 => NEED_MEMDISP=1 BASE0=Ar14() SEG0=FINAL_DSEG()
        // REXB=0 MOD=2 RM=7 => NEED_MEMDISP=1 BASE0=ArDI() SEG0=FINAL_DSEG()
        // REXB=1 MOD=2 RM=7 => NEED_MEMDISP=1 BASE0=Ar15() SEG0=FINAL_DSEG()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.MODRM64alt32));
    }

    public void UISA_ENC_INDEX_XMM_ENC()
    {
        // INDEX=XMM0 => VEXDEST4=0 REXX=0 SIBINDEX=0
        // INDEX=XMM1 => VEXDEST4=0 REXX=0 SIBINDEX=1
        // INDEX=XMM2 => VEXDEST4=0 REXX=0 SIBINDEX=2
        // INDEX=XMM3 => VEXDEST4=0 REXX=0 SIBINDEX=3
        // INDEX=XMM4 => VEXDEST4=0 REXX=0 SIBINDEX=4
        // INDEX=XMM5 => VEXDEST4=0 REXX=0 SIBINDEX=5
        // INDEX=XMM6 => VEXDEST4=0 REXX=0 SIBINDEX=6
        // INDEX=XMM7 => VEXDEST4=0 REXX=0 SIBINDEX=7
        // INDEX=XMM8 => VEXDEST4=0 REXX=1 SIBINDEX=0
        // INDEX=XMM9 => VEXDEST4=0 REXX=1 SIBINDEX=1
        // INDEX=XMM10 => VEXDEST4=0 REXX=1 SIBINDEX=2
        // INDEX=XMM11 => VEXDEST4=0 REXX=1 SIBINDEX=3
        // INDEX=XMM12 => VEXDEST4=0 REXX=1 SIBINDEX=4
        // INDEX=XMM13 => VEXDEST4=0 REXX=1 SIBINDEX=5
        // INDEX=XMM14 => VEXDEST4=0 REXX=1 SIBINDEX=6
        // INDEX=XMM15 => VEXDEST4=0 REXX=1 SIBINDEX=7
        // INDEX=XMM16 => VEXDEST4=1 REXX=0 SIBINDEX=0
        // INDEX=XMM17 => VEXDEST4=1 REXX=0 SIBINDEX=1
        // INDEX=XMM18 => VEXDEST4=1 REXX=0 SIBINDEX=2
        // INDEX=XMM19 => VEXDEST4=1 REXX=0 SIBINDEX=3
        // INDEX=XMM20 => VEXDEST4=1 REXX=0 SIBINDEX=4
        // INDEX=XMM21 => VEXDEST4=1 REXX=0 SIBINDEX=5
        // INDEX=XMM22 => VEXDEST4=1 REXX=0 SIBINDEX=6
        // INDEX=XMM23 => VEXDEST4=1 REXX=0 SIBINDEX=7
        // INDEX=XMM24 => VEXDEST4=1 REXX=1 SIBINDEX=0
        // INDEX=XMM25 => VEXDEST4=1 REXX=1 SIBINDEX=1
        // INDEX=XMM26 => VEXDEST4=1 REXX=1 SIBINDEX=2
        // INDEX=XMM27 => VEXDEST4=1 REXX=1 SIBINDEX=3
        // INDEX=XMM28 => VEXDEST4=1 REXX=1 SIBINDEX=4
        // INDEX=XMM29 => VEXDEST4=1 REXX=1 SIBINDEX=5
        // INDEX=XMM30 => VEXDEST4=1 REXX=1 SIBINDEX=6
        // INDEX=XMM31 => VEXDEST4=1 REXX=1 SIBINDEX=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.UISA_ENC_INDEX_XMM));
    }

    public void NELEM_EIGHTHMEM_DEC()
    {
        // ELEMENT_SIZE=1 VL=2 => NELEM=64
        // ELEMENT_SIZE=2 VL=2 => NELEM=32
        // ELEMENT_SIZE=4 VL=2 => NELEM=16
        // ELEMENT_SIZE=8 VL=2 => NELEM=8
        // ELEMENT_SIZE=16 VL=2 => NELEM=4
        // ELEMENT_SIZE=32 VL=2 => NELEM=2
        // ELEMENT_SIZE=64 VL=2 => NELEM=1
        // ELEMENT_SIZE=128 VL=2 => error
        // ELEMENT_SIZE=256 VL=2 => error
        // ELEMENT_SIZE=512 VL=2 => error
        // ELEMENT_SIZE=1 VL=1 => NELEM=32
        // ELEMENT_SIZE=2 VL=1 => NELEM=16
        // ELEMENT_SIZE=4 VL=1 => NELEM=8
        // ELEMENT_SIZE=8 VL=1 => NELEM=4
        // ELEMENT_SIZE=16 VL=1 => NELEM=2
        // ELEMENT_SIZE=32 VL=1 => NELEM=1
        // ELEMENT_SIZE=64 VL=1 => error
        // ELEMENT_SIZE=128 VL=1 => error
        // ELEMENT_SIZE=256 VL=1 => error
        // ELEMENT_SIZE=512 VL=1 => error
        // ELEMENT_SIZE=1 VL=0 => NELEM=16
        // ELEMENT_SIZE=2 VL=0 => NELEM=8
        // ELEMENT_SIZE=4 VL=0 => NELEM=4
        // ELEMENT_SIZE=8 VL=0 => NELEM=2
        // ELEMENT_SIZE=16 VL=0 => NELEM=1
        // ELEMENT_SIZE=32 VL=0 => error
        // ELEMENT_SIZE=64 VL=0 => error
        // ELEMENT_SIZE=128 VL=0 => error
        // ELEMENT_SIZE=256 VL=0 => error
        // ELEMENT_SIZE=512 VL=0 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_EIGHTHMEM));
    }

    public void NELEM_EIGHTHMEM_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_EIGHTHMEM));
    }

    public void NELEM_FULL_DEC()
    {
        // BCRC=0 ELEMENT_SIZE=16 VL=2 => NELEM=32
        // BCRC=1 ELEMENT_SIZE=16 VL=2 => NELEM=1 BCAST=16
        // BCRC=0 ELEMENT_SIZE=32 VL=2 => NELEM=16
        // BCRC=1 ELEMENT_SIZE=32 VL=2 => NELEM=1 BCAST=1
        // BCRC=0 ELEMENT_SIZE=64 VL=2 => NELEM=8
        // BCRC=1 ELEMENT_SIZE=64 VL=2 => NELEM=1 BCAST=5
        // BCRC=0 ELEMENT_SIZE=16 VL=1 => NELEM=16
        // BCRC=1 ELEMENT_SIZE=16 VL=1 => NELEM=1 BCAST=15
        // BCRC=0 ELEMENT_SIZE=32 VL=1 => NELEM=8
        // BCRC=1 ELEMENT_SIZE=32 VL=1 => NELEM=1 BCAST=3
        // BCRC=0 ELEMENT_SIZE=64 VL=1 => NELEM=4
        // BCRC=1 ELEMENT_SIZE=64 VL=1 => NELEM=1 BCAST=13
        // BCRC=0 ELEMENT_SIZE=16 VL=0 => NELEM=8
        // BCRC=1 ELEMENT_SIZE=16 VL=0 => NELEM=1 BCAST=14
        // BCRC=0 ELEMENT_SIZE=32 VL=0 => NELEM=4
        // BCRC=1 ELEMENT_SIZE=32 VL=0 => NELEM=1 BCAST=10
        // BCRC=0 ELEMENT_SIZE=64 VL=0 => NELEM=2
        // BCRC=1 ELEMENT_SIZE=64 VL=0 => NELEM=1 BCAST=11
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_FULL));
    }

    public void NELEM_FULL_ENC()
    {
        // BCAST!=0 => BCRC=1
        // else => BCRC=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_FULL));
    }

    public void NELEM_FULLMEM_DEC()
    {
        // ELEMENT_SIZE=1 VL=2 => NELEM=512
        // ELEMENT_SIZE=2 VL=2 => NELEM=256
        // ELEMENT_SIZE=4 VL=2 => NELEM=128
        // ELEMENT_SIZE=8 VL=2 => NELEM=64
        // ELEMENT_SIZE=16 VL=2 => NELEM=32
        // ELEMENT_SIZE=32 VL=2 => NELEM=16
        // ELEMENT_SIZE=64 VL=2 => NELEM=8
        // ELEMENT_SIZE=128 VL=2 => NELEM=4
        // ELEMENT_SIZE=256 VL=2 => NELEM=2
        // ELEMENT_SIZE=512 VL=2 => NELEM=1
        // ELEMENT_SIZE=1 VL=1 => NELEM=256
        // ELEMENT_SIZE=2 VL=1 => NELEM=128
        // ELEMENT_SIZE=4 VL=1 => NELEM=64
        // ELEMENT_SIZE=8 VL=1 => NELEM=32
        // ELEMENT_SIZE=16 VL=1 => NELEM=16
        // ELEMENT_SIZE=32 VL=1 => NELEM=8
        // ELEMENT_SIZE=64 VL=1 => NELEM=4
        // ELEMENT_SIZE=128 VL=1 => NELEM=2
        // ELEMENT_SIZE=256 VL=1 => NELEM=1
        // ELEMENT_SIZE=512 VL=1 => error
        // ELEMENT_SIZE=1 VL=0 => NELEM=128
        // ELEMENT_SIZE=2 VL=0 => NELEM=64
        // ELEMENT_SIZE=4 VL=0 => NELEM=32
        // ELEMENT_SIZE=8 VL=0 => NELEM=16
        // ELEMENT_SIZE=16 VL=0 => NELEM=8
        // ELEMENT_SIZE=32 VL=0 => NELEM=4
        // ELEMENT_SIZE=64 VL=0 => NELEM=2
        // ELEMENT_SIZE=128 VL=0 => NELEM=1
        // ELEMENT_SIZE=256 VL=0 => error
        // ELEMENT_SIZE=512 VL=0 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_FULLMEM));
    }

    public void NELEM_FULLMEM_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_FULLMEM));
    }

    public void NELEM_GPR_READER_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_READER));
    }

    public void NELEM_GPR_READER_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_READER));
    }

    public void NELEM_GPR_READER_BYTE_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_READER_BYTE));
    }

    public void NELEM_GPR_READER_BYTE_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_READER_BYTE));
    }

    public void NELEM_GPR_READER_SUBDWORD_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_READER_SUBDWORD));
    }

    public void NELEM_GPR_READER_SUBDWORD_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_READER_SUBDWORD));
    }

    public void NELEM_GPR_READER_WORD_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_READER_WORD));
    }

    public void NELEM_GPR_READER_WORD_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_READER_WORD));
    }

    public void NELEM_GPR_WRITER_LDOP_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_WRITER_LDOP));
    }

    public void NELEM_GPR_WRITER_LDOP_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_WRITER_LDOP));
    }

    public void NELEM_GPR_WRITER_LDOP_D_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_WRITER_LDOP_D));
    }

    public void NELEM_GPR_WRITER_LDOP_D_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_WRITER_LDOP_D));
    }

    public void NELEM_GPR_WRITER_LDOP_Q_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_WRITER_LDOP_Q));
    }

    public void NELEM_GPR_WRITER_LDOP_Q_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_WRITER_LDOP_Q));
    }

    public void NELEM_GPR_WRITER_STORE_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_WRITER_STORE));
    }

    public void NELEM_GPR_WRITER_STORE_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_WRITER_STORE));
    }

    public void NELEM_GPR_WRITER_STORE_BYTE_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_WRITER_STORE_BYTE));
    }

    public void NELEM_GPR_WRITER_STORE_BYTE_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_WRITER_STORE_BYTE));
    }

    public void NELEM_GPR_WRITER_STORE_SUBDWORD_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_WRITER_STORE_SUBDWORD));
    }

    public void NELEM_GPR_WRITER_STORE_SUBDWORD_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_WRITER_STORE_SUBDWORD));
    }

    public void NELEM_GPR_WRITER_STORE_WORD_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GPR_WRITER_STORE_WORD));
    }

    public void NELEM_GPR_WRITER_STORE_WORD_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GPR_WRITER_STORE_WORD));
    }

    public void NELEM_GSCAT_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_GSCAT));
    }

    public void NELEM_GSCAT_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_GSCAT));
    }

    public void NELEM_HALF_DEC()
    {
        // BCRC=0 ELEMENT_SIZE=32 VL=2 => NELEM=8
        // BCRC=1 ELEMENT_SIZE=32 VL=2 => NELEM=1 BCAST=3
        // BCRC=0 ELEMENT_SIZE=32 VL=1 => NELEM=4
        // BCRC=1 ELEMENT_SIZE=32 VL=1 => NELEM=1 BCAST=10
        // BCRC=0 ELEMENT_SIZE=32 VL=0 => NELEM=2
        // BCRC=1 ELEMENT_SIZE=32 VL=0 => NELEM=1 BCAST=22
        // BCRC=0 ELEMENT_SIZE=16 VL=2 => NELEM=16
        // BCRC=1 ELEMENT_SIZE=16 VL=2 => NELEM=1 BCAST=15
        // BCRC=0 ELEMENT_SIZE=16 VL=1 => NELEM=8
        // BCRC=1 ELEMENT_SIZE=16 VL=1 => NELEM=1 BCAST=14
        // BCRC=0 ELEMENT_SIZE=16 VL=0 => NELEM=4
        // BCRC=1 ELEMENT_SIZE=16 VL=0 => NELEM=1 BCAST=27
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_HALF));
    }

    public void NELEM_HALF_ENC()
    {
        // BCAST!=0 => BCRC=1
        // else => BCRC=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_HALF));
    }

    public void NELEM_HALFMEM_DEC()
    {
        // ELEMENT_SIZE=1 VL=2 => NELEM=256
        // ELEMENT_SIZE=2 VL=2 => NELEM=128
        // ELEMENT_SIZE=4 VL=2 => NELEM=64
        // ELEMENT_SIZE=8 VL=2 => NELEM=32
        // ELEMENT_SIZE=16 VL=2 => NELEM=16
        // ELEMENT_SIZE=32 VL=2 => NELEM=8
        // ELEMENT_SIZE=64 VL=2 => NELEM=4
        // ELEMENT_SIZE=128 VL=2 => NELEM=2
        // ELEMENT_SIZE=256 VL=2 => NELEM=1
        // ELEMENT_SIZE=512 VL=2 => error
        // ELEMENT_SIZE=1 VL=1 => NELEM=128
        // ELEMENT_SIZE=2 VL=1 => NELEM=64
        // ELEMENT_SIZE=4 VL=1 => NELEM=32
        // ELEMENT_SIZE=8 VL=1 => NELEM=16
        // ELEMENT_SIZE=16 VL=1 => NELEM=8
        // ELEMENT_SIZE=32 VL=1 => NELEM=4
        // ELEMENT_SIZE=64 VL=1 => NELEM=2
        // ELEMENT_SIZE=128 VL=1 => NELEM=1
        // ELEMENT_SIZE=256 VL=1 => error
        // ELEMENT_SIZE=512 VL=1 => error
        // ELEMENT_SIZE=1 VL=0 => NELEM=64
        // ELEMENT_SIZE=2 VL=0 => NELEM=32
        // ELEMENT_SIZE=4 VL=0 => NELEM=16
        // ELEMENT_SIZE=8 VL=0 => NELEM=8
        // ELEMENT_SIZE=16 VL=0 => NELEM=4
        // ELEMENT_SIZE=32 VL=0 => NELEM=2
        // ELEMENT_SIZE=64 VL=0 => NELEM=1
        // ELEMENT_SIZE=128 VL=0 => error
        // ELEMENT_SIZE=256 VL=0 => error
        // ELEMENT_SIZE=512 VL=0 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_HALFMEM));
    }

    public void NELEM_HALFMEM_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_HALFMEM));
    }

    public void NELEM_MEM128_DEC()
    {
        // BCRC=0 => ELEMENT_SIZE=64 NELEM=2
        // BCRC=1 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_MEM128));
    }

    public void NELEM_MEM128_ENC()
    {
        // BCAST!=0 => error
        // else => BCRC=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_MEM128));
    }

    public void NELEM_MOVDDUP_DEC()
    {
        // ELEMENT_SIZE=64 VL=0 => NELEM=1
        // ELEMENT_SIZE=64 VL=1 => NELEM=4
        // ELEMENT_SIZE=64 VL=2 => NELEM=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_MOVDDUP));
    }

    public void NELEM_MOVDDUP_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_MOVDDUP));
    }

    public void NELEM_QUARTERMEM_DEC()
    {
        // ELEMENT_SIZE=1 VL=2 => NELEM=128
        // ELEMENT_SIZE=2 VL=2 => NELEM=64
        // ELEMENT_SIZE=4 VL=2 => NELEM=32
        // ELEMENT_SIZE=8 VL=2 => NELEM=16
        // ELEMENT_SIZE=16 VL=2 => NELEM=8
        // ELEMENT_SIZE=32 VL=2 => NELEM=4
        // ELEMENT_SIZE=64 VL=2 => NELEM=2
        // ELEMENT_SIZE=128 VL=2 => NELEM=1
        // ELEMENT_SIZE=256 VL=2 => error
        // ELEMENT_SIZE=512 VL=2 => error
        // ELEMENT_SIZE=1 VL=1 => NELEM=64
        // ELEMENT_SIZE=2 VL=1 => NELEM=32
        // ELEMENT_SIZE=4 VL=1 => NELEM=16
        // ELEMENT_SIZE=8 VL=1 => NELEM=8
        // ELEMENT_SIZE=16 VL=1 => NELEM=4
        // ELEMENT_SIZE=32 VL=1 => NELEM=2
        // ELEMENT_SIZE=64 VL=1 => NELEM=1
        // ELEMENT_SIZE=128 VL=1 => error
        // ELEMENT_SIZE=256 VL=1 => error
        // ELEMENT_SIZE=512 VL=1 => error
        // ELEMENT_SIZE=1 VL=0 => NELEM=32
        // ELEMENT_SIZE=2 VL=0 => NELEM=16
        // ELEMENT_SIZE=4 VL=0 => NELEM=8
        // ELEMENT_SIZE=8 VL=0 => NELEM=4
        // ELEMENT_SIZE=16 VL=0 => NELEM=2
        // ELEMENT_SIZE=32 VL=0 => NELEM=1
        // ELEMENT_SIZE=64 VL=0 => error
        // ELEMENT_SIZE=128 VL=0 => error
        // ELEMENT_SIZE=256 VL=0 => error
        // ELEMENT_SIZE=512 VL=0 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_QUARTERMEM));
    }

    public void NELEM_QUARTERMEM_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_QUARTERMEM));
    }

    public void NELEM_SCALAR_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_SCALAR));
    }

    public void NELEM_SCALAR_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_SCALAR));
    }

    public void NELEM_TUPLE1_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE1));
    }

    public void NELEM_TUPLE1_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE1));
    }

    public void NELEM_TUPLE1_4X_DEC()
    {
        // VL=0 => NELEM=4
        // VL=1 => NELEM=4
        // VL=2 => NELEM=4
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE1_4X));
    }

    public void NELEM_TUPLE1_4X_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE1_4X));
    }

    public void NELEM_TUPLE1_BYTE_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE1_BYTE));
    }

    public void NELEM_TUPLE1_BYTE_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE1_BYTE));
    }

    public void NELEM_TUPLE1_SUBDWORD_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE1_SUBDWORD));
    }

    public void NELEM_TUPLE1_SUBDWORD_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE1_SUBDWORD));
    }

    public void NELEM_TUPLE1_WORD_DEC()
    {
        // VL=0 => NELEM=1
        // VL=1 => NELEM=1
        // VL=2 => NELEM=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE1_WORD));
    }

    public void NELEM_TUPLE1_WORD_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE1_WORD));
    }

    public void NELEM_TUPLE2_DEC()
    {
        // VL=0 => NELEM=2
        // VL=1 => NELEM=2
        // VL=2 => NELEM=2
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE2));
    }

    public void NELEM_TUPLE2_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE2));
    }

    public void NELEM_TUPLE4_DEC()
    {
        // VL=0 => NELEM=4
        // VL=1 => NELEM=4
        // VL=2 => NELEM=4
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE4));
    }

    public void NELEM_TUPLE4_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE4));
    }

    public void NELEM_TUPLE8_DEC()
    {
        // VL=0 => NELEM=8
        // VL=1 => NELEM=8
        // VL=2 => NELEM=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.NELEM_TUPLE8));
    }

    public void NELEM_TUPLE8_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.NELEM_TUPLE8));
    }

    public void OeAX_DEC()
    {
        // EOSZ=1 => OUTREG=AX
        // EOSZ=2 => OUTREG=EAX
        // EOSZ=3 => OUTREG=EAX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OeAX));
    }

    public void ONE_DEC()
    {
        // MODE=0 => IMM_WIDTH=8 UIMM0=1
        // MODE=1 => IMM_WIDTH=8 UIMM0=1
        // MODE=2 => IMM_WIDTH=8 UIMM0=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ONE));
    }

    public void OrAX_DEC()
    {
        // EOSZ=1 => OUTREG=AX
        // EOSZ=2 => OUTREG=EAX
        // EOSZ=3 => OUTREG=RAX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OrAX));
    }

    public void OrBP_DEC()
    {
        // EOSZ=1 => OUTREG=BP
        // EOSZ=2 => OUTREG=EBP
        // EOSZ=3 => OUTREG=RBP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OrBP));
    }

    public void OrBX_DEC()
    {
        // EOSZ=1 => OUTREG=BX
        // EOSZ=2 => OUTREG=EBX
        // EOSZ=3 => OUTREG=RBX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OrBX));
    }

    public void OrCX_DEC()
    {
        // EOSZ=1 => OUTREG=CX
        // EOSZ=2 => OUTREG=ECX
        // EOSZ=3 => OUTREG=RCX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OrCX));
    }

    public void OrDX_DEC()
    {
        // EOSZ=1 => OUTREG=DX
        // EOSZ=2 => OUTREG=EDX
        // EOSZ=3 => OUTREG=RDX
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OrDX));
    }

    public void OrSP_DEC()
    {
        // EOSZ=1 => OUTREG=SP
        // EOSZ=2 => OUTREG=ESP
        // EOSZ=3 => OUTREG=RSP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OrSP));
    }

    public void OSZ_NONTERM_DEC()
    {
        // MODE=0 OSZ=0 => EOSZ=1
        // MODE=0 OSZ=1 => EOSZ=2
        // MODE=1 OSZ=1 => EOSZ=1
        // MODE=1 OSZ=0 => EOSZ=2
        // MODE=2 OSZ=1 REXW=0 => EOSZ=1
        // MODE=2 OSZ=0 REXW=0 => EOSZ=2
        // MODE=2 OSZ=1 REXW=1 => EOSZ=3
        // MODE=2 OSZ=0 REXW=1 => EOSZ=3
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OSZ_NONTERM));
    }

    public void OSZ_NONTERM_ENC_ENC()
    {
        // VEXVALID=0 MODE=0 EOSZ=1 => null
        // VEXVALID=0 MODE=0 EOSZ=2 DF32=1 => null
        // VEXVALID=0 MODE=0 EOSZ=2 DF32=0 => OSZ=1
        // VEXVALID=0 MODE=1 EOSZ=1 => OSZ=1
        // VEXVALID=0 MODE=1 EOSZ=2 => null
        // VEXVALID=0 MODE=2 EOSZ=1 => OSZ=1
        // VEXVALID=0 MODE=2 EOSZ=2 DF64=1 => error
        // VEXVALID=0 MODE=2 EOSZ=2 DF64=0 => null
        // VEXVALID=0 MODE=2 EOSZ=3 DF64=1 => null
        // VEXVALID=0 MODE=2 EOSZ=3 DF64=0 => REXW=1
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.OSZ_NONTERM_ENC));
    }

    public void OVERRIDE_SEG0_DEC()
    {
        // MODE=0 => MODE=0 =>
        // MODE=1 => MODE=1 =>
        // MODE=2 => MODE=2 =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OVERRIDE_SEG0));
    }

    public void OVERRIDE_SEG0_ENC()
    {
        // SEG0=@ => SEG_OVD=0
        // SEG0=DS => SEG_OVD=0
        // SEG0=CS => SEG_OVD=1
        // SEG0=ES => SEG_OVD=3
        // SEG0=FS => SEG_OVD=4
        // SEG0=GS => SEG_OVD=5
        // SEG0=SS => SEG_OVD=6
        Context.RuleActivated((RuleTableKind.ENC,RuleName.OVERRIDE_SEG0));
    }

    public void OVERRIDE_SEG1_DEC()
    {
        // MODE=0 => MODE=0 =>
        // MODE=1 => MODE=1 =>
        // MODE=2 => MODE=2 =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.OVERRIDE_SEG1));
    }

    public void OVERRIDE_SEG1_ENC()
    {
        // SEG1=@ => SEG_OVD=0
        // SEG1=DS => SEG_OVD=0
        // SEG1=CS => SEG_OVD=1
        // SEG1=ES => SEG_OVD=3
        // SEG1=FS => SEG_OVD=4
        // SEG1=GS => SEG_OVD=5
        // SEG1=SS => SEG_OVD=6
        Context.RuleActivated((RuleTableKind.ENC,RuleName.OVERRIDE_SEG1));
    }

    public void PREFIX_ENC_ENC()
    {
        // REP=2 => 0xF2 NO_RETURN=1
        // REP=3 => 0xF3 NO_RETURN=1
        // OSZ=1 => 0x66 NO_RETURN=1
        // ASZ=1 => 0x67 NO_RETURN=1
        // LOCK=1 => 0xF0 NO_RETURN=1
        // SEG_OVD=4 => 0x64 NO_RETURN=1
        // SEG_OVD=5 => 0x65 NO_RETURN=1
        // MODE=2 HINT=3 => 0x2E NO_RETURN=1
        // MODE=2 HINT=4 => 0x3E NO_RETURN=1
        // MODE=2 HINT=5 => 0x3E NO_RETURN=1
        // MODE=3 SEG_OVD=1 => 0x2E NO_RETURN=1
        // MODE=3 HINT=3 => 0x2E NO_RETURN=1
        // MODE=3 SEG_OVD=2 => 0x3E NO_RETURN=1
        // MODE=3 HINT=4 => 0x3E NO_RETURN=1
        // MODE=3 HINT=5 => 0x3E NO_RETURN=1
        // MODE=3 SEG_OVD=3 => 0x26 NO_RETURN=1
        // MODE=3 SEG_OVD=6 => 0x36 NO_RETURN=1
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.PREFIX_ENC));
    }

    public void PREFIXES_DEC()
    {
        // MODE=2 0b0010_0 wrxb => REX=1 REXW=1 REXR=1 REXX=1 REXB=1
        // MODE=2 0xF2 MODE_FIRST_PREFIX=0 => REX=0 REXW=0 REXB=0 REXR=0 REXX=0 REP=2 REP=2
        // MODE=2 0xF3 MODE_FIRST_PREFIX=0 => REX=0 REXW=0 REXB=0 REXR=0 REXX=0 REP=3 REP=3
        // MODE=2 0xF2 MODE_FIRST_PREFIX=1 REP=0 => REX=0 REXW=0 REXB=0 REXR=0 REXX=0 REP=2 REP=2
        // MODE=2 0xF3 MODE_FIRST_PREFIX=1 REP=0 => REX=0 REXW=0 REXB=0 REXR=0 REXX=0 REP=3 REP=3
        // MODE=2 0xF2 MODE_FIRST_PREFIX=1 REP!=0 => REX=0
        // MODE=2 0xF3 MODE_FIRST_PREFIX=1 REP!=0 => REX=0
        // MODE=2 0x66 => OSZ=1 PREFIX66=1 REX=0 REXW=0 REXB=0 REXR=0 REXX=0
        // MODE=2 0x67 => ASZ=1 REX=0 REXW=0 REXB=0 REXR=0 REXX=0
        // MODE=2 0xF0 => LOCK=1 REX=0 REXW=0 REXB=0 REXR=0 REXX=0
        // MODE=2 0x2E => HINT=1 REX=0 REXW=0 REXB=0 REXR=0 REXX=0
        // MODE=2 0x3E => HINT=2 REX=0 REXW=0 REXB=0 REXR=0 REXX=0
        // MODE=2 0x26 => REX=0
        // MODE=2 0x64 => SEG_OVD=4 REX=0 REXW=0 REXB=0 REXR=0 REXX=0
        // MODE=2 0x65 => SEG_OVD=5 REX=0 REXW=0 REXB=0 REXR=0 REXX=0
        // MODE=2 0x36 => REX=0
        // MODE=1 0xF2 MODE_FIRST_PREFIX=0 => REP=2 REP=2
        // MODE=1 0xF3 MODE_FIRST_PREFIX=0 => REP=3 REP=3
        // MODE=1 0xF2 MODE_FIRST_PREFIX=1 REP=0 => REP=2 REP=2
        // MODE=1 0xF3 MODE_FIRST_PREFIX=1 REP=0 => REP=3 REP=3
        // MODE=1 0xF2 MODE_FIRST_PREFIX=1 REP!=0 => MODE=1 0xF2 MODE_FIRST_PREFIX=1 REP!=0 =>
        // MODE=1 0xF3 MODE_FIRST_PREFIX=1 REP!=0 => MODE=1 0xF3 MODE_FIRST_PREFIX=1 REP!=0 =>
        // MODE=1 0x66 => OSZ=1 PREFIX66=1
        // MODE=1 0x67 => ASZ=1
        // MODE=1 0xF0 => LOCK=1
        // MODE=1 0x2E => SEG_OVD=1 HINT=1
        // MODE=1 0x3E => SEG_OVD=2 HINT=2
        // MODE=1 0x26 => SEG_OVD=3
        // MODE=1 0x64 => SEG_OVD=4
        // MODE=1 0x65 => SEG_OVD=5
        // MODE=1 0x36 => SEG_OVD=6
        // MODE=0 0xF2 MODE_FIRST_PREFIX=0 => REP=2 REP=2
        // MODE=0 0xF3 MODE_FIRST_PREFIX=0 => REP=3 REP=3
        // MODE=0 0xF2 MODE_FIRST_PREFIX=1 REP=0 => REP=2 REP=2
        // MODE=0 0xF3 MODE_FIRST_PREFIX=1 REP=0 => REP=3 REP=3
        // MODE=0 0xF2 MODE_FIRST_PREFIX=1 REP!=0 => MODE=0 0xF2 MODE_FIRST_PREFIX=1 REP!=0 =>
        // MODE=0 0xF3 MODE_FIRST_PREFIX=1 REP!=0 => MODE=0 0xF3 MODE_FIRST_PREFIX=1 REP!=0 =>
        // MODE=0 0x66 => OSZ=1 PREFIX66=1
        // MODE=0 0x67 => ASZ=1
        // MODE=0 0xF0 => LOCK=1
        // MODE=0 0x2E => SEG_OVD=1 HINT=1
        // MODE=0 0x3E => SEG_OVD=2 HINT=2
        // MODE=0 0x26 => SEG_OVD=3
        // MODE=0 0x64 => SEG_OVD=4
        // MODE=0 0x65 => SEG_OVD=5
        // MODE=0 0x36 => SEG_OVD=6
        // else => else =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.PREFIXES));
    }

    public void REFINING66_DEC()
    {
        // MODE=0 => EOSZ=1 OSZ=0
        // MODE=1 => EOSZ=2 OSZ=0
        // MODE=2 REXW=0 => EOSZ=2 OSZ=0
        // MODE=2 REXW=1 => EOSZ=3 OSZ=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.REFINING66));
    }

    public void REFINING66_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.REFINING66));
    }

    public void REMOVE_SEGMENT_DEC()
    {
        // MODE=0 => SEG0=INVALID
        // MODE=1 => SEG0=INVALID
        // MODE=2 => SEG0=INVALID
        Context.RuleActivated((RuleTableKind.DEC,RuleName.REMOVE_SEGMENT));
    }

    public void REMOVE_SEGMENT_ENC()
    {
        // AGEN=0 => null
        // AGEN=1 => REMOVE_SEGMENT_AGEN1()
        Context.RuleActivated((RuleTableKind.ENC,RuleName.REMOVE_SEGMENT));
    }

    public void REMOVE_SEGMENT_AGEN1_ENC()
    {
        // SEG0=@ => null
        // SEG0=SEGe() => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.REMOVE_SEGMENT_AGEN1));
    }

    public void REX_PREFIX_ENC_ENC()
    {
        // MODE=2 NOREX=0 NEEDREX=1 REXW[w] REXB[b] REXX[x] REXR[r] => 0b0010_0 wrxb
        // MODE=2 NOREX=0 REX=1 REXW[w] REXB[b] REXX[x] REXR[r] => 0b0010_0 wrxb
        // MODE=2 NOREX=0 REXW=1 REXB[b] REXX[x] REXR[r] => 0b0010_0 wrxb
        // MODE=2 NOREX=0 REXW[w] REXB=1 REXX[x] REXR[r] => 0b0010_0 wrxb
        // MODE=2 NOREX=0 REXW[w] REXB[b] REXX=1 REXR[r] => 0b0010_0 wrxb
        // MODE=2 NOREX=0 REXW[w] REXB[b] REXX[x] REXR=1 => 0b0010_0 wrxb
        // MODE=2 NOREX=1 NEEDREX=1 => error
        // MODE=2 NOREX=1 REX=1 => error
        // MODE=2 NOREX=1 REXW=1 => error
        // MODE=2 NOREX=1 REXB=1 => error
        // MODE=2 NOREX=1 REXX=1 => error
        // MODE=2 NOREX=1 REXR=1 => error
        // MODE=2 NEEDREX=0 REX=0 REXW=0 REXB=0 REXX=0 REXR=0 => null
        // MODE=1 REX=0 REXW=0 REXB=0 REXX=0 REXR=0 => null
        // MODE=0 REX=0 REXW=0 REXB=0 REXX=0 REXR=0 => null
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.REX_PREFIX_ENC));
    }

    public void rFLAGS_DEC()
    {
        // MODE=0 => OUTREG=FLAGS
        // MODE=1 => OUTREG=EFLAGS
        // MODE=2 => OUTREG=RFLAGS
        Context.RuleActivated((RuleTableKind.DEC,RuleName.rFLAGS));
    }

    public void rIP_DEC()
    {
        // MODE=0 => OUTREG=EIP
        // MODE=1 => OUTREG=EIP
        // MODE=2 => OUTREG=RIP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.rIP));
    }

    public void rIPa_DEC()
    {
        // EASZ=2 => OUTREG=EIP
        // EASZ=3 => OUTREG=RIP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.rIPa));
    }

    public void SAE_DEC()
    {
        // BCRC=1 => SAE=1
        // BCRC=0 => error
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SAE));
    }

    public void SAE_ENC()
    {
        // SAE=1 => BCRC=1
        // SAE=0 => BCRC=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SAE));
    }

    public void SE_IMM8_DEC()
    {
        // UIMM0[ssss_uuuu] => IMM_WIDTH=8 
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SE_IMM8));
    }

    public void SE_IMM8_ENC()
    {
        // DUMMY=0 ESRC[ssss] UIMM0[dddd] => ssss_dddd
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SE_IMM8));
    }

    public void SEG_DEC()
    {
        // REG=0 => OUTREG=ES
        // REG=1 => OUTREG=CS
        // REG=2 => OUTREG=SS
        // REG=3 => OUTREG=DS
        // REG=4 => OUTREG=FS
        // REG=5 => OUTREG=GS
        // REG=6 => OUTREG=ERROR ENCODER_PREFERRED=1
        // REG=7 => OUTREG=ERROR
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SEG));
    }

    public void SEG_MOV_DEC()
    {
        // REG=0 => OUTREG=ES
        // REG=1 => OUTREG=ERROR
        // REG=2 => OUTREG=SS
        // REG=3 => OUTREG=DS
        // REG=4 => OUTREG=FS
        // REG=5 => OUTREG=GS
        // REG=6 => OUTREG=ERROR ENCODER_PREFERRED=1
        // REG=7 => OUTREG=ERROR
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SEG_MOV));
    }

    public void SEGe_ENC()
    {
        // OUTREG=DS => null
        // OUTREG=CS => null
        // OUTREG=ES => null
        // OUTREG=FS => null
        // OUTREG=GS => null
        // OUTREG=SS => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SEGe));
    }

    public void SEGMENT_DEFAULT_ENCODE_ENC()
    {
        // BASE0=rIPa() => null
        // BASE0=ArSP() => DEFAULT_SEG=1
        // BASE0=ArBP() => DEFAULT_SEG=1
        // BASE0=@ => DEFAULT_SEG=0
        // BASE0=ArAX() => DEFAULT_SEG=0
        // BASE0=ArCX() => DEFAULT_SEG=0
        // BASE0=ArDX() => DEFAULT_SEG=0
        // BASE0=ArBX() => DEFAULT_SEG=0
        // BASE0=ArSI() => DEFAULT_SEG=0
        // BASE0=ArDI() => DEFAULT_SEG=0
        // BASE0=Ar8() => DEFAULT_SEG=0
        // BASE0=Ar9() => DEFAULT_SEG=0
        // BASE0=Ar10() => DEFAULT_SEG=0
        // BASE0=Ar11() => DEFAULT_SEG=0
        // BASE0=Ar12() => DEFAULT_SEG=0
        // BASE0=Ar13() => DEFAULT_SEG=0
        // BASE0=Ar14() => DEFAULT_SEG=0
        // BASE0=Ar15() => DEFAULT_SEG=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SEGMENT_DEFAULT_ENCODE));
    }

    public void SEGMENT_ENCODE_ENC()
    {
        // DEFAULT_SEG=1 SEG0=@ => SEG_OVD=0
        // DEFAULT_SEG=1 SEG0=CS => SEG_OVD=1
        // DEFAULT_SEG=1 SEG0=DS => SEG_OVD=2
        // DEFAULT_SEG=1 SEG0=SS => SEG_OVD=0
        // DEFAULT_SEG=1 SEG0=ES => SEG_OVD=3
        // DEFAULT_SEG=1 SEG0=FS => SEG_OVD=4
        // DEFAULT_SEG=1 SEG0=GS => SEG_OVD=5
        // DEFAULT_SEG=0 SEG0=@ => SEG_OVD=0
        // DEFAULT_SEG=0 SEG0=CS => SEG_OVD=1
        // DEFAULT_SEG=0 SEG0=DS => SEG_OVD=0
        // DEFAULT_SEG=0 SEG0=SS => SEG_OVD=6
        // DEFAULT_SEG=0 SEG0=ES => SEG_OVD=3
        // DEFAULT_SEG=0 SEG0=FS => SEG_OVD=4
        // DEFAULT_SEG=0 SEG0=GS => SEG_OVD=5
        // else => SEG_OVD=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SEGMENT_ENCODE));
    }

    public void SIB_DEC()
    {
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=ArAX() SCALE=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar8() SCALE=1
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=ArCX() SCALE=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar9() SCALE=1
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDX() SCALE=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar10() SCALE=1
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBX() SCALE=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar11() SCALE=1
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=INVALID SCALE=1 ENCODER_PREFERRED=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar12() SCALE=1
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBP() SCALE=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar13() SCALE=1
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=ArSI() SCALE=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar14() SCALE=1
        // REXX=0 SIBSCALE[0b00] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDI() SCALE=1
        // REXX=1 SIBSCALE[0b00] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar15() SCALE=1
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=ArAX() SCALE=2
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar8() SCALE=2
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=ArCX() SCALE=2
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar9() SCALE=2
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDX() SCALE=2
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar10() SCALE=2
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBX() SCALE=2
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar11() SCALE=2
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=INVALID SCALE=1
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar12() SCALE=2
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBP() SCALE=2
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar13() SCALE=2
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=ArSI() SCALE=2
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar14() SCALE=2
        // REXX=0 SIBSCALE[0b01] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDI() SCALE=2
        // REXX=1 SIBSCALE[0b01] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar15() SCALE=2
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=ArAX() SCALE=4
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar8() SCALE=4
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=ArCX() SCALE=4
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar9() SCALE=4
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDX() SCALE=4
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar10() SCALE=4
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBX() SCALE=4
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar11() SCALE=4
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=INVALID SCALE=1
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar12() SCALE=4
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBP() SCALE=4
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar13() SCALE=4
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=ArSI() SCALE=4
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar14() SCALE=4
        // REXX=0 SIBSCALE[0b10] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDI() SCALE=4
        // REXX=1 SIBSCALE[0b10] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar15() SCALE=4
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=ArAX() SCALE=8
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0000] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar8() SCALE=8
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=ArCX() SCALE=8
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0001] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar9() SCALE=8
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDX() SCALE=8
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0010] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar10() SCALE=8
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBX() SCALE=8
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0011] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar11() SCALE=8
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=INVALID SCALE=1
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0100] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar12() SCALE=8
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=ArBP() SCALE=8
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0101] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar13() SCALE=8
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=ArSI() SCALE=8
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0110] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar14() SCALE=8
        // REXX=0 SIBSCALE[0b11] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=ArDI() SCALE=8
        // REXX=1 SIBSCALE[0b11] SIBINDEX[0b0111] SIBBASE[bbb] SIB_BASE0() => INDEX=Ar15() SCALE=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SIB));
    }

    public void SIB_BASE0_DEC()
    {
        // REXB=0 SIBBASE=0 => BASE0=ArAX() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=0 => BASE0=Ar8() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=1 => BASE0=ArCX() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=1 => BASE0=Ar9() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=2 => BASE0=ArDX() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=2 => BASE0=Ar10() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=3 => BASE0=ArBX() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=3 => BASE0=Ar11() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=4 => BASE0=ArSP() SEG0=FINAL_SSEG()
        // REXB=1 SIBBASE=4 => BASE0=Ar12() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=5 MOD=0 => NEED_MEMDISP=1 BASE0=INVALID SEG0=FINAL_DSEG() ENCODER_PREFERRED=1
        // REXB=0 SIBBASE=5 MOD=1 => BASE0=ArBP() SEG0=FINAL_SSEG() DISP_WIDTH=8
        // REXB=0 SIBBASE=5 MOD=2 => BASE0=ArBP() SEG0=FINAL_SSEG() DISP_WIDTH=32
        // REXB=1 SIBBASE=5 MOD=0 => NEED_MEMDISP=1 BASE0=INVALID SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=5 MOD=1 => BASE0=Ar13() SEG0=FINAL_DSEG() DISP_WIDTH=8
        // REXB=1 SIBBASE=5 MOD=2 => BASE0=Ar13() SEG0=FINAL_DSEG() DISP_WIDTH=32
        // REXB=0 SIBBASE=6 => BASE0=ArSI() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=6 => BASE0=Ar14() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=7 => BASE0=ArDI() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=7 => BASE0=Ar15() SEG0=FINAL_DSEG()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SIB_BASE0));
    }

    public void SIB_NT_ENC()
    {
        // NEED_SIB=1 SIBBASE[bbb] SIBSCALE[ss] SIBINDEX[iii] => ss_iii_bbb
        // NEED_SIB=0 => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SIB_NT));
    }

    public void SIB_REQUIRED_ENCODE_ENC()
    {
        // EASZ=2 INDEX=GPR32e() => NEED_SIB=1
        // EASZ=3 INDEX=GPR64e() => NEED_SIB=1
        // EASZ=3 BASE0=@ DISP_WIDTH=32 => NEED_SIB=1
        // EASZ=2 MODE=2 BASE0=@ DISP_WIDTH=32 => NEED_SIB=1
        // EASZ=2 MODE=0 => null
        // EASZ=2 MODE=1 => null
        // EASZ=4 BASE0=ArSP() => NEED_SIB=1
        // EASZ=4 BASE0=Ar12() => NEED_SIB=1
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SIB_REQUIRED_ENCODE));
    }

    public void SIBBASE_ENCODE_ENC()
    {
        // NEED_SIB=0 => null
        // NEED_SIB=1 => SIBBASE_ENCODE_SIB1()
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SIBBASE_ENCODE));
    }

    public void SIBBASE_ENCODE_SIB1_ENC()
    {
        // BASE0=ArAX() => SIBBASE=0 REXB=0
        // BASE0=Ar8() => SIBBASE=0 REXB=1
        // BASE0=ArCX() => SIBBASE=1 REXB=0
        // BASE0=Ar9() => SIBBASE=1 REXB=1
        // BASE0=ArDX() => SIBBASE=2 REXB=0
        // BASE0=Ar10() => SIBBASE=2 REXB=1
        // BASE0=ArBX() => SIBBASE=3 REXB=0
        // BASE0=Ar11() => SIBBASE=3 REXB=1
        // BASE0=ArSP() => SIBBASE=4 REXB=0
        // BASE0=Ar12() => SIBBASE=4 REXB=1
        // BASE0=@ => DISP_WIDTH_32() SIBBASE=5 REXB=0
        // BASE0=ArBP() => DISP_WIDTH_0_8_32() SIBBASE=5 REXB=0
        // BASE0=Ar13() => DISP_WIDTH_0_8_32() SIBBASE=5 REXB=1
        // BASE0=ArSI() => SIBBASE=6 REXB=0
        // BASE0=Ar14() => SIBBASE=6 REXB=1
        // BASE0=ArDI() => SIBBASE=7 REXB=0
        // BASE0=Ar15() => SIBBASE=7 REXB=1
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SIBBASE_ENCODE_SIB1));
    }

    public void SIBINDEX_ENCODE_ENC()
    {
        // NEED_SIB=0 => null
        // NEED_SIB=1 => SIBINDEX_ENCODE_SIB1()
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SIBINDEX_ENCODE));
    }

    public void SIBINDEX_ENCODE_SIB1_ENC()
    {
        // INDEX=ArAX() => SIBINDEX=0 REXX=0
        // INDEX=Ar8() => SIBINDEX=0 REXX=1
        // INDEX=ArCX() => SIBINDEX=1 REXX=0
        // INDEX=Ar9() => SIBINDEX=1 REXX=1
        // INDEX=ArDX() => SIBINDEX=2 REXX=0
        // INDEX=Ar10() => SIBINDEX=2 REXX=1
        // INDEX=ArBX() => SIBINDEX=3 REXX=0
        // INDEX=Ar11() => SIBINDEX=3 REXX=1
        // INDEX=@ => SIBINDEX=4 REXX=0
        // INDEX=Ar12() => SIBINDEX=4 REXX=1
        // INDEX=ArBP() => SIBINDEX=5 REXX=0
        // INDEX=Ar13() => SIBINDEX=5 REXX=1
        // INDEX=ArSI() => SIBINDEX=6 REXX=0
        // INDEX=Ar14() => SIBINDEX=6 REXX=1
        // INDEX=ArDI() => SIBINDEX=7 REXX=0
        // INDEX=Ar15() => SIBINDEX=7 REXX=1
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SIBINDEX_ENCODE_SIB1));
    }

    public void SIBSCALE_ENCODE_ENC()
    {
        // NEED_SIB=0 => null
        // NEED_SIB=1 SCALE=0 => SIBSCALE=0b00
        // NEED_SIB=1 SCALE=1 => SIBSCALE=0b00
        // NEED_SIB=1 SCALE=2 => SIBSCALE=0b01
        // NEED_SIB=1 SCALE=4 => SIBSCALE=0b10
        // NEED_SIB=1 SCALE=8 => SIBSCALE=0b11
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.SIBSCALE_ENCODE));
    }

    public void SIMM8_DEC()
    {
        // i/8 => IMM_WIDTH=8 IMM0SIGNED=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SIMM8));
    }

    public void SIMMz_DEC()
    {
        // EOSZ=1 i/16 => IMM_WIDTH=16 IMM0SIGNED=1
        // EOSZ=2 i/32 => IMM_WIDTH=32 IMM0SIGNED=1
        // EOSZ=3 i/32 => IMM_WIDTH=32 IMM0SIGNED=1
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SIMMz));
    }

    public void SrBP_DEC()
    {
        // SMODE=0 => OUTREG=BP
        // SMODE=1 => OUTREG=EBP
        // SMODE=2 => OUTREG=RBP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SrBP));
    }

    public void SrSP_DEC()
    {
        // SMODE=0 => OUTREG=SP
        // SMODE=1 => OUTREG=ESP
        // SMODE=2 => OUTREG=RSP
        Context.RuleActivated((RuleTableKind.DEC,RuleName.SrSP));
    }

    public void TMM_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=TMM0
        // REXB=0 RM=1 => OUTREG=TMM1
        // REXB=0 RM=2 => OUTREG=TMM2
        // REXB=0 RM=3 => OUTREG=TMM3
        // REXB=0 RM=4 => OUTREG=TMM4
        // REXB=0 RM=5 => OUTREG=TMM5
        // REXB=0 RM=6 => OUTREG=TMM6
        // REXB=0 RM=7 => OUTREG=TMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.TMM_B));
    }

    public void TMM_N_DEC()
    {
        // VEXDEST3=1 VEXDEST210=7 => OUTREG=TMM0
        // VEXDEST3=1 VEXDEST210=6 => OUTREG=TMM1
        // VEXDEST3=1 VEXDEST210=5 => OUTREG=TMM2
        // VEXDEST3=1 VEXDEST210=4 => OUTREG=TMM3
        // VEXDEST3=1 VEXDEST210=3 => OUTREG=TMM4
        // VEXDEST3=1 VEXDEST210=2 => OUTREG=TMM5
        // VEXDEST3=1 VEXDEST210=1 => OUTREG=TMM6
        // VEXDEST3=1 VEXDEST210=0 => OUTREG=TMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.TMM_N));
    }

    public void TMM_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=TMM0
        // REXR=0 REG=1 => OUTREG=TMM1
        // REXR=0 REG=2 => OUTREG=TMM2
        // REXR=0 REG=3 => OUTREG=TMM3
        // REXR=0 REG=4 => OUTREG=TMM4
        // REXR=0 REG=5 => OUTREG=TMM5
        // REXR=0 REG=6 => OUTREG=TMM6
        // REXR=0 REG=7 => OUTREG=TMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.TMM_R));
    }

    public void UIMM16_DEC()
    {
        // i/16 => IMM_WIDTH=16
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UIMM16));
    }

    public void UIMM32_DEC()
    {
        // i/32 => IMM_WIDTH=32
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UIMM32));
    }

    public void UIMM8_DEC()
    {
        // i/8 => IMM_WIDTH=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UIMM8));
    }

    public void UIMM8_1_DEC()
    {
        // i/8 => DUMMY=0
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UIMM8_1));
    }

    public void UIMMv_DEC()
    {
        // EOSZ=1 i/16 => IMM_WIDTH=16
        // EOSZ=2 i/32 => IMM_WIDTH=32
        // EOSZ=3 i/64 => IMM_WIDTH=64
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UIMMv));
    }

    public void UISA_ENC_INDEX_YMM_ENC()
    {
        // INDEX=YMM0 => VEXDEST4=0 REXX=0 SIBINDEX=0
        // INDEX=YMM1 => VEXDEST4=0 REXX=0 SIBINDEX=1
        // INDEX=YMM2 => VEXDEST4=0 REXX=0 SIBINDEX=2
        // INDEX=YMM3 => VEXDEST4=0 REXX=0 SIBINDEX=3
        // INDEX=YMM4 => VEXDEST4=0 REXX=0 SIBINDEX=4
        // INDEX=YMM5 => VEXDEST4=0 REXX=0 SIBINDEX=5
        // INDEX=YMM6 => VEXDEST4=0 REXX=0 SIBINDEX=6
        // INDEX=YMM7 => VEXDEST4=0 REXX=0 SIBINDEX=7
        // INDEX=YMM8 => VEXDEST4=0 REXX=1 SIBINDEX=0
        // INDEX=YMM9 => VEXDEST4=0 REXX=1 SIBINDEX=1
        // INDEX=YMM10 => VEXDEST4=0 REXX=1 SIBINDEX=2
        // INDEX=YMM11 => VEXDEST4=0 REXX=1 SIBINDEX=3
        // INDEX=YMM12 => VEXDEST4=0 REXX=1 SIBINDEX=4
        // INDEX=YMM13 => VEXDEST4=0 REXX=1 SIBINDEX=5
        // INDEX=YMM14 => VEXDEST4=0 REXX=1 SIBINDEX=6
        // INDEX=YMM15 => VEXDEST4=0 REXX=1 SIBINDEX=7
        // INDEX=YMM16 => VEXDEST4=1 REXX=0 SIBINDEX=0
        // INDEX=YMM17 => VEXDEST4=1 REXX=0 SIBINDEX=1
        // INDEX=YMM18 => VEXDEST4=1 REXX=0 SIBINDEX=2
        // INDEX=YMM19 => VEXDEST4=1 REXX=0 SIBINDEX=3
        // INDEX=YMM20 => VEXDEST4=1 REXX=0 SIBINDEX=4
        // INDEX=YMM21 => VEXDEST4=1 REXX=0 SIBINDEX=5
        // INDEX=YMM22 => VEXDEST4=1 REXX=0 SIBINDEX=6
        // INDEX=YMM23 => VEXDEST4=1 REXX=0 SIBINDEX=7
        // INDEX=YMM24 => VEXDEST4=1 REXX=1 SIBINDEX=0
        // INDEX=YMM25 => VEXDEST4=1 REXX=1 SIBINDEX=1
        // INDEX=YMM26 => VEXDEST4=1 REXX=1 SIBINDEX=2
        // INDEX=YMM27 => VEXDEST4=1 REXX=1 SIBINDEX=3
        // INDEX=YMM28 => VEXDEST4=1 REXX=1 SIBINDEX=4
        // INDEX=YMM29 => VEXDEST4=1 REXX=1 SIBINDEX=5
        // INDEX=YMM30 => VEXDEST4=1 REXX=1 SIBINDEX=6
        // INDEX=YMM31 => VEXDEST4=1 REXX=1 SIBINDEX=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.UISA_ENC_INDEX_YMM));
    }

    public void UISA_ENC_INDEX_ZMM_ENC()
    {
        // INDEX=ZMM0 => VEXDEST4=0 REXX=0 SIBINDEX=0
        // INDEX=ZMM1 => VEXDEST4=0 REXX=0 SIBINDEX=1
        // INDEX=ZMM2 => VEXDEST4=0 REXX=0 SIBINDEX=2
        // INDEX=ZMM3 => VEXDEST4=0 REXX=0 SIBINDEX=3
        // INDEX=ZMM4 => VEXDEST4=0 REXX=0 SIBINDEX=4
        // INDEX=ZMM5 => VEXDEST4=0 REXX=0 SIBINDEX=5
        // INDEX=ZMM6 => VEXDEST4=0 REXX=0 SIBINDEX=6
        // INDEX=ZMM7 => VEXDEST4=0 REXX=0 SIBINDEX=7
        // INDEX=ZMM8 => VEXDEST4=0 REXX=1 SIBINDEX=0
        // INDEX=ZMM9 => VEXDEST4=0 REXX=1 SIBINDEX=1
        // INDEX=ZMM10 => VEXDEST4=0 REXX=1 SIBINDEX=2
        // INDEX=ZMM11 => VEXDEST4=0 REXX=1 SIBINDEX=3
        // INDEX=ZMM12 => VEXDEST4=0 REXX=1 SIBINDEX=4
        // INDEX=ZMM13 => VEXDEST4=0 REXX=1 SIBINDEX=5
        // INDEX=ZMM14 => VEXDEST4=0 REXX=1 SIBINDEX=6
        // INDEX=ZMM15 => VEXDEST4=0 REXX=1 SIBINDEX=7
        // INDEX=ZMM16 => VEXDEST4=1 REXX=0 SIBINDEX=0
        // INDEX=ZMM17 => VEXDEST4=1 REXX=0 SIBINDEX=1
        // INDEX=ZMM18 => VEXDEST4=1 REXX=0 SIBINDEX=2
        // INDEX=ZMM19 => VEXDEST4=1 REXX=0 SIBINDEX=3
        // INDEX=ZMM20 => VEXDEST4=1 REXX=0 SIBINDEX=4
        // INDEX=ZMM21 => VEXDEST4=1 REXX=0 SIBINDEX=5
        // INDEX=ZMM22 => VEXDEST4=1 REXX=0 SIBINDEX=6
        // INDEX=ZMM23 => VEXDEST4=1 REXX=0 SIBINDEX=7
        // INDEX=ZMM24 => VEXDEST4=1 REXX=1 SIBINDEX=0
        // INDEX=ZMM25 => VEXDEST4=1 REXX=1 SIBINDEX=1
        // INDEX=ZMM26 => VEXDEST4=1 REXX=1 SIBINDEX=2
        // INDEX=ZMM27 => VEXDEST4=1 REXX=1 SIBINDEX=3
        // INDEX=ZMM28 => VEXDEST4=1 REXX=1 SIBINDEX=4
        // INDEX=ZMM29 => VEXDEST4=1 REXX=1 SIBINDEX=5
        // INDEX=ZMM30 => VEXDEST4=1 REXX=1 SIBINDEX=6
        // INDEX=ZMM31 => VEXDEST4=1 REXX=1 SIBINDEX=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.UISA_ENC_INDEX_ZMM));
    }

    public void UISA_VMODRM_XMM_DEC()
    {
        // MOD=0 UISA_VSIB_XMM() => MOD=0 UISA_VSIB_XMM() =>
        // MOD=1 UISA_VSIB_XMM() MEMDISP8() => MOD=1 UISA_VSIB_XMM() MEMDISP8() =>
        // MOD=2 UISA_VSIB_XMM() MEMDISP32() => MOD=2 UISA_VSIB_XMM() MEMDISP32() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VMODRM_XMM));
    }

    public void UISA_VMODRM_YMM_DEC()
    {
        // MOD=0 UISA_VSIB_YMM() => MOD=0 UISA_VSIB_YMM() =>
        // MOD=1 UISA_VSIB_YMM() MEMDISP8() => MOD=1 UISA_VSIB_YMM() MEMDISP8() =>
        // MOD=2 UISA_VSIB_YMM() MEMDISP32() => MOD=2 UISA_VSIB_YMM() MEMDISP32() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VMODRM_YMM));
    }

    public void UISA_VMODRM_ZMM_DEC()
    {
        // MOD=0 UISA_VSIB_ZMM() => MOD=0 UISA_VSIB_ZMM() =>
        // MOD=1 UISA_VSIB_ZMM() MEMDISP8() => MOD=1 UISA_VSIB_ZMM() MEMDISP8() =>
        // MOD=2 UISA_VSIB_ZMM() MEMDISP32() => MOD=2 UISA_VSIB_ZMM() MEMDISP32() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VMODRM_ZMM));
    }

    public void UISA_VSIB_BASE_DEC()
    {
        // REXB=0 SIBBASE=0 => BASE0=ArAX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=1 => BASE0=ArCX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=2 => BASE0=ArDX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=3 => BASE0=ArBX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=4 => BASE0=ArSP() SEG0=FINAL_SSEG()
        // REXB=0 SIBBASE=5 MOD=0 MEMDISP32() => BASE0=INVALID SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=5 MOD!=0 => BASE0=ArBP() SEG0=FINAL_SSEG()
        // REXB=0 SIBBASE=6 => BASE0=ArSI() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=7 => BASE0=ArDI() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=0 => BASE0=Ar8() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=1 => BASE0=Ar9() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=2 => BASE0=Ar10() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=3 => BASE0=Ar11() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=4 => BASE0=Ar12() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=5 MOD=0 MEMDISP32() => BASE0=INVALID SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=5 MOD!=0 => BASE0=Ar13() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=6 => BASE0=Ar14() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=7 => BASE0=Ar15() SEG0=FINAL_DSEG()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VSIB_BASE));
    }

    public void UISA_VSIB_INDEX_XMM_DEC()
    {
        // VEXDEST4=0 REXX=0 SIBINDEX=0 => OUTREG=XMM0
        // VEXDEST4=0 REXX=0 SIBINDEX=1 => OUTREG=XMM1
        // VEXDEST4=0 REXX=0 SIBINDEX=2 => OUTREG=XMM2
        // VEXDEST4=0 REXX=0 SIBINDEX=3 => OUTREG=XMM3
        // VEXDEST4=0 REXX=0 SIBINDEX=4 => OUTREG=XMM4
        // VEXDEST4=0 REXX=0 SIBINDEX=5 => OUTREG=XMM5
        // VEXDEST4=0 REXX=0 SIBINDEX=6 => OUTREG=XMM6
        // VEXDEST4=0 REXX=0 SIBINDEX=7 => OUTREG=XMM7
        // VEXDEST4=0 REXX=1 SIBINDEX=0 => OUTREG=XMM8
        // VEXDEST4=0 REXX=1 SIBINDEX=1 => OUTREG=XMM9
        // VEXDEST4=0 REXX=1 SIBINDEX=2 => OUTREG=XMM10
        // VEXDEST4=0 REXX=1 SIBINDEX=3 => OUTREG=XMM11
        // VEXDEST4=0 REXX=1 SIBINDEX=4 => OUTREG=XMM12
        // VEXDEST4=0 REXX=1 SIBINDEX=5 => OUTREG=XMM13
        // VEXDEST4=0 REXX=1 SIBINDEX=6 => OUTREG=XMM14
        // VEXDEST4=0 REXX=1 SIBINDEX=7 => OUTREG=XMM15
        // VEXDEST4=1 REXX=0 SIBINDEX=0 => OUTREG=XMM16
        // VEXDEST4=1 REXX=0 SIBINDEX=1 => OUTREG=XMM17
        // VEXDEST4=1 REXX=0 SIBINDEX=2 => OUTREG=XMM18
        // VEXDEST4=1 REXX=0 SIBINDEX=3 => OUTREG=XMM19
        // VEXDEST4=1 REXX=0 SIBINDEX=4 => OUTREG=XMM20
        // VEXDEST4=1 REXX=0 SIBINDEX=5 => OUTREG=XMM21
        // VEXDEST4=1 REXX=0 SIBINDEX=6 => OUTREG=XMM22
        // VEXDEST4=1 REXX=0 SIBINDEX=7 => OUTREG=XMM23
        // VEXDEST4=1 REXX=1 SIBINDEX=0 => OUTREG=XMM24
        // VEXDEST4=1 REXX=1 SIBINDEX=1 => OUTREG=XMM25
        // VEXDEST4=1 REXX=1 SIBINDEX=2 => OUTREG=XMM26
        // VEXDEST4=1 REXX=1 SIBINDEX=3 => OUTREG=XMM27
        // VEXDEST4=1 REXX=1 SIBINDEX=4 => OUTREG=XMM28
        // VEXDEST4=1 REXX=1 SIBINDEX=5 => OUTREG=XMM29
        // VEXDEST4=1 REXX=1 SIBINDEX=6 => OUTREG=XMM30
        // VEXDEST4=1 REXX=1 SIBINDEX=7 => OUTREG=XMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VSIB_INDEX_XMM));
    }

    public void UISA_VSIB_INDEX_YMM_DEC()
    {
        // VEXDEST4=0 REXX=0 SIBINDEX=0 => OUTREG=YMM0
        // VEXDEST4=0 REXX=0 SIBINDEX=1 => OUTREG=YMM1
        // VEXDEST4=0 REXX=0 SIBINDEX=2 => OUTREG=YMM2
        // VEXDEST4=0 REXX=0 SIBINDEX=3 => OUTREG=YMM3
        // VEXDEST4=0 REXX=0 SIBINDEX=4 => OUTREG=YMM4
        // VEXDEST4=0 REXX=0 SIBINDEX=5 => OUTREG=YMM5
        // VEXDEST4=0 REXX=0 SIBINDEX=6 => OUTREG=YMM6
        // VEXDEST4=0 REXX=0 SIBINDEX=7 => OUTREG=YMM7
        // VEXDEST4=0 REXX=1 SIBINDEX=0 => OUTREG=YMM8
        // VEXDEST4=0 REXX=1 SIBINDEX=1 => OUTREG=YMM9
        // VEXDEST4=0 REXX=1 SIBINDEX=2 => OUTREG=YMM10
        // VEXDEST4=0 REXX=1 SIBINDEX=3 => OUTREG=YMM11
        // VEXDEST4=0 REXX=1 SIBINDEX=4 => OUTREG=YMM12
        // VEXDEST4=0 REXX=1 SIBINDEX=5 => OUTREG=YMM13
        // VEXDEST4=0 REXX=1 SIBINDEX=6 => OUTREG=YMM14
        // VEXDEST4=0 REXX=1 SIBINDEX=7 => OUTREG=YMM15
        // VEXDEST4=1 REXX=0 SIBINDEX=0 => OUTREG=YMM16
        // VEXDEST4=1 REXX=0 SIBINDEX=1 => OUTREG=YMM17
        // VEXDEST4=1 REXX=0 SIBINDEX=2 => OUTREG=YMM18
        // VEXDEST4=1 REXX=0 SIBINDEX=3 => OUTREG=YMM19
        // VEXDEST4=1 REXX=0 SIBINDEX=4 => OUTREG=YMM20
        // VEXDEST4=1 REXX=0 SIBINDEX=5 => OUTREG=YMM21
        // VEXDEST4=1 REXX=0 SIBINDEX=6 => OUTREG=YMM22
        // VEXDEST4=1 REXX=0 SIBINDEX=7 => OUTREG=YMM23
        // VEXDEST4=1 REXX=1 SIBINDEX=0 => OUTREG=YMM24
        // VEXDEST4=1 REXX=1 SIBINDEX=1 => OUTREG=YMM25
        // VEXDEST4=1 REXX=1 SIBINDEX=2 => OUTREG=YMM26
        // VEXDEST4=1 REXX=1 SIBINDEX=3 => OUTREG=YMM27
        // VEXDEST4=1 REXX=1 SIBINDEX=4 => OUTREG=YMM28
        // VEXDEST4=1 REXX=1 SIBINDEX=5 => OUTREG=YMM29
        // VEXDEST4=1 REXX=1 SIBINDEX=6 => OUTREG=YMM30
        // VEXDEST4=1 REXX=1 SIBINDEX=7 => OUTREG=YMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VSIB_INDEX_YMM));
    }

    public void UISA_VSIB_INDEX_ZMM_DEC()
    {
        // VEXDEST4=0 REXX=0 SIBINDEX=0 => OUTREG=ZMM0
        // VEXDEST4=0 REXX=0 SIBINDEX=1 => OUTREG=ZMM1
        // VEXDEST4=0 REXX=0 SIBINDEX=2 => OUTREG=ZMM2
        // VEXDEST4=0 REXX=0 SIBINDEX=3 => OUTREG=ZMM3
        // VEXDEST4=0 REXX=0 SIBINDEX=4 => OUTREG=ZMM4
        // VEXDEST4=0 REXX=0 SIBINDEX=5 => OUTREG=ZMM5
        // VEXDEST4=0 REXX=0 SIBINDEX=6 => OUTREG=ZMM6
        // VEXDEST4=0 REXX=0 SIBINDEX=7 => OUTREG=ZMM7
        // VEXDEST4=0 REXX=1 SIBINDEX=0 => OUTREG=ZMM8
        // VEXDEST4=0 REXX=1 SIBINDEX=1 => OUTREG=ZMM9
        // VEXDEST4=0 REXX=1 SIBINDEX=2 => OUTREG=ZMM10
        // VEXDEST4=0 REXX=1 SIBINDEX=3 => OUTREG=ZMM11
        // VEXDEST4=0 REXX=1 SIBINDEX=4 => OUTREG=ZMM12
        // VEXDEST4=0 REXX=1 SIBINDEX=5 => OUTREG=ZMM13
        // VEXDEST4=0 REXX=1 SIBINDEX=6 => OUTREG=ZMM14
        // VEXDEST4=0 REXX=1 SIBINDEX=7 => OUTREG=ZMM15
        // VEXDEST4=1 REXX=0 SIBINDEX=0 => OUTREG=ZMM16
        // VEXDEST4=1 REXX=0 SIBINDEX=1 => OUTREG=ZMM17
        // VEXDEST4=1 REXX=0 SIBINDEX=2 => OUTREG=ZMM18
        // VEXDEST4=1 REXX=0 SIBINDEX=3 => OUTREG=ZMM19
        // VEXDEST4=1 REXX=0 SIBINDEX=4 => OUTREG=ZMM20
        // VEXDEST4=1 REXX=0 SIBINDEX=5 => OUTREG=ZMM21
        // VEXDEST4=1 REXX=0 SIBINDEX=6 => OUTREG=ZMM22
        // VEXDEST4=1 REXX=0 SIBINDEX=7 => OUTREG=ZMM23
        // VEXDEST4=1 REXX=1 SIBINDEX=0 => OUTREG=ZMM24
        // VEXDEST4=1 REXX=1 SIBINDEX=1 => OUTREG=ZMM25
        // VEXDEST4=1 REXX=1 SIBINDEX=2 => OUTREG=ZMM26
        // VEXDEST4=1 REXX=1 SIBINDEX=3 => OUTREG=ZMM27
        // VEXDEST4=1 REXX=1 SIBINDEX=4 => OUTREG=ZMM28
        // VEXDEST4=1 REXX=1 SIBINDEX=5 => OUTREG=ZMM29
        // VEXDEST4=1 REXX=1 SIBINDEX=6 => OUTREG=ZMM30
        // VEXDEST4=1 REXX=1 SIBINDEX=7 => OUTREG=ZMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VSIB_INDEX_ZMM));
    }

    public void UISA_VSIB_XMM_DEC()
    {
        // SIBSCALE[0b00] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_XMM() SCALE=1
        // SIBSCALE[0b01] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_XMM() SCALE=2
        // SIBSCALE[0b10] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_XMM() SCALE=4
        // SIBSCALE[0b11] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_XMM() SCALE=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VSIB_XMM));
    }

    public void UISA_VSIB_YMM_DEC()
    {
        // SIBSCALE[0b00] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_YMM() SCALE=1
        // SIBSCALE[0b01] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_YMM() SCALE=2
        // SIBSCALE[0b10] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_YMM() SCALE=4
        // SIBSCALE[0b11] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_YMM() SCALE=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VSIB_YMM));
    }

    public void UISA_VSIB_ZMM_DEC()
    {
        // SIBSCALE[0b00] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_ZMM() SCALE=1
        // SIBSCALE[0b01] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_ZMM() SCALE=2
        // SIBSCALE[0b10] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_ZMM() SCALE=4
        // SIBSCALE[0b11] SIBINDEX[iii] SIBBASE[bbb] UISA_VSIB_BASE() => INDEX=UISA_VSIB_INDEX_ZMM() SCALE=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.UISA_VSIB_ZMM));
    }

    public void VEX_ESCVL_ENC_ENC()
    {
        // VL=0 VEX_PREFIX=0 => 0b0000_0
        // VL=0 VEX_PREFIX=1 => 0b0000_1
        // VL=0 VEX_PREFIX=3 => 0b0001_0
        // VL=0 VEX_PREFIX=2 => 0b0001_1
        // VL=1 VEX_PREFIX=0 => 0b0010_0
        // VL=1 VEX_PREFIX=1 => 0b0010_1
        // VL=1 VEX_PREFIX=3 => 0b0011_0
        // VL=1 VEX_PREFIX=2 => 0b0011_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VEX_ESCVL_ENC));
    }

    public void VEX_MAP_ENC_ENC()
    {
        // VEX_C4=1 MAP=0 REXW[w] => 0b0000_0 w
        // VEX_C4=1 MAP=1 REXW[w] => 0b0000_1 w
        // VEX_C4=1 MAP=2 REXW[w] => 0b0001_0 w
        // VEX_C4=1 MAP=3 REXW[w] => 0b0001_1 w
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VEX_MAP_ENC));
    }

    public void VEX_REG_ENC_ENC()
    {
        // MODE=2 VEXDEST3[u] VEXDEST210[ddd] => u_ddd
        // MODE=3 VEXDEST3[u] VEXDEST210[ddd] => 1_ddd
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VEX_REG_ENC));
    }

    public void VEX_REXR_ENC_ENC()
    {
        // MODE=2 REXR=1 => 0b0000_0
        // MODE=2 REXR=0 => 0b0000_1
        // MODE=3 REXR=1 => error
        // MODE=3 REXR=0 => 0b0000_1
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VEX_REXR_ENC));
    }

    public void VEX_REXXB_ENC_ENC()
    {
        // MODE=2 VEX_C4=1 REXX=0 REXB=0 => 0b0001_1
        // MODE=2 VEX_C4=1 REXX=1 REXB=0 => 0b0000_1
        // MODE=2 VEX_C4=1 REXX=0 REXB=1 => 0b0001_0
        // MODE=2 VEX_C4=1 REXX=1 REXB=1 => 0b0000_0
        // MODE=3 VEX_C4=1 REXX=0 REXB=0 => 0b0001_1
        // MODE=3 VEX_C4=1 REXX=1 REXB=0 => error
        // MODE=3 VEX_C4=1 REXX=0 REXB=1 => error
        // MODE=3 VEX_C4=1 REXX=1 REXB=1 => error
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VEX_REXXB_ENC));
    }

    public void VEX_TYPE_ENC_ENC()
    {
        // REXX=1 => 0xC4 VEX_C4=1
        // REXB=1 => 0xC4 VEX_C4=1
        // MAP=0 => 0xC4 VEX_C4=1
        // MAP=2 => 0xC4 VEX_C4=1
        // MAP=3 => 0xC4 VEX_C4=1
        // REXW=1 => 0xC4 VEX_C4=1
        // else => 0xC5 VEX_C4=0
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VEX_TYPE_ENC));
    }

    public void VEXED_REX_ENC()
    {
        // VEXVALID=3 => XOP_ENC()
        // VEXVALID=0 => REX_PREFIX_ENC()
        // VEXVALID=1 => NEWVEX_ENC()
        // VEXVALID=2 => EVEX_ENC()
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VEXED_REX));
    }

    public void VGPR32_B_DEC()
    {
        // MODE=0 => OUTREG=VGPR32_B_32()
        // MODE=1 => OUTREG=VGPR32_B_32()
        // MODE=2 => OUTREG=VGPR32_B_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_B));
    }

    public void VGPR32_B_32_DEC()
    {
        // RM=0 => OUTREG=EAX
        // RM=1 => OUTREG=ECX
        // RM=2 => OUTREG=EDX
        // RM=3 => OUTREG=EBX
        // RM=4 => OUTREG=ESP
        // RM=5 => OUTREG=EBP
        // RM=6 => OUTREG=ESI
        // RM=7 => OUTREG=EDI
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_B_32));
    }

    public void VGPR32_B_64_DEC()
    {
        // REXB=0 RM=0 => OUTREG=EAX
        // REXB=0 RM=1 => OUTREG=ECX
        // REXB=0 RM=2 => OUTREG=EDX
        // REXB=0 RM=3 => OUTREG=EBX
        // REXB=0 RM=4 => OUTREG=ESP
        // REXB=0 RM=5 => OUTREG=EBP
        // REXB=0 RM=6 => OUTREG=ESI
        // REXB=0 RM=7 => OUTREG=EDI
        // REXB=1 RM=0 => OUTREG=R8D
        // REXB=1 RM=1 => OUTREG=R9D
        // REXB=1 RM=2 => OUTREG=R10D
        // REXB=1 RM=3 => OUTREG=R11D
        // REXB=1 RM=4 => OUTREG=R12D
        // REXB=1 RM=5 => OUTREG=R13D
        // REXB=1 RM=6 => OUTREG=R14D
        // REXB=1 RM=7 => OUTREG=R15D
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_B_64));
    }

    public void VGPR32_N_DEC()
    {
        // MODE=0 => OUTREG=VGPR32_N_32()
        // MODE=1 => OUTREG=VGPR32_N_32()
        // MODE=2 => OUTREG=VGPR32_N_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_N));
    }

    public void VGPR32_N_32_DEC()
    {
        // VEXDEST210=7 => OUTREG=EAX
        // VEXDEST210=6 => OUTREG=ECX
        // VEXDEST210=5 => OUTREG=EDX
        // VEXDEST210=4 => OUTREG=EBX
        // VEXDEST210=3 => OUTREG=ESP
        // VEXDEST210=2 => OUTREG=EBP
        // VEXDEST210=1 => OUTREG=ESI
        // VEXDEST210=0 => OUTREG=EDI
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_N_32));
    }

    public void VGPR32_N_64_DEC()
    {
        // VEXDEST3=1 VEXDEST210=7 => OUTREG=EAX
        // VEXDEST3=1 VEXDEST210=6 => OUTREG=ECX
        // VEXDEST3=1 VEXDEST210=5 => OUTREG=EDX
        // VEXDEST3=1 VEXDEST210=4 => OUTREG=EBX
        // VEXDEST3=1 VEXDEST210=3 => OUTREG=ESP
        // VEXDEST3=1 VEXDEST210=2 => OUTREG=EBP
        // VEXDEST3=1 VEXDEST210=1 => OUTREG=ESI
        // VEXDEST3=1 VEXDEST210=0 => OUTREG=EDI
        // VEXDEST3=0 VEXDEST210=7 => OUTREG=R8D
        // VEXDEST3=0 VEXDEST210=6 => OUTREG=R9D
        // VEXDEST3=0 VEXDEST210=5 => OUTREG=R10D
        // VEXDEST3=0 VEXDEST210=4 => OUTREG=R11D
        // VEXDEST3=0 VEXDEST210=3 => OUTREG=R12D
        // VEXDEST3=0 VEXDEST210=2 => OUTREG=R13D
        // VEXDEST3=0 VEXDEST210=1 => OUTREG=R14D
        // VEXDEST3=0 VEXDEST210=0 => OUTREG=R15D
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_N_64));
    }

    public void VGPR32_R_DEC()
    {
        // MODE=0 => OUTREG=VGPR32_R_32()
        // MODE=1 => OUTREG=VGPR32_R_32()
        // MODE=2 => OUTREG=VGPR32_R_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_R));
    }

    public void VGPR32_R_32_DEC()
    {
        // REG=0 => OUTREG=EAX
        // REG=1 => OUTREG=ECX
        // REG=2 => OUTREG=EDX
        // REG=3 => OUTREG=EBX
        // REG=4 => OUTREG=ESP
        // REG=5 => OUTREG=EBP
        // REG=6 => OUTREG=ESI
        // REG=7 => OUTREG=EDI
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_R_32));
    }

    public void VGPR32_R_64_DEC()
    {
        // REXR=0 REG=0 => OUTREG=EAX
        // REXR=0 REG=1 => OUTREG=ECX
        // REXR=0 REG=2 => OUTREG=EDX
        // REXR=0 REG=3 => OUTREG=EBX
        // REXR=0 REG=4 => OUTREG=ESP
        // REXR=0 REG=5 => OUTREG=EBP
        // REXR=0 REG=6 => OUTREG=ESI
        // REXR=0 REG=7 => OUTREG=EDI
        // REXR=1 REG=0 => OUTREG=R8D
        // REXR=1 REG=1 => OUTREG=R9D
        // REXR=1 REG=2 => OUTREG=R10D
        // REXR=1 REG=3 => OUTREG=R11D
        // REXR=1 REG=4 => OUTREG=R12D
        // REXR=1 REG=5 => OUTREG=R13D
        // REXR=1 REG=6 => OUTREG=R14D
        // REXR=1 REG=7 => OUTREG=R15D
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR32_R_64));
    }

    public void VGPR64_B_DEC()
    {
        // REXB=0 RM=0 => OUTREG=RAX
        // REXB=0 RM=1 => OUTREG=RCX
        // REXB=0 RM=2 => OUTREG=RDX
        // REXB=0 RM=3 => OUTREG=RBX
        // REXB=0 RM=4 => OUTREG=RSP
        // REXB=0 RM=5 => OUTREG=RBP
        // REXB=0 RM=6 => OUTREG=RSI
        // REXB=0 RM=7 => OUTREG=RDI
        // REXB=1 RM=0 => OUTREG=R8
        // REXB=1 RM=1 => OUTREG=R9
        // REXB=1 RM=2 => OUTREG=R10
        // REXB=1 RM=3 => OUTREG=R11
        // REXB=1 RM=4 => OUTREG=R12
        // REXB=1 RM=5 => OUTREG=R13
        // REXB=1 RM=6 => OUTREG=R14
        // REXB=1 RM=7 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR64_B));
    }

    public void VGPR64_N_DEC()
    {
        // VEXDEST3=1 VEXDEST210=7 => OUTREG=RAX
        // VEXDEST3=1 VEXDEST210=6 => OUTREG=RCX
        // VEXDEST3=1 VEXDEST210=5 => OUTREG=RDX
        // VEXDEST3=1 VEXDEST210=4 => OUTREG=RBX
        // VEXDEST3=1 VEXDEST210=3 => OUTREG=RSP
        // VEXDEST3=1 VEXDEST210=2 => OUTREG=RBP
        // VEXDEST3=1 VEXDEST210=1 => OUTREG=RSI
        // VEXDEST3=1 VEXDEST210=0 => OUTREG=RDI
        // VEXDEST3=0 VEXDEST210=7 => OUTREG=R8
        // VEXDEST3=0 VEXDEST210=6 => OUTREG=R9
        // VEXDEST3=0 VEXDEST210=5 => OUTREG=R10
        // VEXDEST3=0 VEXDEST210=4 => OUTREG=R11
        // VEXDEST3=0 VEXDEST210=3 => OUTREG=R12
        // VEXDEST3=0 VEXDEST210=2 => OUTREG=R13
        // VEXDEST3=0 VEXDEST210=1 => OUTREG=R14
        // VEXDEST3=0 VEXDEST210=0 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR64_N));
    }

    public void VGPR64_R_DEC()
    {
        // REXR=0 REG=0 => OUTREG=RAX
        // REXR=0 REG=1 => OUTREG=RCX
        // REXR=0 REG=2 => OUTREG=RDX
        // REXR=0 REG=3 => OUTREG=RBX
        // REXR=0 REG=4 => OUTREG=RSP
        // REXR=0 REG=5 => OUTREG=RBP
        // REXR=0 REG=6 => OUTREG=RSI
        // REXR=0 REG=7 => OUTREG=RDI
        // REXR=1 REG=0 => OUTREG=R8
        // REXR=1 REG=1 => OUTREG=R9
        // REXR=1 REG=2 => OUTREG=R10
        // REXR=1 REG=3 => OUTREG=R11
        // REXR=1 REG=4 => OUTREG=R12
        // REXR=1 REG=5 => OUTREG=R13
        // REXR=1 REG=6 => OUTREG=R14
        // REXR=1 REG=7 => OUTREG=R15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPR64_R));
    }

    public void VGPRy_B_DEC()
    {
        // EOSZ=1 => OUTREG=VGPR32_B()
        // EOSZ=2 => OUTREG=VGPR32_B()
        // EOSZ=3 => OUTREG=VGPR64_B()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPRy_B));
    }

    public void VGPRy_N_DEC()
    {
        // EOSZ=1 => OUTREG=VGPR32_N()
        // EOSZ=2 => OUTREG=VGPR32_N()
        // EOSZ=3 => OUTREG=VGPR64_N()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPRy_N));
    }

    public void VGPRy_R_DEC()
    {
        // EOSZ=1 => OUTREG=VGPR32_R()
        // EOSZ=2 => OUTREG=VGPR32_R()
        // EOSZ=3 => OUTREG=VGPR64_R()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VGPRy_R));
    }

    public void VMODRM_MOD_ENCODE_ENC()
    {
        // EASZ=2 DISP_WIDTH=0 BASE0=ArBP() => MOD=1 DISP_WIDTH=8 DISP=0x0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar13() => MOD=1 DISP_WIDTH=8 DISP=0x0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArBP() => MOD=1 DISP_WIDTH=8 DISP=0x0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar13() => MOD=1 DISP_WIDTH=8 DISP=0x0
        // EASZ=2 DISP_WIDTH=0 BASE0=ArAX() => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=ArBX() => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=ArCX() => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=ArDX() => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=ArSI() => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=ArDI() => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=ArSP() => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar8() MODE=2 => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar9() MODE=2 => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar10() MODE=2 => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar11() MODE=2 => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar12() MODE=2 => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar14() MODE=2 => MOD=0
        // EASZ=2 DISP_WIDTH=0 BASE0=Ar15() MODE=2 => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArAX() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArBX() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArCX() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArDX() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArSI() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArDI() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=ArSP() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar8() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar9() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar10() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar11() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar12() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar14() => MOD=0
        // EASZ=3 DISP_WIDTH=0 BASE0=Ar15() => MOD=0
        // EASZ=2 DISP_WIDTH=8 => MOD=1
        // EASZ=3 DISP_WIDTH=8 BASE0=GPR64e() => MOD=1
        // EASZ=2 DISP_WIDTH=32 BASE0=@ => MOD=0
        // EASZ=2 DISP_WIDTH=32 BASE0=GPR32e() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=@ => MOD=0
        // EASZ=3 DISP_WIDTH=32 BASE0=ArAX() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=ArBX() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=ArCX() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=ArDX() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=ArSI() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=ArDI() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=ArSP() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=ArBP() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar8() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar9() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar10() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar11() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar12() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar13() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar14() => MOD=2
        // EASZ=3 DISP_WIDTH=32 BASE0=Ar15() => MOD=2
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VMODRM_MOD_ENCODE));
    }

    public void VMODRM_XMM_DEC()
    {
        // MOD=0 VSIB_XMM() => MOD=0 VSIB_XMM() =>
        // MOD=1 VSIB_XMM() MEMDISP8() => MOD=1 VSIB_XMM() MEMDISP8() =>
        // MOD=2 VSIB_XMM() MEMDISP32() => MOD=2 VSIB_XMM() MEMDISP32() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VMODRM_XMM));
    }

    public void VMODRM_YMM_DEC()
    {
        // MOD=0 VSIB_YMM() => MOD=0 VSIB_YMM() =>
        // MOD=1 VSIB_YMM() MEMDISP8() => MOD=1 VSIB_YMM() MEMDISP8() =>
        // MOD=2 VSIB_YMM() MEMDISP32() => MOD=2 VSIB_YMM() MEMDISP32() =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VMODRM_YMM));
    }

    public void VSIB_BASE_DEC()
    {
        // REXB=0 SIBBASE=0 => BASE0=ArAX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=1 => BASE0=ArCX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=2 => BASE0=ArDX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=3 => BASE0=ArBX() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=4 => BASE0=ArSP() SEG0=FINAL_SSEG()
        // REXB=0 SIBBASE=5 MOD=0 MEMDISP32() => BASE0=INVALID SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=5 MOD!=0 => BASE0=ArBP() SEG0=FINAL_SSEG()
        // REXB=0 SIBBASE=6 => BASE0=ArSI() SEG0=FINAL_DSEG()
        // REXB=0 SIBBASE=7 => BASE0=ArDI() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=0 => BASE0=Ar8() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=1 => BASE0=Ar9() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=2 => BASE0=Ar10() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=3 => BASE0=Ar11() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=4 => BASE0=Ar12() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=5 MOD=0 MEMDISP32() => BASE0=INVALID SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=5 MOD!=0 => BASE0=Ar13() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=6 => BASE0=Ar14() SEG0=FINAL_DSEG()
        // REXB=1 SIBBASE=7 => BASE0=Ar15() SEG0=FINAL_DSEG()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VSIB_BASE));
    }

    public void VSIB_ENC_ENC()
    {
        // DUMMY=0 SIBBASE[bbb] SIBINDEX[iii] SIBSCALE[ss] => ss_iii_bbb
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VSIB_ENC));
    }

    public void VSIB_ENC_BASE_ENC()
    {
        // BASE0=ArAX() => REXB=0 SIBBASE=0
        // BASE0=ArCX() => REXB=0 SIBBASE=1
        // BASE0=ArDX() => REXB=0 SIBBASE=2
        // BASE0=ArBX() => REXB=0 SIBBASE=3
        // BASE0=ArSP() => REXB=0 SIBBASE=4
        // BASE0=@ => DISP_WIDTH_32() REXB=0 SIBBASE=5
        // BASE0=ArBP() => DISP_WIDTH_8_32() REXB=0 SIBBASE=5
        // BASE0=Ar13() => DISP_WIDTH_8_32() REXB=1 SIBBASE=5
        // BASE0=ArSI() => REXB=0 SIBBASE=6
        // BASE0=ArDI() => REXB=0 SIBBASE=7
        // BASE0=Ar8() => REXB=1 SIBBASE=0
        // BASE0=Ar9() => REXB=1 SIBBASE=1
        // BASE0=Ar10() => REXB=1 SIBBASE=2
        // BASE0=Ar11() => REXB=1 SIBBASE=3
        // BASE0=Ar12() => REXB=1 SIBBASE=4
        // BASE0=Ar14() => REXB=1 SIBBASE=6
        // BASE0=Ar15() => REXB=1 SIBBASE=7
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VSIB_ENC_BASE));
    }

    public void VSIB_ENC_INDEX_XMM_ENC()
    {
        // INDEX=XMM0 => REXX=0 SIBINDEX=0
        // INDEX=XMM1 => REXX=0 SIBINDEX=1
        // INDEX=XMM2 => REXX=0 SIBINDEX=2
        // INDEX=XMM3 => REXX=0 SIBINDEX=3
        // INDEX=XMM4 => REXX=0 SIBINDEX=4
        // INDEX=XMM5 => REXX=0 SIBINDEX=5
        // INDEX=XMM6 => REXX=0 SIBINDEX=6
        // INDEX=XMM7 => REXX=0 SIBINDEX=7
        // INDEX=XMM8 => REXX=1 SIBINDEX=0
        // INDEX=XMM9 => REXX=1 SIBINDEX=1
        // INDEX=XMM10 => REXX=1 SIBINDEX=2
        // INDEX=XMM11 => REXX=1 SIBINDEX=3
        // INDEX=XMM12 => REXX=1 SIBINDEX=4
        // INDEX=XMM13 => REXX=1 SIBINDEX=5
        // INDEX=XMM14 => REXX=1 SIBINDEX=6
        // INDEX=XMM15 => REXX=1 SIBINDEX=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VSIB_ENC_INDEX_XMM));
    }

    public void VSIB_ENC_INDEX_YMM_ENC()
    {
        // INDEX=YMM0 => REXX=0 SIBINDEX=0
        // INDEX=YMM1 => REXX=0 SIBINDEX=1
        // INDEX=YMM2 => REXX=0 SIBINDEX=2
        // INDEX=YMM3 => REXX=0 SIBINDEX=3
        // INDEX=YMM4 => REXX=0 SIBINDEX=4
        // INDEX=YMM5 => REXX=0 SIBINDEX=5
        // INDEX=YMM6 => REXX=0 SIBINDEX=6
        // INDEX=YMM7 => REXX=0 SIBINDEX=7
        // INDEX=YMM8 => REXX=1 SIBINDEX=0
        // INDEX=YMM9 => REXX=1 SIBINDEX=1
        // INDEX=YMM10 => REXX=1 SIBINDEX=2
        // INDEX=YMM11 => REXX=1 SIBINDEX=3
        // INDEX=YMM12 => REXX=1 SIBINDEX=4
        // INDEX=YMM13 => REXX=1 SIBINDEX=5
        // INDEX=YMM14 => REXX=1 SIBINDEX=6
        // INDEX=YMM15 => REXX=1 SIBINDEX=7
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VSIB_ENC_INDEX_YMM));
    }

    public void VSIB_ENC_SCALE_ENC()
    {
        // SCALE=0 => SIBSCALE=0b00
        // SCALE=1 => SIBSCALE=0b00
        // SCALE=2 => SIBSCALE=0b01
        // SCALE=4 => SIBSCALE=0b10
        // SCALE=8 => SIBSCALE=0b11
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.VSIB_ENC_SCALE));
    }

    public void VSIB_INDEX_XMM_DEC()
    {
        // REXX=0 SIBINDEX=0 => OUTREG=XMM0
        // REXX=0 SIBINDEX=1 => OUTREG=XMM1
        // REXX=0 SIBINDEX=2 => OUTREG=XMM2
        // REXX=0 SIBINDEX=3 => OUTREG=XMM3
        // REXX=0 SIBINDEX=4 => OUTREG=XMM4
        // REXX=0 SIBINDEX=5 => OUTREG=XMM5
        // REXX=0 SIBINDEX=6 => OUTREG=XMM6
        // REXX=0 SIBINDEX=7 => OUTREG=XMM7
        // REXX=1 SIBINDEX=0 => OUTREG=XMM8
        // REXX=1 SIBINDEX=1 => OUTREG=XMM9
        // REXX=1 SIBINDEX=2 => OUTREG=XMM10
        // REXX=1 SIBINDEX=3 => OUTREG=XMM11
        // REXX=1 SIBINDEX=4 => OUTREG=XMM12
        // REXX=1 SIBINDEX=5 => OUTREG=XMM13
        // REXX=1 SIBINDEX=6 => OUTREG=XMM14
        // REXX=1 SIBINDEX=7 => OUTREG=XMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VSIB_INDEX_XMM));
    }

    public void VSIB_INDEX_YMM_DEC()
    {
        // REXX=0 SIBINDEX=0 => OUTREG=YMM0
        // REXX=0 SIBINDEX=1 => OUTREG=YMM1
        // REXX=0 SIBINDEX=2 => OUTREG=YMM2
        // REXX=0 SIBINDEX=3 => OUTREG=YMM3
        // REXX=0 SIBINDEX=4 => OUTREG=YMM4
        // REXX=0 SIBINDEX=5 => OUTREG=YMM5
        // REXX=0 SIBINDEX=6 => OUTREG=YMM6
        // REXX=0 SIBINDEX=7 => OUTREG=YMM7
        // REXX=1 SIBINDEX=0 => OUTREG=YMM8
        // REXX=1 SIBINDEX=1 => OUTREG=YMM9
        // REXX=1 SIBINDEX=2 => OUTREG=YMM10
        // REXX=1 SIBINDEX=3 => OUTREG=YMM11
        // REXX=1 SIBINDEX=4 => OUTREG=YMM12
        // REXX=1 SIBINDEX=5 => OUTREG=YMM13
        // REXX=1 SIBINDEX=6 => OUTREG=YMM14
        // REXX=1 SIBINDEX=7 => OUTREG=YMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VSIB_INDEX_YMM));
    }

    public void VSIB_XMM_DEC()
    {
        // SIBSCALE[0b00] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_XMM() SCALE=1
        // SIBSCALE[0b01] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_XMM() SCALE=2
        // SIBSCALE[0b10] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_XMM() SCALE=4
        // SIBSCALE[0b11] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_XMM() SCALE=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VSIB_XMM));
    }

    public void VSIB_YMM_DEC()
    {
        // SIBSCALE[0b00] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_YMM() SCALE=1
        // SIBSCALE[0b01] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_YMM() SCALE=2
        // SIBSCALE[0b10] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_YMM() SCALE=4
        // SIBSCALE[0b11] SIBINDEX[iii] SIBBASE[bbb] VSIB_BASE() => INDEX=VSIB_INDEX_YMM() SCALE=8
        Context.RuleActivated((RuleTableKind.DEC,RuleName.VSIB_YMM));
    }

    public void X87_DEC()
    {
        // RM=0 => OUTREG=ST0
        // RM=1 => OUTREG=ST1
        // RM=2 => OUTREG=ST2
        // RM=3 => OUTREG=ST3
        // RM=4 => OUTREG=ST4
        // RM=5 => OUTREG=ST5
        // RM=6 => OUTREG=ST6
        // RM=7 => OUTREG=ST7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.X87));
    }

    public void XMM_B_DEC()
    {
        // MODE=0 => OUTREG=XMM_B_32()
        // MODE=1 => OUTREG=XMM_B_32()
        // MODE=2 => OUTREG=XMM_B_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_B));
    }

    public void XMM_B_32_DEC()
    {
        // RM=0 => OUTREG=XMM0
        // RM=1 => OUTREG=XMM1
        // RM=2 => OUTREG=XMM2
        // RM=3 => OUTREG=XMM3
        // RM=4 => OUTREG=XMM4
        // RM=5 => OUTREG=XMM5
        // RM=6 => OUTREG=XMM6
        // RM=7 => OUTREG=XMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_B_32));
    }

    public void XMM_B_64_DEC()
    {
        // REXB=0 RM=0 => OUTREG=XMM0
        // REXB=0 RM=1 => OUTREG=XMM1
        // REXB=0 RM=2 => OUTREG=XMM2
        // REXB=0 RM=3 => OUTREG=XMM3
        // REXB=0 RM=4 => OUTREG=XMM4
        // REXB=0 RM=5 => OUTREG=XMM5
        // REXB=0 RM=6 => OUTREG=XMM6
        // REXB=0 RM=7 => OUTREG=XMM7
        // REXB=1 RM=0 => OUTREG=XMM8
        // REXB=1 RM=1 => OUTREG=XMM9
        // REXB=1 RM=2 => OUTREG=XMM10
        // REXB=1 RM=3 => OUTREG=XMM11
        // REXB=1 RM=4 => OUTREG=XMM12
        // REXB=1 RM=5 => OUTREG=XMM13
        // REXB=1 RM=6 => OUTREG=XMM14
        // REXB=1 RM=7 => OUTREG=XMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_B_64));
    }

    public void XMM_B3_DEC()
    {
        // MODE=0 => OUTREG=XMM_B3_32()
        // MODE=1 => OUTREG=XMM_B3_32()
        // MODE=2 => OUTREG=XMM_B3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_B3));
    }

    public void XMM_B3_32_DEC()
    {
        // RM=0 => OUTREG=XMM0
        // RM=1 => OUTREG=XMM1
        // RM=2 => OUTREG=XMM2
        // RM=3 => OUTREG=XMM3
        // RM=4 => OUTREG=XMM4
        // RM=5 => OUTREG=XMM5
        // RM=6 => OUTREG=XMM6
        // RM=7 => OUTREG=XMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_B3_32));
    }

    public void XMM_B3_64_DEC()
    {
        // REXX=0 REXB=0 RM=0 => OUTREG=XMM0
        // REXX=0 REXB=0 RM=1 => OUTREG=XMM1
        // REXX=0 REXB=0 RM=2 => OUTREG=XMM2
        // REXX=0 REXB=0 RM=3 => OUTREG=XMM3
        // REXX=0 REXB=0 RM=4 => OUTREG=XMM4
        // REXX=0 REXB=0 RM=5 => OUTREG=XMM5
        // REXX=0 REXB=0 RM=6 => OUTREG=XMM6
        // REXX=0 REXB=0 RM=7 => OUTREG=XMM7
        // REXX=0 REXB=1 RM=0 => OUTREG=XMM8
        // REXX=0 REXB=1 RM=1 => OUTREG=XMM9
        // REXX=0 REXB=1 RM=2 => OUTREG=XMM10
        // REXX=0 REXB=1 RM=3 => OUTREG=XMM11
        // REXX=0 REXB=1 RM=4 => OUTREG=XMM12
        // REXX=0 REXB=1 RM=5 => OUTREG=XMM13
        // REXX=0 REXB=1 RM=6 => OUTREG=XMM14
        // REXX=0 REXB=1 RM=7 => OUTREG=XMM15
        // REXX=1 REXB=0 RM=0 => OUTREG=XMM16
        // REXX=1 REXB=0 RM=1 => OUTREG=XMM17
        // REXX=1 REXB=0 RM=2 => OUTREG=XMM18
        // REXX=1 REXB=0 RM=3 => OUTREG=XMM19
        // REXX=1 REXB=0 RM=4 => OUTREG=XMM20
        // REXX=1 REXB=0 RM=5 => OUTREG=XMM21
        // REXX=1 REXB=0 RM=6 => OUTREG=XMM22
        // REXX=1 REXB=0 RM=7 => OUTREG=XMM23
        // REXX=1 REXB=1 RM=0 => OUTREG=XMM24
        // REXX=1 REXB=1 RM=1 => OUTREG=XMM25
        // REXX=1 REXB=1 RM=2 => OUTREG=XMM26
        // REXX=1 REXB=1 RM=3 => OUTREG=XMM27
        // REXX=1 REXB=1 RM=4 => OUTREG=XMM28
        // REXX=1 REXB=1 RM=5 => OUTREG=XMM29
        // REXX=1 REXB=1 RM=6 => OUTREG=XMM30
        // REXX=1 REXB=1 RM=7 => OUTREG=XMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_B3_64));
    }

    public void XMM_N_DEC()
    {
        // MODE=0 => OUTREG=XMM_N_32()
        // MODE=1 => OUTREG=XMM_N_32()
        // MODE=2 => OUTREG=XMM_N_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_N));
    }

    public void XMM_N_32_DEC()
    {
        // VEXDEST210=7 => OUTREG=XMM0
        // VEXDEST210=6 => OUTREG=XMM1
        // VEXDEST210=5 => OUTREG=XMM2
        // VEXDEST210=4 => OUTREG=XMM3
        // VEXDEST210=3 => OUTREG=XMM4
        // VEXDEST210=2 => OUTREG=XMM5
        // VEXDEST210=1 => OUTREG=XMM6
        // VEXDEST210=0 => OUTREG=XMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_N_32));
    }

    public void XMM_N_64_DEC()
    {
        // VEXDEST3=1 VEXDEST210=7 => OUTREG=XMM0
        // VEXDEST3=1 VEXDEST210=6 => OUTREG=XMM1
        // VEXDEST3=1 VEXDEST210=5 => OUTREG=XMM2
        // VEXDEST3=1 VEXDEST210=4 => OUTREG=XMM3
        // VEXDEST3=1 VEXDEST210=3 => OUTREG=XMM4
        // VEXDEST3=1 VEXDEST210=2 => OUTREG=XMM5
        // VEXDEST3=1 VEXDEST210=1 => OUTREG=XMM6
        // VEXDEST3=1 VEXDEST210=0 => OUTREG=XMM7
        // VEXDEST3=0 VEXDEST210=7 => OUTREG=XMM8
        // VEXDEST3=0 VEXDEST210=6 => OUTREG=XMM9
        // VEXDEST3=0 VEXDEST210=5 => OUTREG=XMM10
        // VEXDEST3=0 VEXDEST210=4 => OUTREG=XMM11
        // VEXDEST3=0 VEXDEST210=3 => OUTREG=XMM12
        // VEXDEST3=0 VEXDEST210=2 => OUTREG=XMM13
        // VEXDEST3=0 VEXDEST210=1 => OUTREG=XMM14
        // VEXDEST3=0 VEXDEST210=0 => OUTREG=XMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_N_64));
    }

    public void XMM_N3_DEC()
    {
        // MODE=0 => OUTREG=XMM_N3_32()
        // MODE=1 => OUTREG=XMM_N3_32()
        // MODE=2 => OUTREG=XMM_N3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_N3));
    }

    public void XMM_N3_32_DEC()
    {
        // VEXDEST210=7 => OUTREG=XMM0
        // VEXDEST210=6 => OUTREG=XMM1
        // VEXDEST210=5 => OUTREG=XMM2
        // VEXDEST210=4 => OUTREG=XMM3
        // VEXDEST210=3 => OUTREG=XMM4
        // VEXDEST210=2 => OUTREG=XMM5
        // VEXDEST210=1 => OUTREG=XMM6
        // VEXDEST210=0 => OUTREG=XMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_N3_32));
    }

    public void XMM_N3_64_DEC()
    {
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=7 => OUTREG=XMM0
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=6 => OUTREG=XMM1
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=5 => OUTREG=XMM2
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=4 => OUTREG=XMM3
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=3 => OUTREG=XMM4
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=2 => OUTREG=XMM5
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=1 => OUTREG=XMM6
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=0 => OUTREG=XMM7
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=7 => OUTREG=XMM8
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=6 => OUTREG=XMM9
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=5 => OUTREG=XMM10
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=4 => OUTREG=XMM11
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=3 => OUTREG=XMM12
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=2 => OUTREG=XMM13
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=1 => OUTREG=XMM14
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=0 => OUTREG=XMM15
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=7 => OUTREG=XMM16
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=6 => OUTREG=XMM17
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=5 => OUTREG=XMM18
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=4 => OUTREG=XMM19
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=3 => OUTREG=XMM20
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=2 => OUTREG=XMM21
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=1 => OUTREG=XMM22
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=0 => OUTREG=XMM23
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=7 => OUTREG=XMM24
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=6 => OUTREG=XMM25
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=5 => OUTREG=XMM26
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=4 => OUTREG=XMM27
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=3 => OUTREG=XMM28
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=2 => OUTREG=XMM29
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=1 => OUTREG=XMM30
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=0 => OUTREG=XMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_N3_64));
    }

    public void XMM_R_DEC()
    {
        // MODE=0 => OUTREG=XMM_R_32()
        // MODE=1 => OUTREG=XMM_R_32()
        // MODE=2 => OUTREG=XMM_R_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_R));
    }

    public void XMM_R_32_DEC()
    {
        // REG=0 => OUTREG=XMM0
        // REG=1 => OUTREG=XMM1
        // REG=2 => OUTREG=XMM2
        // REG=3 => OUTREG=XMM3
        // REG=4 => OUTREG=XMM4
        // REG=5 => OUTREG=XMM5
        // REG=6 => OUTREG=XMM6
        // REG=7 => OUTREG=XMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_R_32));
    }

    public void XMM_R_64_DEC()
    {
        // REXR=0 REG=0 => OUTREG=XMM0
        // REXR=0 REG=1 => OUTREG=XMM1
        // REXR=0 REG=2 => OUTREG=XMM2
        // REXR=0 REG=3 => OUTREG=XMM3
        // REXR=0 REG=4 => OUTREG=XMM4
        // REXR=0 REG=5 => OUTREG=XMM5
        // REXR=0 REG=6 => OUTREG=XMM6
        // REXR=0 REG=7 => OUTREG=XMM7
        // REXR=1 REG=0 => OUTREG=XMM8
        // REXR=1 REG=1 => OUTREG=XMM9
        // REXR=1 REG=2 => OUTREG=XMM10
        // REXR=1 REG=3 => OUTREG=XMM11
        // REXR=1 REG=4 => OUTREG=XMM12
        // REXR=1 REG=5 => OUTREG=XMM13
        // REXR=1 REG=6 => OUTREG=XMM14
        // REXR=1 REG=7 => OUTREG=XMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_R_64));
    }

    public void XMM_R3_DEC()
    {
        // MODE=0 => OUTREG=XMM_R3_32()
        // MODE=1 => OUTREG=XMM_R3_32()
        // MODE=2 => OUTREG=XMM_R3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_R3));
    }

    public void XMM_R3_32_DEC()
    {
        // REG=0 => OUTREG=XMM0
        // REG=1 => OUTREG=XMM1
        // REG=2 => OUTREG=XMM2
        // REG=3 => OUTREG=XMM3
        // REG=4 => OUTREG=XMM4
        // REG=5 => OUTREG=XMM5
        // REG=6 => OUTREG=XMM6
        // REG=7 => OUTREG=XMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_R3_32));
    }

    public void XMM_R3_64_DEC()
    {
        // REXRR=0 REXR=0 REG=0 => OUTREG=XMM0
        // REXRR=0 REXR=0 REG=1 => OUTREG=XMM1
        // REXRR=0 REXR=0 REG=2 => OUTREG=XMM2
        // REXRR=0 REXR=0 REG=3 => OUTREG=XMM3
        // REXRR=0 REXR=0 REG=4 => OUTREG=XMM4
        // REXRR=0 REXR=0 REG=5 => OUTREG=XMM5
        // REXRR=0 REXR=0 REG=6 => OUTREG=XMM6
        // REXRR=0 REXR=0 REG=7 => OUTREG=XMM7
        // REXRR=0 REXR=1 REG=0 => OUTREG=XMM8
        // REXRR=0 REXR=1 REG=1 => OUTREG=XMM9
        // REXRR=0 REXR=1 REG=2 => OUTREG=XMM10
        // REXRR=0 REXR=1 REG=3 => OUTREG=XMM11
        // REXRR=0 REXR=1 REG=4 => OUTREG=XMM12
        // REXRR=0 REXR=1 REG=5 => OUTREG=XMM13
        // REXRR=0 REXR=1 REG=6 => OUTREG=XMM14
        // REXRR=0 REXR=1 REG=7 => OUTREG=XMM15
        // REXRR=1 REXR=0 REG=0 => OUTREG=XMM16
        // REXRR=1 REXR=0 REG=1 => OUTREG=XMM17
        // REXRR=1 REXR=0 REG=2 => OUTREG=XMM18
        // REXRR=1 REXR=0 REG=3 => OUTREG=XMM19
        // REXRR=1 REXR=0 REG=4 => OUTREG=XMM20
        // REXRR=1 REXR=0 REG=5 => OUTREG=XMM21
        // REXRR=1 REXR=0 REG=6 => OUTREG=XMM22
        // REXRR=1 REXR=0 REG=7 => OUTREG=XMM23
        // REXRR=1 REXR=1 REG=0 => OUTREG=XMM24
        // REXRR=1 REXR=1 REG=1 => OUTREG=XMM25
        // REXRR=1 REXR=1 REG=2 => OUTREG=XMM26
        // REXRR=1 REXR=1 REG=3 => OUTREG=XMM27
        // REXRR=1 REXR=1 REG=4 => OUTREG=XMM28
        // REXRR=1 REXR=1 REG=5 => OUTREG=XMM29
        // REXRR=1 REXR=1 REG=6 => OUTREG=XMM30
        // REXRR=1 REXR=1 REG=7 => OUTREG=XMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_R3_64));
    }

    public void XMM_SE_DEC()
    {
        // MODE=0 => OUTREG=XMM_SE32()
        // MODE=1 => OUTREG=XMM_SE32()
        // MODE=2 => OUTREG=XMM_SE64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_SE));
    }

    public void XMM_SE32_DEC()
    {
        // ESRC=0x0 => OUTREG=XMM0 ENCODER_PREFERRED=1
        // ESRC=0x1 => OUTREG=XMM1 ENCODER_PREFERRED=1
        // ESRC=0x2 => OUTREG=XMM2 ENCODER_PREFERRED=1
        // ESRC=0x3 => OUTREG=XMM3 ENCODER_PREFERRED=1
        // ESRC=0x4 => OUTREG=XMM4 ENCODER_PREFERRED=1
        // ESRC=0x5 => OUTREG=XMM5 ENCODER_PREFERRED=1
        // ESRC=0x6 => OUTREG=XMM6 ENCODER_PREFERRED=1
        // ESRC=0x7 => OUTREG=XMM7 ENCODER_PREFERRED=1
        // ESRC=0x8 => OUTREG=XMM0
        // ESRC=0x9 => OUTREG=XMM1
        // ESRC=0xA => OUTREG=XMM2
        // ESRC=0xB => OUTREG=XMM3
        // ESRC=0xC => OUTREG=XMM4
        // ESRC=0xD => OUTREG=XMM5
        // ESRC=0xE => OUTREG=XMM6
        // ESRC=0xF => OUTREG=XMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_SE32));
    }

    public void XMM_SE64_DEC()
    {
        // ESRC=0x0 => OUTREG=XMM0
        // ESRC=0x1 => OUTREG=XMM1
        // ESRC=0x2 => OUTREG=XMM2
        // ESRC=0x3 => OUTREG=XMM3
        // ESRC=0x4 => OUTREG=XMM4
        // ESRC=0x5 => OUTREG=XMM5
        // ESRC=0x6 => OUTREG=XMM6
        // ESRC=0x7 => OUTREG=XMM7
        // ESRC=0x8 => OUTREG=XMM8
        // ESRC=0x9 => OUTREG=XMM9
        // ESRC=0xA => OUTREG=XMM10
        // ESRC=0xB => OUTREG=XMM11
        // ESRC=0xC => OUTREG=XMM12
        // ESRC=0xD => OUTREG=XMM13
        // ESRC=0xE => OUTREG=XMM14
        // ESRC=0xF => OUTREG=XMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XMM_SE64));
    }

    public void XOP_MAP_ENC_ENC()
    {
        // MAP=8 REXW[w] => 0b0100_0 w
        // MAP=9 REXW[w] => 0b0100_1 w
        // MAP=10 REXW[w] => 0b0101_0 w
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.XOP_MAP_ENC));
    }

    public void XOP_REXXB_ENC_ENC()
    {
        // MODE=2 REXX=0 REXB=0 => 0b0001_1
        // MODE=2 REXX=1 REXB=0 => 0b0000_1
        // MODE=2 REXX=0 REXB=1 => 0b0001_0
        // MODE=2 REXX=1 REXB=1 => 0b0000_0
        // MODE=3 REXX=0 REXB=0 => 0b0001_1
        // MODE=3 REXX=1 REXB=0 => error
        // MODE=3 REXX=0 REXB=1 => error
        // MODE=3 REXX=1 REXB=1 => error
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.XOP_REXXB_ENC));
    }

    public void XOP_TYPE_ENC_ENC()
    {
        // MAP=8 => 0x8F
        // MAP=9 => 0x8F
        // MAP=10 => 0x8F
        // else => error
        Context.RuleActivated((RuleTableKind.ENC,RuleName.XOP_TYPE_ENC));
    }

    public void YMM_B_DEC()
    {
        // MODE=0 => OUTREG=YMM_B_32()
        // MODE=1 => OUTREG=YMM_B_32()
        // MODE=2 => OUTREG=YMM_B_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_B));
    }

    public void YMM_B_32_DEC()
    {
        // RM=0 => OUTREG=YMM0
        // RM=1 => OUTREG=YMM1
        // RM=2 => OUTREG=YMM2
        // RM=3 => OUTREG=YMM3
        // RM=4 => OUTREG=YMM4
        // RM=5 => OUTREG=YMM5
        // RM=6 => OUTREG=YMM6
        // RM=7 => OUTREG=YMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_B_32));
    }

    public void YMM_B_64_DEC()
    {
        // REXB=0 RM=0 => OUTREG=YMM0
        // REXB=0 RM=1 => OUTREG=YMM1
        // REXB=0 RM=2 => OUTREG=YMM2
        // REXB=0 RM=3 => OUTREG=YMM3
        // REXB=0 RM=4 => OUTREG=YMM4
        // REXB=0 RM=5 => OUTREG=YMM5
        // REXB=0 RM=6 => OUTREG=YMM6
        // REXB=0 RM=7 => OUTREG=YMM7
        // REXB=1 RM=0 => OUTREG=YMM8
        // REXB=1 RM=1 => OUTREG=YMM9
        // REXB=1 RM=2 => OUTREG=YMM10
        // REXB=1 RM=3 => OUTREG=YMM11
        // REXB=1 RM=4 => OUTREG=YMM12
        // REXB=1 RM=5 => OUTREG=YMM13
        // REXB=1 RM=6 => OUTREG=YMM14
        // REXB=1 RM=7 => OUTREG=YMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_B_64));
    }

    public void YMM_B3_DEC()
    {
        // MODE=0 => OUTREG=YMM_B3_32()
        // MODE=1 => OUTREG=YMM_B3_32()
        // MODE=2 => OUTREG=YMM_B3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_B3));
    }

    public void YMM_B3_32_DEC()
    {
        // RM=0 => OUTREG=YMM0
        // RM=1 => OUTREG=YMM1
        // RM=2 => OUTREG=YMM2
        // RM=3 => OUTREG=YMM3
        // RM=4 => OUTREG=YMM4
        // RM=5 => OUTREG=YMM5
        // RM=6 => OUTREG=YMM6
        // RM=7 => OUTREG=YMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_B3_32));
    }

    public void YMM_B3_64_DEC()
    {
        // REXX=0 REXB=0 RM=0 => OUTREG=YMM0
        // REXX=0 REXB=0 RM=1 => OUTREG=YMM1
        // REXX=0 REXB=0 RM=2 => OUTREG=YMM2
        // REXX=0 REXB=0 RM=3 => OUTREG=YMM3
        // REXX=0 REXB=0 RM=4 => OUTREG=YMM4
        // REXX=0 REXB=0 RM=5 => OUTREG=YMM5
        // REXX=0 REXB=0 RM=6 => OUTREG=YMM6
        // REXX=0 REXB=0 RM=7 => OUTREG=YMM7
        // REXX=0 REXB=1 RM=0 => OUTREG=YMM8
        // REXX=0 REXB=1 RM=1 => OUTREG=YMM9
        // REXX=0 REXB=1 RM=2 => OUTREG=YMM10
        // REXX=0 REXB=1 RM=3 => OUTREG=YMM11
        // REXX=0 REXB=1 RM=4 => OUTREG=YMM12
        // REXX=0 REXB=1 RM=5 => OUTREG=YMM13
        // REXX=0 REXB=1 RM=6 => OUTREG=YMM14
        // REXX=0 REXB=1 RM=7 => OUTREG=YMM15
        // REXX=1 REXB=0 RM=0 => OUTREG=YMM16
        // REXX=1 REXB=0 RM=1 => OUTREG=YMM17
        // REXX=1 REXB=0 RM=2 => OUTREG=YMM18
        // REXX=1 REXB=0 RM=3 => OUTREG=YMM19
        // REXX=1 REXB=0 RM=4 => OUTREG=YMM20
        // REXX=1 REXB=0 RM=5 => OUTREG=YMM21
        // REXX=1 REXB=0 RM=6 => OUTREG=YMM22
        // REXX=1 REXB=0 RM=7 => OUTREG=YMM23
        // REXX=1 REXB=1 RM=0 => OUTREG=YMM24
        // REXX=1 REXB=1 RM=1 => OUTREG=YMM25
        // REXX=1 REXB=1 RM=2 => OUTREG=YMM26
        // REXX=1 REXB=1 RM=3 => OUTREG=YMM27
        // REXX=1 REXB=1 RM=4 => OUTREG=YMM28
        // REXX=1 REXB=1 RM=5 => OUTREG=YMM29
        // REXX=1 REXB=1 RM=6 => OUTREG=YMM30
        // REXX=1 REXB=1 RM=7 => OUTREG=YMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_B3_64));
    }

    public void YMM_N_DEC()
    {
        // MODE=0 => OUTREG=YMM_N_32()
        // MODE=1 => OUTREG=YMM_N_32()
        // MODE=2 => OUTREG=YMM_N_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_N));
    }

    public void YMM_N_32_DEC()
    {
        // VEXDEST210=7 => OUTREG=YMM0
        // VEXDEST210=6 => OUTREG=YMM1
        // VEXDEST210=5 => OUTREG=YMM2
        // VEXDEST210=4 => OUTREG=YMM3
        // VEXDEST210=3 => OUTREG=YMM4
        // VEXDEST210=2 => OUTREG=YMM5
        // VEXDEST210=1 => OUTREG=YMM6
        // VEXDEST210=0 => OUTREG=YMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_N_32));
    }

    public void YMM_N_64_DEC()
    {
        // VEXDEST3=1 VEXDEST210=7 => OUTREG=YMM0
        // VEXDEST3=1 VEXDEST210=6 => OUTREG=YMM1
        // VEXDEST3=1 VEXDEST210=5 => OUTREG=YMM2
        // VEXDEST3=1 VEXDEST210=4 => OUTREG=YMM3
        // VEXDEST3=1 VEXDEST210=3 => OUTREG=YMM4
        // VEXDEST3=1 VEXDEST210=2 => OUTREG=YMM5
        // VEXDEST3=1 VEXDEST210=1 => OUTREG=YMM6
        // VEXDEST3=1 VEXDEST210=0 => OUTREG=YMM7
        // VEXDEST3=0 VEXDEST210=7 => OUTREG=YMM8
        // VEXDEST3=0 VEXDEST210=6 => OUTREG=YMM9
        // VEXDEST3=0 VEXDEST210=5 => OUTREG=YMM10
        // VEXDEST3=0 VEXDEST210=4 => OUTREG=YMM11
        // VEXDEST3=0 VEXDEST210=3 => OUTREG=YMM12
        // VEXDEST3=0 VEXDEST210=2 => OUTREG=YMM13
        // VEXDEST3=0 VEXDEST210=1 => OUTREG=YMM14
        // VEXDEST3=0 VEXDEST210=0 => OUTREG=YMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_N_64));
    }

    public void YMM_N3_DEC()
    {
        // MODE=0 => OUTREG=YMM_N3_32()
        // MODE=1 => OUTREG=YMM_N3_32()
        // MODE=2 => OUTREG=YMM_N3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_N3));
    }

    public void YMM_N3_32_DEC()
    {
        // VEXDEST210=7 => OUTREG=YMM0
        // VEXDEST210=6 => OUTREG=YMM1
        // VEXDEST210=5 => OUTREG=YMM2
        // VEXDEST210=4 => OUTREG=YMM3
        // VEXDEST210=3 => OUTREG=YMM4
        // VEXDEST210=2 => OUTREG=YMM5
        // VEXDEST210=1 => OUTREG=YMM6
        // VEXDEST210=0 => OUTREG=YMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_N3_32));
    }

    public void YMM_N3_64_DEC()
    {
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=7 => OUTREG=YMM0
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=6 => OUTREG=YMM1
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=5 => OUTREG=YMM2
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=4 => OUTREG=YMM3
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=3 => OUTREG=YMM4
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=2 => OUTREG=YMM5
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=1 => OUTREG=YMM6
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=0 => OUTREG=YMM7
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=7 => OUTREG=YMM8
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=6 => OUTREG=YMM9
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=5 => OUTREG=YMM10
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=4 => OUTREG=YMM11
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=3 => OUTREG=YMM12
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=2 => OUTREG=YMM13
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=1 => OUTREG=YMM14
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=0 => OUTREG=YMM15
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=7 => OUTREG=YMM16
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=6 => OUTREG=YMM17
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=5 => OUTREG=YMM18
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=4 => OUTREG=YMM19
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=3 => OUTREG=YMM20
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=2 => OUTREG=YMM21
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=1 => OUTREG=YMM22
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=0 => OUTREG=YMM23
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=7 => OUTREG=YMM24
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=6 => OUTREG=YMM25
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=5 => OUTREG=YMM26
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=4 => OUTREG=YMM27
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=3 => OUTREG=YMM28
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=2 => OUTREG=YMM29
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=1 => OUTREG=YMM30
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=0 => OUTREG=YMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_N3_64));
    }

    public void YMM_R_DEC()
    {
        // MODE=0 => OUTREG=YMM_R_32()
        // MODE=1 => OUTREG=YMM_R_32()
        // MODE=2 => OUTREG=YMM_R_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_R));
    }

    public void YMM_R_32_DEC()
    {
        // REG=0 => OUTREG=YMM0
        // REG=1 => OUTREG=YMM1
        // REG=2 => OUTREG=YMM2
        // REG=3 => OUTREG=YMM3
        // REG=4 => OUTREG=YMM4
        // REG=5 => OUTREG=YMM5
        // REG=6 => OUTREG=YMM6
        // REG=7 => OUTREG=YMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_R_32));
    }

    public void YMM_R_64_DEC()
    {
        // REXR=0 REG=0 => OUTREG=YMM0
        // REXR=0 REG=1 => OUTREG=YMM1
        // REXR=0 REG=2 => OUTREG=YMM2
        // REXR=0 REG=3 => OUTREG=YMM3
        // REXR=0 REG=4 => OUTREG=YMM4
        // REXR=0 REG=5 => OUTREG=YMM5
        // REXR=0 REG=6 => OUTREG=YMM6
        // REXR=0 REG=7 => OUTREG=YMM7
        // REXR=1 REG=0 => OUTREG=YMM8
        // REXR=1 REG=1 => OUTREG=YMM9
        // REXR=1 REG=2 => OUTREG=YMM10
        // REXR=1 REG=3 => OUTREG=YMM11
        // REXR=1 REG=4 => OUTREG=YMM12
        // REXR=1 REG=5 => OUTREG=YMM13
        // REXR=1 REG=6 => OUTREG=YMM14
        // REXR=1 REG=7 => OUTREG=YMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_R_64));
    }

    public void YMM_R3_DEC()
    {
        // MODE=0 => OUTREG=YMM_R3_32()
        // MODE=1 => OUTREG=YMM_R3_32()
        // MODE=2 => OUTREG=YMM_R3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_R3));
    }

    public void YMM_R3_32_DEC()
    {
        // REG=0 => OUTREG=YMM0
        // REG=1 => OUTREG=YMM1
        // REG=2 => OUTREG=YMM2
        // REG=3 => OUTREG=YMM3
        // REG=4 => OUTREG=YMM4
        // REG=5 => OUTREG=YMM5
        // REG=6 => OUTREG=YMM6
        // REG=7 => OUTREG=YMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_R3_32));
    }

    public void YMM_R3_64_DEC()
    {
        // REXRR=0 REXR=0 REG=0 => OUTREG=YMM0
        // REXRR=0 REXR=0 REG=1 => OUTREG=YMM1
        // REXRR=0 REXR=0 REG=2 => OUTREG=YMM2
        // REXRR=0 REXR=0 REG=3 => OUTREG=YMM3
        // REXRR=0 REXR=0 REG=4 => OUTREG=YMM4
        // REXRR=0 REXR=0 REG=5 => OUTREG=YMM5
        // REXRR=0 REXR=0 REG=6 => OUTREG=YMM6
        // REXRR=0 REXR=0 REG=7 => OUTREG=YMM7
        // REXRR=0 REXR=1 REG=0 => OUTREG=YMM8
        // REXRR=0 REXR=1 REG=1 => OUTREG=YMM9
        // REXRR=0 REXR=1 REG=2 => OUTREG=YMM10
        // REXRR=0 REXR=1 REG=3 => OUTREG=YMM11
        // REXRR=0 REXR=1 REG=4 => OUTREG=YMM12
        // REXRR=0 REXR=1 REG=5 => OUTREG=YMM13
        // REXRR=0 REXR=1 REG=6 => OUTREG=YMM14
        // REXRR=0 REXR=1 REG=7 => OUTREG=YMM15
        // REXRR=1 REXR=0 REG=0 => OUTREG=YMM16
        // REXRR=1 REXR=0 REG=1 => OUTREG=YMM17
        // REXRR=1 REXR=0 REG=2 => OUTREG=YMM18
        // REXRR=1 REXR=0 REG=3 => OUTREG=YMM19
        // REXRR=1 REXR=0 REG=4 => OUTREG=YMM20
        // REXRR=1 REXR=0 REG=5 => OUTREG=YMM21
        // REXRR=1 REXR=0 REG=6 => OUTREG=YMM22
        // REXRR=1 REXR=0 REG=7 => OUTREG=YMM23
        // REXRR=1 REXR=1 REG=0 => OUTREG=YMM24
        // REXRR=1 REXR=1 REG=1 => OUTREG=YMM25
        // REXRR=1 REXR=1 REG=2 => OUTREG=YMM26
        // REXRR=1 REXR=1 REG=3 => OUTREG=YMM27
        // REXRR=1 REXR=1 REG=4 => OUTREG=YMM28
        // REXRR=1 REXR=1 REG=5 => OUTREG=YMM29
        // REXRR=1 REXR=1 REG=6 => OUTREG=YMM30
        // REXRR=1 REXR=1 REG=7 => OUTREG=YMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_R3_64));
    }

    public void YMM_SE_DEC()
    {
        // MODE=0 => OUTREG=YMM_SE32()
        // MODE=1 => OUTREG=YMM_SE32()
        // MODE=2 => OUTREG=YMM_SE64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_SE));
    }

    public void YMM_SE32_DEC()
    {
        // ESRC=0x0 => OUTREG=YMM0 ENCODER_PREFERRED=1
        // ESRC=0x1 => OUTREG=YMM1 ENCODER_PREFERRED=1
        // ESRC=0x2 => OUTREG=YMM2 ENCODER_PREFERRED=1
        // ESRC=0x3 => OUTREG=YMM3 ENCODER_PREFERRED=1
        // ESRC=0x4 => OUTREG=YMM4 ENCODER_PREFERRED=1
        // ESRC=0x5 => OUTREG=YMM5 ENCODER_PREFERRED=1
        // ESRC=0x6 => OUTREG=YMM6 ENCODER_PREFERRED=1
        // ESRC=0x7 => OUTREG=YMM7 ENCODER_PREFERRED=1
        // ESRC=0x8 => OUTREG=YMM0
        // ESRC=0x9 => OUTREG=YMM1
        // ESRC=0xA => OUTREG=YMM2
        // ESRC=0xB => OUTREG=YMM3
        // ESRC=0xC => OUTREG=YMM4
        // ESRC=0xD => OUTREG=YMM5
        // ESRC=0xE => OUTREG=YMM6
        // ESRC=0xF => OUTREG=YMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_SE32));
    }

    public void YMM_SE64_DEC()
    {
        // ESRC=0x0 => OUTREG=YMM0
        // ESRC=0x1 => OUTREG=YMM1
        // ESRC=0x2 => OUTREG=YMM2
        // ESRC=0x3 => OUTREG=YMM3
        // ESRC=0x4 => OUTREG=YMM4
        // ESRC=0x5 => OUTREG=YMM5
        // ESRC=0x6 => OUTREG=YMM6
        // ESRC=0x7 => OUTREG=YMM7
        // ESRC=0x8 => OUTREG=YMM8
        // ESRC=0x9 => OUTREG=YMM9
        // ESRC=0xA => OUTREG=YMM10
        // ESRC=0xB => OUTREG=YMM11
        // ESRC=0xC => OUTREG=YMM12
        // ESRC=0xD => OUTREG=YMM13
        // ESRC=0xE => OUTREG=YMM14
        // ESRC=0xF => OUTREG=YMM15
        Context.RuleActivated((RuleTableKind.DEC,RuleName.YMM_SE64));
    }

    public void ZMM_B3_DEC()
    {
        // MODE=0 => OUTREG=ZMM_B3_32()
        // MODE=1 => OUTREG=ZMM_B3_32()
        // MODE=2 => OUTREG=ZMM_B3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_B3));
    }

    public void ZMM_B3_32_DEC()
    {
        // RM=0 => OUTREG=ZMM0
        // RM=1 => OUTREG=ZMM1
        // RM=2 => OUTREG=ZMM2
        // RM=3 => OUTREG=ZMM3
        // RM=4 => OUTREG=ZMM4
        // RM=5 => OUTREG=ZMM5
        // RM=6 => OUTREG=ZMM6
        // RM=7 => OUTREG=ZMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_B3_32));
    }

    public void ZMM_B3_64_DEC()
    {
        // REXX=0 REXB=0 RM=0 => OUTREG=ZMM0
        // REXX=0 REXB=0 RM=1 => OUTREG=ZMM1
        // REXX=0 REXB=0 RM=2 => OUTREG=ZMM2
        // REXX=0 REXB=0 RM=3 => OUTREG=ZMM3
        // REXX=0 REXB=0 RM=4 => OUTREG=ZMM4
        // REXX=0 REXB=0 RM=5 => OUTREG=ZMM5
        // REXX=0 REXB=0 RM=6 => OUTREG=ZMM6
        // REXX=0 REXB=0 RM=7 => OUTREG=ZMM7
        // REXX=0 REXB=1 RM=0 => OUTREG=ZMM8
        // REXX=0 REXB=1 RM=1 => OUTREG=ZMM9
        // REXX=0 REXB=1 RM=2 => OUTREG=ZMM10
        // REXX=0 REXB=1 RM=3 => OUTREG=ZMM11
        // REXX=0 REXB=1 RM=4 => OUTREG=ZMM12
        // REXX=0 REXB=1 RM=5 => OUTREG=ZMM13
        // REXX=0 REXB=1 RM=6 => OUTREG=ZMM14
        // REXX=0 REXB=1 RM=7 => OUTREG=ZMM15
        // REXX=1 REXB=0 RM=0 => OUTREG=ZMM16
        // REXX=1 REXB=0 RM=1 => OUTREG=ZMM17
        // REXX=1 REXB=0 RM=2 => OUTREG=ZMM18
        // REXX=1 REXB=0 RM=3 => OUTREG=ZMM19
        // REXX=1 REXB=0 RM=4 => OUTREG=ZMM20
        // REXX=1 REXB=0 RM=5 => OUTREG=ZMM21
        // REXX=1 REXB=0 RM=6 => OUTREG=ZMM22
        // REXX=1 REXB=0 RM=7 => OUTREG=ZMM23
        // REXX=1 REXB=1 RM=0 => OUTREG=ZMM24
        // REXX=1 REXB=1 RM=1 => OUTREG=ZMM25
        // REXX=1 REXB=1 RM=2 => OUTREG=ZMM26
        // REXX=1 REXB=1 RM=3 => OUTREG=ZMM27
        // REXX=1 REXB=1 RM=4 => OUTREG=ZMM28
        // REXX=1 REXB=1 RM=5 => OUTREG=ZMM29
        // REXX=1 REXB=1 RM=6 => OUTREG=ZMM30
        // REXX=1 REXB=1 RM=7 => OUTREG=ZMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_B3_64));
    }

    public void ZMM_N3_DEC()
    {
        // MODE=0 => OUTREG=ZMM_N3_32()
        // MODE=1 => OUTREG=ZMM_N3_32()
        // MODE=2 => OUTREG=ZMM_N3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_N3));
    }

    public void ZMM_N3_32_DEC()
    {
        // VEXDEST210=7 => OUTREG=ZMM0
        // VEXDEST210=6 => OUTREG=ZMM1
        // VEXDEST210=5 => OUTREG=ZMM2
        // VEXDEST210=4 => OUTREG=ZMM3
        // VEXDEST210=3 => OUTREG=ZMM4
        // VEXDEST210=2 => OUTREG=ZMM5
        // VEXDEST210=1 => OUTREG=ZMM6
        // VEXDEST210=0 => OUTREG=ZMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_N3_32));
    }

    public void ZMM_N3_64_DEC()
    {
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=7 => OUTREG=ZMM0
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=6 => OUTREG=ZMM1
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=5 => OUTREG=ZMM2
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=4 => OUTREG=ZMM3
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=3 => OUTREG=ZMM4
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=2 => OUTREG=ZMM5
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=1 => OUTREG=ZMM6
        // VEXDEST4=0 VEXDEST3=1 VEXDEST210=0 => OUTREG=ZMM7
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=7 => OUTREG=ZMM8
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=6 => OUTREG=ZMM9
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=5 => OUTREG=ZMM10
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=4 => OUTREG=ZMM11
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=3 => OUTREG=ZMM12
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=2 => OUTREG=ZMM13
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=1 => OUTREG=ZMM14
        // VEXDEST4=0 VEXDEST3=0 VEXDEST210=0 => OUTREG=ZMM15
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=7 => OUTREG=ZMM16
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=6 => OUTREG=ZMM17
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=5 => OUTREG=ZMM18
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=4 => OUTREG=ZMM19
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=3 => OUTREG=ZMM20
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=2 => OUTREG=ZMM21
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=1 => OUTREG=ZMM22
        // VEXDEST4=1 VEXDEST3=1 VEXDEST210=0 => OUTREG=ZMM23
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=7 => OUTREG=ZMM24
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=6 => OUTREG=ZMM25
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=5 => OUTREG=ZMM26
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=4 => OUTREG=ZMM27
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=3 => OUTREG=ZMM28
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=2 => OUTREG=ZMM29
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=1 => OUTREG=ZMM30
        // VEXDEST4=1 VEXDEST3=0 VEXDEST210=0 => OUTREG=ZMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_N3_64));
    }

    public void ZMM_R3_DEC()
    {
        // MODE=0 => OUTREG=ZMM_R3_32()
        // MODE=1 => OUTREG=ZMM_R3_32()
        // MODE=2 => OUTREG=ZMM_R3_64()
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_R3));
    }

    public void ZMM_R3_32_DEC()
    {
        // REG=0 => OUTREG=ZMM0
        // REG=1 => OUTREG=ZMM1
        // REG=2 => OUTREG=ZMM2
        // REG=3 => OUTREG=ZMM3
        // REG=4 => OUTREG=ZMM4
        // REG=5 => OUTREG=ZMM5
        // REG=6 => OUTREG=ZMM6
        // REG=7 => OUTREG=ZMM7
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_R3_32));
    }

    public void ZMM_R3_64_DEC()
    {
        // REXRR=0 REXR=0 REG=0 => OUTREG=ZMM0
        // REXRR=0 REXR=0 REG=1 => OUTREG=ZMM1
        // REXRR=0 REXR=0 REG=2 => OUTREG=ZMM2
        // REXRR=0 REXR=0 REG=3 => OUTREG=ZMM3
        // REXRR=0 REXR=0 REG=4 => OUTREG=ZMM4
        // REXRR=0 REXR=0 REG=5 => OUTREG=ZMM5
        // REXRR=0 REXR=0 REG=6 => OUTREG=ZMM6
        // REXRR=0 REXR=0 REG=7 => OUTREG=ZMM7
        // REXRR=0 REXR=1 REG=0 => OUTREG=ZMM8
        // REXRR=0 REXR=1 REG=1 => OUTREG=ZMM9
        // REXRR=0 REXR=1 REG=2 => OUTREG=ZMM10
        // REXRR=0 REXR=1 REG=3 => OUTREG=ZMM11
        // REXRR=0 REXR=1 REG=4 => OUTREG=ZMM12
        // REXRR=0 REXR=1 REG=5 => OUTREG=ZMM13
        // REXRR=0 REXR=1 REG=6 => OUTREG=ZMM14
        // REXRR=0 REXR=1 REG=7 => OUTREG=ZMM15
        // REXRR=1 REXR=0 REG=0 => OUTREG=ZMM16
        // REXRR=1 REXR=0 REG=1 => OUTREG=ZMM17
        // REXRR=1 REXR=0 REG=2 => OUTREG=ZMM18
        // REXRR=1 REXR=0 REG=3 => OUTREG=ZMM19
        // REXRR=1 REXR=0 REG=4 => OUTREG=ZMM20
        // REXRR=1 REXR=0 REG=5 => OUTREG=ZMM21
        // REXRR=1 REXR=0 REG=6 => OUTREG=ZMM22
        // REXRR=1 REXR=0 REG=7 => OUTREG=ZMM23
        // REXRR=1 REXR=1 REG=0 => OUTREG=ZMM24
        // REXRR=1 REXR=1 REG=1 => OUTREG=ZMM25
        // REXRR=1 REXR=1 REG=2 => OUTREG=ZMM26
        // REXRR=1 REXR=1 REG=3 => OUTREG=ZMM27
        // REXRR=1 REXR=1 REG=4 => OUTREG=ZMM28
        // REXRR=1 REXR=1 REG=5 => OUTREG=ZMM29
        // REXRR=1 REXR=1 REG=6 => OUTREG=ZMM30
        // REXRR=1 REXR=1 REG=7 => OUTREG=ZMM31
        Context.RuleActivated((RuleTableKind.DEC,RuleName.ZMM_R3_64));
    }

    public void XSAVE_DEC()
    {
        // MODE=0 => MODE=0 =>
        // MODE=1 => MODE=1 =>
        // MODE=2 => MODE=2 =>
        Context.RuleActivated((RuleTableKind.DEC,RuleName.XSAVE));
    }

    public void XSAVE_ENC()
    {
        // else => null
        Context.RuleActivated((RuleTableKind.ENC,RuleName.XSAVE));
    }

}
