//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct RuleCell<T> : IComparable<RuleCell<T>>
            where T : unmanaged
        {
            public readonly Coordinate Point;

            public readonly RuleSig Rule;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly T Value;

            [MethodImpl(Inline)]
            public RuleCell(Coordinate point, RuleSig rule, FieldKind field, RuleOperator op, T value)
            {
                Rule = rule;
                Field = field;
                Point = point;
                Operator = op;
                Value = value;
            }

            public ushort Seq
            {
                [MethodImpl(Inline)]
                get => Point.Seq;
            }

            public ushort Table
            {
                [MethodImpl(Inline)]
                get => Point.Table;
            }

            public byte Row
            {
                [MethodImpl(Inline)]
                get => Point.Row;
            }

            public byte Col
            {
                [MethodImpl(Inline)]
                get => Point.Col;
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Rule.TableKind;
            }

            public RuleName TableName
            {
                [MethodImpl(Inline)]
                get => Rule.TableName;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => HashCodes.combine(Point.Hash, bw32(Value), PolyBits.pack((byte)Field,(byte)Operator));
            }

            [MethodImpl(Inline)]
            public int CompareTo(RuleCell<T> src)
                => Point.CompareTo(src.Point);

            [MethodImpl(Inline)]
            public bool Equals(RuleCell<T> src)
            {
                var result = Field == src.Field;
                result &= Operator == src.Operator;
                result &= bw64(Value) == bw64(src.Value);
                result &= Point == src.Point;
                return result;
            }

            public override int GetHashCode()
                => Hash;
        }
    }
}