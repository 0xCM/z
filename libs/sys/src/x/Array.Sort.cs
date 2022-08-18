//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static T[] Sort<T>(this T[] src)
            where T : IComparable<T>
        {
            System.Array.Sort(src);
            return src;
        }

        public static T[] Sort<T,C>(this T[] src, C comparer)
            where C : IComparer<T>
        {
            System.Array.Sort(src,comparer);
            return src;
        }
    }
}