//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedModels.RuleName;

    partial class XedRuleSeq
    {
        /*
        SEQUENCE VMODRM_XMM_BIND
            VMODRM_MOD_ENCODE_BIND()
            VSIB_ENC_BASE_BIND()
            VSIB_ENC_INDEX_XMM_BIND()
            VSIB_ENC_SCALE_BIND()
            VSIB_ENC_BIND()
            SEGMENT_DEFAULT_ENCODE_BIND()
            SEGMENT_ENCODE_BIND()
            DISP_NT_BIND()
        */

        public static SeqDef VMODRM_XMM_BIND() => bind(nameof(VMODRM_XMM_BIND), new RuleName[]{
            VMODRM_MOD_ENCODE,
            VSIB_ENC_BASE,
            VSIB_ENC_INDEX_XMM,
            VSIB_ENC_SCALE,
            VSIB_ENC,
            SEGMENT_DEFAULT_ENCODE,
            SEGMENT_ENCODE,
            DISP_NT,
            });
    }
}