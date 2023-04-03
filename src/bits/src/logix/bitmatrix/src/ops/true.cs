//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitMatrix
    {
        [MethodImpl(Inline), True, Closures(Closure)]
        public static ref readonly BitMatrix<T> @true<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T:unmanaged
        {
            Z.Content.Fill(Limits.maxval<T>());
            return ref Z;
        }
    }
}