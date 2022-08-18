//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static ConcurrentBag<T> bag<T>()
            => new();
    }
}