//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Defines a 16-bit bitvector from the lo 16 bits of the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector16 ToBitVector16(this uint src)
            => (ushort)src;

        /// <summary>
        /// Constructs a canonical 8-bit bitvector from an 8-bit primal value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector8 ToBitVector8(this byte src)
            => src;

        /// <summary>
        /// Constructs a canonical 32-bit bitvector from a 32-bit primal value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector32 ToBitVector32(this uint src)
            => src;

        /// <summary>
        /// Defines a 32-bit bitvector with content determined by a 32-bit usigned integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector32 ToBitVector32(this int src)
            => (uint)src;

        /// <summary>
        /// Constructs a 16-bit bitvector from a 16-bit scalar
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector16 ToBitVector16(this ushort src)
            => src;

        /// <summary>
        /// Constructs a 64-bit bitvector from a 64-bit primal value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector64 ToBitVector64(this ulong src)
            => src;

        /// <summary>
        /// Creates a 24-bit bitvector from an 8-bit scalar
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector24 ToBitVector24(this byte src)
            => src;

        /// <summary>
        /// Creates a 24-bit bitvector from a 16-bit scalar
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector24 ToBitVector24(this ushort src)
            => src;

        /// <summary>
        /// Creates a 24-bit bitvector from a 32-bit scalar
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector24 ToBitVector24(this uint src)
            => src;

        /// <summary>
        /// Creates a 24-bit bitvector from a 64-bit scalar
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector24 ToBitVector24(this ulong src)
            => (uint)src;

        /// <summary>
        /// Constructs a generic bitvector from bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static ScalarBits<T> ToScalarBits<T>(this BitString src)
            where T : unmanaged
                => ScalarBits.load<T>(src);

        [MethodImpl(Inline)]
        public static ScalarBits<N,T> ToScalarBits<N,T>(this BitString src, N n = default, T t =default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => ScalarBits.natural<N,T>(src);

        /// <summary>
        /// Constructs a 4-bit bitvector from bitstring
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static BitVector4 ToBitVector(this BitString src, N4 n)
            => BitVectors.create(n,src);

        /// <summary>
        /// Creates an 8-bit bitvector from bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitVector8 ToBitVector(this BitString src, N8 n)
            => BitVectors.create(n,src);

        /// <summary>
        /// Creates a 16-bit bitvector from bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitVector16 ToBitVector(this BitString src, N16 n)
            => src.TakeUInt16();

        /// <summary>
        /// Creates a 24-bit bitvector from bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitVector24 ToBitVector(this BitString src, N24 n)
        {
            var lo = src.Slice(0,16).TakeUInt16();
            var hi = src.Slice(16,8).TakeUInt8();
            return new BitVector24(lo,hi);
        }

        /// <summary>
        /// Creates a 32-bit bitvector from bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitVector32 ToBitVector(this BitString src, N32 n)
            => BitVectors.create(n, src);

        /// <summary>
        /// Creates a 64-bit bitvector from bitstring
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline)]
        public static BitVector64 ToBitVector(this BitString src, N64 n)
            => BitVectors.create(n,src);


    }
}