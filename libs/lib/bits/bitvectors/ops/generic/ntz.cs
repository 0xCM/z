//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class BitVectors
    {
        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz, Closures(Closure)]
        public static T ntz<T>(in ScalarBits<T> x)
            where T : unmanaged
                => gbits.ntz(x.State);

        /// <summary>
        /// Counts the number of trailing zero bits
        /// </summary>
        [MethodImpl(Inline)]
        public static T ntz<N,T>(in ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.ntz(x.State);

        /// <summary>
        /// Counts the number of trailing zeros
        /// </summary>
        [MethodImpl(Inline)]
        public static T ntz<T>(in BitVector128<T> x)
            where T : unmanaged
        {
            var lo = x.Lo;
            if(lo != 0)
                return generic<T>(gbits.ntz(lo.State));
            else
                return generic<T>(gmath.add(gbits.ntz(x.Hi.State), 64ul));
        }
    }
}