//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class gmath
    {
        /// <summary>
        /// Defines the ternary bitwise select operator over primal unsigned integers,
        /// select(a,b,c) := or(a & b, and(~a, c)) = or(and(a,b), notimpl(a,c));
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Select, Closures(Integers)]
        public static T select<T>(T a, T b, T c)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.select(uint8(a), uint8(b), uint8(c)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.select(uint16(a), uint16(b), uint16(c)));
            else
                return or(and(a,b), nonimpl(a,c));
        }

        /// <summary>
        ///  This operator is equivalent to select, but is implemented xor(b, and(xor(b,a),  mask))
        /// </summary>
        /// <param name="mask">Mask that identifies which of the two source operands to choose a given bit</param>
        /// <param name="a">The first operand, a bit from which is chosen if the corresponding mask bit is enabled</param>
        /// <param name="b">The second operand, a bit from which is chosen if the corresponding mask bit is disabled</param>
        /// <typeparam name="T">The primal type</typeparam>
        /// <remarks>Code generation for this is good; type-specific specializations exist for convenience. Algorithm
        /// taken from https://graphics.stanford.edu/~seander/bithacks.html</remarks>
        [MethodImpl(Inline), Closures(Integers)]
        public static T blend<T>(T a, T b, T mask)
            where T : unmanaged
                => xor(a, and(xor(a,b), mask));
    }
}