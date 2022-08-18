//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Computes the length of the interval by finding the magnitude of the difference
        /// between its left/right endpoints
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <typeparam name="T">The primal numeric type over which the interval is defined</typeparam>
        [MethodImpl(Inline)]
        public static T Length<T>(this Interval<T> src)
            where T : unmanaged
                => gcalc.length(src);
    }
}