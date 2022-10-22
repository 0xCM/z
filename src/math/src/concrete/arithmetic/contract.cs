//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Evenly projects points from the interval [0,2^31 - 1] onto the interval [0,max)
        /// See https://github.com/lemire/fastrange/blob/master/fastrange.h
        /// </summary>
        /// <param name="src">The value to contract</param>
        /// <param name="max">The maximum value in the target interval</param>
        [MethodImpl(Inline), Op]
        public static uint contract(uint src, uint max)
            => (uint)(((ulong)src * (ulong)max) >> 32);

        /// <summary>
        /// Evenly projects points from the interval [0,2^63 - 1] onto the interval [0,max)
        /// See https://github.com/lemire/fastrange/blob/master/fastrange.h
        /// </summary>
        /// <param name="src">The value to contract</param>
        /// <param name="max">The maximum value in the target interval</param>
        [MethodImpl(Inline), Op]
        public static ulong contract(ulong src, ulong max)
            => UInt128.mulhi(src,max);
    }
}