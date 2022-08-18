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
        [MethodImpl(Inline), False, Closures(Closure)]
        public static BitMatrix<T> @false<T>()
            where T:unmanaged
                => BitMatrixA.zero<T>();

        [MethodImpl(Inline), False, Closures(Closure)]
        public static BitMatrix<T> @false<T>(in BitMatrix<T> A)
            where T:unmanaged
                => BitMatrixA.@false(A);

        [MethodImpl(Inline), False, Closures(Closure)]
        public static BitMatrix<T> @false<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T:unmanaged
                => BitMatrixA.@false(A,B);

        [MethodImpl(Inline), False, Closures(Closure)]
        public static ref readonly BitMatrix<T> @false<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T:unmanaged
        {
            Z.Content.Fill(core.zero<T>());
            return ref Z;
        }
    }
}