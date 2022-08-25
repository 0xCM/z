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
        /// Logically equivalent to the composite operation (src-1) ^ src that enables the
        /// lower bits of the source up to and including the least set bit
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T blsi<T>(T src)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return generic<T>(bits.blsi(uint8(src)));
            else if(size<T>() == 2)
                return generic<T>(bits.blsi(uint16(src)));
            else if(size<T>() == 4)
                return generic<T>(bits.blsi(uint32(src)));
            else if(size<T>() == 8)
                return generic<T>(bits.blsi(uint64(src)));
            else
                throw no<T>();
        }
    }
}