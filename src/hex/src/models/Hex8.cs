//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = Hex8;
    using K = Hex8Kind;
    using W = W8;

    [DataWidth(Width)]
    public readonly struct Hex8 : IHexNumber<H,W,K>
    {
        [Parser]
        public static bool parse(string src, out H dst)
        {
            var result = byte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out byte _dst);
            dst = _dst;
            return result;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out H dst)
        {
            var result = byte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out byte _dst);
            dst = _dst;
            return result;
        }

        public const byte Width = 8;

        public const byte MaxValue = Pow2.T08m1;

        public const K KMin = K.x00;

        public const K KMax = K.xff;

        public const K KOne = K.x01;

        public static H Zero => KMin;

        public static H One => KOne;

        public static H Min => KMin;

        public static H Max => KMax;

        public readonly K Value;

        [MethodImpl(Inline)]
        public Hex8(K src)
            => Value = src;

        [MethodImpl(Inline)]
        public Hex8(byte src)
            => Value = (K)src;

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

        public Hex4 Lo
        {
            [MethodImpl(Inline)]
            get => (byte)((byte)Value & 0xF);
        }

        public Hex4 Hi
        {
            [MethodImpl(Inline)]
            get => (byte)((byte)Value >> 4);
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
            => new ((Hex8Kind)src);

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
        public static implicit operator H(Hex1Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex2Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex3Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex4Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex5Kind src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Address8 src)
            => new ((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator Address8(H src)
            => new (src);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex16 src)
            => new ((byte)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex32 src)
            => new ((byte)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex64 src)
            => new ((byte)src.Value);
    }
}