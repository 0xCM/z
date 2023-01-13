//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static class PolyCells
    {
        const NumericKind Closure = AllNumeric;

        [MethodImpl(Inline)]
        public static CellEmitter<F> emitter<F>(ISource src)
            where F : struct, IDataCell
                => new CellEmitter<F>(src);

        [MethodImpl(Inline), Op]
        public static CellEmitter emitter(ISource src)
            => new CellEmitter(src);

        /// <summary>
        /// Creates a stream of fixed values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="F">The fixed type</typeparam>
        public static IEnumerable<F> Cells<F>(this ISource src)
            where F: unmanaged, IDataCell
                => cellstream<F>(src);

        /// <summary>
        /// Creates a cell index of specified count
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="src">The cell count</param>
        /// <typeparam name="F">The fixed type</typeparam>
        public static Index<F> Cells<F>(this ISource src, uint count)
            where F: unmanaged, IDataCell
                => celldata<F>(src, count);

        [MethodImpl(Inline), Op]
        public static Cell8 Cell(this ISource src, W8 w)
            => cell(src, w);

        [MethodImpl(Inline), Op]
        public static Cell16 Cell(this ISource src, W16 w)
            => cell(src, w);

        [MethodImpl(Inline), Op]
        public static Cell32 Cell(this ISource src, W32 w)
            => cell(src, w);

        [MethodImpl(Inline), Op]
        public static Cell64 Cell(this ISource src, W64 w)
            => cell(src, w);

        [MethodImpl(Inline), Op]
        public static Cell128 Cell(this ISource src, W128 w)
            => cell(src, w);

        [MethodImpl(Inline), Op]
        public static Cell256 Cell(this ISource src, W256 w)
            => cell(src, w);

        [MethodImpl(Inline), Op]
        public static Cell512 Cell(this ISource src, W512 w)
            => cell(src, w);

        [MethodImpl(Inline), Op]
        public static Cell8 cell(ISource source, W8 w)
            => source.Next<byte>();

        [MethodImpl(Inline), Op]
        public static Cell16 cell(ISource source, W16 w)
            => source.Next<ushort>();

        [MethodImpl(Inline), Op]
        public static Cell32 cell(ISource source, W32 w)
            => source.Next<uint>();

        [MethodImpl(Inline), Op]
        public static Cell64 cell(ISource source, W64 w)
            => source.Next<ulong>();

        [MethodImpl(Inline), Op]
        public static Cell128 cell(ISource source, W128 w)
            => (source.Next<ulong>(), source.Next<ulong>());

        [MethodImpl(Inline), Op]
        public static Cell256 cell(ISource source, W256 w)
        {
            var dst = Cell256.Empty;
            ref var storage = ref Unsafe.As<Cell256,Vector256<ulong>>(ref dst);
            storage = storage.WithLower(cell(source,w128));
            storage = storage.WithUpper(cell(source,w128));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Cell512 cell(ISource source, W512 w)
        {
            var lo = cell(source,w256);
            var hi = cell(source,w256);
            return new Cell512(lo,hi);
        }

        /// <summary>
        /// Creates a cell index of specified count
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="src">The cell count</param>
        /// <typeparam name="F">The fixed type</typeparam>
        public static Index<F> celldata<F>(ISource src, uint count)
            where F: unmanaged, IDataCell
                => cellstream<F>(src).Take(count).Array();

        [Op, Closures(Closure)]
        public static IEnumerable<Cell128> cellstream<T>(ISource src, W128 w)
            where T : unmanaged
                => new CellStream<Cell128,W128,T>(src).Stream;

        public static IEnumerable<F> cellstream<F,W,T>(ISource src, F f = default, W w = default, T t = default)
            where F : unmanaged, IDataCell
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => new CellStream<F,W,T>(src).Stream;

        public static IEnumerable<F> cellstream<F,W,T>(ISource src)
            where F : unmanaged, IDataCell
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => new CellStream<F,W,T>(src).Stream;

        public static IEnumerable<F> cellstream<F>(ICellValues<F> source)
            where F : struct, IDataCell
        {
            while(true)
                yield return source.Next();
        }

        /// <summary>
        /// Creates a stream of fixed values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="F">The fixed type</typeparam>
        public static IEnumerable<F> cellstream<F>(ISource src)
            where F: unmanaged, IDataCell
                => cellstream(emitter<F>(src));
    }
}