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
        /// Allocates and deposits vector content to a data block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock128<T> ToBlock<T>(this Vector128<T> src)
            where T : unmanaged
        {
            var dst = SpanBlocks.single<T>(w128);
            gcpu.vstore(src, ref dst.First);
            return dst;
        }

        /// <summary>
        /// Allocates and deposits vector content to a data block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock256<T> ToBlock<T>(this Vector256<T> src)
            where T : unmanaged
        {
            var dst = SpanBlocks.single<T>(w256);
            gcpu.vstore(src, ref dst.First);
            return dst;
        }

        /// <summary>
        /// Allocates and deposits vector content to a data block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock512<T> ToBlock<T>(this Vector512<T> src)
            where T : unmanaged
        {
            var dst = SpanBlocks.single<T>(w512);
            gcpu.vstore(src, ref dst.First);
            return dst;
        }
    }
}