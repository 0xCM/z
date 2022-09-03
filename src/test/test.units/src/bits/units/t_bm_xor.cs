//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public class t_bm_xor : t_bits<t_bm_xor>
    {
        void bm_xor_g8x8x8()
            => bm_xor_check<byte>();

        public void bm_xor_g16x16x16()
            => bm_xor_check<ushort>();

        public void bm_xor_g32x32x32()
            => bm_xor_check<uint>();

        public void bm_xor_g64x64x64()
            => bm_xor_check<ulong>();

        public void bm_xor_n64x64x8()
            => bm_xor_check<N64,byte>();

        public void bm_xor_n50x50x16()
            => bm_xor_check<N50,ushort>();

        public void bm_xor_n64x64x64()
            => bm_xor_check<N64,ulong>();

        public void bm_xor_n64x64x16()
            => bm_xor_check<N64,ushort>();

        public void bm_xor_n256x256x32()
            => bm_xor_check<N256,uint>();

        public void bm_xor_n331x331x8()
            => bm_xor_check(TypeNats.seq(n3,n3,n1), z8);

        Span<T> xor<T>(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<T> dst)
            where T : unmanaged
        {
            for(var i=0; i<Claim.length(lhs,rhs); i++)
                dst[i] = gmath.xor(lhs[i], rhs[i]);
           return dst;
        }

        Span<T> xor<T>(Span<T> a, ReadOnlySpan<T> b)
            where T : unmanaged
                => xor(a,b, a);

        protected void bm_xor_check<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var A = Random.BitMatrix(n,t);
                var B = Random.BitMatrix(n,t);
                var C1 = BitMatrixA.xor(A, B).Content;
                var C2 = xor(A.Content, B.Content);
                ClaimNumeric.eq((ulong)A.Order, nat64u<N>());
                ClaimNumeric.eq((ulong)B.Order, nat64u<N>());
                ClaimNumeric.eq(C1,C2);
            }
        }

       protected void bm_xor_check<T>(T t = default)
            where T : unmanaged
        {
            var C = BitMatrix.alloc<T>();
            for(var i=0; i<RepCount; i++)
            {
                var A = Random.BitMatrix<T>();
                var B = Random.BitMatrix<T>();
                BitMatrix.xor(A, B, C);

                for(var j =0; j< C.Order; j++)
                {
                    var a = A[i];
                    var b = B[i];
                    var z = C[i];

                    var x = BitVectors.xor(a,b);
                    Claim.eq((T)x, (T)z);
                }
            }
        }
    }
}