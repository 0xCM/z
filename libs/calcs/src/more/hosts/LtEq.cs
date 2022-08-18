//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric), LtEq]
        public readonly struct LtEq<T> : IFunc<T,T,bit>, IBinarySpanPred<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(T x, T y)
                => gmath.lteq(x,y);

            [MethodImpl(Inline)]
            public Span<bit> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<bit> dst)
                => gcalc.apply(this, a,b,dst);
        }
    }
}