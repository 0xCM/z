//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Numeric;

    partial class gmath
    {
        /// <summary>
        /// Defines the test lt:bit := a < b, succeeding if the first operand is smaller than the second
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Lt, Closures(AllNumeric)]
        public static bit lt<T>(T a, T b)
            where T : unmanaged
                => lt_u(a,b);

        [MethodImpl(Inline)]
        static bit lt_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.lt(force<T,uint>(a), force<T,uint>(b));
            else if(typeof(T) == typeof(ushort))
                return math.lt(force<T,uint>(a), force<T,uint>(b));
            else if(typeof(T) == typeof(uint))
                return math.lt(uint32(a), uint32(b));
            else if(typeof(T) == typeof(ulong))
                return math.lt(uint64(a), uint64(b));
            else
                return lt_i(a,b);
        }

        [MethodImpl(Inline)]
        static bit lt_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return math.lt(force<T,int>(a), force<T,int>(b));
            else if(typeof(T) == typeof(short))
                return math.lt(force<T,int>(a), force<T,int>(b));
            else if(typeof(T) == typeof(int))
                 return math.lt(int32(a), int32(b));
            else if(typeof(T) == typeof(long))
                 return math.lt(int64(a), int64(b));
            else
                return gfp.lt(a,b);
        }
    }
}