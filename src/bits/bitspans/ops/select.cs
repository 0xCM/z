//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static BitSpan select(in BitSpan a, in BitSpan b, in BitSpan c, in BitSpan z)
        {
            var tmp = alloc(z.BitCount);
            not(a, tmp);
            and(a, b, z);
            and(tmp, c, tmp);
            or(z, tmp, z);
            return z;
        }

        /// <summary>
        /// Computes the ternary select s := a ? b : c = (a & b) | (~a & c)
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [Op]
        public static BitSpan select(in BitSpan a, in BitSpan b, in BitSpan c)
            => select(a, b, c, alloc(c.BitCount));
    }
}