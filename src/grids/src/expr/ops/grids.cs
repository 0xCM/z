//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

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

    }
}