//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        public readonly record struct RuleOp : ILogicOperand<Value>
        {
            public readonly Nonterminal Rule;

            public readonly RuleOperator Operator;

            public readonly Value Value;

            [MethodImpl(Inline)]
            public RuleOp(RuleName rule, RuleOperator op, Value value)
            {
                Rule = rule;
                Operator = op;
                Value = value;
            }

            Value ILogicOperand<Value>.Value
                => Value;

            RuleOperator ILogicOperand.Operator
                => Operator;
        }
    }
}