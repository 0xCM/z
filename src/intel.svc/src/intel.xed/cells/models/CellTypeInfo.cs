//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct CellTypeInfo : IEquatable<CellTypeInfo>, IComparable<CellTypeInfo>
    {
        [MethodImpl(Inline)]
        public static CellTypeInfo @operator(RuleOperator op)
            => new (0, RuleCellKind.Operator, op, asci16.Null, default);

        public readonly FieldKind Field;

        public readonly RuleCellType Type;

        public readonly RuleOperator Operator;

        public readonly asci16 TypeName;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public CellTypeInfo(FieldKind field, RuleCellType @class, RuleOperator op, asci16 type, DataSize size)
        {
            Field = field;
            Type = @class;
            Operator = op;
            Size = size;
            TypeName = type;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Type.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Type.IsEmpty;
        }

        public string Format()
            => CellRender.format(this);

        public override string ToString()
            => Format();

        public int CompareTo(CellTypeInfo src)
        {
            var result = Type.CompareTo(src.Type);
            if(result == 0)
            {
                result = Xed.cmp(Field,src.Field);
                if(result == 0)
                    result = Operator.CompareTo(src.Operator);
            }
            return result;
        }

        public static CellTypeInfo Empty
            => new (FieldKind.INVALID, RuleCellType.Empty, RuleOperator.None, asci16.Null, default);
    }
}
