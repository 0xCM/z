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
        /// Defines the test lt:bit := a <= b, succeeding if the first operand is smaller than or equal to the second
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), LtEq, Closures(AllNumeric)]
        public static bit lteq<T>(T a, T b)
            where T : unmanaged
                => lteq_u(a,b);

        [MethodImpl(Inline)]
        static bit lteq_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.le(force<T,uint>(a), force<T,uint>(b));
            else if(typeof(T) == typeof(ushort))
                return math.le(force<T,uint>(a), force<T,uint>(b));
            else if(typeof(T) == typeof(uint))
                return math.le(uint32(a), uint32(b));
            else if(typeof(T) == typeof(ulong))
                return math.le(uint64(a), uint64(b));
            else
                return lteq_i(a,b);
        }

        [MethodImpl(Inline)]
        static bit lteq_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return math.le(force<T,int>(a), force<T,int>(b));
            else if(typeof(T) == typeof(short))
                return math.le(force<T,int>(a), force<T,int>(b));
            else if(typeof(T) == typeof(int))
                 return math.le(int32(a), int32(b));
            else if(typeof(T) == typeof(long))
                 return math.le(int64(a), int64(b));
            else
                return gfp.lteq(a,b);
        }
    }
}