//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = Hex3;
    using K = Hex3Kind;
    using W = W3;

    [DataWidth(Width,StorageWidth)]
    public readonly record struct Hex3
    {
        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out Hex3 dst)
        {
            var outcome = Hex.parse8u(src, out var x);
            dst = new Hex3((Hex3Kind)(x & 0b111));
            return outcome;
        }

        [Parser]
        public static bool parse(string src, out Hex3 dst)
        {
            var outcome = Hex.parse8u(src, out var x);
            dst = new Hex3((Hex3Kind)(x & 0b111));
            return outcome;
        }

        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, Hex3 src)
            => (char)Hex.symbol(@case, (Hex3Kind)src.Value);

        public const byte Width = 3;

        const byte StorageWidth = 8;

        public const byte MaxValue = Pow2.T03m1;

        public static H Zero => new H(z8);

        public static H One => new H(1);

        public static H Min => Zero;

        public static H Max => new H(MaxValue);

        public readonly byte Value;

        [MethodImpl(Inline)]
        public Hex3(K src)
            => Value = (byte)((byte)src & MaxValue);

        [MethodImpl(Inline)]
        public Hex3(byte src)
            => Value = (byte)((byte)src & MaxValue);

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

        public string Text
        {
            [MethodImpl(Inline)]
            get => hexchar(UpperCase, this).ToString();
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
            => (K)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Hex4(Hex3 src)
            => new Hex4((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex5(Hex3 src)
            => new Hex5((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex8(Hex3 src)
            => new Hex8((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex4Kind(Hex3 src)
            => (Hex4Kind)src;

        [MethodImpl(Inline)]
        public static implicit operator Hex5Kind(Hex3 src)
            => (Hex5Kind)src;

        [MethodImpl(Inline)]
        public static implicit operator Hex8Kind(Hex3 src)
            => (Hex8Kind)src;

        [MethodImpl(Inline)]
        public static implicit operator H(byte src)
            => new H(src);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(H src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(H src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint(H src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(H src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ulong(H src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(Hex1Kind src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex2Kind src)
            => new H((byte)src);
    }
}