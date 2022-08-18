//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class BitPack32
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T pack<T>(Span<Bit32> src, T t = default)
            where T : unmanaged
                => pack_u<T>(src);

        [MethodImpl(Inline)]
        static T pack_u<T>(Span<Bit32> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(pack(src, n8));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(pack(src, n16));
            else if(typeof(T) == typeof(uint))
                return generic<T>(pack(src, n32));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(pack(src, n64));
            else
                return pack_i<T>(src);
        }

        [MethodImpl(Inline)]
        static T pack_i<T>(Span<Bit32> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return Numeric.force<T>(pack(src, n8));
            else if(typeof(T) == typeof(short))
                return Numeric.force<T>(pack(src, n16));
            else if(typeof(T) == typeof(int))
                return Numeric.force<T>(pack(src, n32));
            else if(typeof(T) == typeof(long))
                return Numeric.force<T>(pack(src, n64));
            else
                throw no<T>();
        }

        /// <summary>
        /// Packs the leading 8 source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        [MethodImpl(Inline), Op]
        public static byte pack(Span<Bit32> src, N8 count)
        {
            var v0 = cpu.vload(w256, first(convert(src, 0, width<byte>(w8))));
            return (byte)vpack.vpacklsb(vpack.vpack128x8u(v0));
        }

        /// <summary>
        /// Packs the 16 leading source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        [MethodImpl(Inline), Op]
        public static ushort pack(Span<Bit32> src, N16 count)
        {
            ref readonly var unpacked = ref first(convert(src, 0, width<ushort>(w8)));
            var buffer = z16;
            return BitPack.pack1x16(unpacked, ref buffer);
        }

        /// <summary>
        /// Packs the 32 leading source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        [MethodImpl(Inline), Op]
        public static uint pack(Span<Bit32> src, N32 count)
        {
            ref readonly var unpacked = ref first(convert(src, 0, width<uint>(w8)));
            var buffer = z32;
            return BitPack.pack1x32(unpacked, ref buffer);
        }

        /// <summary>
        /// Packs the 64 leading source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        [MethodImpl(Inline), Op]
        public static ulong pack(Span<Bit32> src, N64 count)
        {
            ref readonly var unpacked = ref first(convert(src, 0, width<ulong>(w8)));
            var buffer = z64;
            return BitPack.pack64x1(unpacked, ref buffer);
        }

        [MethodImpl(Inline)]
        static Span<uint> convert(Span<Bit32> src, int offset, int count)
           => src.Slice(offset, count).Recover<Bit32,uint>();
    }
}