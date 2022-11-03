//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class StringMatcher
    {
        public static StringMatcher create(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var expressions = alloc<string>(count);
            var indices = alloc<CharIndices>(count);
            var lengths = alloc<ushort>(count);
            for(var i=0; i<count; i++)
                seek(expressions, i) = skip(src,i);

            expressions.Sort();
            for(var i=0; i<count; i++)
            {
                ref readonly var expr = ref skip(expressions,i);
                seek(indices, i) = CharIndices.calc(expr);
                seek(lengths, i) = (ushort)expr.Length;
            }

            return new StringMatcher(expressions, indices, lengths);
        }

        readonly Index<string> TargetData;

        readonly Index<CharIndices> IndexData;

        readonly Index<ushort> DistinctLengths;

        readonly Index<Entry> EntryData;

        readonly Index<CharMatchRow> RowData;

        readonly Index<CharGroupMembers> GroupMemberData;

        public readonly uint EntryCount;

        public readonly ushort MinLength;

        public readonly ushort MaxLength;

        public readonly CharCounts Counts;

        public readonly CharPositions Positions;

        public StringMatcher(string[] targets, CharIndices[] indices, ushort[] lengths)
        {
            TargetData = targets;
            IndexData = indices;
            DistinctLengths = lengths.Distinct().Sort();
            EntryCount = TargetData.Count;
            EntryData = alloc<Entry>(EntryCount);
            var max = z16;
            var min = ushort.MaxValue;
            for(var i=0u; i<EntryCount; i++)
            {
                ref readonly var length = ref skip(lengths,i);
                EntryData[i] = new Entry(i, TargetData[i], IndexData[i], length);
                if(length > max)
                    max = length;

                if(length < min)
                    min = length;
            }
            MinLength = min;
            MaxLength = max;
            Counts = CharCounts.calc(targets);
            Positions = CharPositions.compute(targets);
            RowData = BuildTable();
            GroupMemberData = groups(RowData);
        }

        public ReadOnlySpan<ushort> Lengths
        {
            [MethodImpl(Inline)]
            get => DistinctLengths;
        }

        public ref readonly Entry this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref EntryData[i];
        }

        public ref readonly Entry this[int i]
        {
            [MethodImpl(Inline)]
            get => ref EntryData[i];
        }

        public ReadOnlySpan<Entry> Entries
        {
            [MethodImpl(Inline)]
            get => EntryData;
        }

        public ReadOnlySpan<CharMatchRow> MemberRows(CharGroupMembers g)
            => slice(RowData.View, g.MinSeq, g.Count);

        public ReadOnlySpan<CharMatchRow> MatchRows
        {
            [MethodImpl(Inline)]
            get => RowData;
        }

        public ReadOnlySpan<CharGroupMembers> GroupRows
        {
            [MethodImpl(Inline)]
            get => GroupMemberData;
        }

        static Index<CharGroupMembers> groups(ReadOnlySpan<CharMatchRow> src)
        {
            var dst = list<CharGroupMembers>();
            var count = src.Length;
            var group = CharGroup.Empty;
            var min = 0u;
            var max = 0u;

            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                ref readonly var g = ref row.Group;
                if(g != group)
                {
                    if(group.IsNonEmpty)
                    {
                        dst.Add(new CharGroupMembers(group,min,max));
                        group = g;
                    }
                    else
                    {
                        group = g;
                    }
                    min = row.Seq;
                    max = row.Seq;
                }
                else
                {
                    max = row.Seq;
                }
            }
            return dst.ToArray();
        }

        Index<CharMatchRow> BuildTable()
        {
            var entries = Entries;
            var chars = Counts.Chars.ToArray().Sort();
            var positions = Positions;
            var lengths = Lengths;
            var points = Intervals.points(Intervals.closed(z16, MaxLength));
            var buffer = list<CharMatchRow>();
            var counter = 0u;
            for(var j=0; j<chars.Length; j++)
            {
                ref readonly var c = ref skip(chars,j);
                for(var k=z16; k<points.Length; k++)
                {
                    var targets = positions.Targets(c,k);
                    for(var i=0; i<targets.Length; i++)
                    {
                        var target = skip(targets,i);
                        var entry = this[target];
                        var row = default(CharMatchRow);
                        row.Char = c;
                        row.Pos = k;
                        row.TargetLength = entry.Length;
                        row.TargetId = entry.Key;
                        row.Target = entry.Target;
                        row.Group = (row.TargetLength, row.Pos);
                        buffer.Add(row);
                    }
                }
            }

            var data = buffer.ToArray().Sort();
            var count = data.Length;
            for(var i=0u; i<count; i++)
                seek(data,i).Seq = i;
            return data;
        }
    }
}