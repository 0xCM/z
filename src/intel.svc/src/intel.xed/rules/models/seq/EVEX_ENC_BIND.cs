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
        SEQUENCE EVEX_ENC_BIND
            EVEX_62_REXR_ENC_BIND
            EVEX_REXX_ENC_BIND
            EVEX_REXB_ENC_BIND
            EVEX_REXRR_ENC_BIND
            EVEX_MAP_ENC_BIND
            EVEX_REXW_VVVV_ENC_BIND
            EVEX_UPP_ENC_BIND
            EVEX_LL_ENC_BIND
            AVX512_EVEX_BYTE3_ENC_BIND
        */
        public static SeqDef EVEX_ENC_BIND() => bind(nameof(EVEX_ENC_BIND), new RuleName[]{
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