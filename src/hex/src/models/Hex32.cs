//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = Hex32;
    using W = W32;
    using K = System.UInt32;

    [DataWidth(Width)]
    public readonly struct Hex32 : IHexNumber<H,W,K>
    {
        [Parser]
        public static bool parse(string src, out H dst)
        {
            var result = K.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out K _dst);
            dst = _dst;
            return result;
        }


        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out H dst)
        {
            var result = K.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out K _dst);
            dst = _dst;
            return result;
        }
        public const byte Width = 32;

        public const K MaxValue = Pow2.T32m1;

        public static H Zero => new H(0);

        public static H Max => new H(MaxValue);

        public readonly K Value;

        [MethodImpl(Inline)]
        public Hex32(K offset)
            => Value = offset;

        public static W W
            => default;

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

        public Hex16 Lo
        {
            [MethodImpl(Inline)]
            get => (ushort)Value;
        }

        public Hex16 Hi
        {
            [MethodImpl(Inline)]
            get => (ushort)(Value >> 16);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(H src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is H a && Equals(a);

        [MethodImpl(Inline)]
        public int CompareTo(H src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public string Format()
            => HexFormatter.format(Value, W, false, UpperCase);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator H(K src)
            => new H(src);

        [MethodImpl(Inline)]
        public static explicit operator H(Hash32 src)
            => new H((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator K(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(int src)
            => new H((uint)src);

        [MethodImpl(Inline)]
        public static explicit operator int(H src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(H src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator short(H src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(H src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(H src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Address32(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(Address32 src)
            => new H(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator H(MemoryAddress src)
            => new H((K)src.Location);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex64 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator Hash32(H src)
            => (uint)src;

        [MethodImpl(Inline)]
        public static H operator+(H x, H y)
            => new H((K)(x.Value + y.Value));

        [MethodImpl(Inline)]
        public static H operator-(H x, H y)
            => new H((K)(x.Value - y.Value));

        [MethodImpl(Inline)]
        public static bool operator <(H a, H b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(H a, H b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(H a, H b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(H a, H b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator==(H x, H y)
            => x.Value == y.Value;

        [MethodImpl(Inline)]
        public static bool operator!=(H x, H y)
            => x.Value != y.Value;
    }
}