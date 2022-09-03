//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitMatrix
    {
        /// <summary>
        /// Permutes the rows of a target matrix via premultiplication by a permutation-identified permutation matrix
        /// </summary>
        /// <param name="spec">The permutation definition</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix8 premul(in NatPerm<N8> spec, in BitMatrix8 A)
        {
            var P = spec.ToBitMatrix();
            return P * A;
        }

        /// <summary>
        /// Permutes the rows of a target matrix via premultiplication by a permutation-identified permutation matrix
        /// </summary>
        /// <param name="spec">The permutation definition</param>
        /// <param name="A">The target matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix16 premul(in NatPerm<N16> spec, BitMatrix16 A)
        {
            var P = spec.ToBitMatrix();
            return P * A;;
        }

        /// <summary>
        /// Permutes the rows of a target matrix via premultiplication by a permutation-identified permutation matrix
        /// </summary>
        /// <param name="spec">The permutation definition</param>
        /// <param name="A">The target matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix32 premul(in NatPerm<N32> spec, in BitMatrix32 A)
        {
            var P = spec.ToBitMatrix();
            return P * A;
        }

        /// <summary>
        /// Permutes the rows of a target matrix via premultiplication by a permutation-identified permutation matrix
        /// </summary>
        /// <param name="spec">The permutation definition</param>
        /// <param name="A">The target matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix64 premul(in NatPerm<N64> spec, in BitMatrix64 A)
        {
            var P = spec.ToBitMatrix();
            return P * A;;
        }
    }
}