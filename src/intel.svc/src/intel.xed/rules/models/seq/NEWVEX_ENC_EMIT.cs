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
        SEQUENCE NEWVEX_ENC_EMIT
            VEX_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            VEX_REXXB_ENC_EMIT
            VEX_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT
        */
        public static SeqDef NEWVEX_ENC_EMIT() => emit(nameof(NEWVEX_ENC_EMIT), new RuleName[]{
            VEX_TYPE_ENC,
            VEX_REXR_ENC,
            VEX_REXXB_ENC,
            VEX_MAP_ENC,
            VEX_REG_ENC,
            VEX_ESCVL_ENC,
        });

    }
}