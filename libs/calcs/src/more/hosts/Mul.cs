//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Mul]
        public readonly struct Mul<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a, T b)
                => gmath.mul(a, b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
                => Calcs.mul(a,b,dst);
        }
    }
}