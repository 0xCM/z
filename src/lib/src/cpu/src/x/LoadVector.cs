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
        /// Loads a 128-bit vector from the first 128-bit block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this in SpanBlock128<T> src)
            where T : unmanaged
                => gcpu.vload(src, 0);

        /// <summary>
        /// Loads a 256-bit vector from the first 256-bit block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this in SpanBlock256<T> src)
            where T : unmanaged
                => gcpu.vload(src);

        /// <summary>
        /// Loads a 512-bit vector from the first 512-bit block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this in SpanBlock512<T> src)
            where T : unmanaged
                => gcpu.vload(src);

        /// <summary>
        /// Loads a block-identified 128-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this in SpanBlock128<T> src, int block)
            where T : unmanaged
                => gcpu.vload(src, block);

        /// <summary>
        /// Loads a 256-bit vector from an index-identified block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this in SpanBlock256<T> src, int block)
            where T : unmanaged
                => gcpu.vload(src,block);

        /// <summary>
        /// Loads a 256-bit vector from an index-identified block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this in SpanBlock256<T> src, uint block)
            where T : unmanaged
                => gcpu.vload(src, (int)block);

        /// <summary>
        /// Loads 512-bit vector from an index-identified block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this in SpanBlock512<T> src, int block)
            where T : unmanaged
                => gcpu.vload(src,block);

        /// <summary>
        /// Loads a 128-bit vector from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this Span<T> src, W128 w, int offset = 0)
            where T : unmanaged
                => gcpu.vload(w, src, offset);

        /// <summary>
        /// Loads a 256-bit vector from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this Span<T> src, W256 n, int offset = 0)
            where T : unmanaged
                => gcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 512-bit vector from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this Span<T> src, W512 n, int offset = 0)
            where T : unmanaged
                => gcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 128-bit vector from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this ReadOnlySpan<T> src, W128 n, int offset = 0)
            where T : unmanaged
                => gcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 256-bit vector from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this ReadOnlySpan<T> src, W256 n, int offset = 0)
            where T : unmanaged
                => gcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 512-bit vector from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this ReadOnlySpan<T> src, W512 n, int offset = 0)
            where T : unmanaged
                => gcpu.vload(n, src, offset);
    }
}