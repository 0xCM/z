//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric), Square]
        public readonly struct Square<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a)
                => gmath.square(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, Span<T> dst)
                => Calcs.square(src,dst);
        }
    }
}