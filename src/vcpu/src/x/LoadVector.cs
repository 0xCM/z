//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Loads a 128-bit vector from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this Span<T> src, W128 w, int offset = 0)
            where T : unmanaged
                => vgcpu.vload(w, src, offset);

        /// <summary>
        /// Loads a 256-bit vector from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this Span<T> src, W256 n, int offset = 0)
            where T : unmanaged
                => vgcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 512-bit vector from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this Span<T> src, W512 n, int offset = 0)
            where T : unmanaged
                => vgcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 128-bit vector from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this ReadOnlySpan<T> src, W128 n, int offset = 0)
            where T : unmanaged
                => vgcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 256-bit vector from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this ReadOnlySpan<T> src, W256 n, int offset = 0)
            where T : unmanaged
                => vgcpu.vload(n, src, offset);

        /// <summary>
        /// Loads a 512-bit vector from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this ReadOnlySpan<T> src, W512 n, int offset = 0)
            where T : unmanaged
                => vgcpu.vload(n, src, offset);
    }
}