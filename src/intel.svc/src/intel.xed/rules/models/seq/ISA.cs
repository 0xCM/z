//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedModels.RuleName;

    partial class XedRuleSeq
    {
        /*
        ISA()::
        PREFIXES() OSZ_NONTERM() ASZ_NONTERM() EVEX_SPLITTER() |

        */

        public static SeqDef ISA() => def(nameof(ISA), RuleTableKind.DEC,
            PREFIXES,
            OSZ_NONTERM,
            ASZ_NONTERM,
            EVEX_SPLITTER
            );
    }
}