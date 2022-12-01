//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static BitNumbers;

    using U = uint24;
    using W = W24;
    using T = System.UInt32;
    using N = N24;
    using L = Limits24u;
    using K = System.UInt32;

    using api = BitNumbers;

    /// <summary>
    /// Represents the value of an unsigned integer of bit-width 24
    /// </summary>
    [DataWidth(PackedWidth,NativeWidth), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct uint24 : IBitNumber<U,W,K,T>
    {
        byte B0;

        byte B1;

        byte B2;

        [MethodImpl(Inline)]
        public uint24(byte b0, byte b1, byte b2)
        {
            B0 = b0;
            B1 = b1;
            B2 = b2;
        }

        [MethodImpl(Inline)]
        public void Split(out byte b0, out byte b1, out byte b2)
        {
            b0 = B0;
            b1 = B1;
            b2 = B2;
        }

        internal uint Value
        {
            [MethodImpl(Inline)]
            get =>api.join(B0, B1, B2);

            [MethodImpl(Inline)]
            set => api.update(value, ref this);
        }

        uint IBits<uint>.Value
            => Value;

        byte IBits.Width
            => PackedWidth;

        /// <summary>
        /// Queries the state of an index-identified bit
        /// </summary>
        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(Value, pos);
        }

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

        /// <summary>
        /// Specifies whether the current value is the maximum value
        /// </summary>
        public bool IsMax
        {
            [MethodImpl(Inline)]
            get => Value == (T)MaxValue;
        }

        /// <summary>
        /// Specifies whether the current value is the minimum value
        /// </summary>
        public bool IsMin
        {
            [MethodImpl(Inline)]
            get => Value == (T)MinValue;
        }

        [MethodImpl(Inline)]
        internal uint24(T src)
            : this() => Value = src & (T)MaxValue;

        [MethodImpl(Inline)]
        public uint24(bool src)
        {
            B0 = @byte(src);
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        public uint24(bit src)
        {
            B0 = @byte(src);
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        public uint24(byte src)
        {
            B0 = src;
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(sbyte src)
        {
            B0 = (byte)src;
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(short src)
        {
            B0 = (byte)src;
            B1 = (byte)(((uint)(byte)src) << 8);
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(ushort src)
        {
            B0 = (byte)src;
            B1 = (byte)(((uint)(byte)src) << 8);
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(int src)
            : this() => Value = (T)src & (T)MaxValue;

        [MethodImpl(Inline)]
        internal uint24(long src)
            : this() => Value = (T)src & (T)MaxValue;

        [MethodImpl(Inline)]
        internal uint24(ulong src)
            : this() => Value = (T)src & (T)MaxValue;

        [MethodImpl(Inline)]
        internal uint24(T src, bool @unchecked)
            : this() => Value = src;

        [MethodImpl(Inline)]
        static U wrap(T x)
            => new U(x, true);

        [MethodImpl(Inline)]
        static U reduce(uint x)
            => new U(x % Mod);

        [MethodImpl(Inline)]
        static U dec(U x)
        {
            var y = (long)x.Value - 1;
            return y < 0 ? Max : new U((T)y, true);
        }

        [MethodImpl(Inline)]
        public bool Equals(U b)
            => Value == b.Value;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public Span<bit> _Bits
        {
            [MethodImpl(Inline)]
            get => bits(this);
        }

        [MethodImpl(Inline)]
        public int CompareTo(U src)
            => Value.CompareTo(src.Value);

        [Ignore]
        public override int GetHashCode()
            => (int)Value;

        [Ignore]
        public override bool Equals(object src)
            => src is uint24 x && Equals(x);

        [MethodImpl(Inline)]
        public string Format()
             => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator true(U x)
            => x.Value != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U x)
            => x.Value == 0;

        [MethodImpl(Inline)]
        public static implicit operator U(bit src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(bool src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint1 src)
            => new U((bit)src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint2 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint3 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint4 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint5 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint6 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint7 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint8b src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(Hex8 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(Hex16 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(byte src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(ushort src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(short src)
            => new U(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint src)
            => new U(src);

        [MethodImpl(Inline)]
        public static explicit operator U(Hex32 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => (bit)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator bool(U src)
            => (bit)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint1(U src)
            => (uint1)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint2(U src)
            => (uint2)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint3(U src)
            => (uint3)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint4(U src)
            => (uint4)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint5(U src)
            => (uint5)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint6(U src)
            => (uint6)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint7(U src)
            => (uint7)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint8b(U src)
            => (uint8b)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(U src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Hex8(U src)
            => (Hex8)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(U src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator short(U src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(U src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Hex16(U src)
            => (Hex16)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(U src)
            => (long)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static U operator == (U a, U b)
            => new U(a.Value == b.Value);

        [MethodImpl(Inline)]
        public static U operator != (U a, U b)
            => new U(a.Value != b.Value);

        [MethodImpl(Inline)]
        public static U operator < (U a, U b)
            => new U(a.Value < b.Value);

        [MethodImpl(Inline)]
        public static U operator <= (U a, U b)
            => new U(a.Value <= b.Value);

        [MethodImpl(Inline)]
        public static U operator > (U a, U b)
            => new U(a.Value > b.Value);

        [MethodImpl(Inline)]
        public static U operator >= (U a, U b)
            => new U(a.Value >= b.Value);

        [MethodImpl(Inline)]
        public static U operator - (U src)
            => new U(~src.Value + 1u);

        [MethodImpl(Inline)]
        public static U operator -- (U src)
            => api.dec(src);

        [MethodImpl(Inline)]
        public static U operator ++ (in U src)
            => api.inc(src);

        [MethodImpl(Inline)]
        public static U operator + (U a, U b)
            => reduce(a.Value + b.Value);

        [MethodImpl(Inline)]
        public static U operator - (U a, U b)
            => reduce(a.Value - b.Value);

        [MethodImpl(Inline)]
        public static U operator * (U a, U b)
            => reduce(a.Value * b.Value);

        [MethodImpl(Inline)]
        public static U operator / (U a, U b)
            => wrap(a.Value / b.Value);

        [MethodImpl(Inline)]
        public static U operator % (U a, U b)
            => wrap(a.Value % b.Value);

        [MethodImpl(Inline)]
        public static U operator & (U a, U b)
            => (U)(a.Value & b.Value);

        [MethodImpl(Inline)]
        public static U operator | (U a, U b)
            => wrap(a.Value | b.Value);

        [MethodImpl(Inline)]
        public static U operator ^ (U a, U b)
            => wrap(a.Value ^ b.Value);

        [MethodImpl(Inline)]
        public static U operator >> (U a, int b)
            => wrap(a.Value >> b);

        [MethodImpl(Inline)]
        public static U operator << (U a, int b)
            => wrap(a.Value << b);

        [MethodImpl(Inline)]
        public static U operator ~ (U src)
            => wrap(~src.Value);

        public const L MinValue = L.Min;

        public const L MaxValue = L.Max;

        public const T Mask = (T)MaxValue;

        public const byte PackedWidth = 24;

        public const byte NativeWidth = 24;

        public const byte Size = 3;

        public const uint Mod = (T)MaxValue + 1u;

        public static W W => default;

        public static N N => default;

        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min
        {
            [MethodImpl(Inline)]
            get => @as<L,U>(MinValue);
        }

        /// <summary>
        /// Specifies the maximum <see cref='U'/> value
        /// </summary>
        public static U Max
        {
            [MethodImpl(Inline)]
            get => @as<L,U>(MaxValue);
        }

        /// <summary>
        /// Specifies  <see cref='U'/> type's zero-value
        /// </summary>
        public static U Zero
        {
            [MethodImpl(Inline)]
            get => @as<T,U>(0);
        }

        /// <summary>
        /// Specifies <see cref='U'/> type's one-value
        /// </summary>
        public static U One
        {
            [MethodImpl(Inline)]
            get => @as<T,U>(1);
        }
    }
}