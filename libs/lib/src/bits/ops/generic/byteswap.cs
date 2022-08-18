//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        [MethodImpl(Inline), Byteswap, Closures(UInt16x32x64k)]
        public static T byteswap<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(ushort))
                return generic<T>(bits.byteswap(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.byteswap(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.byteswap(uint64(src)));
            else
                throw no<T>();
        }
    }
}