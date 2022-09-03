//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct SpanClaims : ICheckSpans
    {
        public static void eq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : unmanaged
                => iter(a,b, (a,b) => NumericClaims.eq(a,b));

        public static void eq<T>(Span<T> a, Span<T> b)
            where T : unmanaged
                => iter(a,b, (a,b) => NumericClaims.eq(a,b));

        public static void eq<N,T>(NatSpan<N,T> a, NatSpan<N,T> b)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => eq(a.Edit, b.Edit);

       public static void eq<M,N,T>(TableSpan<M,N,T> a, TableSpan<M,N,T> b)
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
            where T : unmanaged
                => eq(a.Data, b.Data);
   }
}