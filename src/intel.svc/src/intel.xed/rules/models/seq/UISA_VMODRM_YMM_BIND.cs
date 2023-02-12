//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedRules.RuleName;

    partial class XedRuleSeq
    {
        /*
        SEQUENCE UISA_VMODRM_YMM_BIND
            VMODRM_MOD_ENCODE_BIND()  # FROM HSW
            VSIB_ENC_BASE_BIND()      # FROM HSW
            UISA_ENC_INDEX_YMM_BIND()
            VSIB_ENC_SCALE_BIND()   # FROM HSW
            VSIB_ENC_BIND()         # FROM HSW
            SEGMENT_DEFAULT_ENCODE_BIND() # FROM BASE ISA
            SEGMENT_ENCODE_BIND()         # FROM BASE ISA
            DISP_NT_BIND()          # FROM BASE ISA

        */
        public static SeqDef UISA_VMODRM_YMM_BIND() => bind(nameof(UISA_VMODRM_YMM_BIND), new RuleName[]{
            VMODRM_MOD_ENCODE,
            VSIB_ENC_BASE,
            UISA_ENC_INDEX_YMM,
            VSIB_ENC_SCALE,
            VSIB_ENC,
            SEGMENT_DEFAULT_ENCODE,
            SEGMENT_ENCODE,
            DISP_NT,
            });

    }
}