//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        public readonly record struct RuleOp<T> : ILogicOperand<T>
            where T : unmanaged, IValue<T>
        {
            public readonly Nonterminal Rule;

            public readonly RuleOperator Operator;

            public readonly T Value;

            [MethodImpl(Inline)]
            public RuleOp(RuleName rule, RuleOperator op, T value)
            {
                Rule = rule;
                Operator = op;
                Value = value;
            }

            T ILogicOperand<T>.Value
                => Value;

            RuleOperator ILogicOperand.Operator
                => Operator;

            [MethodImpl(Inline)]
            public static implicit operator RuleOp(RuleOp<T> src)
                =>  new RuleOp(src.Rule, src.Operator, XedGrids.Value.untype(src.Value));
        }
    }
}