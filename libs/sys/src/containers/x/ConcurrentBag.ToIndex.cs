//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Index<T> ToIndex<T>(this ConcurrentBag<T> src)
            => src.ToArray();
    }
}