//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static RenderStyle;
    using static XedModels;

    using S = RenderStyle;

    partial class XedRules
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct Coordinate : IComparable<Coordinate>
        {
            [Render(6)]
            public readonly ushort Seq;

            [Render<S>(6,Fixed)]
            public readonly num9 Table;

            [Render<S>(6,Fixed)]
            public readonly num8 Row;

            [Render<S>(6,Fixed)]
            public readonly num4 Col;

            [Render(6)]
            public readonly RuleTableKind Kind;

            [Render(1)]
            public readonly RuleName Name;

            [MethodImpl(Inline)]
            public Coordinate(ushort index, num9 table, num8 row, num4 col, RuleTableKind kind, RuleName name)
            {
                Seq = index;
                Table = table;
                Row = row;
                Col = col;
                Kind = kind;
                Name = name;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Bitfields.pack(Table, Row, Col);
            }

            [MethodImpl(Inline)]
            public int CompareTo(Coordinate src)
            {
                var result = Table.CompareTo(src.Table);
                if(result==0)
                {
                    result = Row.CompareTo(src.Row);
                    if(result==0)
                        result = Col.CompareTo(src.Col);
                }
                return result;
            }

            public bool Equals(Coordinate src)
            {
                var result = Table == src.Table;
                result &= Row == src.Row;
                result &= Col == src.Col;
                return result;
            }

            public override int GetHashCode()
                => Hash;

            public string Format()
                => string.Format("{0:D3} {1:D2} {2:D2}", (ushort)Table, (byte)Row, (byte)Col);

            public override string ToString()
                => Format();
        }
   }
}