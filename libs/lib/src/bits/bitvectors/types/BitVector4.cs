//---------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using V = BitVector4;
    using D = Byte;
    using W = W4;
    using N = N4;
    using api = BitVectors;

    /// <summary>
    /// Defines a 4-bit bitvector
    /// </summary>
    [DataWidth(4,8)]
    public struct BitVector4 : IEquatable<V>, IComparable<V>
    {
        public const D MaxValue = 0xF;

        public static V Zero => 0;

        public static V One => 1;

        public static V Ones => MaxValue;

        public static N N => default;

        public static W W => default;

        internal D Data;

        [MethodImpl(Inline)]
        internal BitVector4(D data, bit direct)
            => Data = data;

        [MethodImpl(Inline)]
        public BitVector4(D data)
            => Data = math.and(data, MaxValue);

        /// <summary>
        /// Extracts the scalar represented by the vector
        /// </summary>
        public byte State
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
            get => 4;
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

        public bool Enabled
        {
            [MethodImpl(Inline)]
            get => (MaxValue & Data) == MaxValue;
        }

        [MethodImpl(Inline)]
        public bit Test(byte pos)
            => (Data & (1 << pos)) != 0;

        [MethodImpl(Inline)]
        public V Set(byte pos, bit state)
        {
            Data = math.and(bit.set(Data, pos, state), MaxValue);
            return this;
        }

        [MethodImpl(Inline)]
        public BitVector8 Concat(V src)
            => api.join(this, src);

        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => Test(pos);

            [MethodImpl(Inline)]
            set => Data = Set(pos,value);
        }

        public V this[byte first, byte last]
        {
            [MethodImpl(Inline)]
            get => BitVectors.extract(this,first,last);
        }

        [MethodImpl(Inline)]
        public bool Equals(V src)
            => Data == src.Data;

        public override bool Equals(object obj)
            => obj is V x  && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(V src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override string ToString()
            => this.Format();

        [MethodImpl(Inline)]
        public static implicit operator V(byte src)
            => new V(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(V src)
            => src.Data;

        /// <summary>
        /// Computes the XOR of the source operands.
        /// Note that this operator is equivalent to the addition operator (+)
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator ^(in V x, in V y)
            => (byte)(x.Data ^ y.Data);

        /// <summary>
        /// Computes the bitwise AND of the source operands
        /// Note that the AND operator is equivalent to the (*) operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator &(in V x, in V y)
            => (byte)(x.Data & y.Data);

        /// <summary>
        /// Computes the bitwise OR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator |(in V x, in V y)
            => BitVectors.or(x,y);

        /// <summary>
        /// Computes the bitwise complement
        /// </summary>
        /// <param name="x">The left bitvector</param>
        [MethodImpl(Inline)]
        public static V operator ~(V src)
            => BitVectors.not(src);


        [MethodImpl(Inline)]
        public static V operator >>(V x, int shift)
            => BitVectors.srl(x,(byte)shift);

        [MethodImpl(Inline)]
        public static V operator <<(V x, int shift)
            => BitVectors.sll(x,(byte)shift);

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
        /// Note that this operator is equivalent to the AND operator (&)
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator *(in V x, in V y)
            => (byte)(x.Data & y.Data);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(V x, V y)
            => BitVectors.dot(x,y);

        [MethodImpl(Inline)]
        public static V operator -(in V src)
            => BitVectors.negate(src);

        /// <summary>
        /// Subtracts the second operand from the first.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator - (V x, V y)
            => BitVectors.sub(x,y);

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

        [MethodImpl(Inline)]
        public static implicit operator BitVector8(BitVector4 src)
            => src.State;

        [MethodImpl(Inline)]
        public static implicit operator BitVector16(BitVector4 src)
            => src.State;

        [MethodImpl(Inline)]
        public static implicit operator BitVector32(BitVector4 src)
            => src.State;

        [MethodImpl(Inline)]
        public static implicit operator BitVector64(BitVector4 src)
            => src.State;
    }
}