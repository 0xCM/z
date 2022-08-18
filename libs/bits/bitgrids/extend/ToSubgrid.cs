//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Creates a subgrid of dimensions 2x12 from a 24-bit bitvector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static SubGrid32<N2,N12,uint> ToSubGrid(this BitVector24 x, N2 m, N12 n)
            => (uint)x;

        /// <summary>
        /// Creates a subgrid of dimensions 12x2 from a 24-bit bitvector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static SubGrid32<N12,N2,uint> ToSubGrid(this BitVector24 x, N12 m, N2 n)
            => (uint)x;

        /// <summary>
        /// Creates a subgrid of dimensions 3x8 from a 24-bit bitvector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static SubGrid32<N3,N8,uint> ToSubGrid(this BitVector24 x, N3 m, N8 n)
            => (uint)x;

        /// <summary>
        /// Creates a subgrid of dimensions 8x3 from a 24-bit bitvector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static SubGrid32<N8,N3,uint> ToSubGrid(this BitVector24 x, N8 m, N3 n)
            => (uint)x;

        /// <summary>
        /// Creates a subgrid of dimensions 4x6 from a 24-bit bitvector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static SubGrid32<N4,N6,uint> ToSubGrid(this BitVector24 x, N4 m, N6 n)
            => (uint)x;

        /// <summary>
        /// Creates a subgrid of dimensions 6x4 from a 24-bit bitvector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static SubGrid32<N6,N4,uint> ToSubGrid(this BitVector24 x, N6 m, N4 n)
            => (uint)x;
    }
}