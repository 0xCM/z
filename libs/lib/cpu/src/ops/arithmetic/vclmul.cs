//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Pclmulqdq;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_clmulepi64_si128 (__m128i a, __m128i b, const int imm8) PCLMULQDQ xmm, xmm/m128, imm8
        /// Computes the caryless 128-bit product of two 64-bit operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        [MethodImpl(Inline), ClMul]
        public static Vector128<ulong> vclmul(Vector128<ulong> a, Vector128<ulong> b, [Imm] byte selector)
            => CarrylessMultiply(a,b, selector);

        /// __m128i _mm_clmulepi64_si128 (__m128i a, __m128i b, const int imm8) PCLMULQDQ xmm, xmm/m128, imm8
        /// Computes the caryless 128-bit product of two 64-bit operands
        /// </summary>
        /// <param name="lhs">The left operand</param>
        /// <param name="rhs">The right operand</param>
        /// <param name="mask">Specifies the components of the source vectors to multiply</param>
        [MethodImpl(Inline), ClMul]
        public static Vector128<ulong> vclmul(Vector128<ulong> a, Vector128<ulong> b, [Imm] ClMulKind selector)
            => CarrylessMultiply(a, b, (byte)selector);

        /// <summary>
        /// __m128i _mm_clmulepi64_si128 (__m128i a, __m128i b, const int imm8) PCLMULQDQ xmm, xmm/m128, imm8
        /// Computes the caryless product of the upper/lower sections the source vector
        /// </summary>
        /// <param name="a">The source vector defining the left/right operands</param>
        [MethodImpl(Inline), ClMul]
        public static Vector128<ulong> vclmul(Vector128<ulong> a)
            => vclmul(a,a,ClMulKind.LoHi);

        /// <summary>
        /// Computes the carryless product of two 64-bit operands reduced by a specified polynomial
        /// </summary>
        /// <param name="a">The source vector defining the left/right operands</param>
        /// <param name="poly">The reducing polynomial</param>
        [MethodImpl(Inline), ClMul]
        public static Vector128<ulong> vclmulr(Vector128<ulong> a, Vector128<ulong> poly)
        {
            var prod = vclmul(a);
            prod = cpu.vxor(prod, vclmul(vsrl(prod, 64), poly, ClMulKind.Lo));
            prod = cpu.vxor(prod, vclmul(vsrl(prod, 64), poly, ClMulKind.Lo));
            return prod;
        }
    }
}