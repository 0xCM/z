//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SpanBlocks
    {
        /// <summary>
        /// Loads a span into a blocked container without checks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt8k)]
        public static SpanBlock8<T> unsafeload<T>(W8 w, Span<T> src)
            where T : unmanaged
                => new SpanBlock8<T>(src);

        /// <summary>
        /// Loads a span into a blocked container without checks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt16k)]
        public static SpanBlock16<T> unsafeload<T>(W16 w, Span<T> src)
            where T : unmanaged
                => new SpanBlock16<T>(src);

        /// <summary>
        /// Loads a span into a blocked container without checks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock32<T> unsafeload<T>(W32 w, Span<T> src)
            where T : unmanaged
                => new SpanBlock32<T>(src);

        /// <summary>
        /// Loads a span into a blocked container without checks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock64<T> unsafeload<T>(W64 w, Span<T> src)
            where T : unmanaged
                => new SpanBlock64<T>(src);

        /// <summary>
        /// Loads a span into a blocked container without checks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock128<T> unsafeload<T>(W128 w, Span<T> src)
            where T : unmanaged
                => new SpanBlock128<T>(src);

        /// <summary>
        /// Loads a span into a blocked container without checks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock256<T> unsafeload<T>(W256 w, Span<T> src)
            where T : unmanaged
                => new SpanBlock256<T>(src);

        /// <summary>
        /// Loads a span into a blocked container without checks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Load, Closures(UInt32k)]
        public static SpanBlock512<T> unsafeload<T>(W512 w, Span<T> src)
            where T : unmanaged
                => new SpanBlock512<T>(src);
    }
}