//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static sys;

    partial struct Calcs
    {
        /// <summary>
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="data">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(Numeric8k)]
        public static void broadcast<T>(T src, in SpanBlock8<T> dst)
            where T : unmanaged
        {
            var blocks = dst.BlockCount;
            for(var i=0; i<blocks; i++)
                broadcast(src, dst.CellBlock(i));
        }

        /// <summary>
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="src">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(Numeric8x16k)]
        public static void broadcast<T>(T src, in SpanBlock16<T> dst)
            where T : unmanaged
        {
            var blocks = dst.BlockCount;
            for(var i=0; i<blocks; i++)
                broadcast(src, dst.CellBlock(i));
        }

        /// <summary>
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="src">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(Numeric8x16x32k)]
        public static void broadcast<T>(T src, in SpanBlock32<T> dst)
            where T : unmanaged
        {
            var blocks = dst.BlockCount;
            for(var i=0; i<blocks; i++)
                broadcast(src, dst.CellBlock(i));
        }

        /// <summary>
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="src">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(AllNumeric)]
        public static void broadcast<T>(T src, in SpanBlock64<T> dst)
            where T : unmanaged
        {
            var blocks = dst.BlockCount;
            for(var i=0; i<blocks; i++)
                broadcast(src, dst.CellBlock(i));
        }

        /// <summary>
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="src">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(AllNumeric)]
        public static void broadcast<T>(T src, SpanBlock128<T> dst)
            where T : unmanaged
                => dst.Fill(src);

        /// <summary>
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="src">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(AllNumeric)]
        public static void broadcast<T>(T src, SpanBlock256<T> dst)
            where T : unmanaged
                => dst.Fill(src);

        /// <summary>
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="src">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Broadcast, Closures(AllNumeric)]
        public static void broadcast<T>(T src, in SpanBlock512<T> dst)
            where T : unmanaged
                => dst.Fill(src);

        /// <summary>
        /// Expands a bit-level S-pattern to a block-level T-pattern
        /// </summary>
        /// <param name="src">The source pattern</param>
        /// <param name="enabled">The value to assign to a block when the corresponding index-identified bit is enabled</param>
        /// <param name="dst">The target pattern receiver</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock128<T> broadcast<S,T>(S src, T enabled, SpanBlock128<T> dst)
            where S : unmanaged
            where T : unmanaged
        {
            var length = sys.min(dst.CellCount, width<S>());
            for(var i=0; i<length; i++)
                dst[i] = gbits.test(src, (byte)i) ? enabled : default;
            return dst;
        }

        /// <summary>
        /// Expands a bit-level S-pattern to a block-level T-pattern
        /// </summary>
        /// <param name="src">The source pattern</param>
        /// <param name="enabled">The value to assign to a block when the corresponding index-identified bit is enabled</param>
        /// <param name="dst">The target pattern receiver</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static SpanBlock256<T> broadcast<S,T>(S src, T enabled, SpanBlock256<T> dst)
            where S : unmanaged
            where T : unmanaged
        {
            var length = sys.min(dst.CellCount, width<S>());
            for(var i=0; i<length; i++)
                dst[i] = gbits.test(src,(byte)i) ? enabled : default;
            return dst;
        }

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBroadcast128<T> vbroadcast<T>(W128 w)
            where T : unmanaged
                => default(VBroadcast128<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBroadcast256<T> vbroadcast<T>(W256 w)
            where T : unmanaged
                => default(VBroadcast256<T>);

        [MethodImpl(Inline)]
        public static VBroadcast128<S,T> vbroadcast<S,T>(W128 w, S s = default, T t = default)
            where T : unmanaged
            where S : unmanaged
                => default(VBroadcast128<S,T>);

        [MethodImpl(Inline)]
        public static VBroadcast256<S,T> vbroadcast<S,T>(W256 w, S s = default, T t = default)
            where T : unmanaged
            where S : unmanaged
                => default(VBroadcast256<S,T>);

        [MethodImpl(Inline)]
        static void broadcast<T>(T src, Span<T> dst)
        {
            var count = dst.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = src;
        }
    }
}