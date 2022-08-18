//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    public readonly struct @string<C> : IString16<@string<C>,C>
        where C : unmanaged, ICharBlock<C>
    {
        readonly C Block;

        [MethodImpl(Inline)]
        public @string(C block)
        {
            Block = block;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Block.Length;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => (uint)Block.Capacity;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Block.Hash;
        }

        public Span<char> Data
        {
            [MethodImpl(Inline)]
            get => Block.Data;
        }

        public ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => Block.Data;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => recover<byte>(Data);
        }

        public ReadOnlySpan<char> String
        {
            [MethodImpl(Inline)]
            get => Block.String;
        }

        public string Format()
            => Block.Format();

        public override string ToString()
            => Format();

        public int CompareTo(@string<C> src)
            => Data.SequenceCompareTo(src.Data);

        public bool Equals(@string<C> src)
            => Data.SequenceEqual(src.Data);

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object obj)
            => obj is @string<C> x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator @string<C>(C block)
            => new @string<C>(block);

        [MethodImpl(Inline)]
        public static implicit operator @string<C>(string src)
            => new @string<C>(CharBlocks.init<C>(src, out _));

        [MethodImpl(Inline)]
        public static implicit operator @string<C>(ReadOnlySpan<char> src)
            => new @string<C>(CharBlocks.init<C>(src, out _));
    }
}