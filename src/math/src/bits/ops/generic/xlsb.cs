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
        /// Extracts the least set source bit and is logically equivalent to the composite operation (-src) & src
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T xlsb<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.xlsb(uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.xlsb(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.xlsb(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.xlsb(uint64(src)));
            else
                throw no<T>();
        }
    }
}