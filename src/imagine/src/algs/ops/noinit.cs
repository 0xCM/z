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
        public static ref T noinit<T>(out T dst)
        {
            SkipInit(out dst);
            return ref dst;
        }
    }
}