//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        public readonly struct CharIndices : IIndex<CharIndex>
        {
            readonly Index<CharIndex> Data;

            [MethodImpl(Inline)]
            public CharIndices(CharIndex[] src)
            {
                Data = src;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public CharIndex[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }
            public Span<CharIndex> Edit
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public ReadOnlySpan<CharIndex> View
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public ref CharIndex this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref CharIndex this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public string Format()
                => Data.Delimit().Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CharIndices(CharIndex[] src)
                => new CharIndices(src);
        }
    }
}