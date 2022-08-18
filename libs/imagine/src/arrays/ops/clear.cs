//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] clear<T>(T[] src)
        {
            if(src.Length !=0)
                Array.Clear(src,0,src.Length);
            return src;
        }
    }
}