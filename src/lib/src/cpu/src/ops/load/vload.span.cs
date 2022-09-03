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
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Loads a 128-bit vector from the first 128 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(W128 w, Span<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 128-bit vector from the first 128 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(W128 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 256-bit vector from the first 256 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(W256 w, Span<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 512-bit vector from the first 512 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(W512 w, Span<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 128-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(W128 w, Span<T> src, int offset)
            where T : unmanaged
                => vload(w, seek(src, (uint)offset));

        /// <summary>
        /// Loads a 256-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(W256 w, Span<T> src, int offset)
            where T : unmanaged
                => vload(w, seek(src, (uint)offset));

        /// <summary>
        /// Loads a 256-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(N512 w, Span<T> src, int offset)
            where T : unmanaged
                => vload(w, seek(src, (uint)offset));

        /// <summary>
        /// Loads a 256-bit vector from the first 256 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(N256 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 256-bit vector from the first 256 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(N512 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 128-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(N128 w, ReadOnlySpan<T> src, int offset)
            where T : unmanaged
                => vload(w, skip(src, offset));

        /// <summary>
        /// Loads a 256-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(N256 w, ReadOnlySpan<T> src, int offset)
            where T : unmanaged
                => vload(w, skip(src, offset));

        /// <summary>
        /// Loads a 512-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(N512 w, ReadOnlySpan<T> src, int offset)
            where T : unmanaged
                => vload(w, skip(src, offset));
    }
}