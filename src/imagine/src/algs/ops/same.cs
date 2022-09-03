//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool same<T>(in T a, in T b)
            => AreSame(ref edit(a), ref edit(b));
    }
}