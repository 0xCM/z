//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedRules.RuleName;

    partial class XedSeq
    {
        /*
        SEQUENCE NEWVEX_ENC_BIND
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND
        */

        public static SeqDef NEWVEX_ENC_BIND() => bind(nameof(NEWVEX_ENC_BIND), new RuleName[]{
            VEX_TYPE_ENC,
            VEX_REXR_ENC,
            VEX_REXXB_ENC,
            VEX_MAP_ENC,
            VEX_REG_ENC,
            VEX_ESCVL_ENC,
        });
    }
}