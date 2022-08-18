//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DelimitedIndex<T> : IIndex<T>, ITextual
    {
        public readonly Index<T> Data;

        public readonly string Delimiter;

        public readonly int CellPad;

        public readonly Fence<char>? Fence;

        [MethodImpl(Inline)]
        public DelimitedIndex(T[] src, char delimiter, int pad, Fence<char>? fence)
        {
            Data = src;
            Delimiter = delimiter.ToString();
            CellPad = pad;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public DelimitedIndex(T[] src, string delimiter, int pad, Fence<char>? fence)
        {
            Data = src;
            Delimiter = delimiter;
            CellPad = pad;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public DelimitedIndex(T[] src)
        {
            Data = src;
            Delimiter = ListDelimiter.ToString();
            CellPad = 0;
            Fence = null;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public string Format()
        {
            var content = text.delimit(Data.View, Delimiter, CellPad);
            if(Fence != null && sys.nonempty(content))
                return text.enclose(content, Fence.Value);
            else
                return content;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DelimitedIndex<T>(T[] src)
            => new DelimitedIndex<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator DelimitedIndex<T>(Index<T> src)
            => new DelimitedIndex<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator DelimitedIndex<T>(List<T> src)
            => new DelimitedIndex<T>(src.ToArray());
    }
}