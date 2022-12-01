//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitNumbers;

    using U = uint5;
    using W = W5;
    using K = BitSeq5;
    using T = System.Byte;
    using N = N5;
    using api = BitNumbers;

    /// <summary>
    /// Represents a value in the range [<see cef='MinLiteral'/>, <see cref='MaxValue'/>]
    /// </summary>
    [DataWidth(Width)]
    public readonly struct uint5 : IBitNumber<U,W,K,T>
    {
        [Parser]
        public static bool parse(string src, out U dst)
        {
            var result = BitParser.parse(src, Width, out byte b);
            dst = b;
            return result;
        }

        internal readonly T Value;

        [MethodImpl(Inline)]
        internal uint5(uint8b src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(byte src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(byte src, bool @unchecked)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint5(sbyte src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(short src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(ushort src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(int x)
            => Value = (byte)((uint)x & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(uint src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(long src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint5(uint src, bool safe)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint5(K src)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint5(BitState src)
            => Value = (byte)src;

        /// <summary>
        /// Queries an index-identified bit
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

        [MethodImpl(Inline)]
        public string Format(N2 b)
            => BitRender.gformat(Value);

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
        public bool Equals(U y)
            => eq(this,y);

        public override bool Equals(object y)
            => y is U x && Equals(x);

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public int CompareTo(U src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator uint8b(U src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator U(uint8b src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(K src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator K(U src)
            => (K)src.Value;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => new bit(src.Value & 1);

        [MethodImpl(Inline)]
        public static explicit operator U(bit src)
            => (byte)src;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => (ushort)src.Value;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.Value;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 65-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.Value;

        /// <summary>
        /// Converts a 5-bit integer to a signed 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.Value;

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(byte src)
            => uint5(src);

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator U(uint src)
            => uint5(src);

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(ulong src)
            => uint5(src);

        [MethodImpl(Inline)]
        public static U @bool(bool src)
            => uint5(src);

        [MethodImpl(Inline)]
        public static bool operator true(U x)
            => x.Value != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U x)
            => x.Value == 0;

        [MethodImpl(Inline)]
        public static U operator + (U x, U y)
            => add(x,y);

        [MethodImpl(Inline)]
        public static U operator - (U x, U y)
            => sub(x,y);

        [MethodImpl(Inline)]
        public static U operator * (U x, U y)
            => mul(x,y);

        [MethodImpl(Inline)]
        public static U operator / (U x, U y)
            => div(x,y);

        [MethodImpl(Inline)]
        public static U operator % (U x, U y)
            => mod(x,y);

        [MethodImpl(Inline)]
        public static U operator &(U x, U y)
            => and(x,y);

        [MethodImpl(Inline)]
        public static U operator |(U x, U y)
            => or(x,y);

        [MethodImpl(Inline)]
        public static U operator ^(U x, U y)
            => xor(x,y);

        [MethodImpl(Inline)]
        public static U operator >>(U x, int count)
            => srl(x, (byte)count);

        [MethodImpl(Inline)]
        public static U operator <<(U x, int count)
            => sll(x, (byte)count);

        [MethodImpl(Inline)]
        public static U operator ~(U src)
            => wrap5(~src.Value & MaxValue);

        [MethodImpl(Inline)]
        public static U operator ++(U x)
            => inc(x);

        [MethodImpl(Inline)]
        public static U operator --(U x)
            => dec(x);

        [MethodImpl(Inline)]
        public static bool operator ==(U x, U y)
            => eq(x,y);

        [MethodImpl(Inline)]
        public static bool operator !=(U x, U y)
            => !x.Equals(y);

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

        /// <summary>
        /// Specifies the inclusive lower bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MinLiteral = 0;

        /// <summary>
        /// Specifies the inclusive upper bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MaxValue = Pow2.T05m1;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 5;

        /// <summary>
        /// Specifies the count of unique values representable by a <see cref='U'/>
        /// </summary>
        public const byte Mod = (byte)MaxValue + 1;

        /// <summary>
        /// Specifies the <see cref='Width'/> values as a type-level width
        /// </summary>
        public static W W => default;

        /// <summary>
        /// Specifies the <see cref='Width'/> values as a type-level natural
        /// </summary>
        public static N N => default;

        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min => default;

        /// <summary>
        /// Specifies the maximum <see cref='U'/> value
        /// </summary>
        public static U Max
        {
            [MethodImpl(Inline)]
            get => new U(MaxValue,true);
        }

        /// <summary>
        /// Specifies the <see cref='U'/> zero value
        /// </summary>
        public static U Zero
        {
            [MethodImpl(Inline)]
            get => new U(0,true);
        }

        /// <summary>
        /// Specifies the <see cref='U'/> one value
        /// </summary>
        public static U One
        {
            [MethodImpl(Inline)]
            get => new U(1,true);
        }
   }
}