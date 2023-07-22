//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Bmi2;
    using static System.Runtime.Intrinsics.X86.Bmi2.X64;

    partial class vcpu 
    {
        /// <summary>
        /// unsigned int _mulx_u32 (unsigned int a, unsigned int b, unsigned int* hi) MULX r32a, r32b, reg/m32
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), MulHi]
        public static unsafe uint mulhi(uint x, uint y)
        {
            var lo = 0u;
            return MultiplyNoFlags(x, y, &lo);
        }

        /// <summary>
        /// unsigned __int64 _mulx_u64 (unsigned __int64 a, unsigned __int64 b, unsigned __int64* hi) MULX r64a, r64b, reg/m64
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), MulHi]
        public static unsafe ulong mulhi(ulong x, ulong y)
        {
            var lo = 0ul;
            return MultiplyNoFlags(x, y, &lo);
        }

        /// <summary>
        /// unsigned int _mulx_u32 (unsigned int a, unsigned int b, unsigned int* hi) MULX
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(Inline), MulLo]
        public static unsafe uint mullo(uint a, uint b)
        {
            var lo = 0u;
            MultiplyNoFlags(a, b, &lo);
            return lo;
        }

        /// <summary>
        /// unsigned __int64 _mulx_u64 (unsigned __int64 a, unsigned __int64 b, unsigned  __int64* hi) MULX r64a, r64b, reg/m64
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [MethodImpl(Inline), MulLo]
        public static unsafe ulong mullo(ulong a, ulong b)
        {
            var lo = 0ul;
            MultiplyNoFlags(a, b, &lo);
            return lo;
        }

        [MethodImpl(Inline), MulX]
        public static unsafe Pair<uint> mulx(uint a, uint b)
        {
            var lo = 0u;
            var hi = MultiplyNoFlags(a, b, &lo);
            return (lo,hi);
        }

        [MethodImpl(Inline), MulX]
        public static unsafe Pair<ulong> mulx(ulong a, ulong b)
        {
            var lo = 0ul;
            var hi = MultiplyNoFlags(a, b, &lo);
            return (lo,hi);
        }

        // /// <summary>
        // /// Computes the full 16-bit product of corresponding left and right source components
        // /// </summary>
        // /// <param name="x">The left vector</param>
        // /// <param name="y">The right vector</param>
        // /// <param name="lo">Receiver for the product of the lower components</param>
        // /// <param name="hi">Receiver for the product of the upper components</param>
        // [MethodImpl(Inline), Mul]
        // public static Vector256<short> vmul(Vector128<sbyte> x, Vector128<sbyte> y)
        //     => vmullo(vpack.vinflate256x16i(x), vpack.vinflate256x16i(y));

        // /// <summary>
        // /// Computes the full 16-bit product of corresponding left and right source components
        // /// </summary>
        // /// <param name="x">The left vector</param>
        // /// <param name="y">The right vector</param>
        // /// <param name="lo">Receiver for the product of the lower components</param>
        // /// <param name="hi">Receiver for the product of the upper components</param>
        // [MethodImpl(Inline), Mul]
        // public static Vector256<ushort> vmul(Vector128<byte> x, Vector128<byte> y)
        // {
        //     var z0 = vpack.vinflate256x16u(x);
        //     var z1 = vpack.vinflate256x16u(y);
        //     return vmullo(z0,z1);
        // }

        // /// <summary>
        // /// Computes the full 32-bit product of corresponding left and right source components
        // /// </summary>
        // /// <param name="x">The left vector</param>
        // /// <param name="y">The right vector</param>
        // /// <param name="lo">Receiver for the product of the lower components</param>
        // /// <param name="hi">Receiver for the product of the upper components</param>
        // [MethodImpl(Inline), Mul]
        // public static Vector256<int> vmul(Vector128<short> x, Vector128<short> y)
        // {
        //     var z0 = vpack.vinflate256x32i(x);
        //     var z1 = vpack.vinflate256x32i(y);
        //     return vmullo(z0,z1);
        // }

        // /// <summary>
        // /// Computes the full 32-bit product of corresponding left and right source components
        // /// </summary>
        // /// <param name="x">The left vector</param>
        // /// <param name="y">The right vector</param>
        // /// <param name="lo">Receiver for the product of the lower components</param>
        // /// <param name="hi">Receiver for the product of the upper components</param>
        // [MethodImpl(Inline), Mul]
        // public static Vector256<uint> vmul(Vector128<ushort> x, Vector128<ushort> y)
        // {
        //     var z0 = vpack.vinflate256x32u(x);
        //     var z1 = vpack.vinflate256x32u(y);
        //     return vmullo(z0,z1);
        // }

        /// <summary>
        ///  __m128i _mm_mul_epi32 (__m128i a, __m128i b) PMULDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Mul]
        public static Vector256<long> vmul(Vector128<int> x, Vector128<int> y)
        {
            var lo = Multiply(x, y);
            var hi = Multiply(vswaphl(x), vswaphl(y));
            return vconcat(lo,hi);
        }

        /// <summary>
        /// __m128i _mm_mul_epu32 (__m128i a, __m128i b) PMULUDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mul]
        public static Vector256<ulong> vmul(Vector128<uint> x, Vector128<uint> y)
        {
            var lo = Multiply(x, y);
            var hi = Multiply(vswaphl(x), vswaphl(y));
            return vconcat(lo,hi);
        }

        /// <summary>
        /// Multiplies two two 256-bit/u64 vectors to yield a 256-bit/u64 vector; only provides reasonable
        /// results if there's no 64-bit overflow
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Mul]
        public static Vector256<ulong> vmul(Vector256<ulong> x, Vector256<ulong> y)
        {
            var loMask = vbroadcast(w256, 0x00000000fffffffful);
            var xh = v32u(vsrl(x, 32));
            var yl = v32u(vand(y, loMask));
            return vadd(
                Multiply(v32u(vand(x, loMask)), yl),
                vadd(vsll(Multiply(xh, yl), 32),
                    vsll(Multiply(xh, v32u(vsrl(y, 32))), 32)));
        }
    }
}