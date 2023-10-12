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
        SEQUENCE UISA_VMODRM_ZMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
    */

    public static SeqDef UISA_VMODRM_ZMM_EMIT() => emit(nameof(UISA_VMODRM_ZMM_EMIT), new RuleName[]{
            VSIB_ENC,
            DISP_NT,
        });
}
