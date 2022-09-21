//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    //using System.Linq;

    partial class XTend
    {
       [Op, Closures(Closure)]
        public static bool Contains<T>(this T[] src, T match)
            => src.ToHashSet().Contains(match);
    }
}