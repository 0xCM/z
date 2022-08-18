//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public static class XCalc
    {
        /// <summary>
        /// Reduces a stream to a single value via an additive monoid
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The stream element type</typeparam>
        [MethodImpl(Inline)]
        public static T Accumulate<T>(this ReadOnlySpan<T> src)
            where T : struct, IAdditiveMonoid<T>
        {
            var accumulate = default(T).Zero;
            var count = src.Length;
            for(var i=0u; i<count; i++)
                accumulate = accumulate.Add(skip(src,i));
            return accumulate;
        }

        /// <summary>
        /// Reduces a stream to a single value via a multiplicative monoid
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The stream element type</typeparam>
        [MethodImpl(Inline)]
        public static T Multiply<T>(this ReadOnlySpan<T> src)
            where T : unmanaged, IMultiplicativeMonoid<T>
        {
            var accumulate = default(T).One;
            foreach(var item in src)
                accumulate = accumulate.Mul(item);
            return accumulate;
        }
    }
}