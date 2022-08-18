//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BitPack
    {
        public static byte scalar(string src, out byte dst)
        {
            var storage = ByteBlock8.Empty;
            var buffer = recover<bit>(storage.Bytes);
            dst = 0;
            var count = BitParser.parse(src, buffer);
            if(count >= 0)
                dst = scalar<byte>(buffer);
            return (byte)count;
        }

        public static byte scalar(string src, out ushort dst)
        {
            var storage = ByteBlock16.Empty;
            var buffer = recover<bit>(storage.Bytes);
            dst = 0;
            var count = BitParser.parse(src, buffer);
            if(count >= 0)
                dst = scalar<ushort>(buffer);
            return (byte)count;
        }

        /// <summary>
        /// Packs a section of bits into a scalar
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        /// <param name="offset">The index of the first bit </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T scalar<T>(ReadOnlySpan<bit> src, int offset = 0, int? count = null)
            where T : unmanaged
        {
            var len = min((count == null ? (int)width<T>() : count.Value), src.Length - offset);
            return scalar<T>(core.slice(src,offset, len));;
        }

        /// <summary>
        /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T scalar<T>(ReadOnlySpan<bit> src)
            where T : unmanaged
        {
            var dst = default(T);
            if(src.Length == 0)
                return dst;
            return pack(src, ref dst);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static ref T pack<T>(ReadOnlySpan<bit> src, ref T dst)
            where T : unmanaged
        {
            pack(recover<bit,byte>(src),0u, out dst);
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static ref T pack<T>(ReadOnlySpan<byte> src, uint offset, out T dst)
            where T : unmanaged
        {
            dst = default;
            var buffer = bytes(dst);
            pack(src, offset, ref first(buffer));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        static void pack(ReadOnlySpan<byte> src, uint offset, ref byte dst)
        {
            const byte M = 8;
            var count = src.Length;
            var kIn = (uint)(count - offset);
            var kOut = kIn/M + (kIn % M == 0 ? 0 : 1);
            for(int i=0, j=0; j<kOut; i+=M, j++)
            {
                ref var b = ref seek(dst, j);
                for(var k=0; k<M; k++)
                {
                    var srcIx = i + k + offset;
                    if(srcIx < kIn && skip(src, srcIx) != 0)
                        b |= (byte)(1 << k);
                }
            }
        }
    }
}