//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric)]
        public readonly struct Dist<T> : IFunc<T,T,ulong>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ulong Invoke(T a, T b)
                => gmath.dist(a,b);
        }
    }
}