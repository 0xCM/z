//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMatrix
    {
        /// <summary>
        /// Permutes the rows of a matrix in-place according to a permutation
        /// </summary>
        /// <param name="spec">The permutation definition</param>
        /// <param name="A">The matrix to be permuted</param>
        [Op]
        public static ref readonly BitMatrix<T> permute<T>(Perm spec, in BitMatrix<T> A)
            where T : unmanaged
        {
            for(var row = 0; row < spec.Length; row++)
                if(spec[row] != row)
                    A.RowSwap(row, spec[row]);
            return ref A;
        }

        /// <summary>
        /// Permutes the rows of a matrix in-place according to a specified permutation
        /// </summary>
        /// <param name="perm">The permutation to apply</param>
        /// <param name="A">The matrix to be permuted</param>
        [Op]
        public static ref readonly BitMatrix16 permute(in NatPerm<N16> perm, in BitMatrix16 A)
        {
            for(var row = 0; row < perm.Length; row++)
                if(perm[row] != row)
                    A.RowSwap(row, perm[row]);
            return ref A;
        }

        /// <summary>
        /// Permutes the rows of a matrix in-place according to a permutation
        /// </summary>
        /// <param name="perm">The permutation definition</param>
        /// <param name="A">The source/target matrix</param>
        [Op]
        public static ref readonly BitMatrix32 permute(in NatPerm<N32> perm, in BitMatrix32 A)
        {
            for(var row = 0u; row < perm.Length; row++)
                if(perm[(int)row] != row)
                    rowswap(A, row, (uint)perm[(int)row]);
            return ref A;
        }

        /// <summary>
        /// Permutes the rows of a matrix in-place according to a permutation
        /// </summary>
        /// <param name="perm">The permutation definition</param>
        /// <param name="A">The source/target matrix</param>
        [Op]
        public static ref readonly BitMatrix64 permute(in NatPerm<N64> perm, in BitMatrix64 A)
        {
            for(var row = 0; row < perm.Length; row++)
                if(perm[row] != row)
                    A.RowSwap(row, perm[row]);
            return ref A;
        }

        /// <summary>
        /// Creates a canonical permutation matrix by swapping matrix rows of the identity matrix as specified by a permutation
        /// </summary>
        /// <param name="spec">The permutation spec</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix64 permute(NatPerm<N64> spec)
            => permute(spec, identity(n64));
    }
}