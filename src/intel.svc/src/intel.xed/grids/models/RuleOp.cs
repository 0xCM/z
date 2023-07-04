//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    partial class XedGrids
    {
        public readonly record struct RuleOp : ILogicOperand<Value>
        {
            public readonly Nonterminal Rule;

            public readonly RuleOperator Operator;

            public readonly Value Value;

            [MethodImpl(Inline)]
            public RuleOp(NonterminalKind rule, RuleOperator op, Value value)
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