//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static BitNumbers;

    using U = uint1;
    using K = BitSeq1;
    using W = W1;
    using T = System.Byte;
    using N = N1;

    /// <summary>
    /// Represents either 0 or 1
    /// </summary>
    [DataWidth(1)]
    public readonly struct uint1 : IBitNumber<U,W,K,T>
    {
        [Parser]
        public static bool parse(string src, out U dst)
        {
            var result = BitParser.parse(src, out bit b);
            dst = b;
            return result;
        }

        internal readonly T Value;

        [MethodImpl(Inline)]
        internal uint1(uint8b src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(byte src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(byte src, bool @unchecked)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint1(sbyte src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(short src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(ushort src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(int x)
            => Value = (byte)((uint)x & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(uint src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(long src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint1(uint src, bool safe)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint1(BitState src)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint1(bit src)
            => Value = (byte)src;

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

        /// <summary>
        /// Renders the source value as as hexadecimal string
        /// </summary>
        [MethodImpl(Inline)]
        public string Format()
            => Value == 0 ? "0" : "1";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(U y)
            => eq(this,y);

        public override bool Equals(object y)
            => y is U x && Equals(x);

        [MethodImpl(Inline)]
        public char ToChar()
            => Value != 0 ? '1' : '0';

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

        byte IBits<byte>.Value
            => Value;

        byte IBits.Width
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator uint2(U src)
            => new uint2(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint3(U src)
            => new uint3(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint4(U src)
            => new uint4(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint5(U src)
            => new uint5(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint6(U src)
            => new uint6(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint8b(U src)
            => new uint8b(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator U(uint8b src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(BitState src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator bool(U src)
            => src.Value == 1;

        [MethodImpl(Inline)]
        public static implicit operator U(bit src)
            => new U((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator bit(U src)
            => new bit(src.Value & 1);

        /// <summary>
        /// Converts a 1-bit integer to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator U(X00 src)
            => (byte)src;

        [MethodImpl(Inline)]
        public static implicit operator U(X01 src)
            => (byte)src;

        /// <summary>
        /// Converts a 1-bit integer to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => (ushort)src.Value;

        /// <summary>
        /// Converts a 1-bit integer to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.Value;

        /// <summary>
        /// Converts a 1-bit integer to an unsigned 61-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.Value;

        /// <summary>
        /// Converts a 1-bit integer to a signed 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.Value;

        /// <summary>
        /// Creates a 1-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(byte src)
            => uint1(src);

        /// <summary>
        /// Creates a 1-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator U(uint src)
            => uint1(src);

        /// <summary>
        /// Creates a 1-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(ulong src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static implicit operator U(bool src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint2 src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint3 src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint4 src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint5 src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint6 src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint7 src)
            => uint1(src);

        [MethodImpl(Inline)]
        public static U @bool(bool x)
            => uint1(x);

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
            => wrap1(~src.Value & MaxValue);

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
        public const T MaxValue = Pow2.T01m1;

        /// <summary>
        /// Specifies the count of unique values representable by a <see cref='U'/>
        /// </summary>
        public const uint Count = MaxValue + 1;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 1;

        public static W W => default;

        public static N N => default;


        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min
        {
            [MethodImpl(Inline)]
            get => new U(MinLiteral,true);
        }

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

        public Span<bit> _Bits
        {
            [MethodImpl(Inline)]
            get => bits(this);
        }

    }
}