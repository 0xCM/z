//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    partial class XTend
    {
        [Op, Closures(Closure)]
        public static ConstSet<T> ToConstSet<T>(this IEnumerable<T> src)
            => new ConstSet<T>(src);

        [Op, Closures(Closure)]
        public static ConstSet<T> ToConstSet<T>(this T[] src)
            => new ConstSet<T>(src);

        [Op, Closures(Closure)]
        public static ConstSet<T> ToConstSet<T>(this Index<T> src)
            => new ConstSet<T>(src);
    }
}
