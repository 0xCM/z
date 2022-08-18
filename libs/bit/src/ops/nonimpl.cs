//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        /// <summary>
        /// Computes the nonimplication c := a < -- b := ~(a | ~b) = ~a & b
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), NonImpl]
        public static bit nonimpl(bit a, bit b)
            => and(not(a),  b);
    }
}