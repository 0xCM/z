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
        SEQUENCE EVEX_ENC_EMIT
            EVEX_62_REXR_ENC_EMIT
            EVEX_REXX_ENC_EMIT
            EVEX_REXB_ENC_EMIT
            EVEX_REXRR_ENC_EMIT
            EVEX_MAP_ENC_EMIT
            EVEX_REXW_VVVV_ENC_EMIT
            EVEX_UPP_ENC_EMIT
            EVEX_LL_ENC_EMIT
            AVX512_EVEX_BYTE3_ENC_EMIT
        */

        public static SeqDef EVEX_ENC_EMIT() => emit(nameof(EVEX_ENC_EMIT), new RuleName[]{
            EVEX_62_REXR_ENC,
            EVEX_REXX_ENC,
            EVEX_REXB_ENC,
            EVEX_REXRR_ENC,
            EVEX_MAP_ENC,
            EVEX_REXW_VVVV_ENC,
            EVEX_UPP_ENC,
            EVEX_LL_ENC,
            AVX512_EVEX_BYTE3_ENC,
            });
    }
}