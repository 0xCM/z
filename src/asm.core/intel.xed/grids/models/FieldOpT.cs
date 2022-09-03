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
                => new FieldOp(src.Field, src.Operator, XedGrids.Value.untype(src.Value));
        }
    }
}