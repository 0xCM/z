//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using BL = math;

    partial class gbits
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
                return generic<T>(BL.select(uint8(a), uint8(b), uint8(c)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(BL.select(uint16(a), uint16(b), uint16(c)));
            else
                return or(and(a,b), nonimpl(a,c));
        }
    }
}