//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static T Reduce<M,N,T>(this TableSpan<M,N,T> src, Func<T,T,T> f)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.Data.ReadOnly().Reduce(f);

        /// <summary>
        /// Fills a tabular span of natural dimensions with streamed elements
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="M">The row dimension type</typeparam>
        /// <typeparam name="N">The column dimension type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static void StreamTo<M,N,T>(this IEnumerable<T> src, in TableSpan<M,N,T> dst)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => src.Take((uint)NatCalc.mul<M,N>()).StreamTo(dst.Data);
    }
}