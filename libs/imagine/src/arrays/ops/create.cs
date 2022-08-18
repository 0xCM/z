//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] create<T>(IEnumerable<T> src)
            => sys.array(src);
    }
}