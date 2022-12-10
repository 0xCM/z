//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct BitMatrixFunctions
    {
        public delegate BitMatrix<T> UnaryRefOp<T>(in BitMatrix<T> A, ref BitMatrix<T> Z)
            where T : unmanaged;

        public delegate BitMatrix<T> UnaryOp<T>(in BitMatrix<T> a, in BitMatrix<T> dst)
            where T : unmanaged;

        public delegate BitMatrix<T> BinaryOp<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> dst)
            where T : unmanaged;

        public delegate BitMatrix<T> TernaryOp<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> c, in BitMatrix<T> dst)
            where T : unmanaged;
    }
}
