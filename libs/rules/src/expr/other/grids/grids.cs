//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Expr;

    partial struct expr
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static g8x8<T> grid8x8<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => first(recover<T,g8x8<T>>(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static g5x5<T> grid5x5<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => first(recover<T,g5x5<T>>(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static g4x4<T> grid4x4<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => first(recover<T,g4x4<T>>(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static g3x3<T> grid3x3<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => first(recover<T,g3x3<T>>(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static g2x2<T> grid2x2<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => first(recover<T,g2x2<T>>(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> row<T>(ref g8x8<T> src, uint i)
            where T : unmanaged
                => slice(cells(ref src),i*src.N,src.M);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> row<T>(ref g5x5<T> src, uint i)
            where T : unmanaged
                => slice(cells(ref src),i*src.N,src.M);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> row<T>(ref g4x4<T> src, uint i)
            where T : unmanaged
                => slice(cells(ref src),i*src.N,src.M);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> row<T>(ref g3x3<T> src, uint i)
            where T : unmanaged
                => slice(cells(ref src),i*src.N,src.M);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> row<T>(ref g2x2<T> src, uint i)
            where T : unmanaged
                => slice(cells(ref src),i*src.N,src.M);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g8x8<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref g8x8<T> src)
            where T : unmanaged
                => ref @as<g8x8<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref g5x5<T> src)
            where T : unmanaged
                => ref @as<g5x5<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g5x5<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref g4x4<T> src)
            where T : unmanaged
                => ref @as<g4x4<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g4x4<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref g3x3<T> src)
            where T : unmanaged
                => ref @as<g3x3<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g3x3<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref g2x2<T> src)
            where T : unmanaged
                => ref @as<g2x2<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g2x2<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GridSpec spec<T>(uint rows, uint cols)
            where T : unmanaged
                => gridspec((ushort)rows, (ushort)cols, (ushort)width<T>());

        /// <summary>
        /// Computes the number of bytes required to cover a grid, predicated on row/col counts
        /// </summary>
        /// <param name="rows">The number of grid rows</param>
        /// <param name="cols">The number of grid columns</param>
        [MethodImpl(Inline), Op]
        static ByteSize gridsize(int rows, int cols)
        {
            var points = rows*cols;
            return (points >> 3) + (points % 8 != 0 ? 1 : 0);
        }

        /// <summary>
        /// Defines a grid specification predicated on specified row count, col count and bit width
        /// </summary>
        /// <param name="rows">The number of rows in the grid</param>
        /// <param name="cols">The number of columns in the grid</param>
        /// <param name="segwidth">The width of a grid cell</param>
        [MethodImpl(Inline), Op]
        static GridSpec gridspec(ushort rows, ushort cols, ushort segwidth)
        {
            var bytes = (uint)gridsize(rows, cols);
            var bits = bytes*8;
            var segs = grids.gridcells(rows, cols, segwidth);
            return new GridSpec(rows, cols, segwidth, bytes, bits, segs);
        }
    }
}