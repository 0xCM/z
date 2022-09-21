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
        public static Span<T> cells<T>(ref g2x2<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);
 
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g3x3<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g4x4<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g5x5<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref g8x8<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.MxN);
    }
}