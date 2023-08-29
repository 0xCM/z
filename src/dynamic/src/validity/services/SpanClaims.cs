//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct SpanClaims : ICheckSpans
    {
        /// <summary>
        /// Iterates a pair of spans in tandem, invoking a caller-supplied action for each cell pair
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="f">The action to invoke</param>
        /// <typeparam name="S">The cell type of the first operand</typeparam>
        /// <typeparam name="T">The cell type of the second operand</typeparam>
        [MethodImpl(Inline)]
        static void iter<S,T>(Span<S> x, Span<T> y, Action<S,T> f)
        {
            var count = min(x.Length, y.Length);
            for(var i=0u; i<count; i++)
                f(skip(x,i),skip(y,i));
        }

        /// <summary>
        /// Iterates a pair of readonly spans in tandem, invoking a caller-supplied action for each cell pair
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="f">The action to invoke</param>
        /// <typeparam name="S">The cell type of the first operand</typeparam>
        /// <typeparam name="T">The cell type of the second operand</typeparam>
        [MethodImpl(Inline)]
        static void iter<S,T>(ReadOnlySpan<S> x, ReadOnlySpan<T> y, Action<S,T> f)
        {
            var count = min(x.Length, y.Length);
            for(var i=0u; i<count; i++)
                f(skip(x,i),skip(y,i));
        }

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