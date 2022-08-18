//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitMaskLiterals;

    partial struct cpu
    {
        static Vector256<ulong> K1
        {
            [MethodImpl(Inline), Op]
            get => vbroadcast(n256, Even64);
        }

        static Vector256<ulong> K2
        {
            [MethodImpl(Inline), Op]
            get => vbroadcast(n256, Even64x2);
        }

        static Vector256<ulong> K4
        {
            [MethodImpl(Inline), Op]
            get => vbroadcast(n256, Lsb64x8x4);
        }

        static Vector128<ulong> v128K1
        {
            [MethodImpl(Inline), Op]
            get => vbroadcast(n128, Even64);
        }

        static Vector128<ulong> v128K2
        {
            [MethodImpl(Inline), Op]
            get => vbroadcast(n128, Even64x2);
        }

        static Vector128<ulong> v128K4
        {
            [MethodImpl(Inline), Op]
            get => vbroadcast(n128, Lsb64x8x4);
        }

        /// <summary>
        /// Computes the population count of the content of 3 128-bit vectors
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <param name="z">The third vector</param>
        /// <remarks>
        /// This is a vectorization of the scalar algorithm found at https://www.chessprogramming.org/Population_Count
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static uint vpop(Vector128<ulong> x, Vector128<ulong> y, Vector128<ulong> z)
        {
            const ulong kf = Lsb64x8x1;

            var k1 = v128K1;
            var k2 = v128K2;
            var k4 = v128K4;
            var maj =  vor(vand(vxor(x,y),z), vand(x,y));
            var odd =  vxor(vxor(x,y),z);

            maj = vsub(maj, vand(vsrl(maj, 1), k1));
            odd = vsub(odd, vand(vsrl(odd, 1), k1));

            maj = vadd(vand(maj,k2), vand(vsrl(maj, 2), k2));
            odd = vadd(vand(odd,k2), vand(vsrl(odd, 2), k2));

            maj = vand(vadd(maj, vsrl(maj,4)), k4);
            odd = vand(vadd(odd, vsrl(odd,4)), k4);

            odd = vadd(vadd(maj, maj), odd);

            var dst = ByteBlocks.alloc(n16);
            vstore(odd, ref dst.A);
            var total = 0ul;

            total += (dst.A * kf) >> 56;
            total += (dst.B * kf) >> 56;

            return (uint)total;
        }

        /// <summary>
        /// Computes the population count of the content of 3 256-bit vectors
        /// </summary>
        /// <param name="a">The first vector</param>
        /// <param name="b">The second vector</param>
        /// <param name="c">The third vector</param>
        /// <remarks>
        /// This is a vectorization of the scalar algorithm found at https://www.chessprogramming.org/Population_Count
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static uint vpop(Vector256<ulong> a, Vector256<ulong> b, Vector256<ulong> c)
        {
            const ulong kf = Lsb64x8x1;

            var k1 = K1;
            var k2 = K2;
            var k4 = K4;
            var maj =  vor(vand(vxor(a,b),c), vand(a,b));
            var odd =  vxor(vxor(a,b),c);

            maj = vsub(maj, vand(vsrl(maj, 1), k1));
            odd = vsub(odd, vand(vsrl(odd, 1), k1));

            maj = vadd(vand(maj,k2), vand(vsrl(maj, 2), k2));
            odd = vadd(vand(odd,k2), vand(vsrl(odd, 2), k2));

            maj = vand(vadd(maj, vsrl(maj,4)), k4);
            odd = vand(vadd(odd, vsrl(odd,4)), k4);

            odd = vadd(vadd(maj, maj), odd);

            var dst = ByteBlocks.alloc(n32);
            ref var X = ref ByteBlocks.first<ulong>(ref dst);
            vstore(odd, ref X);

            var total = 0ul;
            total += (seek(X, 0) * kf) >> 56;
            total += (seek(X, 1) * kf) >> 56;
            total += (seek(X, 2) * kf) >> 56;
            total += (seek(X, 3) * kf) >> 56;

            return (uint)total;
        }
    }
}