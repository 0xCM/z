//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public static class PolyPower
    {
        /// <summary>
        /// Produces a random power of 2 within the primal type domain
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T Power<T>(this IBoundSource src, T t = default)
            where T : unmanaged
                => Numeric.force<ulong,T>(Pow2.pow((byte)src.Log2(t)));

        /// <summary>
        /// Produces a random power of 2 with specified min/max exponent values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="minexp">The min exponent value</param>
        /// <param name="maxexp">The max exponent value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T Power<T>(this IBoundSource src, int minexp, int maxexp)
            where T : unmanaged
        {
            var exp = src.Next((byte)minexp, (byte)(maxexp + 1));
            return Numeric.force<ulong,T>(Pow2.pow(exp));
        }

        /// <summary>
        /// Produces a power-of-2 exponent n (i.e. log base 2) such that 2^n < maxvalue[T];
        /// consequently, the exponentiation of the retrieved value will be confiled to
        /// the domain of the type (ignoring sign)
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline)]
        public static int Log2<T>(this IBoundSource src, T t = default)
            where T : unmanaged
                => src.Next(0, (int)width<T>());
    }
}