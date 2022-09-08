//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        /// <summary>
        /// Inverts an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Toggle, Closures(AllNumeric)]
        public static T toggle<T>(T src, int pos)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return toggle_u(src,pos);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return toggle_i(src,pos);
            else
                return toggle_f(src,pos);
        }

        [MethodImpl(Inline)]
        static T toggle_i<T>(T src, int pos)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(bits.toggle(int8(src), pos));
            else if(typeof(T) == typeof(short))
                 return generic<T>(bits.toggle(int16(src), pos));
            else if(typeof(T) == typeof(int))
                 return generic<T>(bits.toggle(int32(src), pos));
            else
                 return generic<T>(bits.toggle(int64(src), pos));
        }

        [MethodImpl(Inline)]
        static T toggle_u<T>(T src, int pos)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                 return generic<T>(bits.toggle(uint8(src), pos));
            else if(typeof(T) == typeof(ushort))
                 return generic<T>(bits.toggle(uint16(src), pos));
            else if(typeof(T) == typeof(uint))
                 return generic<T>(bits.toggle(uint32(src), pos));
            else
                 return generic<T>(bits.toggle(uint64(src), pos));
        }

        [MethodImpl(Inline)]
        static T toggle_f<T>(T src, int pos)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return generic<T>(bits.toggle(float32(src), pos));
            else if(typeof(T) == typeof(double))
                 return generic<T>(bits.toggle(float64(src), pos));
            else
                throw no<T>();
        }
    }
}