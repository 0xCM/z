//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        [Op,Closures(Closure)]
        public static T[] where<T>(T[] src, Func<T,bool> predicate)
            => from x in src where predicate(x) select x;
    }
}