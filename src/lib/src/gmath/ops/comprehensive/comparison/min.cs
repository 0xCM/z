//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gmath
    {
        [MethodImpl(Inline), Min, Closures(AllNumeric)]
        public static T min<T>(T a, T b)
            where T : unmanaged
                => min_u(a,b);

        /// <summary>
        /// Finds a numeric cell of minimal value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Min, Closures(AllNumeric)]
        public static T min<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            if(count == 0)
                return default;

            ref readonly var a = ref first(src);
            var result = a;
            for(var i = 1; i<count; i++)
            {
                ref readonly var test = ref skip(a, i);
                if(gmath.lt(test, result))
                    result = test;
            }

            return result;
        }

        [MethodImpl(Inline)]
        static T min_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.min(uint8(a), uint8(b)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.min(uint16(a), uint16(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.min(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.min(uint64(a), uint64(b)));
            else
                return min_i(a,b);
        }

        [MethodImpl(Inline)]
        static T min_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.min(int8(a), int8(b)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.min(int16(a), int16(b)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.min(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.min(int64(a), int64(b)));
            else
                return gfp.min(a,b);
        }
    }
}
