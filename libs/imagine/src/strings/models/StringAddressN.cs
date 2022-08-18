//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using api = MemoryStrings;

    /// <summary>
    /// Specifes the location of a string in memory with a naturally-specified length
    /// </summary>
    public unsafe readonly struct StringAddress<N>
        where N : unmanaged, ITypeNat
    {
        internal readonly StringAddress Source;

        [MethodImpl(Inline)]
        public StringAddress(StringAddress src)
        {
            Source = src;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Source.Address;
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => Typed.nat32u<N>();
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Source.IsNonZero;
        }

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<char>(), Length);
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => api.render(this, ref i, dst);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(StringAddress<N> src)
            => Source.Equals(src);

        public static implicit operator StringAddress(StringAddress<N> src)
            => new StringAddress(src.Address);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(StringAddress<N> src)
            => src.Address;

        [MethodImpl(Inline)]
        public static implicit operator StringAddress<N>(string src)
            => api.natural<N>(src);
    }
}