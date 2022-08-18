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
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct FieldOp : ILogicOperand<Value>
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly Value Value;

            [MethodImpl(Inline)]
            public FieldOp(FieldKind field, RuleOperator op, Value value)
            {
                Field = field;
                Operator = op;
                Value = value;
            }

            RuleOperator ILogicOperand.Operator
                => Operator;

            Value ILogicOperand<Value>.Value
                => Value;
        }
    }
}