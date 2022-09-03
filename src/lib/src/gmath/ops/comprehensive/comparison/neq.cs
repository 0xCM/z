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
        /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Neq, Closures(AllNumeric)]
        public static bit neq<T>(T a, T b)
            where T : unmanaged
                => neq_u(a,b);

        [MethodImpl(Inline)]
        static bit neq_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.neq(uint8(a), uint8(b));
            else if(typeof(T) == typeof(ushort))
                return math.neq(uint16(a), uint16(b));
            else if(typeof(T) == typeof(uint))
                return math.neq(uint32(a), uint32(b));
            else if(typeof(T) == typeof(ulong))
                return math.neq(uint64(a), uint64(b));
            else
                return neq_i(a,b);
        }

        [MethodImpl(Inline)]
        static bit neq_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return math.neq(int8(a), int8(b));
            else if(typeof(T) == typeof(short))
                 return math.neq(int16(a), int16(b));
            else if(typeof(T) == typeof(int))
                 return math.neq(int32(a), int32(b));
            else if(typeof(T) == typeof(long))
                 return math.neq(int64(a), int64(b));
            else
                return gfp.neq(a,b);
        }
    }
}