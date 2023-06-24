//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public record struct XedTableStats : IComparable<XedTableStats>
    {
        const string TableId = "rules.stats";

        [Render(6)]
        public uint Seq;

        [Render(6)]
        public RuleTableKind Kind;

        [Render(32)]
        public RuleName Rule;

        [Render(12)]
        public DataSize TableSize;

        [Render(12)]
        public DataSize MaxRowSize;

        [Render(8)]
        public ushort Rows;

        [Render(8)]
        public ushort Cells;

        [Render(8)]
        public byte MaxCols;

        [Render(16)]
        public DataSize UniformSize;

        [Render(12)]
        public bit Homogenous;

        [MethodImpl(Inline)]
        public XedTableStats(uint seq,RuleSig rule, DataSize tsz, DataSize mrsz, ushort rows, ushort cells, byte maxcc)
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

        public int CompareTo(XedTableStats src)
            => Sig.CompareTo(src.Sig);
    }
}