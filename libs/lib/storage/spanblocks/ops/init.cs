//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CellCalcs;

    partial struct SpanBlocks
    {
        /// <summary>
        /// Loads a single 16-bit block from the leading elements of a source span (unchecked)
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Numeric8k)]
        public static SpanBlock8<T> init<T>(W8 w, Span<T> src)
            where T : unmanaged
                => unsafeload(w, src.Slice(0, blocklength<T>(w)));

        /// <summary>
        /// Loads a single 16-bit block from the leading elements of a source span (unchecked)
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Numeric8x16k)]
        public static SpanBlock16<T> init<T>(W16 w, Span<T> src)
            where T : unmanaged
                => unsafeload(w, src.Slice(0, blocklength<T>(w)));

        /// <summary>
        /// Loads a single 32-bit block from the leading elements of a source span (unchecked)
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Numeric8x16x32k)]
        public static SpanBlock32<T> init<T>(W32 w, Span<T> src)
            where T : unmanaged
                => unsafeload(w, src.Slice(0, blocklength<T>(w)));

        /// <summary>
        /// Loads a single 64-bit block from the leading elements of a source span (unchecked)
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(AllNumeric)]
        public static SpanBlock64<T> init<T>(W64 w, Span<T> src)
            where T : unmanaged
                => unsafeload(w, src.Slice(0, blocklength<T>(w)));

        /// <summary>
        /// Loads a single 128-bit block from the leading elements of a source span (unchecked)
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(AllNumeric)]
        public static SpanBlock128<T> init<T>(W128 w, Span<T> src)
            where T : unmanaged
                => unsafeload(w, src.Slice(0, blocklength<T>(w)));

        /// <summary>
        /// Loads a single 256-bit block from the leading elements of a source span (unchecked)
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(AllNumeric)]
        public static SpanBlock256<T> init<T>(W256 w, Span<T> src)
            where T : unmanaged
                => unsafeload(w, src.Slice(0, blocklength<T>(w)));

        /// <summary>
        /// Loads a single 512-bit block from the leading elements of a source span (unchecked)
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(AllNumeric)]
        public static SpanBlock512<T> init<T>(W512 w, Span<T> src)
            where T : unmanaged
                => unsafeload(w, src.Slice(0, blocklength<T>(w)));
    }
}