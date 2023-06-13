//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;

    /// <summary>
    /// Covers an A-parametric sequence of asci sequences
    /// </summary>
    public readonly struct AsciSeq<N,A> : IAsciSeq<AsciSeq<N,A>,N>
        where A : unmanaged, IAsciSeq<A,N>
        where N : unmanaged, ITypeNat
    {
        public readonly A Content;

        [MethodImpl(Inline)]
        public AsciSeq(A src)
            => Content = src;

        [MethodImpl(Inline)]
        public AsciSeq<N,A> Load(A src)
            => new AsciSeq<N,A>(src);

        [MethodImpl(Inline)]
        public AsciSeq<N,A> Replicate()
            => new AsciSeq<N,A>(Content);

        [MethodImpl(Inline)]
        public AsciSeq<N,A> Empty()
            => new AsciSeq<N,A>(Content.Empty());

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => (uint)Content.Capacity;
        }

        public Span<C> Codes
        {
            [MethodImpl(Inline), UnscopedRef]
            get => recover<byte,C>(bytes(Content));
        }

        public Span<S> Symbols
        {
            [MethodImpl(Inline), UnscopedRef]
            get => recover<byte,S>(bytes(Content));
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Content.ByteCount;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public bool IsBlank
        {
            [MethodImpl(Inline)]
            get => SQ.whitespace(Codes);
        }

        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => SQ.@null(Codes);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public string Format()
            => Text;

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.Hash;
        }

        public int CompareTo(AsciSeq<N,A> src)
            => Content.CompareTo(src.Content);

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(AsciSeq<N,A> src)
            => Content.Equals(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator A(AsciSeq<N,A> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator AsciSeq<N,A>(A src)
            => new AsciSeq<N,A>(src);
    }
}