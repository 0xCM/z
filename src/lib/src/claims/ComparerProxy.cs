//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

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