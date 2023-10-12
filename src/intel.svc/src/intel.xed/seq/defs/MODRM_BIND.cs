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
        SIB_REQUIRED_ENCODE_BIND,
        SIBSCALE_ENCODE_BIND,
        SIBINDEX_ENCODE_BIND,
        SIBBASE_ENCODE_BIND,
        MODRM_RM_ENCODE_BIND,
        MODRM_MOD_ENCODE_BIND,
        SEGMENT_DEFAULT_ENCODE_BIND,
        SEGMENT_ENCODE_BIND,
        SIB_NT_BIND,
        DISP_NT_BIND,
    });
}
