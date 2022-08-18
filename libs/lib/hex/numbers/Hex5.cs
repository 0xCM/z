//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = Hex5;
    using K = Hex5Kind;
    using W = W5;

    [DataWidth(Width,StorageWidth)]
    public readonly struct Hex5
    {
        [Parser]
        public static Outcome parse(string src, out H dst)
        {
            var outcome = Hex.parse8u(src, out var x);
            dst = new H((K)(x & 0b11111));
            return outcome;
        }

        [Parser]
        public static Outcome parse(ReadOnlySpan<char> src, out H dst)
        {
            var outcome = Hex.parse8u(src, out var x);
            dst = new H((K)(x & 0b11111));
            return outcome;
        }

        public const byte Width = 5;

        const byte StorageWidth = 8;

        public const byte MaxValue = Pow2.T05m1;

        public const K KMin = K.x00;

        public const K KMax = K.x1f;

        public const K KOne = K.x01;

        public static H Zero => KMin;

        public static H One => KOne;

        public static H Min => KMin;

        public static H Max => KMax;

        public readonly K Value;

        [MethodImpl(Inline)]
        public Hex5(K src)
             => Value = src & KMax;

        [MethodImpl(Inline)]
        public Hex5(byte src)
            => Value = (K)src & KMax;

        [MethodImpl(Inline)]
        public bool Equals(H src)
            => Value == src.Value;

        public bool IsZero
        {
             [MethodImpl(Inline)]
             get => Value == 0;
        }

        public bool IsNonZero
        {
             [MethodImpl(Inline)]
             get => Value != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is H c && Equals(c);

        public string Text
        {
            [MethodImpl(Inline)]
            get => ((byte)Value).FormatHex(specifier:false, zpad:true, uppercase:true);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Text;


        public override string ToString()
            => Text;

        [MethodImpl(Inline)]
        public int CompareTo(H src)
            => ((byte)Value).CompareTo((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(K src)
            => new H(src);

        [MethodImpl(Inline)]
        public static implicit operator K(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(byte src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(H src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(H src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint(H src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(H src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ulong(H src)
            => (ulong)src.Value;
    }
}