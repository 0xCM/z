//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class BitMatrix8x
    {
        /// <summary>
        /// Converts the matrix to a bitvector
        /// </summary>
        [MethodImpl(Inline)]
        public static BitVector64 ToBitVector(this BitMatrix8 A)
            => BitVectors.create(n64,(ulong)A);

        /// <summary>
        /// Creates the matrix determined by a permutation
        /// </summary>
        /// <param name="perm">The source permutation</param>
        [MethodImpl(Inline)]
        public static BitMatrix8 ToBitMatrix(this NatPerm<N8> perm)
        {
            var dst = BitMatrix.alloc(n8);
            for(var row = 0; row<perm.Length; row++)
                dst[row, perm[row]] = bit.On;
            return dst;
        }

        [MethodImpl(Inline)]
        public static string Format(this BitMatrix8 src)
            => src.Bytes.FormatGridBits(src.Order);

        /// <summary>
        /// Determines whether this matrix is equivalent to the canonical 0 matrix
        /// </summary>
        [MethodImpl(Inline)]
        public static bit IsZero(this BitMatrix8 A)
            => BitMatrix.empty(A);

        /// <summary>
        /// Constructs an 8-node graph via the adjacency matrix interpretation
        /// </summary>
        [MethodImpl(Inline)]
        public static ValueGraph<byte> ToGraph(this BitMatrix8 A)
            => BitMatrix.graph(A);

        /// <summary>
        /// Packs the matrix into an unsigned 64-bit integer
        /// </summary>
        [MethodImpl(Inline)]
        public static ulong Pack(this BitMatrix8 A)
            => core.u64(A.Bytes);

        /// <summary>
        /// Transposes a copy of the source matrix
        /// </summary>
        [MethodImpl(Inline)]
        public static BitMatrix8 Transpose(this BitMatrix8 A)
            => BitMatrix.transpose_v2(A);

        [MethodImpl(Inline)]
        public static BitMatrix8 AndNot(this BitMatrix8 A, in BitMatrix8 B)
            => BitMatrix.cnonimpl(A, B);

        /// <summary>
        /// Retrives the bitvector determined by the matrix diagonal
        /// </summary>
        [MethodImpl(Inline)]
        public static BitVector8 Diagonal(this BitMatrix8 A)
            => BitMatrix.diagonal(A);

        [MethodImpl(Inline)]
        public static BitMatrix8 ToPrimalBits(this ulong src, N8 n = default)
            => BitMatrix.primal(n, src);

        /// <summary>
        /// Creates a new matrix by cloning the existing matrix or allocating a matrix with the same structure
        /// </summary>
        /// <param name="structureOnly">Specifies whether the replication reproduces only structure and is thus equivalent to an allocation</param>
        [MethodImpl(Inline)]
        public static BitMatrix8 Replicate(this BitMatrix8 A)
            => BitMatrix.primal(n8, A.Bytes.Replicate());
    }
}