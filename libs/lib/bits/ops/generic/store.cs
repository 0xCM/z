//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T store<T>(in T src, byte min, byte max, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
            {
                ref var target = ref dst;
                target = @as<byte,T>(bits.store(u8(src), min, max, ref uint8(ref dst)));
                return ref dst;
            }
            else if(typeof(T) == typeof(ushort))
            {
                ref var target = ref dst;
                target = @as<ushort,T>(bits.store(u16(src), min, max, ref uint16(ref dst)));
                return ref dst;
            }
            else if(typeof(T) == typeof(uint))
            {
                ref var target = ref dst;
                target = @as<uint,T>(bits.store(u32(src), min, max, ref uint32(ref dst)));
                return ref dst;
            }
            else if(typeof(T) == typeof(ulong))
            {
                ref var target = ref dst;
                target = @as<ulong,T>(bits.store(u64(src), min, max, ref uint64(ref dst)));
                return ref dst;
            }
            else
                throw no<T>();
         }
    }
}