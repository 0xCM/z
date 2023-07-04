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
        SEQUENCE ISA_BINDINGS
            FIXUP_EOSZ_ENC_BIND()   | FIXUP_EOSZ_ENC
            FIXUP_EASZ_ENC_BIND()   | FIXUP_EASZ_ENC
            ASZ_NONTERM_BIND()      | ASZ_NONTERM
            INSTRUCTIONS_BIND()     | *select encoding function*
            OSZ_NONTERM_ENC_BIND()  | OSZ_NONTERM_ENC
            PREFIX_ENC_BIND()       | PREFIX_ENC
            REX_PREFIX_ENC_BIND()   | REX_PREFIX_ENC

        */
        public static SeqDef ISA_BINDINGS() => bind(nameof(ISA_BINDINGS), new NonterminalKind[]{
                FIXUP_EOSZ_ENC,
                FIXUP_EASZ_ENC,
                ASZ_NONTERM,
                INSTRUCTIONS,
                OSZ_NONTERM_ENC,
                PREFIX_ENC,
                VEXED_REX,
        });
    }
}