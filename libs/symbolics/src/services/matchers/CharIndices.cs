//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class StringMatcher
    {
        public readonly struct CharIndices : IIndex<CharIndex>
        {
            public static CharIndices calc(ReadOnlySpan<char> src)
            {
                var count = src.Length;
                var dst = alloc<CharIndex>(count);
                for(var i=z16; i<count; i++)
                    seek(dst,i) = (skip(src,i), i);
                return dst;
            }

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