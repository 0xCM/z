//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [Op, Closures(Closure)]
        public static ref T single<T>(T[] src)
        {
            var count = src?.Length ?? 0;
            if(count != 1)
                sys.@throw($"There are {src.Length} elements where there should be exactly 1");
            return ref first(src);
        }
    }
}