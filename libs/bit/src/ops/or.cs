//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        /// <summary>
        /// Computes c = a | b
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline), Op]
        public static bit or(bit a, bit b)
            => new bit(a.State | b.State);
    }
}