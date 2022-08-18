//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Intervals
    {
        /// <summary>
        /// Determines whether a test point is within an interval defined by inclusive lower/upper bounds
        /// </summary>
        /// <param name="src">The point to test</param>
        /// <param name="min">The inclusive lower bound</param>
        /// <param name="max">The inclusive upper bound</param>
        [MethodImpl(Inline), Op]
        public static bool between(ulong src, ulong min, ulong max)
            => src >= min && src <= max;
    }
}