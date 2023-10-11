//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct FieldOp<T> : ILogicOperand<T>
        where T : unmanaged, IValue<T>
    {
        public readonly FieldKind Field;

        public readonly RuleOperator Operator;

        public readonly T Value;

        [MethodImpl(Inline)]
        public FieldOp(FieldKind field, RuleOperator op, T value)
        {
            Field = field;
            Operator = op;
            Value = value;
        }

        T ILogicOperand<T>.Value
            => Value;

        RuleOperator ILogicOperand.Operator
            => Operator;

        [MethodImpl(Inline)]
        public static implicit operator FieldOp(FieldOp<T> src)
            => new (src.Field, src.Operator, XedGrids.Value.untype(src.Value));
    }
}
