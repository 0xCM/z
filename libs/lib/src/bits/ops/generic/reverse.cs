//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        /// <summary>
        /// Reverses the bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <remarks>BAD</remarks>
        [MethodImpl(Inline)]
        public static T reverse<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.reverse(uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.reverse(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.reverse(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.reverse(uint64(src)));
            else
                throw no<T>();
        }
    }
}