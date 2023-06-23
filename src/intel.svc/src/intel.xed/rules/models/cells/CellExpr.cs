//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct CellExpr
        {
            public readonly FieldValue Value;

            public readonly RuleOperator Operator;

            [MethodImpl(Inline)]
            public CellExpr(OperatorKind op, FieldValue value)
            {
                Operator = op;
                Value = value;
            }

            public RuleCellKind CellKind
            {
                [MethodImpl(Inline)]
                get => Value.CellKind;
            }

            public readonly FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Value.Field;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsNonEmpty;
            }

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Value.IsNonterm;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static CellExpr Empty => default;
        }
    }
}