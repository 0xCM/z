//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cells
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Cell128<T> For<T>(W128 w, int min, int max, Func<int,T> f)
            where T : unmanaged
        {
            var dst = default(Cell128<T>);
            for(var i=min; i<=max; i++)
                dst[i] = f(i);
            return dst;
        }

        [MethodImpl(Inline), Op,Closures(Closure)]
        public static Cell256<T> For<T>(W256 w, int min, int max, Func<int,T> f)
            where T : unmanaged
        {
            var dst = default(Cell256<T>);
            for(var i=min; i<=max; i++)
                dst[i] = f(i);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Cell512<T> For<T>(W512 w, int min, int max, Func<int,T> f)
            where T : unmanaged
        {
            var dst = default(Cell512<T>);
            for(var i=min; i<=max; i++)
                dst[i] = f(i);
            return dst;
        }
    }
}