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
        public static SeqDef VMODRM_XMM_EMIT() => emit(nameof(VMODRM_XMM_EMIT), new RuleName[]{
            VSIB_ENC,
            DISP_NT,
            });
    }
}