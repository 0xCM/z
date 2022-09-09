//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> defer<T>(IEnumerable<T> src)
            => Deferrals.defer(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> defer<T>()
            => new Deferred<T>(sys.empty<T>());
   }
}