//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Delegates
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Producer<T> producer<T>(System.Func<T> f)
            => new Producer<T>(f);

        [MethodImpl(Inline)]
        public static Producer<T,C> producer<T,C>(System.Func<T> f)
            where T : unmanaged
            where C : unmanaged
                => new Producer<T,C>(f);
    }
}