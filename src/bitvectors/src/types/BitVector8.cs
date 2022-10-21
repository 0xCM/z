//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using V = BitVector8;
    using D = Byte;
    using W = W8;
    using N = N8;
    using api = BitVectors;

    [DataWidth(8)]
    public struct BitVector8 : IEquatable<V>, IComparable<V>
    {
        public const D MaxValue = D.MaxValue;

        public static V Zero => default;

        public static V One => 1;

        public static V Ones => MaxValue;

        public static N N => default;

        public static W W => default;

        internal D Data;

        [MethodImpl(Inline)]
        public BitVector8(D src)
            => Data = src;

        /// <summary>
        /// Extracts the scalar represented by the vector
        /// </summary>
        public D State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// The number of bits represented by the vector
        /// </summary>
        public readonly uint Width
        {
            [MethodImpl(Inline)]
            get => 8;
        }

        /// <summary>
        /// Presents bitvector content as a bytespan
        /// </summary>
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => core.bytes(Data);
        }

        public bit IsZero
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bit IsNonZero
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        /// <summary>
        /// Tests whether all bits are on
        /// </summary>
        public readonly bool Enabled
        {
            [MethodImpl(Inline)]
            get => (MaxValue & Data) == MaxValue;
        }

        /// <summary>
        /// The vector's 4 most significant bits
        /// </summary>
        public readonly BitVector4 Hi
        {
            [MethodImpl(Inline)]
            get => bits.hi(Data);
        }

        /// <summary>
        /// The vector's 4 least significant bits
        /// </summary>
        public readonly BitVector4 Lo
        {
            [MethodImpl(Inline)]
            get => bits.lo(Data);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Data;
        }

        [MethodImpl(Inline)]
        public bit Test(byte pos)
            => bit.test(Data, pos);

        [MethodImpl(Inline)]
        public V Set(byte pos, bit state)
        {
            Data = bit.set(Data, pos, state);
            return this;
        }

        /// <summary>
        /// Gets/sets the state of an index-identified bit
        /// </summary>
        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(Data, (byte)pos);

            [MethodImpl(Inline)]
            set => Data = bit.set(Data, (byte)pos, value);
        }

        /// <summary>
        /// Selects a contiguous range of bits
        /// </summary>
        /// <param name="first">The position of the first bit</param>
        /// <param name="last">The position of the last bit</param>
        public V this[byte first, byte last]
        {
            [MethodImpl(Inline)]
            get => BitVectors.extract(this,first,last);
        }

        [MethodImpl(Inline)]
        public BitVector16 Concat(V src)
            => api.join(this, src);

        [MethodImpl(Inline)]
        public readonly bool Equals(V y)
            => Data == y.Data;

        public override bool Equals(object obj)
            => obj is V x ? Equals(x) : false;

        [MethodImpl(Inline)]
        public int CompareTo(V src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public string Format(in BitFormat config)
            => BitVectors.format(this,config);

        public string Format()
            => BitVectors.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ScalarBits<byte>(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator V(byte src)
            => new V(src);

        /// <summary>
        /// Implicitly converts a byte classifier to a vector
        /// </summary>
        /// <param name="src">The classifier</param>
        [MethodImpl(Inline)]
        public static implicit operator V(Hex8Kind src)
            => (byte)src;

        /// <summary>
        /// Implicitly converts a vector to a byte classifier
        /// </summary>
        /// <param name="src">The vector</param>
        [MethodImpl(Inline)]
        public static implicit operator Hex8Kind(V src)
            => (Hex8Kind)src.Data;

        /// <summary>
        /// Converts the source vector to the underlying scalar
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector16(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector32(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector64(V src)
            => src.Data;

        /// <summary>
        /// <summary>
        /// Computes the component-wise AND of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator &(V x, V y)
            => BitVectors.and(x,y);

        /// <summary>
        /// Computes the bitwise OR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator |(V x, V y)
            => BitVectors.or(x,y);

        /// Computes the XOR of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator ^(V x, V y)
            => BitVectors.xor(x,y);

        /// <summary>
        /// Left-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator <<(V x, int shift)
            => BitVectors.sll(x,(byte)shift);

        /// <summary>
        /// Right-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator >>(V x, int shift)
            => BitVectors.srl(x,(byte)shift);

        /// <summary>
        /// Computes the one's complement of the operand.
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator ~(V x)
            => BitVectors.not(x);

        /// <summary>
        /// Computes the two's complement of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator -(V x)
            => BitVectors.negate(x);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator +(V x, V y)
            => BitVectors.add(x,y);

        /// <summary>
        /// Computes the product of the operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator *(V x, V y)
            => BitVectors.gfmul(x,y);

        /// <summary>
        /// Computes the arithmetic difference between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator - (V x, V y)
            => BitVectors.sub(x,y);

        /// <summary>
        /// Raises a vector b to a power n where n >= 0
        /// </summary>
        /// <param name="b">The base vector</param>
        /// <param name="n">The power</param>
        [MethodImpl(Inline)]
        public static V operator ^(V b, int n)
            => BitVectors.pow(b,n);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(V x, V y)
            => BitVectors.dot(x,y);

        /// <summary>
        /// Arithmetically increments the bitvector
        /// </summary>
        /// <param name="lhs">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator ++(V src)
            => BitVectors.inc(src);

        /// <summary>
        /// Arithmetically decrements the bitvector
        /// </summary>
        /// <param name="lhs">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator --(V src)
            => BitVectors.dec(src);

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(V src)
            => src.IsNonZero;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(V src)
            => src.IsZero;

        /// <summary>
        /// Computes the operand's logical negation: if x = 0 then 1 else 0
        /// </summary>
        /// <param name="src">The ource operand</param>
        [MethodImpl(Inline)]
        public static bit operator !(V src)
            => src.IsZero;

        /// <summary>
        /// Determines whether operand content is identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator ==(V x, V y)
            => math.eq(x,y);

        /// <summary>
        /// Determines whether operand content is non-identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator !=(V x, V y)
            => math.neq(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <(V x, V y)
            => math.lt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >(V x, V y)
            => math.gt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <=(V x, V y)
            => math.lteq(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >=(V x, V y)
            => math.gteq(x,y);
    }
}