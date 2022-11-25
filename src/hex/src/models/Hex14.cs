//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = Hex14;
    using K = UInt16;

    [DataWidth(Width,StorageWidth)]
    public readonly struct Hex14 : IEquatable<Hex14>, IComparable<Hex14>
    {
        public const byte Width = 14;

        const byte StorageWidth = 16;

        public const K MaxValue = Pow2.T14m1;

        public static H Zero => new H(0);

        public static H One => new H(1);

        public static H Min => Zero;

        public static H Max => new H(MaxValue);

        public readonly K Value;

        [MethodImpl(Inline)]
        public Hex14(K src)
            => Value = (K)(src & MaxValue);

        [MethodImpl(Inline)]
        public Hex14(uint src)
            => Value = (K)(src & MaxValue);

        [MethodImpl(Inline)]
        public Hex14(int src)
            => Value = (K)(src & MaxValue);

        [MethodImpl(Inline)]
        public Hex14(long src)
            => Value = (K)(src & MaxValue);

        [MethodImpl(Inline)]
        public Hex14(ulong src)
            => Value = (K)(src & MaxValue);

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
            get => Value;
        }

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is H c && Equals(c);

        public string Text
        {
            [MethodImpl(Inline)]
            get => Value.FormatHex(specifier:false, zpad:true, uppercase:true);
        }


        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public override string ToString()
            => Text;

        [MethodImpl(Inline)]
        public int CompareTo(H src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static H operator + (H x, H y)
            => new H(x.Value + y.Value);

        [MethodImpl(Inline)]
        public static H operator - (H x, H y)
            => new H(x.Value - y.Value);

        [MethodImpl(Inline)]
        public static H operator * (H x, H y)
            => new H(x.Value * y.Value);

        [MethodImpl(Inline)]
        public static H operator / (H x, H y)
            => new H(x.Value / y.Value);

        [MethodImpl(Inline)]
        public static H operator % (H x, H y)
            => new H(x.Value % y.Value);

        [MethodImpl(Inline)]
        public static H operator &(H x, H y)
            => new H(x.Value & y.Value);

        [MethodImpl(Inline)]
        public static H operator |(H x, H y)
            => new H(x.Value | y.Value);

        [MethodImpl(Inline)]
        public static H operator ^(H x, H y)
            => new H(x.Value ^ y.Value);

        [MethodImpl(Inline)]
        public static H operator >>(H x, int count)
            => new H(x.Value >> count);

        [MethodImpl(Inline)]
        public static H operator <<(H x, int count)
            => new H(x.Value << count);

        [MethodImpl(Inline)]
        public static H operator ~(H src)
            => new H(~src.Value);

        [MethodImpl(Inline)]
        public static H operator ++(H x)
            => new H(~x.Value);

        [MethodImpl(Inline)]
        public static H operator --(H x)
            => new H(~x.Value);

        [MethodImpl(Inline)]
        public static bool operator ==(H x, H y)
            => x.Value == y.Value;

        [MethodImpl(Inline)]
        public static bool operator !=(H x, H y)
            => x.Value != y.Value;

        [MethodImpl(Inline)]
        public static bool operator < (H x, H y)
            => x.Value < y.Value;

        [MethodImpl(Inline)]
        public static bool operator <= (H x, H y)
            => x.Value <= y.Value;

        [MethodImpl(Inline)]
        public static bool operator > (H x, H y)
            => x.Value > y.Value;

        [MethodImpl(Inline)]
        public static bool operator >= (H x, H y)
            => x.Value >= y.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(H src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(H src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator short(H src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(H src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator int(H src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(H src)
            => (long)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(H src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(K src)
            => new H(src);

        [MethodImpl(Inline)]
        public static implicit operator H(byte src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static implicit operator H(sbyte src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static implicit operator H(short src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static explicit operator H(uint src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static explicit operator H(int src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static explicit operator H(long src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static explicit operator H(ulong src)
            => new H((K)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex1 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex2 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex3 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex4 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex6 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex7 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex8 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex10 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex12 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex16 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex32 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static explicit operator H(Hex64 src)
            => new H((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex16(H src)
            => new Hex16(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex32(H src)
            => new Hex32(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex64(H src)
            => new Hex64(src.Value);
    }
}