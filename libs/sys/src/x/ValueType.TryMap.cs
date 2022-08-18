//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static Y? TryMap<X,Y>(this X? x, Func<X,Y> f)
            where X : struct
            where Y : struct
                => x.HasValue ? f(x.Value) : (Y?)null;
    }
}