//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void swap<T>(in T a, in T b)
            where T : unmanaged
        {
            var tmp = a;
            ref var x = ref edit(a);
            x = b;
            ref var y = ref edit(b);
            y = tmp;
        }
    }
}