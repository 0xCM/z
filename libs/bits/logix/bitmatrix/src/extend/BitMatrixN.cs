//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public static class BitMatrixNx
    {
        public static BitMatrix<N,T> Replicate<N,T>(this BitMatrix<N,T> A)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<N,T>(A.Content.Replicate());

        public static BitBlock<N,T> Diagonal<N,T>(this BitMatrix<N,T> A)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var order = nat32i<N>();
            var dst = BitBlocks.alloc<N,T>();
            for(var i=0; i < order; i++)
                dst[i] = A[i,i];
            return dst;
        }

        [MethodImpl(Inline)]
        public static BitMatrix<N8,N1,byte> ToNatBits(this byte src, N8 m, N1 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N1,N8,byte> ToNatBits(this byte src, N1 m, N8 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N4,N2,byte> ToNatBits(this byte src, N4 m, N2 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N2,N4,byte> ToNatBits(this byte src, N2 m, N4 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N4,ushort> ToNatBits(this ushort src, N4 n)
            => BitMatrix.natural(src,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N2,N8,ushort> ToNatBits(this ushort src, N2 m, N8 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N8,N2,ushort> ToNatBits(this ushort src, N8 m, N2 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N1,N16,ushort> ToNatBits(this ushort src, N1 m, N16 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N16,N1,ushort> ToNatBits(this ushort src, N16 m, N1 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N64,N1,ulong> ToNatBits(this ulong src, N64 m, N1 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N1,N64,ulong> ToNatBits(this ulong src, N1 m, N64 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N2,N32,ulong> ToNatBits(this ulong src, N2 m, N32 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N32,N2,ulong> ToNatBits(this ulong src, N32 m, N2 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N16,N4,ulong> ToNatBits(this ulong src, N16 m, N4 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N4,N16,ulong> ToNatBits(this ulong src, N4 m, N16 n)
            => BitMatrix.natural(src,m,n);

        [MethodImpl(Inline)]
        public static BitMatrix<N8,ulong> ToNatBits(this ulong src, N8 n)
            => BitMatrix.natural(src,n);
    }
}