//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using BL = math;

    partial class gbits
    {
        [MethodImpl(Inline), Not, Closures(Integers)]
        public static T not<T>(T a)
            where T : unmanaged
                => not_u(a);

        [MethodImpl(Inline)]
        static T not_u<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(BL.not(uint8(a)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(BL.not(uint16(a)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(BL.not(uint32(a)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(BL.not(uint64(a)));
            else
                return not_i(a);
        }

        [MethodImpl(Inline)]
        static T not_i<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(BL.not(int8(a)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(BL.not(int16(a)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(BL.not(int32(a)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(BL.not(int64(a)));
            else
                throw no<T>();
        }
    }
}