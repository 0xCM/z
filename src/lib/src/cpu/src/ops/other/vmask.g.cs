//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    using static Root;
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Distributes each bit of the source to the hi bit of each byte a 256-bit target vector
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmask256<T>(uint src)
            where T : unmanaged
                => generic<T>(v8u(BitMasks.vmask256x8u(src)));

        /// <summary>
        /// Distributes each bit of the source to a specified bit of each byte in a 256-bit target vector
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The byte-relative bit position index in the range [0,7]</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmask256<T>(uint src, byte index)
            where T : unmanaged
                => generic<T>(v8u(vpack.vinflate256x8u(src,index)));

        /// <summary>
        /// int _mm_movemask_epi8 (__m128i a) PMOVMSKB reg, xmm
        /// Creates a 16-bit mask from the most significant bit of each byte in the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), MoveMask, Closures(Closure)]
        public static ushort vmask16u<T>(Vector128<T> src)
            where T : unmanaged
                => (ushort)MoveMask(v8u(src));

        /// <summary>
        /// int _mm256_movemask_epi8 (__m256i a) VPMOVMSKB reg, ymm
        /// Creates a 32-bit mask from the most significant bit of each byte in the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), MoveMask, Closures(Closure)]
        public static uint vmask32u<T>(Vector256<T> src)
            where T : unmanaged
                => (uint)MoveMask(v8u(src));

        /// <summary>
        /// Creates a 16-bit mask from each byte in the source vector at a byte-relative bit index
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">An integer between 0 and 7</param>
        [MethodImpl(Inline), MoveIMask, Closures(Closure)]
        public static ushort vmask16u<T>(Vector128<T> src, [Imm] byte index)
            where T : unmanaged
                => (ushort)MoveMask(v8u(cpu.vsll(v64u(src), (byte)(7 - index))));

        /// <summary>
        /// Creates a 32-bit mask from each byte in the source vector at a byte-relative bit index
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">An integer between 0 and 7</param>
        [MethodImpl(Inline), MoveIMask, Closures(Closure)]
        public static uint vmask32u<T>(Vector256<T> src, [Imm] byte index)
            where T : unmanaged
                => (uint)MoveMask(v8u(cpu.vsll(v64u(src), (byte)(7 - index))));

        /// <summary>
        /// Creates a 16-bit mask from each byte in the source vector at a byte-relative bit index
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">An integer between 0 and 7</param>
        [MethodImpl(Inline), MoveIMask, Closures(Closure)]
        public static ushort vmask16u<T>(Vector128<T> src, [Imm] HexDigitValue index)
            where T : unmanaged
                => (ushort)MoveMask(v8u(cpu.vsll(v64u(src), (byte)(7 - index))));
    }
}