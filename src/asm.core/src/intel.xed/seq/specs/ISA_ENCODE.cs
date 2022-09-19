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
        SEQUENCE ISA_ENCODE
            ISA_BINDINGS
            ISA_EMIT
        */

        public static SeqControl ISA_ENCODE() => control(nameof(ISA_ENCODE), new SeqDef[]{
            ISA_BINDINGS(),
            ISA_EMIT(),
            });
    }
}