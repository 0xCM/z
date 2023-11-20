//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct FieldAssign
    {
        public readonly FieldKind Field;

        public readonly FieldValue Value;

        [MethodImpl(Inline)]
        public FieldAssign(FieldValue value)
        {
            Field = value.Field;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Field == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Field != 0;
        }

        [MethodImpl(Inline)]
        public CellExpr Expression()
            => Xed.expr(OperatorKind.Eq, Value);

        public string Format()
            => XedRender.format(Expression());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FieldAssign(FieldValue src)
            => new (src);

        public static FieldAssign Empty => new FieldAssign(FieldValue.Empty);
    }
}
