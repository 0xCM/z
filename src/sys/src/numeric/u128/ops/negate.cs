//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct UInt128
    {
        /// <summary>
        /// Computes the two's complement of a 128-bit integer
        /// </summary>
        /// <param name="x">The integer, represented via paired hi/lo components</param>
        [MethodImpl(Inline), Negate]
        public static ref UInt128 negate(ref UInt128 x)
        {
            var y = not(x);
            x = add(ref y, (1ul,0ul));
            return ref x;
        }
    }
}