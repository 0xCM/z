//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Between]
        public readonly struct Between<T> : IFunc<T,T,T,bit>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly bit Invoke(T x, T a, T b)
                => gmath.between(x,a,b);
        }
    }
}