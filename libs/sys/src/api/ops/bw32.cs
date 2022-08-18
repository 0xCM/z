//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 32
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static uint bw32<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return u32(src);
            else
                return (uint)u64(src);
        }

        [MethodImpl(Inline), Op]
        public static int bw32i(ReadOnlySpan<byte> src)
        {
            var storage = 0;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static uint bw32u(ReadOnlySpan<byte> src)
        {
            var storage = 0u;
            ref var dst = ref @as<byte>(storage);
            var count = Math.Min(4,src.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
            return storage;
        }

    }
}