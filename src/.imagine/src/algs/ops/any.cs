//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool any<T>(T[] src)
            => src?.Length != 0;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool any<T>(T[] src, T match)
        {
            for(var i=0; i<src.Length; i++)
                if(Arrays.skip(src, i).Equals(match))
                    return true;
            return false;
        }
    }
}