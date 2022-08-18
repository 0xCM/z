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
        [Closures(Integers)]
        public readonly struct ModMul<T> : ITernaryOp<T>, ITernarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a, T b, T m)
                => gmath.modmul(a,b,m);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ReadOnlySpan<T> c, Span<T> dst)
                => Calcs.modmul(a,b,c,dst);
        }
    }
}