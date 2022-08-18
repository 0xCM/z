//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static T[] Skip<T>(this T[] src, int count)
            => Enumerable.Skip(src, count).ToArray();
    }
}