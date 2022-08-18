//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline)]
        public static T[] sort<T>(T[] src)
            where T : IComparable<T>
        {
            if(src.Length != 0)
                Array.Sort(src);
            return src;
        }

        [MethodImpl(Inline)]
        public static T[] sort<T>(T[] src, IComparer<T> comparer)
        {
            Array.Sort(src,comparer);
            return src;
        }
    }
}