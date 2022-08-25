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
        /// Extracts mask-identified bits from the source and deposits the result to the contiguous low bits of a zero-initialied target
        /// </summary>
        /// <param name="src">The source vale</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Gather, Closures(Closure)]
        public static T gather<T>(T src, T mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.gather(uint8(src), uint8(mask)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.gather(uint16(src), uint16(mask)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.gather(uint32(src), uint32(mask)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.gather(uint64(src), uint64(mask)));
            else
                throw no<T>();
        }
    }
}