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
        /// Defines the test between:bit := (x >= min) && (x <= max)
        /// </summary>
        /// <param name="src">The test value</param>
        /// <param name="min">The lower bound</param>
        /// <param name="max">The upper bound</param>
        [MethodImpl(Inline), Between, Closures(AllNumeric)]
        public static bit between<T>(T src, T min, T max)
            where T : unmanaged
                => between_u(src,min,max);

        [MethodImpl(Inline)]
        static bit between_u<T>(T x, T min, T max)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.between(force<T,uint>(x), force<T,uint>(min), force<T,uint>(max));
            else if(typeof(T) == typeof(ushort))
                return math.between(force<T,uint>(x), force<T,uint>(min), force<T,uint>(max));
            else if(typeof(T) == typeof(uint))
                return math.between(uint32(x), uint32(min), uint32(max));
            else if(typeof(T) == typeof(ulong))
                return math.between(uint64(x), uint64(min), uint64(max));
            else
                return between_i(x,min,max);
        }

        [MethodImpl(Inline)]
        static bit between_i<T>(T x, T min, T max)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return math.between(force<T,int>(x), force<T,int>(min), force<T,int>(max));
            else if(typeof(T) == typeof(short))
                return math.between(force<T,int>(x), force<T,int>(min), force<T,int>(max));
            else if(typeof(T) == typeof(int))
                return math.between(int32(x), int32(min), int32(max));
            else if(typeof(T) == typeof(long))
                return math.between(int64(x), int64(min), int64(max));
            else
                return gfp.between(x,min,max);
        }
    }
}