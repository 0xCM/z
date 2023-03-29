//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = NativeStrings;

    public readonly record struct NativeString<K,B> : INativeString<NativeString<K,B>,K,B>
        where K : unmanaged, IEquatable<K>, IComparable<K>
        where B : unmanaged, IStorageBlock<B>
    {
        readonly B Data;

        [MethodImpl(Inline)]
        public NativeString(B block)
        {
            Data = block;
        }

        public byte CharSize
        {
            [MethodImpl(Inline)]
            get => (byte)size<K>();
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Data.ByteCount/CharSize;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.ByteCount/CharSize;
        }

        public BitWidth BitWidth
        {
            [MethodImpl(Inline)]
            get => Length*CharSize*8;
        }

        public ReadOnlySpan<K> Cells
        {
            [MethodImpl(Inline)]
            get => recover<K>(Data.Bytes);
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

        public ReadOnlySpan<char> String
            => CharSize == 16 ? recover<char>(Bytes) : AsciSymbols.format(recover<AsciCode>(Bytes));

        public int CompareTo(NativeString<K,B> src)
            => Format().CompareTo(src.Format());

        public bool Equals(NativeString<K,B> src)
            => Bytes.SequenceEqual(src.Bytes);

        public string Format()
            => new string(String);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator NativeString<K,B>(B block)
            => new NativeString<K,B>(block);

        public static uint StorageSize
        {
            [MethodImpl(Inline)]
            get => size<B>();
        }

        [MethodImpl(Inline)]
        public static implicit operator NativeString<K,B>(string src)
            => api.load<K,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator NativeString<K,B>(ReadOnlySpan<char> src)
            => api.load<K,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<K>(NativeString<K,B> src)
            => src.Cells;

        public static NativeString<K,B> Empty => default;
    }
}