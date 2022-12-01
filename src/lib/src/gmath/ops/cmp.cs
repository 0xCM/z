//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gmath
    {
        /// <summary>
        /// Compares two operands via their <see cref='IComparable'> implementations
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Eq, Closures(AllNumeric)]
        public static int cmp<T>(T a, T b)
            where T : unmanaged
                => cmp_u(a,b);

        [MethodImpl(Inline)]
        static int cmp_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.cmp(uint8(a), uint8(b));
            else if(typeof(T) == typeof(ushort))
                return math.cmp(uint16(a), uint16(b));
            else if(typeof(T) == typeof(uint))
                return math.cmp(uint32(a), uint32(b));
            else if(typeof(T) == typeof(ulong))
                return math.cmp(uint64(a), uint64(b));
            else
                return cmp_i(a,b);
        }

        [MethodImpl(Inline)]
        static int cmp_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return math.cmp(int8(a), int8(b));
            else if(typeof(T) == typeof(short))
                 return math.cmp(int16(a), int16(b));
            else if(typeof(T) == typeof(int))
                 return math.cmp(int32(a), int32(b));
            else if(typeof(T) == typeof(long))
                 return math.cmp(int64(a), int64(b));
             else
                return gfp.cmp(a,b);
       }
    }
}