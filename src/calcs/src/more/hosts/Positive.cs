//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Positive]
        public readonly struct PositiveOp<T> : IFunc<T,bit>, IUnarySpanPred<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(T a)
                => gmath.positive(a);

            [MethodImpl(Inline)]
            public Span<bit> Invoke(ReadOnlySpan<T> src, Span<bit> dst)
                => gcalc.apply(this, src, dst);
        }
    }
}