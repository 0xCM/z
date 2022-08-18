//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = CheckLengths;

    public interface ICheckLengths : IClaimValidator
    {
        int length<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            => api.length(a, b);

        int length<T>(T[] lhs, T[] rhs)
             => api.length(lhs, rhs);

        int length<T>(Span<T> lhs, Span<T> rhs)
            => api.length(lhs, rhs);
    }
}
