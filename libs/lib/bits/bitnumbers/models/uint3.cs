//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitNumbers;

    using U = uint3;
    using K = BitSeq3;
    using W = W3;
    using T = System.Byte;
    using N = N3;
    using api = BitNumbers;

    /// <summary>
    /// Represents a value in the range [<see cef='MinLiteral'/>, <see cref='MaxValue'/>]
    /// </summary>
    [DataWidth(Width)]
    public readonly struct uint3 : IBitNumber<U,W,K,T>
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
        internal uint3(uint8b src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(byte src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(byte src, bool @unchecked)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint3(sbyte src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(short src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(ushort src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(int x)
            => Value = (byte)((uint)x & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(uint src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(long src)
            => Value = (byte)((uint)src & MaxValue);

        [MethodImpl(Inline)]
        internal uint3(uint src, bool safe)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint3(K src)
            => Value = (byte)src;

        [MethodImpl(Inline)]
        internal uint3(BitState src)
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
        public bool Equals(U rhs)
            => eq(this,rhs);

        public override bool Equals(object rhs)
            => rhs is U x && Equals(x);
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
        public static implicit operator uint4(U src)
            => new uint4(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint5(U src)
            => new uint5(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint6(U src)
            => new uint6(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator uint7(U src)
            => new uint7(src.Value);

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

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => new bit(src.Value & 1);

        [MethodImpl(Inline)]
        public static explicit operator U(bit src)
            => (byte)src;

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => (byte)src.Value;

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => (ushort)src.Value;

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.Value;

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 63-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.Value;

        /// <summary>
        /// Converts a 3-bit integer to a signed 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.Value;

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(byte src)
            => uint3(src);

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator U(uint src)
            => uint3(src);

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(ulong src)
            => uint3(src);

        [MethodImpl(Inline)]
        public static U @bool(bool a)
            => uint3(a);

        [MethodImpl(Inline)]
        public static bool operator true(U a)
            => a.Value != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U a)
            => a.Value == 0;

        [MethodImpl(Inline)]
        public static U operator + (U a, U b)
            => add(a,b);

        [MethodImpl(Inline)]
        public static U operator - (U x, U y)
            => sub(x,y);

        [MethodImpl(Inline)]
        public static U operator * (U lhs, U rhs)
            => mul(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator / (U lhs, U rhs)
            => div(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator % (U lhs, U rhs)
            => mod(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator &(U lhs, U rhs)
            => and(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator |(U lhs, U rhs)
            => or(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator ^(U lhs, U rhs)
            => xor(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator >>(U lhs, int count)
            => srl(lhs, (byte)count);

        [MethodImpl(Inline)]
        public static U operator <<(U lhs, int count)
            => sll(lhs, (byte)count);

        [MethodImpl(Inline)]
        public static U operator ~(U src)
            => wrap3(~src.Value & MaxValue);

        [MethodImpl(Inline)]
        public static U operator ++(U x)
            => inc(x);

        [MethodImpl(Inline)]
        public static U operator --(U x)
            => dec(x);

        [MethodImpl(Inline)]
        public static bool operator ==(U a, U rhs)
            => eq(a,rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(U a, U rhs)
            => !a.Equals(rhs);

        [MethodImpl(Inline)]
        public static U operator < (U a, U rhs)
            => @bool(a.Value < rhs.Value);

        [MethodImpl(Inline)]
        public static U operator <= (U a, U rhs)
            => @bool(a.Value <= rhs.Value);

        [MethodImpl(Inline)]
        public static U operator > (U a, U rhs)
            => @bool(a.Value > rhs.Value);

        [MethodImpl(Inline)]
        public static U operator >= (U a, U rhs)
            => @bool(a.Value >= rhs.Value);

        /// <summary>
        /// Specifies the inclusive lower bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MinLiteral = 0;

        /// <summary>
        /// Specifies the inclusive upper bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MaxValue = Pow2.T03m1;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 3;

        /// <summary>
        /// Specifies the count of unique values representable by a <see cref='U'/>
        /// </summary>
        public const byte Mod = (byte)MaxValue + 1;

        /// <summary>
        /// Specifies the <see cref='Width'/> values as a type-level natural
        /// </summary>
        public static N N => default;

        public static W W => default;

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