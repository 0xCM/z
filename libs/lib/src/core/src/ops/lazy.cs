//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Lazy<T> lazy<T>(Func<T> f)
            => new Lazy<T>(f);
    }
}