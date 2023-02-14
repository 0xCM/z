//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public partial class StringMatcher
    {
        readonly Index<CharMatchRow> Rows;

        readonly Index<GroupMembers> Members;

        StringMatcher(Builder state)
        {
            Rows = state.RowData;
            Members = state.GroupMemberData;
        }

        public ReadOnlySpan<CharMatchRow> MemberRows(GroupMembers g)
            => slice(Rows.View, g.MinSeq, g.Count);

        internal class Builder
        {
            public static Builder build(string[] targets, CharIndices[] indices, ushort[] lengths)
            {
                var state = new Builder();
                state.TargetData = targets;
                state.IndexData = indices;
                state.DistinctLengths = lengths.Distinct().Sort();
                state.EntryCount = (uint)targets.Length;
                state.EntryData = alloc<Entry>(targets.Length);
                var max = z16;
                var min = ushort.MaxValue;
                for(var i=0u; i<state.EntryCount; i++)
                {
                    ref readonly var length = ref skip(lengths,i);
                    state.EntryData[i] = new Entry(i, state.TargetData[i], state.IndexData[i], length);
                    if(length > max)
                        max = length;

                    if(length < min)
                        min = length;
                }
                state.MinLength = min;
                state.MaxLength = max;
                state.Counts = counts(targets);
                state.Positions = positions(targets);
                state.RowData = table(state);
                state.GroupMemberData = groups(state.RowData);
                return state;
            }

            internal Index<string> TargetData;

            internal Index<CharIndices> IndexData;

            internal Index<ushort> DistinctLengths;

            internal Index<Entry> EntryData;

            internal Index<CharMatchRow> RowData;

            internal Index<GroupMembers> GroupMemberData;

            public uint EntryCount {get; private set;}

            public ushort MinLength {get; private set;}

            public ushort MaxLength {get; private set;}

            public CharCounts Counts {get; private set;}

            public CharPositions Positions {get; private set;}

            public ReadOnlySpan<Entry> Entries
            {
                [MethodImpl(Inline)]
                get => EntryData;
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
        }
 
        [Op]
        public static ExecToken tables(IWfChannel channel, ReadOnlySeq<string> src, IDbArchive dst, bool validate = true)
        {
            var flow = channel.Running();
            var matcher = create(src);
            channel.TableEmit(matcher.Rows, dst.Table<CharMatchRow>());

            var groups = matcher.Members;
            channel.TableEmit(groups, dst.Table<GroupMembers>());

            if(validate)
            {
                for(var i=0; i<groups.Count; i++)
                {
                    var members = matcher.MemberRows(groups[i]);
                    ref readonly var element = ref first(members);
                    var length = element.TargetLength;
                    var pos = element.Pos;
                    for(var j=0; j<members.Length; j++)
                    {
                        ref readonly var member = ref skip(members,j);
                        Require.equal(member.TargetLength, length);
                        Require.equal(member.Pos, pos);
                    }
                }
            }
            return channel.Ran(flow);
        }

        [Op]
        static Index<CharMatchRow> table(Builder state)
        {
            var entries = state.Entries;
            var chars = state.Counts.Chars.ToArray().Sort();
            var positions = state.Positions;
            var lengths = state.DistinctLengths;
            var points = Intervals.points(Intervals.closed(z16, state.MaxLength));
            var buffer = list<CharMatchRow>();
            var counter = 0u;
            for(var j=0; j<chars.Length; j++)
            {
                ref readonly var c = ref skip(chars,j);
                for(var k=z16; k<points.Length; k++)
                {
                    var tgt = targets(positions,c,k);
                    for(var i=0; i<tgt.Length; i++)
                    {
                        var target = skip(tgt,i);
                        var entry = state[target];
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

        [Op]
        static ReadOnlySpan<uint> targets(CharPositions src, char c, ushort index)
        {
            if(src.Find((c,index), out var targets))
            {
                return targets.ViewDeposited();
            }
            else
            {
                return default;
            }
        }

        [Op]
        static CharPositions positions(ReadOnlySpan<string> src)
        {
            var dst = dict<CharIndex,List<uint>>();
            var count = src.Length;
            for(var i=0u; i<count; i++)
                positions(i, skip(src,i), dst);

            return new CharPositions(dst);
        }

        [Op]
        static CharIndices indices(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = alloc<CharIndex>(count);
            for(var i=z16; i<count; i++)
                seek(dst,i) = (skip(src,i), i);
            return dst;
        }

        [Op]
        static CharCounts counts(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var dst = dict<char,uint>();
            for(var i=0; i<count; i++)
                counts(skip(src,i),dst);
            return new CharCounts(map(dst, e => (e.Key,new CharCount(e.Key, e.Value))).ToDictionary());
        }

        [Op]
        static StringMatcher create(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var expressions = alloc<string>(count);
            var idx = alloc<CharIndices>(count);
            var lengths = alloc<ushort>(count);
            for(var i=0; i<count; i++)
                seek(expressions, i) = skip(src,i);

            expressions.Sort();
            for(var i=0; i<count; i++)
            {
                ref readonly var expr = ref skip(expressions,i);
                seek(idx, i) = indices(expr);
                seek(lengths, i) = (ushort)expr.Length;
            }

            return new StringMatcher(Builder.build(expressions, idx, lengths));
        }

        [Op]
        static Index<GroupMembers> groups(ReadOnlySpan<CharMatchRow> src)
        {
            var dst = list<GroupMembers>();
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
                        dst.Add(new GroupMembers(group, min, max));
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

        [Op]
        static void positions(uint target, ReadOnlySpan<char> src, Dictionary<CharIndex,List<uint>> dst)
        {
            var count = src.Length;
            for(var i=z16; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                var index = new CharIndex(c,i);
                if(dst.TryGetValue(index, out var positions))
                {
                    positions.Add(target);
                }
                else
                {
                    dst[index] = new();
                    dst[index].Add(target);
                }
            }
        }

        [Op]
        static void counts(ReadOnlySpan<char> src, Dictionary<char,uint> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(dst.ContainsKey(c))
                    dst[c] = dst[c] + 1;
                else
                    dst[c] = 1;
            }
        }        
    }
}