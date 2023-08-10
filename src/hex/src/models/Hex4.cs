//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = Hex4;
    using K = Hex4Kind;

    [DataWidth(Width)]
    public readonly record struct Hex4
    {
        [MethodImpl(Inline), Op]
        public static char hexchar(UpperCased @case, H src)
            => (char)Hex.symbol(@case, src.Value);

        [MethodImpl(Inline), Op]
        public static char hexchar(LowerCased @case, H src)
            => (char)Hex.symbol(@case, src.Value);


        public const byte Width = 4;

        const byte StorageWidth = 8;

        public const byte MaxValue = Pow2.T04m1;

        public const K KMin = K.x00;

        public const K KMax = K.x0F;

        public const K KOne = K.x01;

        public static H Zero => KMin;

        public static H One => KOne;

        public static H Min => KMin;

        public static H Max => KMax;

        public readonly K Value;

        [MethodImpl(Inline)]
        public Hex4(K src)
            => Value = src & KMax;

        [MethodImpl(Inline)]
        public Hex4(byte src)
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
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(byte src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static implicit operator Hex5(Hex4 src)
            => new Hex5((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex8(Hex4 src)
            => new Hex8((byte)src.Value);

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

        [MethodImpl(Inline)]
        public static explicit operator H(Hex16 src)
            => new ((byte)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex32 src)
            => new ((byte)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex64 src)
            => new ((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex1Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex2Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex3Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static explicit operator HexDigitValue(Hex4 src)
            => (HexDigitValue)src.Value;
    }
}