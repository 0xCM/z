//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T last<T>(T[] src)
             => ref seek(src, src.Length - 1);
    }
}