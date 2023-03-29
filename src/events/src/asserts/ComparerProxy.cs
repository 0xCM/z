//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ComparerProxy<T> : IComparer<T>
        where T : unmanaged
    {
        readonly Func<T,T,int> Fx;

        [MethodImpl(Inline)]
        public ComparerProxy(Func<T,T,int> comparer)
            => Fx = comparer;

        [MethodImpl(Inline)]
        public int Compare(T x, T y)
            => Fx(x,y);
    }
}