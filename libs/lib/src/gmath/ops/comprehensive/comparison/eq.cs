//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gmath
    {
        /// <summary>
        /// Defines the test eq:bit := a == b, succeeding if numeric equality holds between the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Eq, Closures(AllNumeric)]
        public static bit eq<T>(T a, T b)
            where T : unmanaged
                => eq_u(a,b);

        [MethodImpl(Inline)]
        static bit eq_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.eq(uint8(a), uint8(b));
            else if(typeof(T) == typeof(ushort))
                return math.eq(uint16(a), uint16(b));
            else if(typeof(T) == typeof(uint))
                return math.eq(uint32(a), uint32(b));
            else if(typeof(T) == typeof(ulong))
                return math.eq(uint64(a), uint64(b));
            else
                return eq_i(a,b);
        }

        [MethodImpl(Inline)]
        static bit eq_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return math.eq(int8(a), int8(b));
            else if(typeof(T) == typeof(short))
                 return math.eq(int16(a), int16(b));
            else if(typeof(T) == typeof(int))
                 return math.eq(int32(a), int32(b));
            else if(typeof(T) == typeof(long))
                 return math.eq(int64(a), int64(b));
             else
                return gfp.eq(a,b);
       }
    }
}