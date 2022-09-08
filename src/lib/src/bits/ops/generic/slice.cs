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
        /// Extracts a contiguous range of source bits beginning at a specified index
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="start">The bit position  within the source where extraction should begin</param>
        /// <param name="length">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice, Closures(Integers)]
        public static T slice<T>(T src, byte start, byte length)
            where T : unmanaged
                => bitslice_u(src,start, length);

        [MethodImpl(Inline)]
        static T bitslice_u<T>(T lhs, byte start, byte length)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.slice(uint8(lhs), start, length));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.slice(uint16(lhs), start, length));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.slice(uint32(lhs), start, length));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.slice(uint64(lhs), start, length));
            else
                return bitslice_i(lhs,start,length);
        }

        [MethodImpl(Inline)]
        static T bitslice_i<T>(T lhs, byte start, byte length)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(bits.slice(int8(lhs), start, length));
            else if(typeof(T) == typeof(short))
                return generic<T>(bits.slice(int16(lhs), start, length));
            else if(typeof(T) == typeof(int))
                return generic<T>(bits.slice(int32(lhs), start, length));
            else if(typeof(T) == typeof(long))
                return generic<T>(bits.slice(int64(lhs), start, length));
            else
                throw no<T>();
        }
    }
}