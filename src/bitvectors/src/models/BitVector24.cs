//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using V = BitVector24;
    using D = UInt32;
    using W = W24;
    using N = N24;
    using api = BitVectors;

    /// <summary>
    /// Defines a 32-bit bitvector
    /// </summary>
    [DataWidth(24)]
    public struct BitVector24 : IEquatable<V>, IComparable<V>
    {
        const D MaxValue = D.MaxValue >> 8;

        /// <summary>
        /// Allocates a vector with all bits disabled
        /// </summary>
        public static V Zero => 0;

        public static V One => 1;

        public static V Ones => MaxValue;

        public static N N => default;

        public static W W => default;

        // [MethodImpl(Inline)]
        // public static V FromEnum<T>(T src)
        //     where T : unmanaged, Enum
        //         => Enums.scalar<T,uint>(src);

        internal D Data;

        /// <summary>
        /// Initializes the vector
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public BitVector24(uint src)
            => Data = src & MaxValue;

        /// <summary>
        /// Initializes the vector
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public BitVector24(ushort lo, byte hi)
            => Data = (uint)lo | (uint)hi << 16;

        /// <summary>
        /// Extracts the scalar represented by the vector
        /// </summary>
        public readonly uint State
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
            get => 24;
        }

        /// <summary>
        /// The first 8 bits of the vector
        /// </summary>
        public BitVector8 Lo8
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        /// <summary>
        /// The middle 8 bits of the vector
        /// </summary>
        public BitVector8 Mid8
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 8);
        }

        /// <summary>
        /// The upper 8 bits of the vector
        /// </summary>
        public BitVector8 Hi8
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 16);
        }

        /// <summary>
        /// The first 16 bits of the vector
        /// </summary>
        public BitVector16 Lo16
        {
            [MethodImpl(Inline)]
            get => (ushort)Data;
        }

        /// <summary>
        /// The last 16 bits of the vector
        /// </summary>
        public BitVector16 Hi16
        {
            [MethodImpl(Inline)]
            get => (ushort)(Data >> 8);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data;
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
        /// Queries/Manipulates index-identified bits
        /// </summary>
        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(Data, pos);

            [MethodImpl(Inline)]
            set => Data = bit.set(Data, pos, value);
       }

        /// <summary>
        /// Selects a contiguous range of bits defined by an inclusive 0-based index range
        /// </summary>
        /// <param name="first">The position of the first bit</param>
        /// <param name="last">The position of the last bit</param>
        public V this[byte first, byte last]
        {
            [MethodImpl(Inline)]
            get =>  bits.extract(Data, first, last);
        }

        [MethodImpl(Inline)]
        public bool Equals(V y)
            => Data == y.Data;


        public override bool Equals(object src)
            => src is V x ? Equals(x) : false;

        [MethodImpl(Inline)]
        public int CompareTo(V src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Data.ToBitString(24).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitVector64(V src)
            => BitVectors.create(n64,src.Data);

        [MethodImpl(Inline)]
        public static explicit operator BitVector4(V src)
            => new BitVector4((byte)src.Data);

        [MethodImpl(Inline)]
        public static explicit operator BitVector8(V src)
            => (byte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator BitVector16(V src)
            =>(ushort)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator uint(V src)
            => src.Data;

        /// <summary>
        /// Implicitly converts a scalar value to a 32-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator V(uint src)
            => new V(src);

        /// <summary>
        /// Implicitly converts a scalar value to a 32-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator V(byte src)
            => (uint)src;

        /// <summary>
        /// Implicitly converts a scalar value to a 32-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator V(ushort src)
            => (uint)src;

        /// <summary>
        /// Implicitly constructs a bitvector from a tuple
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator V((ushort lo, byte hi) src)
            => new V(src.lo, src.hi);

        /// <summary>
        /// Computes the bitwise XOR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator ^(V x, V y)
            => x.Data ^ y.Data;

        /// <summary>
        /// Computes the bitwise AND of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator &(V x, V y)
            => x.Data & y.Data;

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(V x, V y)
            => BitVectors.dot(x.Data, y.Data);

        /// <summary>
        /// Computes the bitwise OR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static V operator |(V x, V y)
            => x.Data | y.Data;

        /// <summary>
        /// Computes the bitwise complement of the operand.
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator ~(V src)
            =>  ~ src.Data;

        /// <summary>
        /// Computes the two's complement of the operand
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static V operator -(V x)
            => math.negate(x.Data);

        /// <summary>
        /// Left-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator <<(V x, int shift)
            => x.Data << shift;

        /// <summary>
        /// Right-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static V operator >>(V x, int shift)
            => x.Data >> shift;

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(V x)
            => x.IsNonZero;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(V x)
            => x.IsZero;

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
            => x.Data != y.Data;

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