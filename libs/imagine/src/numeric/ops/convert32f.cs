//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Numeric
    {
        [MethodImpl(Inline)]
        static T convert32f_u<T>(float src)
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(ScalarCast.uint8(src));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(ScalarCast.uint16(src));
            else if(typeof(T) == typeof(uint))
                return generic<T>(ScalarCast.uint32(src));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(ScalarCast.uint64(src));
            else
                return convert32f_i<T>(src);
        }

        [MethodImpl(Inline)]
        static T convert32f_i<T>(float src)
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(ScalarCast.int8(src));
            else if(typeof(T) == typeof(short))
                return generic<T>(ScalarCast.int16(src));
            else if(typeof(T) == typeof(int))
                return generic<T>(ScalarCast.int32(src));
            else if(typeof(T) == typeof(long))
                return generic<T>(ScalarCast.int64(src));
            else
                return convert32f_x<T>(src);
        }

        [MethodImpl(Inline)]
        static T convert32f_x<T>(float src)
        {
            if(typeof(T) == typeof(float))
                return generic<T>((float)src);
            else if(typeof(T) == typeof(double))
                return generic<T>((double)src);
            else if(typeof(T) == typeof(char))
                return generic<T>((char)(int)src);
            else
                return no<float,T>();
        }
    }
}