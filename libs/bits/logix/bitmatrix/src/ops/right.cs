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
        [MethodImpl(Inline), RProject, Closures(Closure)]
        public static ref readonly BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => ref B;

        [MethodImpl(Inline), RProject, Closures(Closure)]
        public static ref readonly BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
        {
            Z.Update(B);
            return ref Z;
        }
    }
}