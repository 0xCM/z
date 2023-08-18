//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitNumbers;
    using static sys;
    using U = uint8b;
    using W = W8;
    using K = BitSeq8;
    using T = System.Byte;
    using N = N8;

    /// <summary>
    /// Represents the value of a type-level octet and thus is an integer in the range [0,255]
    /// </summary>
    [DataWidth(Width)]
    public readonly record struct uint8b : IBitNumber<U,W,K,T>
    {
        [Parser]
        public static bool parse(string src, out U dst)
        {
            var result = BitParser.parse(src, Width, out byte b);
            dst = b;
            return result;
        }

        public const byte BitCount = 8;

        internal readonly T Value;

        [MethodImpl(Inline)]
        public uint8b(byte x)
            => Value = x;

        [MethodImpl(Inline)]
        public uint8b(K x)
            => Value =(byte)x;

        byte IBits<byte>.Value
            => Value;

        byte IBits.Width
            => Width;

        /// <summary>
        /// Queries the state of an index-identified bit
        /// </summary>
        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => test(this, pos);
        }

        public K Kind
        {
            [MethodImpl(Inline)]
            get => (K) Value;
        }

        public T Content
        {
            [MethodImpl(Inline)]
            get => Value;
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
            get => Value == MaxValue;
        }

        /// <summary>
        /// Specifies whether the current value is the minimum value
        /// </summary>
        public bool IsMin
        {
            [MethodImpl(Inline)]
            get => Value == MinLiteral;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public uint4 Lo
        {
            [MethodImpl(Inline)]
            get => lo(this);
        }

        public uint4 Hi
        {
            [MethodImpl(Inline)]
            get => hi(this);
        }

        [MethodImpl(Inline)]
        public U WithLo(uint4 src)
            => movlo(src, this);

        [MethodImpl(Inline)]
        public U WithHi(uint4 src)
            => movhi(src, this);

        [MethodImpl(Inline)]
        public bool Equals(U y)
            => Value == y.Value;

        [MethodImpl(Inline)]
        public int CompareTo(U src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => (int)Hash;

         public string Format()
             => format(this);

        public string Format(BitFormat config)
            => format(this,config);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator U(K src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator K(U src)
            => (K)src.Value;

        [MethodImpl(Inline)]
        public static U @bool(bool x)
            => x ? One : Zero;

        [MethodImpl(Inline)]
        public static bool operator true(U x)
            => x.Value != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U x)
            => x.Value == 0;

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => new (src.Value & 1);

        [MethodImpl(Inline)]
        public static explicit operator U(bit src)
            => (byte)src;

        [MethodImpl(Inline)]
        public static implicit operator U(byte src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(U src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator short(U src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator int(U src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator long(U src)
            => (long)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator float(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator double(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Hex8(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static U operator + (U x, U y)
            => wrap(x.Value + y.Value);

        [MethodImpl(Inline)]
        public static U operator - (U x, U y)
            => wrap(x.Value - y.Value);

        [MethodImpl(Inline)]
        public static U operator * (U x, U y)
            => wrap(x.Value * y.Value);

        [MethodImpl(Inline)]
        public static U operator / (U x, U y)
            => wrap(x.Value / y.Value);

        [MethodImpl(Inline)]
        public static U operator % (U x, U y)
            => wrap(x.Value % y.Value);

        [MethodImpl(Inline)]
        public static U operator < (U x, U y)
            => @bool(x.Value < y.Value);

        [MethodImpl(Inline)]
        public static U operator <= (U x, U y)
            => @bool(x.Value <= y.Value);

        [MethodImpl(Inline)]
        public static U operator > (U x, U y)
            => @bool(x.Value > y.Value);

        [MethodImpl(Inline)]
        public static U operator >= (U x, U y)
            => @bool(x.Value >= y.Value);

        [MethodImpl(Inline)]
        public static U operator & (U x, U y)
            => (U)(x.Value & y.Value);

        [MethodImpl(Inline)]
        public static U operator | (U x, U y)
            => wrap(x.Value | y.Value);

        [MethodImpl(Inline)]
        public static U operator ^ (U x, U y)
            => wrap(x.Value ^ y.Value);

        [MethodImpl(Inline)]
        public static U operator >> (U x, int y)
            => wrap(x.Value >> y);

        [MethodImpl(Inline)]
        public static U operator << (U x, int y)
            => wrap(x.Value << y);

        [MethodImpl(Inline)]
        public static U operator ~ (U src)
            => wrap(~ src.Value);

        [MethodImpl(Inline)]
        public static U operator - (U src)
            => wrap(~src.Value + 1);

        [MethodImpl(Inline)]
        public static U operator -- (U src)
            => dec(src);

        [MethodImpl(Inline)]
        public static U operator ++ (U src)
            => inc(src);

        public const T MinLiteral = 0;

        public const T MaxValue = byte.MaxValue;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 8;

        public const uint Mod = 256;

        public static W W => default;

        public static N N => default;

        public static U Zero => 0;

        public static U One => 1;

        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min
        {
            [MethodImpl(Inline)]
            get => new (MinLiteral);
        }

        /// <summary>
        /// Specifies the maximum <see cref='U'/> value
        /// </summary>
        public static U Max
        {
            [MethodImpl(Inline)]
            get => new (MaxValue);
        }

        [MethodImpl(Inline)]
        static U wrap(int x)
            => new U((byte)x);
    }
}