//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIV
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static LogicSig;

    using ULK = UnaryBitLogicKind;
    using BLK = BinaryBitLogicKind;

    [ApiHost]
    public readonly struct SquareBitLogix
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static ref readonly BitMatrix<T> eval<T>(ULK kind, in BitMatrix<T> A, in BitMatrix<T> Z)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return ref not(A, Z);
                case ULK.Identity: return ref identity(A, Z);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(Closure)]
        public static ref readonly BitMatrix<T> eval<T>(BLK kind, in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> dst)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return ref @true<T>(a, b, dst);
                case BLK.False: return ref @false<T>(a, b, dst);
                case BLK.And: return ref and(a, b, dst);
                case BLK.Nand: return ref nand(a, b, dst);
                case BLK.Or: return ref or(a, b, dst);
                case BLK.Nor: return ref nor(a, b, dst);
                case BLK.Xor: return ref xor(a, b, dst);
                case BLK.Xnor: return ref xnor(a, b, dst);
                case BLK.Left: return ref left(a,b, dst);
                case BLK.LNot: return ref lnot(a, b, dst);
                case BLK.Right: return ref right(a,b, dst);
                case BLK.RNot: return ref rnot(a, b, dst);
                case BLK.Impl: return ref impl(a, b, dst);
                case BLK.NonImpl: return ref nonimpl(a, b, dst);
                case BLK.CImpl: return ref cimpl(a, b, dst);
                case BLK.CNonImpl: return ref cnonimpl(a, b, dst);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        public static BitMatrixFunctions.BinaryOp<T> lookup<T>(BLK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return @true;
                case BLK.False: return @false;
                case BLK.And: return and;
                case BLK.Nand: return nand;
                case BLK.Or: return or;
                case BLK.Nor: return nor;
                case BLK.Xor: return xor;
                case BLK.Xnor: return xnor;
                case BLK.Left: return left;
                case BLK.LNot: return lnot;
                case BLK.Right: return right;
                case BLK.RNot: return rnot;
                case BLK.Impl: return impl;
                case BLK.NonImpl: return nonimpl;
                case BLK.CImpl: return cimpl;
                case BLK.CNonImpl: return cnonimpl;
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [MethodImpl(Inline), Not, Closures(Closure)]
        public static ref readonly BitMatrix<T> not<T>(in BitMatrix<T> a, in BitMatrix<T> dst)
            where T : unmanaged
                => ref BitMatrix.not(a, dst);

        [MethodImpl(Inline), IdentityFunction, Closures(Closure)]
        public static ref readonly BitMatrix<T> identity<T>(in BitMatrix<T> a)
            where T : unmanaged
                => ref BitMatrix.identity(a);

        [MethodImpl(Inline), IdentityFunction, Closures(Closure)]
        public static ref readonly BitMatrix<T> identity<T>(in BitMatrix<T> A, in BitMatrix<T> dst)
            where T : unmanaged
                => ref BitMatrix.identity(A, dst);

        [MethodImpl(Inline), False, Closures(Closure)]
        public static ref readonly BitMatrix<T> @false<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> dst)
            where T:unmanaged
                => ref BitMatrix.@false(a, b, dst);

        [MethodImpl(Inline), True, Closures(Closure)]
        public static ref readonly BitMatrix<T> @true<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> dst)
            where T:unmanaged
                => ref BitMatrix.@true(a, b, dst);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static ref readonly BitMatrix<T> and<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => ref BitMatrix.and(A, B, dst);

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static ref readonly BitMatrix<T> nand<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => ref BitMatrixA.nand(A, B, dst);

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static ref readonly BitMatrix<T> or<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => ref BitMatrix.or(A, B, dst);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static ref readonly BitMatrix<T> nor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => ref BitMatrixA.nor(A,B, dst);

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static ref readonly BitMatrix<T> xor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.xor(A, B, Z);

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static ref readonly BitMatrix<T> xnor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.xnor(A,B, Z);

        [MethodImpl(Inline), Left, Closures(Closure)]
        public static ref readonly BitMatrix<T> left<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => ref BitMatrix.left(A,B);

        [MethodImpl(Inline), Left, Closures(Closure)]
        public static ref readonly BitMatrix<T> left<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.left(A, B, Z);

        [MethodImpl(Inline), Right, Closures(Closure)]
        public static ref readonly BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => ref BitMatrix.right(A, B);

        [MethodImpl(Inline), Right, Closures(Closure)]
        public static ref readonly BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.right(A, B, Z);

        [MethodImpl(Inline), LNot, Closures(Closure)]
        public static ref readonly BitMatrix<T> lnot<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.lnot(A, B, Z);

        [MethodImpl(Inline), RNot, Closures(Closure)]
        public static ref readonly BitMatrix<T> rnot<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.rnot(A, B, Z);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static BitMatrix<T> impl<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => BitMatrix.impl(A,B);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static ref readonly BitMatrix<T> impl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.impl(A, B, Z);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static ref readonly BitMatrix<T> nonimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.nonimpl(A, B, Z);

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static ref readonly BitMatrix<T> cimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.cimpl(A, B, Z);

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static ref readonly BitMatrix<T> cnonimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.cnonimpl(A,B, Z);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static ref readonly BitMatrix<T> xornot<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => ref BitMatrix.xornot(A, B, Z);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static ref readonly BitMatrix<T> select<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> c, in BitMatrix<T> dst)
            where T : unmanaged
                => ref BitMatrix.select(a, b, c, dst);
    }
}