//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Loads 2 block-indexed 128-bit vectors
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block1">The block index of the first vector</param>
        /// <param name="block2">The block index of the second vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ConstPair<Vector128<T>> LoadVectors<T>(this in SpanBlock128<T> src, int block1, int block2)
            where T : unmanaged
                => (gcpu.vload(src, block1), gcpu.vload(src, block2));

        /// <summary>
        /// Loads 3 block-indexed 128-bit vectors
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block1">The block index of the first vector</param>
        /// <param name="block2">The block index of the second vector</param>
        /// <param name="block3">The block index of the third vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ConstTriple<Vector128<T>> LoadVectors<T>(this in SpanBlock128<T> src, int block1, int block2, int block3)
            where T : unmanaged
                => (gcpu.vload(src, block1), gcpu.vload(src, block2), gcpu.vload(src, block3));

        /// <summary>
        /// Loads 2 block-indexed 256-bit vectors
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block1">The block index of the first vector</param>
        /// <param name="block2">The block index of the second vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ConstPair<Vector256<T>> LoadVectors<T>(this in SpanBlock256<T> src, int block1, int block2)
            where T : unmanaged
                => (gcpu.vload(src, block1), gcpu.vload(src, block2));

        /// <summary>
        /// Loads 3 block-indexed 256-bit vectors
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block1">The block index of the first vector</param>
        /// <param name="block2">The block index of the second vector</param>
        /// <param name="block3">The block index of the third vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ConstTriple<Vector256<T>> LoadVectors<T>(this in SpanBlock256<T> src, int block1, int block2, int block3)
            where T : unmanaged
                => (gcpu.vload(src, block1), gcpu.vload(src, block2), gcpu.vload(src, block3));
    }
}