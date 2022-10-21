//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using V = BitVector16;
    using D = UInt16;
    using W = W16;
    using N = N16;
    using api = BitVectors;

    /// <summary>
    /// Defines a 16-bit bitvector
    /// </summary>
    [DataWidth(16)]
    public struct BitVector16 : IEquatable<V>, IComparable<V>
    {
        public const D MaxValue = D.MaxValue;

        public static V Zero => 0;

        public static V One => 1;

        public static V Ones => MaxValue;

        public static N N => default;

        public static W W => default;

        internal D Data;

        /// <summary>
        /// Initializes the vector with the source value it represents
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public BitVector16(D src)
            => Data = src;

        /// <summary>
        /// Extracts the scalar represented by the vector
        /// </summary>
        public ushort State
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
            get => 16;
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
        /// The vector's 8 least significant bits
        /// </summary>
        public BitVector8 Lo
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        /// <summary>
        /// The vector's 8 most significant bits
        /// </summary>
        public BitVector8 Hi
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 8);
        }

        /// <summary>
        /// Presents bitvector content as a bytespan
        /// </summary>
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => core.bytes(Data);
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
        /// Gets/sets the state of an index-identified bit
        /// </summary>
        public bit this[int pos]
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
            get => BitVectors.extract(this, first, last);
        }

        [MethodImpl(Inline)]
        public BitVector32 Concat(V src)
            => api.join(this, src);

        [MethodImpl(Inline)]
        public bool Equals(V y)
            => Data == y.Data;

        public override bool Equals(object obj)
            => obj is V x ? Equals(x) : false;

        [MethodImpl(Inline)]
        public int CompareTo(V src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Hash;

        public string Format(in BitFormat config)
            => BitVectors.format(this,config);

        public string Format()
            => BitVectors.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ScalarBits<ushort>(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator V(ushort src)
            => new V(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector32(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector64(V src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator BitVector8(V src)
            => (byte)src.Data;

        /// <summary>
        /// Computes the bitwise AND of the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator &(V x, V y)
            => BitVectors.and(x,y);

        /// <summary>
        /// Computes the bitwise OR of the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator |(V x, V y)
            => BitVectors.or(x,y);

        /// <summary>
        /// Computes the bitwise XOR of the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator ^(V x, V y)
            => BitVectors.xor(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand.
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator ~(V src)
            => BitVectors.not(src);

        /// <summary>
        /// Computes the arithmetic sum of the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator +(V x, V y)
            => BitVectors.add(x,y);

        /// <summary>
        /// Computes the two's complement of the operand
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static V operator -(V x)
            => BitVectors.negate(x);

        /// <summary>
        /// Computes the arithmetic difference between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator - (V x, V y)
            => BitVectors.sub(x,y);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(V x, V y)
            => BitVectors.dot(x,y);

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
        /// Arithmetically increments the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static V operator ++(V src)
            => BitVectors.inc(src);

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
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
        /// Determines whether the left operand is arithmetically greater than the second
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

        [MethodImpl(Inline)]
        public static bit operator >=(V x, V y)
            => math.gteq(x,y);

    }
}