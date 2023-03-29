//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = NativeStrings;

    public readonly record struct AsciString<B> : IString8<AsciString<B>, B>
        where B : unmanaged, IStorageBlock<B>
    {
        readonly B Data;

        [MethodImpl(Inline)]
        public AsciString(B block)
        {
            Data = block;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => Data.ByteCount/8;
        }

        public ReadOnlySpan<AsciSymbol> Cells
        {
            [MethodImpl(Inline)]
            get => recover<AsciSymbol>(Data.Bytes);
        }

        public Span<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<AsciCode>(Data.Bytes);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => String.Length;
        }

        public ReadOnlySpan<char> String
            => AsciSymbols.format(Cells);

        public int CompareTo(AsciString<B> src)
            => Format().CompareTo(src.Format());

        public bool Equals(AsciString<B> src)
            => Bytes.SequenceEqual(src.Bytes);

        public string Format()
            => new string(String);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator AsciString<B>(B block)
            => new AsciString<B>(block);

        public static uint StorageSize
        {
            [MethodImpl(Inline)]
            get => size<B>();
        }

        [MethodImpl(Inline)]
        public static implicit operator AsciString<B>(ReadOnlySpan<byte> src)
            => api.asci<B>(src);

        [MethodImpl(Inline)]
        public static implicit operator AsciString<B>(ReadOnlySpan<AsciSymbol> src)
            => api.load<B>(src);

        [MethodImpl(Inline)]
        public static implicit operator AsciString<B>(ReadOnlySpan<AsciCode> src)
            => api.load<B>(src);

        public static AsciString<B> Empty => default;
    }
}