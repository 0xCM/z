//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public record struct TableStats : IComparable<TableStats>
        {
            public const string TableId = "rules.stats";

            public const byte FieldCount = 10;

            public uint Seq;

            public RuleTableKind Kind;

            public RuleName Rule;

            public DataSize TableSize;

            public DataSize MaxRowSize;

            public ushort Rows;

            public ushort Cells;

            public byte MaxCols;

            public DataSize UniformSize;

            public bit Homogenous;

            [MethodImpl(Inline)]
            public TableStats(uint seq,RuleSig rule, DataSize tsz, DataSize mrsz, ushort rows, ushort cells, byte maxcc)
            {
                Seq = seq;
                Rule = rule.TableName;
                Kind = rule.TableKind;
                Rows = rows;
                Cells = cells;
                TableSize = tsz;
                MaxRowSize = mrsz;
                MaxCols = maxcc;
                UniformSize = new DataSize(mrsz.PackedWidth*rows, mrsz.NativeWidth*rows);
                Homogenous = TableSize == UniformSize;
            }

            public RuleSig Sig
            {
                [MethodImpl(Inline)]
                get => new RuleSig(Kind,Rule);
            }

            public int CompareTo(TableStats src)
                => Sig.CompareTo(src.Sig);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,6,32,12,12,8,8,8,16,12};
        }
    }
}