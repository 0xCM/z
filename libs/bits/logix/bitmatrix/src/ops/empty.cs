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
        /// Determines whether the matrix is 0-filled
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Bit32 empty<T>(in BitMatrix<T> A)
            where T : unmanaged
                => BitMatrix.testz(A);

        /// <summary>
        /// Determines whether the matrix is 0-filled
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Bit32 empty(in BitMatrix8 A)
            => BitMatrix.testz(A);

        /// <summary>
        /// Determines whether the matrix is 0-filled
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Bit32 empty(in BitMatrix16 A)
            => BitMatrix.testz(A);

        /// <summary>
        /// Determines whether the matrix is 0-filled
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Bit32 empty(in BitMatrix32 A)
            => BitMatrix.testz(A);

        /// <summary>
        /// Determines whether the matrix is 0-filled
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Bit32 empty(in BitMatrix64 A)
            => BitMatrix.testz(A);
    }
}