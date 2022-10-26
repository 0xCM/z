//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 64
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ulong bw64<T>(T src)
            where T : unmanaged
        {
            if(Sized.width<T>() == 8)
                return sys.u8(src);
            if(Sized.width<T>() == 16)
                return sys.u16(src);
            else if(Sized.width<T>() == 32)
                return sys.u32(src);
            else
                return sys.u64(src);
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static long bw64i<T>(T src)
            where T : unmanaged
        {
            if(Sized.width<T>() == 8)
                return sys.i8(src);
            if(Sized.width<T>() == 16)
                return sys.i16(src);
            else if(Sized.width<T>() == 32)
                return sys.i32(src);
            else
                return sys.i64(src);
        }

        [MethodImpl(Inline), Op]
        public static long bw64i(ReadOnlySpan<byte> src)
        {
            var storage = z64i;
            ref var dst = ref sys.@as<byte>(storage);
            var count = min(8,src.Length);
            for(var i=0; i<count; i++)
                sys.seek(dst,i) = sys.skip(src,i);
            return storage;
        }

        [MethodImpl(Inline), Op]
        public static ulong bw64u(ReadOnlySpan<byte> src)
        {
            var storage = z64;
            ref var dst = ref sys.@as<byte>(storage);
            var count = min(8,src.Length);
            for(var i=0; i<count; i++)
                sys.seek(dst,i) = sys.skip(src,i);
            return storage;
        }
    }
}