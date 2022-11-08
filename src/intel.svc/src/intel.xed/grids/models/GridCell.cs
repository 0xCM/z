//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct GridCell : IComparable<GridCell>
        {
            [MethodImpl(Inline)]
            public static GridCell from(in RuleCell src)
            {
                var field = src.Field;
                var type = ColType.field(field);
                if(src.IsNontermCall)
                {
                    type = ColType.nonterm(src.Value.AsNonterm());
                }
                else if(src.IsCellExpr)
                {
                    var expr = src.Value.ToCellExpr();
                    if(expr.IsNonterm)
                        type = ColType.expr(field, expr.Operator, expr.Value.ToRuleName());
                    else
                        type = ColType.expr(field, expr.Operator);
                }

                return new GridCell(src.Key, type, src.Size, src.Value);
            }

            public readonly CellKey Key;

            public readonly ColType Type;

            public readonly DataSize Size;

            public readonly CellValue Value;

            [MethodImpl(Inline)]
            public GridCell(in CellKey key, ColType type, DataSize size, CellValue value)
            {
                Key = key;
                Type = type;
                Size = size;
                Value = value;
            }

            public readonly ushort Table
            {
                [MethodImpl(Inline)]
                get => Key.Table;
            }

            public readonly byte Row
            {
                [MethodImpl(Inline)]
                get => Key.Row;
            }

            public readonly byte Col
            {
                [MethodImpl(Inline)]
                get => Key.Col;
            }

            public readonly FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Key.Field;
            }

            public readonly LogicClass Logic
            {
                [MethodImpl(Inline)]
                get => Key.Logic;
            }

            public ref readonly GridCol Def
            {
                [MethodImpl(Inline)]
                get => ref core.@as<GridCol>(core.bytes(this));
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsNonEmpty;
            }

            [MethodImpl(Inline)]
            public int CompareTo(GridCell src)
                => Col.CompareTo(src.Col);

            public string Format()
                => IsEmpty ? EmptyString :
                    string.Format("{0:D5} | {1:D2} | {2:D2} | {3,-3} | {4,-32} | {5} | {6} | {7,-26} | {8}",
                    Key.Index,
                    Key.Row,
                    Key.Col,
                    XedRender.format(Key.Rule.TableKind),
                    XedRender.format(Key.Rule.TableName),
                    Size.Format(2,2),
                    XedRender.format(Logic),
                    XedRender.format(Field),
                    Value
                    );

            public override string ToString()
                => Format();

            public static GridCell Empty => default;
        }
    }
}