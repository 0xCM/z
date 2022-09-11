//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct LookupTables
    {
        /// <summary>
        /// Defines a key for a cell with coordinates (<paramref name='row'/>, <paramref name='col'/>)
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        [MethodImpl(Inline), Op]
        public static LookupKey key(ushort row, ushort col)
            => @as<uint,LookupKey>((uint)row | ((uint)col) << 16);

        [MethodImpl(Inline), Op]
        public static ref readonly LookupKey key(LookupKeys src, ushort row, ushort col)
        {
            var data = src.View;
            var i = offset(src.Dim, row, col);
            return ref skip(data,i);
        }

        [Op, Closures(Closure)]
        public static LookupTable<T> table<T>(ushort rows, ushort cols)
            => new LookupTable<T>((rows,cols), alloc<T>(rows*cols));

        [Op, Closures(Closure)]
        public static LookupTable<T> table<T>(ushort rows, ushort cols, T[] cells)
        {
            Require.invariant(cells.Length == rows*cols);
            return new LookupTable<T>((rows,cols), cells);
        }

        /// <summary>
        /// Allocates and defines a <see cref='LookupKeys'/> sequence that covers a table of dimension <paramref name='rows'/>x<paramref name='cols'/>
        /// </summary>
        /// <param name="rows">The row count</param>
        /// <param name="cols">The column count</param>
        [Op]
        public static LookupKeys keys(ushort rows, ushort cols)
        {
            var dst = alloc<LookupKey>(rows*cols);
            keys(rows, cols, dst);
            return new LookupKeys((rows,cols),dst);
        }

        [MethodImpl(Inline), Op]
        public static void keys(ushort rows, ushort cols, Span<LookupKey> dst)
        {
            var dim = new GridDim<ushort>(rows,cols);
            for(var i=0; i<rows; i++)
            for(var j=0; j<cols; j++)
                seek(dst, offset(dim,(ushort)i,(ushort)j)) = key((ushort)i, (ushort)j);
        }

        /// <summary>
        /// Defines an association between a <see cef='LookupKey'/> and the identified cell
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cell"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static KeyMap<T> map<T>(LookupKey key, T cell)
            => new KeyMap<T>(key,cell);

        /// <summary>
        /// Returns a reference to a coordiate-identified cell from a linear sequence that
        /// defines a table with row-major order
        /// </summary>
        /// <param name="dim"></param>
        /// <param name="key"></param>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(GridDim<ushort> dim, LookupKey key, Span<T> src)
        {
            var i = offset(dim, key.Row(), key.Col());
            return ref seek(src,i);
        }

        [MethodImpl(Inline), Op]
        public static uint offset(GridDim dim, uint row, uint col)
            => dim.N*row + col;

        [MethodImpl(Inline), Op]
        public static uint offset(GridDim<ushort> dim, ushort row, ushort col)
            => (uint)dim.N*row + col;

        [MethodImpl(Inline), Op]
        public static uint offset(GridDim<ushort> dim, LookupKey key)
            => (uint)dim.N * key.Row() + key.Col();

        [MethodImpl(Inline), Op]
        public static bool eq(LookupKey a, LookupKey b)
            => data(a) == data(b);

        [MethodImpl(Inline), Op]
        public static uint hash(LookupKey src)
            => data(src);

        [Op]
        public static string format(LookupKey key)
        {
            const string Pattern = "({0},{1})";
            return string.Format(Pattern, key.Row(), key.Col());
        }

        [Op, Closures(Closure)]
        public static string format<T>(KeyMap<T> src)
        {
            const string Pattern = "({0},{1}) -> {2}";
            return string.Format(Pattern, src.Key.Row(), src.Key.Col(), src.Target);
        }

        [MethodImpl(Inline), Op]
        internal static uint data(LookupKey src)
            => @as<LookupKey,uint>(src);

        [MethodImpl(Inline), Op]
        internal static LookupKey key(uint src)
            => @as<uint,LookupKey>(src);

        const NumericKind Closure = UnsignedInts;
    }
}