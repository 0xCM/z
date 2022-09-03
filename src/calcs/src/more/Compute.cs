//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Compute
    {
        public static ResultCode run<S,T>(Computation<S,T> comp, in S src, out T dst)
            => comp.Compute(src, out dst);

        public static ResultCode run<S,T>(Computation<S,T> comp, ReadOnlySpan<S> src, Span<T> dst)
            => comp.Compute(src, dst);

        [Op]
        public static ResultCode result(Exception e)
            => new ResultCode(uint.MaxValue);
    }
}