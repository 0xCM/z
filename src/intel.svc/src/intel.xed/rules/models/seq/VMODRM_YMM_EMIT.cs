//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedRules.RuleName;

    partial class XedRuleSeq
    {
        /*
        SEQUENCE VMODRM_YMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */

        public static SeqDef VMODRM_YMM_EMIT() => emit(nameof(VMODRM_YMM_EMIT), new RuleName[]{
            VSIB_ENC,
            DISP_NT,
            });
    }
}