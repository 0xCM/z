//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        public static Index<T> SelectMany<S,T>(this Index<S> source, Func<S,IEnumerable<T>> selector)
            => Enumerable.SelectMany(source,selector).ToArray();
    }
}