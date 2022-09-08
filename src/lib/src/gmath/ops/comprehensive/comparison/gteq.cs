//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Numeric;

    partial class gmath
    {
        /// <summary>
        /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="a">The second operand</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), GtEq, Closures(Integers)]
        public static bit gteq<T>(T a, T b)
            where T : unmanaged
                => gteq_u(a,b);

        [MethodImpl(Inline)]
        static bit gteq_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.gteq(force<T,uint>(a), force<T,uint>(b));
            else if(typeof(T) == typeof(ushort))
                return math.gteq(force<T,uint>(a), force<T,uint>(b));
            else if(typeof(T) == typeof(uint))
                return math.gteq(uint32(a), uint32(b));
            else if(typeof(T) == typeof(ulong))
                return math.gteq(uint64(a), uint64(b));
            else
                return gteq_i(a,b);
        }

        [MethodImpl(Inline)]
        static bit gteq_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return math.gteq(force<T,int>(a), force<T,int>(b));
            else if(typeof(T) == typeof(short))
                return math.gteq(force<T,int>(a), force<T,int>(b));
            else if(typeof(T) == typeof(int))
                 return math.gteq(int32(a), int32(b));
            else if(typeof(T) == typeof(long))
                 return math.gteq(int64(a), int64(b));
            else
                return gfp.gteq(a,b);
        }
    }
}