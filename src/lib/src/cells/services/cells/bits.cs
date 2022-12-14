//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cells
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell128<T> src, int max, int min)
            where T : unmanaged
        {
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(@as<Cell128<T>,T>(src), offset);
            return ref core.first(cover(start, length));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell256<T> src, int max, int min)
            where T : unmanaged
        {
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(@as<Cell256<T>,T>(src), offset);
            return ref core.first(cover(start, length));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell512<T> src, int max, int min)
            where T : unmanaged
        {
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(@as<Cell512<T>,T>(src), offset);
            return ref core.first(cover(start, length));
        }
    }
}