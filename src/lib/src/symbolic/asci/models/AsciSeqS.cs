//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    /// <summary>
    /// Covers an A-parametric sequence of asci sequences
    /// </summary>
    public readonly struct AsciSeq<S> : IAsciSeq<AsciSeq<S>>
        where S : unmanaged, IAsciSeq<S>
    {
        public readonly S Content;

        [MethodImpl(Inline)]
        public AsciSeq(S src)
            => Content = src;

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Content.ByteCount;
        }

        public BitWidth BitWidth
        {
            [MethodImpl(Inline)]
            get => Content.BitWidth;
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

        public Span<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciCode>(bytes(Content));
        }

        public Span<AsciSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciSymbol>(bytes(Content));
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

        public override int GetHashCode()
            => Hash;

        public int CompareTo(AsciSeq<S> src)
            => Content.CompareTo(src.Content);

        public bool Equals(AsciSeq<S> src)
            => Content.Equals(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator S(AsciSeq<S> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator AsciSeq<S>(S src)
            => new AsciSeq<S>(src);
    }
}