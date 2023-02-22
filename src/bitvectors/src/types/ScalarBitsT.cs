//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using api = ScalarBits;

    /// <summary>
    /// Defines a generic bitvector over a primal cell
    /// </summary>
    /// <typeparam name="T">The cell type</typeparam>
    public struct ScalarBits<T> : IComparable<ScalarBits<T>>, IEquatable<ScalarBits<T>>
        where T : unmanaged
    {
        T Data;

        [MethodImpl(Inline)]
        internal ScalarBits(T src)
            => Data = src;

        /// <summary>
        /// Specifies the data over which the vector is defined
        /// </summary>
        public readonly T State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// Extracts the lower bits
        /// </summary>
        public readonly T Lo
        {
            [MethodImpl(Inline)]
            get => gbits.lo(Data);
        }

        /// <summary>
        /// Extracts the upper bits
        /// </summary>
        public readonly T Hi
        {
            [MethodImpl(Inline)]
            get => gbits.hi(Data);
        }

        /// <summary>
        /// The number of bits represented by the vector
        /// </summary>
        public readonly BitWidth Width
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        public readonly ByteSize Size
        {
            [MethodImpl(Inline)]
            get => size<T>();
        }

        /// <summary>
        /// Specifies whether all bits are disabled
        /// </summary>
        public bit IsZero
        {
            [MethodImpl(Inline)]
            get => !gmath.nonz(Data);
        }

        /// <summary>
        /// Specifies whether at least one bit is enabled
        /// </summary>
        public readonly bit IsNonZero
        {
            [MethodImpl(Inline)]
            get => gmath.nonz(Data);
        }

        /// <summary>
        /// Reads/Manipulates a single bit
        /// </summary>
        public bit this[int index]
        {
            [MethodImpl(Inline)]
            get => gbits.test(Data, (byte)index);

            [MethodImpl(Inline)]
            set => Data = gbits.set(Data, (byte)index, value);
        }

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="min">The first bit position</param>
        /// <param name="max">The last bit position</param>
        public ScalarBits<T> this[byte min, byte max]
        {
            [MethodImpl(Inline)]
            get => api.extract(this, min, max);
        }

        [MethodImpl(Inline)]
        public readonly bool Equals(ScalarBits<T> y)
            => gmath.eq(Data, y.Data);

        public readonly override bool Equals(object obj)
            => obj is ScalarBits<T> x && Equals(x);

        public readonly override int GetHashCode()
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public int CompareTo(ScalarBits<T> src)
            => bw64(this).CompareTo(bw64(src));

        public string Format(in BitFormat config)
            => ScalarBits.format(this,config);

        public string Format()
            => ScalarBits.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ScalarBits<T>(T src)
            => new ScalarBits<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(ScalarBits<T> src)
            => src.Data;

        /// <summary>
        /// Computes the bitwise AND between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator &(ScalarBits<T> x, ScalarBits<T> y)
            => api.and(x,y);

        /// <summary>
        /// Computes the bitwise AND between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator |(ScalarBits<T> x, ScalarBits<T> y)
            => BitVectors.or(x,y);

        /// <summary>
        /// Computes the bitwise XOR between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator ^(ScalarBits<T> x, ScalarBits<T> y)
            => BitVectors.xor(x,y);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(ScalarBits<T> x, ScalarBits<T> y)
            => api.dot(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator ~(ScalarBits<T> src)
            => BitVectors.not(src);

        /// <summary>
        /// Computes the two's complement negation of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator -(ScalarBits<T> src)
            => ScalarBits.negate(src);

        /// <summary>
        /// Shifts the source bits leftwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator <<(ScalarBits<T> x, int offset)
            => api.sll(x,(byte)offset);

        /// <summary>
        /// Shifts the source bits rightwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator >>(ScalarBits<T> x, int offset)
            => api.srl(x,(byte)offset);

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(ScalarBits<T> src)
            => src.IsNonZero;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(ScalarBits<T> src)
            => src.IsZero;

        /// <summary>
        /// Increments the vector arithmetically
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator ++(ScalarBits<T> src)
            => ScalarBits.inc(src);

        /// <summary>
        /// Decrements the vector arithmetically
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator --(ScalarBits<T> src)
            => api.dec(src);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator +(ScalarBits<T> x, ScalarBits<T> y)
            => api.add(x,y);

        /// <summary>
        /// Arithmetically subtracts the second operand from the first.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> operator - (ScalarBits<T> x, ScalarBits<T> y)
            => api.sub(x,y);

        /// <summary>
        /// Determines whether operand content is identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator ==(ScalarBits<T> x, ScalarBits<T> y)
            => gmath.eq(x.Data,y.Data);

        /// <summary>
        /// Determines whether operand content is non-identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator !=(ScalarBits<T> x, ScalarBits<T> y)
            => gmath.neq(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <(ScalarBits<T> x, ScalarBits<T> y)
            => gmath.lt(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >(ScalarBits<T> x, ScalarBits<T> y)
            => gmath.gt(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <=(ScalarBits<T> x, ScalarBits<T> y)
            => gmath.lteq(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >=(ScalarBits<T> x, ScalarBits<T> y)
            => gmath.gteq(x.Data,y.Data);
   }
}