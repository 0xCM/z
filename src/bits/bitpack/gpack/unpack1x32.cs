//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gpack
    {
        /// <summary>
        /// Unpacks each primal source bit to a 32-bit target
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The bit target</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void unpack1x32<T>(T src, Span<uint> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                Bitfields.unpack8x32(uint8(src), dst);
            else if(typeof(T) == typeof(ushort))
                BitPack.unpack1x16x32(uint16(src), dst);
            else if(typeof(T) == typeof(uint))
                BitPack.unpack1x32x32(uint32(src), dst);
            else if(typeof(T) == typeof(ulong))
                BitPack.unpack1x64x32(uint64(src), dst);
            else
                throw no<T>();
        }

        /// <summary>
        /// Unpacks each primal source bit to a 32-bit target
        /// </summary>
        /// <param name="src">The packed bit source</param>
        /// <param name="dst">The unpacked bit target</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void unpack1x32<T>(ReadOnlySpan<T> src, in SpanBlock256<uint> dst)
            where T : unmanaged
        {
            var blockcount = dst.BlockCount;
            var bytes = src.Bytes();
            ref readonly var input = ref first(bytes);
            for(var block=0; block<blockcount; block++)
                Bitfields.unpack8x32(skip(input, block), dst.CellBlock(block));
        }

        /// <summary>
        /// Unpacks each primal source bit to a 32-bit blocked target
        /// </summary>
        /// <param name="src">The packed bit source</param>
        /// <param name="dst">The unpacked bit target</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void unpack1x32<T>(ReadOnlySpan<T> src, in SpanBlock256<uint> dst, int block)
            where T : unmanaged
        {
            const int blocklen = 8;
            const int blockcount = 1;
            unpack1x32(skip(src, block), dst.CellBlock(block));
        }

        /// <summary>
        /// Unpacks each primal source bit to a 32-bit target
        /// </summary>
        /// <param name="src">The packed bit source</param>
        /// <param name="dst">The unpacked bit target</param>
        [MethodImpl(Inline)]
        public static void unpack1x32<T>(Span<T> src, in SpanBlock256<uint> dst)
            where T : unmanaged
                => unpack1x32(src.ReadOnly(),dst);

        /// <summary>
        /// Unpacks each primal source bit to a 32-bit blocked target
        /// </summary>
        /// <param name="src">The packed bit source</param>
        /// <param name="dst">The unpacked bit target</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline)]
        public void unpack1x32<T>(Span<T> src, in SpanBlock256<uint> dst, int block)
            where T : unmanaged
                => unpack1x32(src.ReadOnly(), dst, block);
    }
}