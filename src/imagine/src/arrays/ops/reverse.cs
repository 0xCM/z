//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        [Op, Closures(Closure)]
        public static T[] reverse<T>(T[] src)
        {
            Array.Reverse(src);
            return src;
        }
    }
}