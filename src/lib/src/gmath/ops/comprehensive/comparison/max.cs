//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gmath
    {
        [MethodImpl(Inline), Max, Closures(AllNumeric)]
        public static T max<T>(T a, T b)
            where T : unmanaged
                => max_u(a,b);

        /// <summary>
        /// Finds a numeric cell of maximal value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Max, Closures(AllNumeric)]
        public static T max<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            if(count == 0)
                return default;

            ref readonly var a = ref first(src);
            var result = a;
            for(var i=1; i<count; i++)
            {
                ref readonly var test = ref skip(a, i);
                if(gt(test, result))
                    result = test;
            }
            return result;
        }

        [MethodImpl(Inline)]
        static T max_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.max(uint8(a), uint8(b)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.max(uint16(a), uint16(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.max(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.max(uint64(a), uint64(b)));
            else
                return max_i(a,b);
        }

        [MethodImpl(Inline)]
        static T max_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.max(int8(a), int8(b)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.max(int16(a), int16(b)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.max(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.max(int64(a), int64(b)));
            else
                return gfp.max(a,b);
        }
    }
}
