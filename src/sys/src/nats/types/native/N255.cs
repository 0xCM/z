//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = N255;
    using S = INatSeq<N255,N2,N5,N5>;

    public readonly struct N255 : INativeNatural, S
    {
        public const ulong Value = (1ul << 8) - 1;

        public const string Text = "255";

        public ulong NatValue => Value;

        public string NatText => Text;

        public static K Rep => default;

        [MethodImpl(Inline)]
        public static implicit operator int(K src) => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(K src) => (byte)Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(K src) => (ushort)Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(K src) => (uint)Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(K src) => Value;

        [MethodImpl(Inline)]
        public bool Equals(K src) => true;

        [MethodImpl(Inline)]
        public string Format() => Text;

        [MethodImpl(Inline)]
        public override bool Equals(object src)
            => src is K;

        [MethodImpl(Inline)]
        public override string ToString() => Format();

        [MethodImpl(Inline)]
        public override int GetHashCode() =>  (int)Value;
    }
}