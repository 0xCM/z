//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;


    partial class XTend
    {
        [Op, Closures(Closure)]
        public static Multiset<T> ToMultiset<T>(this IEnumerable<T> src)
            => new Multiset<T>(src);

        [Op, Closures(Closure)]
        public static Multiset<T> ToMulitset<T>(this T[] src)
            => new Multiset<T>(src);

        [Op, Closures(Closure)]
        public static Multiset<T> ToMulitset<T>(this Index<T> src)
            => new Multiset<T>(src);
    }
}