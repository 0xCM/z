//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op, Closures(Closure)]
        public static bool Contains<T>(this Index<T> src, T match)
            => src.ToHashSet().Contains(match);
    }
}