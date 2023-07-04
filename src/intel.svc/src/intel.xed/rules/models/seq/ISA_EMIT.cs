//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedModels.NonterminalKind;

    partial class XedRuleSeq
    {
        /*
        SEQUENCE ISA_EMIT
            PREFIX_ENC_EMIT()
            REX_PREFIX_ENC_EMIT() | VEXED_REX_EMIT()
            INSTRUCTIONS_EMIT()
        */
        public static SeqDef ISA_EMIT() => emit(nameof(ISA_EMIT), new NonterminalKind[]{
            PREFIX_ENC,
            VEXED_REX,
            INSTRUCTIONS
        });
    }
}