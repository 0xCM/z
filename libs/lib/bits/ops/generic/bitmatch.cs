//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        /// <summary>
        /// Determines whether identified bits in the operands agree.
        /// </summary>
        /// <param name="a">The first bit source</param>
        /// <param name="i">The first bit position</param>
        /// <param name="b">The second bit source</param>
        /// <param name="j">The second bit position</param>
        /// <typeparam name="S">The left operand type</typeparam>
        /// <typeparam name="T">The right operand type</typeparam>
        [MethodImpl(Inline)]
        public static bit bitmatch<S,T>(S a, byte i, T b, byte j)
            where S : unmanaged
            where T : unmanaged
                => test(a,i) == test(b,j);
    }
}