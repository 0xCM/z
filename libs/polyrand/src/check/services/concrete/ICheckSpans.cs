//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ICheckSpans : IClaimValidator, ICheckGeneric
    {
        void eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : unmanaged
                => SpanClaims.eq(a,b);

        void eq<T>(Span<T> a, Span<T> b)
            where T : unmanaged
                => SpanClaims.eq(a,b);

        void eq<N,T>(NatSpan<N,T> a, NatSpan<N,T> b)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => SpanClaims.eq(a,b);

       void eq<M,N,T>(TableSpan<M,N,T> a, TableSpan<M,N,T> b)
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
            where T : unmanaged
                => SpanClaims.eq(a,b);
    }
}