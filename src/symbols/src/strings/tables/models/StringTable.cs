//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = StringTables;

    public class StringTable
    {
        public readonly StringTableDef Spec;

        public readonly Index<string> Names;

        public readonly Index<char> Content;

        public readonly Index<uint> Offsets;

        public readonly Index<StringTableRow> Rows;

        [MethodImpl(Inline)]
        public StringTable(StringTableDef spec, char[] src, Index<uint> offsets, string[] names, StringTableRow[] rows)
        {
            Spec = spec;
            Content = src;
            Offsets = offsets;
            Names = names;
            Rows = rows;
        }

        [MethodImpl(Inline)]
        public StringTable(StringTableDef spec, char[] src, Index<uint> offsets)
        {
            Spec = spec;
            Content = src;
            Offsets = offsets;
            Names = sys.empty<string>();
            Rows = sys.empty<StringTableRow>();
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Entry(int index)
            => api.entry(this, index);

        public ReadOnlySpan<char> this[int index]
        {
            [MethodImpl(Inline)]
            get => Entry(index);
        }

        public ReadOnlySpan<char> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Entry((int)index);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> String(uint index)
            => this[index];

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => Offsets.Count;
        }
    }
}