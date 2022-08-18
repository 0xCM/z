//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
        [MethodImpl(Inline), Op]
        public static void unpack(byte src, Span<bit> dst)
            => unpack(src, ref first(dst));

        /// <summary>
        /// Populates a caller-supplied target with unpacked source bits
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="T">The data source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void unpack<T>(in T src, Span<bit> dst)
            where T : struct
        {
            var count = size<T>();
            ref readonly var input = ref ScalarCast.uint8(ref edit(src));
            for(var i=0u; i<count; i++)
            {
                ref readonly var b8 = ref skip(input,i);
                for(byte j=0; j<8; j++)
                    seek(dst,j) = bit.test(b8,j);
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref bit unpack<T>(in T src, ref bit dst)
            where T : struct
        {
            var count = size<T>();
            ref readonly var input = ref @as<T,byte>(src);
            for(var i=0u; i<count; i++)
            {
                ref readonly var b8 = ref skip(input,i);
                for(byte j=0; j<8; j++)
                    seek(dst, i+j) = bit.test(b8,j);
            }
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ulong unpack(byte src)
        {
            var storage = 0ul;
            ref var dst = ref @as<ulong,bit>(storage);
            seek(dst, 0) = bit.test(skip(src, 0), 0);
            seek(dst, 1) = bit.test(skip(src, 1), 1);
            seek(dst, 2) = bit.test(skip(src, 2), 2);
            seek(dst, 3) = bit.test(skip(src, 3), 3);
            seek(dst, 4) = bit.test(skip(src, 4), 4);
            seek(dst, 5) = bit.test(skip(src, 5), 5);
            seek(dst, 6) = bit.test(skip(src, 6), 6);
            seek(dst, 7) = bit.test(skip(src, 7), 7);
            return storage;
        }
    }
}