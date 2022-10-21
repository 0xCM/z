//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using V = BitVector64;
    using D = UInt64;
    using W = W64;
    using N = N64;
    using api = BitVectors;

    /// <summary>
    /// Defines a 64-bit bitvector
    /// </summary>
    [DataWidth(64)]
    public struct BitVector64 : IEquatable<V>, IComparable<V>
    {
        public const D MaxValue = D.MaxValue;

        public static V Zero => default;

        public static V One => 1;

        public static V Ones => MaxValue;

        public static N N => default;

        public static W W => default;

        internal D Data;

        /// <summary>
        /// Initializes a vector with the primal source value it represents
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public BitVector64(D data)
            => Data = data;

        /// <summary>
        /// Extracts the scalar represented by the vector
        /// </summary>
        public readonly D State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// The actual number of bits represented by the vector
        /// </summary>
        public readonly uint Width
        {
            [MethodImpl(Inline)]
            get => 64;
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
        /// The vector's 32 least significant bits
        /// </summary>
        public readonly BitVector32 Lo
        {
            [MethodImpl(Inline)]
            get => BitVectors.create(n32, (uint)Data);
        }

        /// <summary>
        /// The vector's 32 most significant bits
        /// </summary>
        public readonly BitVector32 Hi
        {
            [MethodImpl(Inline)]
            get => BitVectors.create(n32,(uint)(Data >> 32));
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Data);
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
            get => Test(pos);

            [MethodImpl(Inline)]
            set => Data = Set(pos,value);
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
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        public V this[byte i0, byte i1]
        {
            [MethodImpl(Inline)]
            get => BitVectors.extract(this,i0, i1);
        }

        /// <summary>
        /// Selects an index-identified byte where i = [0,..,7]
        /// </summary>
        /// <param name="i">The 0-based byte-relative position</param>
        [MethodImpl(Inline)]
        public ref byte Byte(int i)
            => ref Bytes[i];

        [MethodImpl(Inline)]
        public readonly bool Equals(V y)
            => Data == y.Data;

        [MethodImpl(Inline)]
        public int CompareTo(V src)
            => Data.CompareTo(src.Data);

        public override bool Equals(object obj)
            => obj is V x && Equals(x);

        public override int GetHashCode()
            => Hash;

        public string Format(in BitFormat config)
            => BitVectors.format(this, config);

         public string Format()
            => BitVectors.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ScalarBits<ulong>(V src)
            => src.Data;

        /// <summary>
        /// Implicitly converts an unsigned 64-bit integer to a 64-bit bitvector
        /// </summary>
        /// <param name="src">The source integer</param>
        [MethodImpl(Inline)]
        public static implicit operator V(ulong src)
            => new V(src);

        /// <summary>
        /// Implicitly converts a bitvector to a 64-bit unsigned integer
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(V src)
            => src.Data;

        /// <summary>
        /// Explicitly converts a a 64-bit bitvector to an 8-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static explicit operator BitVector4(V src)
            => BitVectors.create(n4,(byte)src.Data);

        /// <summary>
        /// Explicitly converts a a 64-bit bitvector to an 8-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static explicit operator BitVector8(V src)
            => (byte)src.Data;

        /// <summary>
        /// Explicitly converts a a 64-bit bitvector to a 16-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static explicit operator BitVector16(V src)
            => (ushort)src.Data;

        /// <summary>
        /// Explicitly converts a a 64-bit bitvector to a 32-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static explicit operator BitVector32(V src)
            => BitVectors.create(n32, (uint)src.Data);

        /// <summary>
        /// Implicitly converts a scalar value to a 64-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator V(byte src)
            => BitVectors.create(N,src);

        /// <summary>
        /// Implicitly converts a scalar value to a 64-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator V(ushort src)
            => BitVectors.create(N,src);

        /// <summary>
        /// Implicitly converts a scalar value to a 64-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator V(uint src)
            => BitVectors.create(N,src);

        /// <summary>
        /// Computes the bitwise XOR of the source operands
        /// Note that the XOR operator is equivalent to the (+) operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator ^(V x, V y)
            => BitVectors.xor(x,y);

        /// <summary>
        /// Computes the bitwise AND of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
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

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(V x, V y)
            => BitVectors.dot(x,y);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static V operator +(V x, V y)
            => BitVectors.add(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator ~(V src)
            => BitVectors.not(src);

        /// <summary>
        /// Negates the operand via two's complement
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator -(V src)
            => BitVectors.negate(src);

        /// <summary>
        /// Arithmetically subtracts the second operand from the first.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator - (V x, V y)
            => BitVectors.sub(x,y);

        /// <summary>
        /// Shifts the source bits leftwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator <<(V x, int shift)
            => BitVectors.sll(x,(byte)shift);

        /// <summary>
        /// Shifts the source bits rightwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator >>(V x, int shift)
            => BitVectors.srl(x,(byte)shift);

        /// <summary>
        /// Increments the vector arithmetically
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static V operator ++(V x)
            => BitVectors.inc(x);

        /// <summary>
        /// Decrements the vector arithmetically
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static V operator --(V x)
            => BitVectors.dec(x);

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
            => x.Data == y.Data;

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