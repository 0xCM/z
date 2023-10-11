//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedGrids;

partial class XedRules
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
