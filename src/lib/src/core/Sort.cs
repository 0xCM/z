//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Index<T> Sort<T,C>(this Index<T> src, C comparer)
            where C : IComparer<T>
        {
            System.Array.Sort(src,comparer);
            return src;
        }
    }
}