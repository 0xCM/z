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
        /// Interchanges rows i and j where  0 <= i,j < 16
        /// </summary>
        /// <param name="i">A row index</param>
        /// <param name="j">A row index</param>
        [MethodImpl(Inline), Op]
        public static void rowswap(in BitMatrix16 A, uint i, uint j)
            => A.Content.Swap(i,j);

        /// <summary>
        /// Interchanges rows i and j where  0 <= i,j < 32
        /// </summary>
        /// <param name="i">A row index</param>
        /// <param name="j">A row index</param>
        [MethodImpl(Inline), Op]
        public static void rowswap(in BitMatrix32 A, uint i, uint j)
            => A.Content.Swap(i,j);

        /// <summary>
        /// Interchanges rows i and j where  0 <= i,j < 64
        /// </summary>
        /// <param name="i">A row index</param>
        /// <param name="j">A row index</param>
        [MethodImpl(Inline), Op]
        public static void rowswap(in BitMatrix64 A, uint i, uint j)
            => A.Content.Swap(i,j);
    }
}