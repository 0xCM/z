//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class StringMatcher
    {
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
    }
}