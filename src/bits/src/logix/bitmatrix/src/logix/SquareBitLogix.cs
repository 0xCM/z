//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIV
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LogicSig;

    using ULK = UnaryBitLogicKind;
    using BLK = BinaryBitLogicKind;

    [ApiHost]
    public readonly struct SquareBitLogix
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static BitMatrix<T> eval<T>(ULK kind, in BitMatrix<T> A, in BitMatrix<T> Z)
            where T : unmanaged
        {
            switch(kind)
            {
                case ULK.Not: return not(A, Z);
                case ULK.Identity: return identity(A, Z);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(Closure)]
        public static BitMatrix<T> eval<T>(BLK kind, in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> dst)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return @true<T>(a, b, dst);
                case BLK.False: return @false<T>(a, b, dst);
                case BLK.And: return and(a, b, dst);
                case BLK.Nand: return nand(a, b, dst);
                case BLK.Or: return or(a, b, dst);
                case BLK.Nor: return nor(a, b, dst);
                case BLK.Xor: return xor(a, b, dst);
                case BLK.Xnor: return xnor(a, b, dst);
                case BLK.Left: return left(a,b, dst);
                case BLK.LNot: return lnot(a, b, dst);
                case BLK.Right: return right(a,b, dst);
                case BLK.RNot: return rnot(a, b, dst);
                case BLK.Impl: return impl(a, b, dst);
                case BLK.NonImpl: return nonimpl(a, b, dst);
                case BLK.CImpl: return cimpl(a, b, dst);
                case BLK.CNonImpl: return cnonimpl(a, b, dst);
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
        public static BitMatrix<T> not<T>(in BitMatrix<T> a, in BitMatrix<T> dst)
            where T : unmanaged
                => BitMatrix.not(a, dst);

        [MethodImpl(Inline), IdentityFunction, Closures(Closure)]
        public static BitMatrix<T> identity<T>(in BitMatrix<T> a)
            where T : unmanaged
                => BitMatrix.identity(a);

        [MethodImpl(Inline), IdentityFunction, Closures(Closure)]
        public static BitMatrix<T> identity<T>(in BitMatrix<T> A, in BitMatrix<T> dst)
            where T : unmanaged
                => BitMatrix.identity(A, dst);

        [MethodImpl(Inline), False, Closures(Closure)]
        public static BitMatrix<T> @false<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> dst)
            where T:unmanaged
                => BitMatrix.@false(a, b, dst);

        [MethodImpl(Inline), True, Closures(Closure)]
        public static BitMatrix<T> @true<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> dst)
            where T:unmanaged
                => BitMatrix.@true(a, b, dst);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static BitMatrix<T> and<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => BitMatrix.and(A, B, dst);

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static BitMatrix<T> nand<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => BitMatrixA.nand(A, B, dst);

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static BitMatrix<T> or<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => BitMatrix.or(A, B, dst);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static BitMatrix<T> nor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
                => BitMatrixA.nor(A,B, dst);

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static BitMatrix<T> xor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.xor(A, B, Z);

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static BitMatrix<T> xnor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.xnor(A,B, Z);

        [MethodImpl(Inline), Left, Closures(Closure)]
        public static BitMatrix<T> left<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => BitMatrix.left(A,B);

        [MethodImpl(Inline), Left, Closures(Closure)]
        public static BitMatrix<T> left<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.left(A, B, Z);

        [MethodImpl(Inline), Right, Closures(Closure)]
        public static BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => BitMatrix.right(A, B);

        [MethodImpl(Inline), Right, Closures(Closure)]
        public static BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.right(A, B, Z);

        [MethodImpl(Inline), LNot, Closures(Closure)]
        public static BitMatrix<T> lnot<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.lnot(A, B, Z);

        [MethodImpl(Inline), RNot, Closures(Closure)]
        public static BitMatrix<T> rnot<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.rnot(A, B, Z);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static BitMatrix<T> impl<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => BitMatrix.impl(A,B);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static BitMatrix<T> impl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.impl(A, B, Z);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static BitMatrix<T> nonimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.nonimpl(A, B, Z);

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static BitMatrix<T> cimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.cimpl(A, B, Z);

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static BitMatrix<T> cnonimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.cnonimpl(A,B, Z);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static BitMatrix<T> xornot<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
                => BitMatrix.xornot(A, B, Z);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static BitMatrix<T> select<T>(in BitMatrix<T> a, in BitMatrix<T> b, in BitMatrix<T> c, in BitMatrix<T> dst)
            where T : unmanaged
                => BitMatrix.select(a, b, c, dst);
    }
}