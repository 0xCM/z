//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;
using static XedModels.RuleName;

partial class XedRuleSeq
{
    /*
    SEQUENCE VMODRM_YMM_BIND
        VMODRM_MOD_ENCODE_BIND
        VSIB_ENC_BASE_BIND
        VSIB_ENC_INDEX_YMM_BIND
        VSIB_ENC_SCALE_BIND
        VSIB_ENC_BIND
        SEGMENT_DEFAULT_ENCODE_BIND
        SEGMENT_ENCODE_BIND
        DISP_NT_BIND
    */

    public static SeqDef VMODRM_YMM_BIND() => bind(nameof(VMODRM_YMM_BIND), new RuleName[]{
        VMODRM_MOD_ENCODE_BIND,
        VSIB_ENC_BASE_BIND,
        VSIB_ENC_INDEX_YMM_BIND,
        VSIB_ENC_SCALE_BIND,
        VSIB_ENC_BIND,
        SEGMENT_DEFAULT_ENCODE_BIND,
        SEGMENT_ENCODE_BIND,
        DISP_NT_BIND,
        });
}
