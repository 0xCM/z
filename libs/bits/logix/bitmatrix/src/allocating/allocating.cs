//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static LogicSig;

    using ULK = UnaryBitLogicKind;
    using BLK = BinaryBitLogicKind;

    public partial class BitMatrixA
    {
        [Op, Closures(UnsignedInts)]
        public static BitMatrix<T> eval_alloc<T>(BLK kind, BitMatrix<T> A, BitMatrix<T> B)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return @true<T>(A,B);
                case BLK.False: return @false<T>(A,B);
                case BLK.And: return and(A,B);
                case BLK.Nand: return nand(A,B);
                case BLK.Or: return or(A,B);
                case BLK.Nor: return nor(A,B);
                case BLK.Xor: return xor(A,B);
                case BLK.Xnor: return xnor(A,B);
                case BLK.Left: return BitMatrix.left(A,B);
                case BLK.Right: return BitMatrix.right(A,B);
                case BLK.LNot: return lnot(A,B);
                case BLK.RNot: return rnot(A,B);
                case BLK.Impl: return BitMatrix.impl(A,B);
                case BLK.NonImpl: return nonimpl(A,B);
                case BLK.CImpl: return cimpl(A,B);
                case BLK.CNonImpl: return cnonimpl(A,B);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(UnsignedInts)]
        public static BitMatrix<T> eval_alloc<T>(ULK kind, in BitMatrix<T> A)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return not(A);
                case ULK.Identity: return BitMatrix.identity(A);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }
    }
}