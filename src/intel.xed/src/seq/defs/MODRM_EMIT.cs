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
    SEQUENCE MODRM_EMIT
        SIB_NT_EMIT
        DISP_NT_EMIT
    */
    public static SeqDef MODRM_EMIT() => emit(nameof(MODRM_EMIT), new RuleName[]{
        SIB_NT_EMIT,
        DISP_NT_EMIT,
    });
}
