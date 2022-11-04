//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct Calcs
    {
        const NumericKind Closure = Integers;

        public static ResultCode run<S,T>(Computation<S,T> comp, in S src, out T dst)
            => comp.Compute(src, out dst);

        public static ResultCode run<S,T>(Computation<S,T> comp, ReadOnlySpan<S> src, Span<T> dst)
            => comp.Compute(src, dst);
    }
}