//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gmath
    {
        [MethodImpl(Inline), Max, Closures(AllNumeric)]
        public static T max<T>(T a, T b)
            where T : unmanaged
                => max_u(a,b);

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
