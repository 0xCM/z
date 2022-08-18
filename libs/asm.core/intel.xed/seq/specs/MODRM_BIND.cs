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

    partial class XedSeq
    {
        /*
        SEQUENCE MODRM_BIND
            SIB_REQUIRED_ENCODE_BIND()
            SIBSCALE_ENCODE_BIND()
            SIBINDEX_ENCODE_BIND()
            SIBBASE_ENCODE_BIND()
            MODRM_RM_ENCODE_BIND()
            MODRM_MOD_ENCODE_BIND()
            SEGMENT_DEFAULT_ENCODE_BIND()
            SEGMENT_ENCODE_BIND()
            SIB_NT_BIND()
            DISP_NT_BIND()
        */
        public static SeqDef MODRM_BIND() => bind(nameof(MODRM_BIND), new RuleName[]{
            SIB_REQUIRED_ENCODE,
            SIBSCALE_ENCODE,
            SIBINDEX_ENCODE,
            SIBBASE_ENCODE,
            MODRM_RM_ENCODE,
            MODRM_MOD_ENCODE,
            SEGMENT_DEFAULT_ENCODE,
            SEGMENT_ENCODE,
            SIB_NT,
            DISP_NT,
        });
    }
}