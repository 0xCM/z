//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using B = CellCalcs;

    [ApiHost]
    public static class PolySpanBlocks
    {
        const NumericKind Closure = AllNumeric;

        [MethodImpl(Inline), Op]
        public static SpanBlockEmitter emitter(IBoundSource src, Pow2x64 bufferSize = Pow2x64.P2ᐞ14)
            => new SpanBlockEmitter(src, bufferSize);

        [MethodImpl(Inline), Op]
        public static SpanBlockEmitter emitter(IBoundSource src, Index<Cell256> buffer)
            => new SpanBlockEmitter(src, buffer);

        /// <summary>
        /// Allocates and fills specified number of 8-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock8<T> SpanBlocks<T>(this IBoundSource src, W8 w, int count, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 8-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock8<T> SpanBlocks<T>(this IBoundSource src, W8 w, int count, T min, T max)
            where T : unmanaged
                => src.Stream<T>((min,max)).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills a specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [RandomSource]
        public static SpanBlock8<T> SpanBlocks<T>(this ISource src, W8 w, int count, T t = default)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock16<T> SpanBlocks<T>(this IBoundSource src, W16 w, int count, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock16<T> SpanBlocks<T>(this IBoundSource src, W16 w, int count, T min, T max)
            where T : unmanaged
                => src.Stream<T>((min,max)).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills a specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [RandomSource]
        public static SpanBlock16<T> SpanBlocks<T>(this ISource src, W16 w, int count, T t = default)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock32<T> SpanBlocks<T>(this ISource src, W32 w, int count)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock32<T> SpanBlocks<T>(this IBoundSource src, W32 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock32<T> SpanBlocks<T>(this IBoundSource src, W32 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.SpanBlocks(w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [RandomSource]
        public static SpanBlock32<T> SpanBlocks<T>(this IBoundSource src, W32 w, int count, T t)
            where T : unmanaged
                => src.SpanBlocks<T>(w, count);

        /// <summary>
        /// Allocates and fills specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock64<T> SpanBlocks<T>(this ISource src, W64 w, int count)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock64<T> SpanBlocks<T>(this IBoundSource src, W64 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock64<T> SpanBlocks<T>(this IBoundSource src, W64 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.SpanBlocks(w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [RandomSource]
        public static SpanBlock64<T> SpanBlocks<T>(this ISource src, W64 w, int count, T t)
            where T : unmanaged
                => src.SpanBlocks<T>(w,count);

        /// <summary>
        /// Allocates and fills specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock128<T> SpanBlocks<T>(this ISource src, W128 w, int count = 1)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w, count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [RandomSource]
        public static SpanBlock128<T> SpanBlocks<T>(this IBoundSource src, W128 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock128<T> SpanBlocks<T>(this IBoundSource src, W128 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.SpanBlocks(w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock128<T> SpanBlocks<T>(this ISource src, W128 w, int count, T t)
            where T : unmanaged
                => src.SpanBlocks<T>(w,count);

        /// <summary>
        /// Allocates and fills specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The bitness selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock256<T> SpanBlocks<T>(this ISource src, W256 w, int count = 1)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock256<T> SpanBlocks<T>(this IBoundSource src, W256 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock256<T> SpanBlocks<T>(this IBoundSource src, W256 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.SpanBlocks(w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock256<T> SpanBlocks<T>(this ISource src, W256 w, int count, T t)
            where T : unmanaged
                => src.SpanBlocks<T>(w,count);

        /// <summary>
        /// Allocates and fills specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The bitness selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock512<T> SpanBlocks<T>(this ISource src, W512 w, int count = 1)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock512<T> SpanBlocks<T>(this IBoundSource src, W512 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock512<T> SpanBlocks<T>(this IBoundSource src, W512 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.SpanBlocks(w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock512<T> SpanBlocks<T>(this ISource src, W512 w, int count, T t)
            where T : unmanaged
                => src.SpanBlocks<T>(w,count);

        /// <summary>
        /// Fills a single caller-allocated 16-bit block with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The exclusive cell value upper bound</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock16<T> SpanBlock<T>(this IBoundSource src, T min, T max, in SpanBlock16<T> dst, int block)
            where T : unmanaged
        {
            src.Fill(min,max,dst.CellBlock(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 32-bit block with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The exclusive cell value upper bound</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock32<T> SpanBlock<T>(this IBoundSource src, T min, T max, in SpanBlock32<T> dst, int block)
            where T : unmanaged
        {
            src.Fill(min,max,dst.CellBlock(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 64-bit block with random values
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The exclusive cell value upper bound</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock64<T> SpanBlock<T>(this IBoundSource random, T min, T max, in SpanBlock64<T> dst, int block)
            where T : unmanaged
        {
            random.Fill(min,max,dst.CellBlock(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 128-bit block with random values
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The exclusive cell value upper bound</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock128<T> SpanBlock<T>(this IBoundSource random, T min, T max, in SpanBlock128<T> dst, int block)
            where T : unmanaged
        {
            random.Fill(min,max, dst.Block(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 256-bit block with random values
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The inclusive cell value upper bound</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock256<T> SpanBlock<T>(this IBoundSource random, T min, T max, in SpanBlock256<T> dst, int block)
            where T : unmanaged
        {
            random.Fill(min,max,dst.Block(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 512-bit block with random values
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The inclusive cell value upper bound</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock512<T> SpanBlock<T>(this IBoundSource random, T min, T max, in SpanBlock512<T> dst, int block)
            where T : unmanaged
        {
            random.Fill(min,max, dst.Block(block));
            return ref dst;
        }

        /// <summary>
        /// Allocates and fills a single 16-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock8<T> SpanBlock<T>(this IBoundSource source, W8 w)
            where T : unmanaged
                => source.Stream<T>().ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 16-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock16<T> SpanBlock<T>(this IBoundSource source, W16 w)
            where T : unmanaged
                => source.Stream<T>().ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 32-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock32<T> SpanBlock<T>(this ISource source, W32 w)
            where T : unmanaged
                => source.SpanBlocks<T>(w,1);

        /// <summary>
        /// Allocates and fills a single 64-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock64<T> SpanBlock<T>(this ISource source, W64 w)
            where T : unmanaged
                => source.SpanBlocks<T>(w,1);

        /// <summary>
        /// Allocates and fills a single 128-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock128<T> SpanBlock<T>(this ISource source, W128 w)
            where T : unmanaged
                => source.SpanBlocks<T>(w,1);

        /// <summary>
        /// Allocates and fills a single 256-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock256<T> SpanBlock<T>(this ISource source, W256 w)
            where T : unmanaged
                => source.SpanBlocks<T>(w,1);

        /// <summary>
        /// Allocates and fills a single 256-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock512<T> SpanBlock<T>(this ISource source, W512 w)
            where T : unmanaged
                => source.SpanBlocks<T>(w,1);

        /// <summary>
        /// Allocates and fills a single 16-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock16<T> SpanBlock<T>(this IBoundSource source, W16 w, T min, T max)
            where T : unmanaged
                => source.Stream<T>((min,max)).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 32-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The inclusive cell value upper bound</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock32<T> SpanBlock<T>(this IBoundSource source, W32 w, T min, T max)
            where T : unmanaged
                => source.SpanBlocks<T>(w,min,max,1);

        /// <summary>
        /// Allocates and fills a single 64-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The inclusive cell value upper bound</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock64<T> SpanBlock<T>(this IBoundSource source, W64 w, T min, T max)
            where T : unmanaged
                => source.SpanBlocks<T>(w,min,max,1);

        /// <summary>
        /// Allocates and fills a single 128-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The inclusive cell value upper bound</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock128<T> SpanBlock<T>(this IBoundSource source, W128 w, T min, T max)
            where T : unmanaged
                => source.SpanBlocks<T>(w,min,max,1);

        /// <summary>
        /// Allocates and fills a single 256-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The inclusive cell value upper bound</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock256<T> SpanBlock<T>(this IBoundSource source, W256 w, T min, T max)
            where T : unmanaged
                => source.SpanBlocks<T>(w,min,max,1);

        /// <summary>
        /// Allocates and fills a single 256-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="min">The inclusive cell value lower bound</param>
        /// <param name="max">The inclusive cell value upper bound</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static SpanBlock512<T> SpanBlock<T>(this IBoundSource source, W512 w, T min, T max)
            where T : unmanaged
                => source.SpanBlocks<T>(w,min,max,1);

        /// <summary>
        /// Fills a single caller-allocated 16-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock16<T> SpanBlock<T>(this ISource source, in SpanBlock16<T> dst, int block)
            where T : unmanaged
        {
            source.Fill(dst.CellBlock(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 32-bit block with random values
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock32<T> SpanBlock<T>(this ISource source, in SpanBlock32<T> dst, int block)
            where T : unmanaged
        {
            source.Fill(dst.CellBlock(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 64-bit block with random values
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock64<T> SpanBlock<T>(this ISource source, in SpanBlock64<T> dst, int block)
            where T : unmanaged
        {
            source.Fill(dst.CellBlock(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 128-bit block with random values
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock128<T> SpanBlock<T>(this ISource random, in SpanBlock128<T> dst, int block)
            where T : unmanaged
        {
            random.Fill(dst.Block(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 256-bit block with random values
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock256<T> SpanBlock<T>(this ISource random, in SpanBlock256<T> dst, int block)
            where T : unmanaged
        {
            random.Fill(dst.Block(block));
            return ref dst;
        }

        /// <summary>
        /// Fills a single caller-allocated 512-bit block with random values
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The block cell type</typeparam>
        public static ref readonly SpanBlock512<T> SpanBlock<T>(this ISource random, in SpanBlock512<T> dst, int block)
            where T : unmanaged
        {
            random.Fill(dst.Block(block));
            return ref dst;
        }


        /// <summary>
        /// Allocates and fills a single 16-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <param name="filter">An domain refinement filter</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock16<T> SpanBlock<T>(this IBoundSource random, W16 w, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => random.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 32-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <param name="filter">An domain refinement filter</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock32<T> SpanBlock<T>(this IBoundSource random, W32 w, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => random.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 64-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <param name="filter">An domain refinement filter</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock64<T> SpanBlock<T>(this IBoundSource random, W64 w, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => random.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 128-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <param name="filter">An domain refinement filter</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock128<T> SpanBlock<T>(this IBoundSource random, W128 w, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => random.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 256-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <param name="filter">An domain refinement filter</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock256<T> SpanBlock<T>(this IBoundSource random, W256 w, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => random.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 512-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <param name="filter">An domain refinement filter</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock512<T> SpanBlock<T>(this IBoundSource source, W512 w, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => source.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 16-bit block
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock16<T> SpanBlock<T>(this IBoundSource source, W16 w, Interval<T> domain)
            where T : unmanaged
                => source.Stream(domain).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 32-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock32<T> SpanBlock<T>(this IBoundSource random, W32 w, Interval<T> domain)
            where T : unmanaged
                => random.Stream(domain).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 64-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock64<T> SpanBlock<T>(this IBoundSource random, W64 w, Interval<T> domain)
            where T : unmanaged
                => random.Stream(domain).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 128-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock128<T> SpanBlock<T>(this IBoundSource random, W128 w, Interval<T> domain)
            where T : unmanaged
                => random.Stream(domain).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 256-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock256<T> SpanBlock<T>(this IBoundSource random, W256 w, Interval<T> domain)
            where T : unmanaged
                => random.Stream(domain).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

        /// <summary>
        /// Allocates and fills a single 512-bit block
        /// </summary>
        /// <param name="random">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="domain">A domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static SpanBlock512<T> SpanBlock<T>(this IBoundSource random, W512 w, Interval<T> domain)
            where T : unmanaged
                => random.Stream(domain).ToSpan(B.cellblocks<T>(w,1)).Blocked(w);

         /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this ISource source, in SpanBlock8<T> dst)
            where T : unmanaged
                => source.Fill(dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this ISource source, in SpanBlock16<T> dst)
            where T : unmanaged
                => source.Fill(dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this ISource source, in SpanBlock32<T> dst)
            where T : unmanaged
                => source.Fill(dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this ISource source, in SpanBlock64<T> dst)
            where T : unmanaged
                => source.Fill(dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this ISource source, in SpanBlock128<T> dst)
            where T : unmanaged
                => source.Fill(dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this ISource src, in SpanBlock256<T> dst)
            where T : unmanaged
                => src.Fill(dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this ISource src, in SpanBlock512<T> dst)
            where T : unmanaged
                => src.Fill(dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The exclusive upper bound</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this IBoundSource src, T min, T max, in SpanBlock16<T> dst)
            where T : unmanaged
                => src.Fill(min,max,dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The exclusive upper bound</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this IBoundSource src, T min, T max, in SpanBlock32<T> dst)
            where T : unmanaged
                => src.Fill(min, max, dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The exclusive upper bound</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this IBoundSource src, T min, T max, in SpanBlock64<T> dst)
            where T : unmanaged
                => src.Fill(min,max,dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The exclusive upper bound</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this IBoundSource src, T min, T max, in SpanBlock128<T> dst)
            where T : unmanaged
                => src.Fill(min,max,dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The exclusive upper bound</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this IBoundSource src, T min, T max, in SpanBlock256<T> dst)
            where T : unmanaged
                => src.Fill(min,max,dst.Storage);

        /// <summary>
        /// Fills caller-allocated block storage with random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The exclusive upper bound</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static void Fill<T>(this IBoundSource src,T min, T max, in SpanBlock512<T> dst)
            where T : unmanaged
                => src.Fill(min,max,dst.Storage);

        /// <summary>
        /// Allocates and fills specified number of 8-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock8<T> blocks<T>(IBoundSource src, W8 w, int count, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => src.Stream(domain, filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 8-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock8<T> blocks<T>(IBoundSource src, W8 w, int count, T min, T max)
            where T : unmanaged
                => src.Stream<T>((min,max)).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills a specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock8<T> blocks<T>(ISource src, W8 w, int count, T t = default)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock16<T> blocks<T>(IBoundSource src, W16 w, int count, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock16<T> blocks<T>(IBoundSource src, W16 w, int count, T min, T max)
            where T : unmanaged
                => src.Stream<T>((min,max)).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills a specified number of 16-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock16<T> blocks<T>(ISource src, W16 w, int count, T t = default)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock32<T> blocks<T>(ISource src, W32 w, int count)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock32<T> blocks<T>(IBoundSource src, W32 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock32<T> blocks<T>(IBoundSource src, W32 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => blocks<T>(src, w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 32-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock32<T> blocks<T>(IBoundSource src, W32 w, int count, T t)
            where T : unmanaged
                => blocks<T>(src, w, count);

        /// <summary>
        /// Allocates and fills specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock64<T> blocks<T>(ISource src, W64 w, int count)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock64<T> blocks<T>(IBoundSource src, W64 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock64<T> blocks<T>(IBoundSource src, W64 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => blocks<T>(src, w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 64-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock64<T> blocks<T>(ISource src, W64 w, int count, T t)
            where T : unmanaged
                => blocks<T>(src, w,count);

        /// <summary>
        /// Allocates and fills specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock128<T> blocks<T>(ISource src, W128 w, int count = 1)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w, count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock128<T> blocks<T>(IBoundSource src, W128 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock128<T> blocks<T>(IBoundSource src, W128 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => blocks<T>(src, w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 128-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock128<T> blocks<T>(ISource src, W128 w, int count, T t)
            where T : unmanaged
                => blocks<T>(src, w,count);

        /// <summary>
        /// Allocates and fills specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The bitness selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock256<T> blocks<T>(ISource src, W256 w, int count = 1)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock256<T> blocks<T>(IBoundSource src, W256 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock256<T> blocks<T>(IBoundSource src, W256 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => blocks<T>(src, w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 256-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock256<T> blocks<T>(ISource src, W256 w, int count, T t)
            where T : unmanaged
                => blocks<T>(src, w, count);

        /// <summary>
        /// Allocates and fills specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The bitness selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock512<T> blocks<T>(ISource src, W512 w, int count = 1)
            where T : unmanaged
                => src.Stream<T>().ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock512<T> blocks<T>(IBoundSource src, W512 w, Interval<T> domain, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => src.Stream(domain,filter).ToSpan(B.cellblocks<T>(w,count)).Blocked(w);

        /// <summary>
        /// Allocates and fills specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock512<T> blocks<T>(IBoundSource src, W512 w, T min, T max, int count = 1, Func<T,bool> filter = null)
            where T : unmanaged
                => blocks<T>(src, w, (min,max), count, filter);

        /// <summary>
        /// Allocates and fills a specified number of 512-bit blocks
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The number of blocks to allocate and fill</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [Op, Closures(Closure)]
        public static SpanBlock512<T> blocks<T>(ISource src, W512 w, int count, T t)
            where T : unmanaged
                => blocks<T>(src, w, count);
    }
}