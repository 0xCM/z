//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitNumbers;

    using T = uint6;
    using W = W6;
    using K = BitSeq6;
    using D = System.Byte;
    using N = N6;
    using U = uint6;
    using api = BitNumbers;

    /// <summary>
    /// Represents a value in the range [<see cef='MinLiteral'/>, <see cref='MaxValue'/>]
    /// </summary>
    [DataWidth(Width)]
    public readonly struct uint6 : IBitNumber<T,W,K,D>
    {
        [Parser]
        public static bool parse(string src, out U dst)
        {
            var result = BitParser.parse(src, Width, out byte b);
            dst = b;
            return result;
        }

        internal readonly D Value;

        [MethodImpl(Inline)]
        internal uint6(uint8b src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(byte src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(byte src, bool @unchecked)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint6(sbyte src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(short src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(ushort src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(int x)
            => Value = (byte)((uint)x & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(uint src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(long src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint6(K src)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint6(BitState src)
            => Value = (byte)src;

        /// <summary>
        /// Queries and manipulates a bit identified by its 0-based index
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

        public D Content
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
            get => Value == 0;
        }

        [MethodImpl(Inline)]
        public string Format(N2 b)
            => BitRender.gformat(Value,Width);

        byte IBits<byte>.Value
            => Value;

        byte IBits.Width
            => Width;
        public string Format()
             => format(this);

        public override string ToString()
            => Format();
        public string Format(BitFormat config)
            => format(this,config);

        [MethodImpl(Inline)]
        public bool Equals(T y)
            => eq(this,y);

        public override bool Equals(object y)
            => y is T x && Equals(x);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public int CompareTo(T src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator uint8b(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint7(T src)
            => new uint7(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator T(uint8b src)
            => new T(src);

        [MethodImpl(Inline)]
        public static implicit operator T(K src)
            => new T(src);

        [MethodImpl(Inline)]
        public static implicit operator K(T src)
            => (K)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator bit(T src)
            => new bit(src.Value & 1);

        [MethodImpl(Inline)]
        public static explicit operator T(bit src)
            => (byte)src;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(T src)
            => (byte)src.Value;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ushort(T src)
            => (ushort)src.Value;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator uint(T src)
            => src.Value;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 65-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(T src)
            => src.Value;

        /// <summary>
        /// Converts a 5-bit integer to a signed 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator int(T src)
            => (int)src.Value;

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator T(byte src)
            => uint6(src);

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator T(uint src)
            => uint6(src);

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator T(ulong src)
            => uint6(src);

        [MethodImpl(Inline)]
        public static T @bool(bool x)
            => uint6(x);

        [MethodImpl(Inline)]
        public static bool operator true(T x)
            => x.Value != 0;

        [MethodImpl(Inline)]
        public static bool operator false(T x)
            => x.Value == 0;

        [MethodImpl(Inline)]
        public static T operator + (T x, T y)
            => add(x,y);

        [MethodImpl(Inline)]
        public static T operator - (T x, T y)
            => sub(x,y);

        [MethodImpl(Inline)]
        public static T operator * (T x, T y)
            => mul(x,y);

        [MethodImpl(Inline)]
        public static T operator / (T x, T y)
            => div(x,y);

        [MethodImpl(Inline)]
        public static T operator % (T x, T y)
            => mod(x,y);

        [MethodImpl(Inline)]
        public static T operator &(T x, T y)
            => and(x,y);

        [MethodImpl(Inline)]
        public static T operator |(T x, T y)
            => or(x,y);

        [MethodImpl(Inline)]
        public static T operator ^(T x, T y)
            => xor(x,y);

        [MethodImpl(Inline)]
        public static T operator >>(T x, int count)
            => srl(x, (byte)count);

        [MethodImpl(Inline)]
        public static T operator <<(T x, int count)
            => sll(x, (byte)count);

        [MethodImpl(Inline)]
        public static T operator ~(T src)
            => wrap6((byte)(~src.Value & MaxValue));

        [MethodImpl(Inline)]
        public static T operator ++(T x)
            => inc(x);

        [MethodImpl(Inline)]
        public static T operator --(T x)
            => dec(x);

        [MethodImpl(Inline)]
        public static bool operator ==(T x, T y)
            => eq(x,y);

        [MethodImpl(Inline)]
        public static bool operator !=(T x, T y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static T operator < (T x, T y)
            => @bool(x.Value < y.Value);

        [MethodImpl(Inline)]
        public static T operator <= (T x, T y)
            => @bool(x.Value <= y.Value);

        [MethodImpl(Inline)]
        public static T operator > (T x, T y)
            => @bool(x.Value > y.Value);

        [MethodImpl(Inline)]
        public static T operator >= (T x, T y)
            => @bool(x.Value >= y.Value);

        /// <summary>
        /// Specifies the inclusive upper bound of the <see cref='T'/> as a literal value
        /// </summary>
        public const D MaxValue = Pow2.T06m1;

        /// <summary>
        /// Specifies the represented data type bit-width
        /// </summary>
        public const byte Width = 6;

        /// <summary>
        /// Specifies the count of unique values representable by a <see cref='T'/>
        /// </summary>
        public const byte Mod = MaxValue + 1;

        public static W W => default;

        /// <summary>
        /// Specifies the <see cref='Width'/> values as a type-level natural
        /// </summary>
        public static N N => default;

        /// <summary>
        /// Specifies the minimum <see cref='T'/> value
        /// </summary>
        public static T Min => default;

        /// <summary>
        /// Specifies the maximum <see cref='T'/> value
        /// </summary>
        public static T Max
        {
            [MethodImpl(Inline)]
            get => new T(MaxValue,true);
        }

        /// <summary>
        /// Specifies the <see cref='T'/> zero value
        /// </summary>
        public static T Zero => default;

        /// <summary>
        /// Specifies the <see cref='T'/> one value
        /// </summary>
        public static T One
        {
            [MethodImpl(Inline)]
            get => new T(1,true);
        }

        public Span<bit> _Bits
        {
            [MethodImpl(Inline)]
            get => bits(this);
        }
   }
}