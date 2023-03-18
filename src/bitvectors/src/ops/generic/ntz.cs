//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitVectors
    {
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