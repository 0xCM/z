//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;
    using static sys;
    using static cpu;

    partial struct Bitfields
    {
        /// <summary>
        /// Packs 4 1-bit values taken from the least significant bit of each 8-bit source segment
        /// </summary>
        [MethodImpl(Inline), Op]
        public static byte pack2x1(ushort src)
            => (byte)bits.gather(src, Lsb32x8x1);

        /// <summary>
        /// Packs 4 1-bit values taken from the least significant bit of each 8-bit source segment
        /// </summary>
        [MethodImpl(Inline), Op]
        public static byte pack4x1(uint src)
            => (byte)bits.gather(src, Lsb32x8x1);

        /// <summary>
        /// Packs 8 1-bit values taken from the least significant bit of each 8-bit source segment
        /// </summary>
        [MethodImpl(Inline), Op]
        public static byte pack8x1(ulong src)
            => (byte)bits.gather(src, Lsb64x8x1);

        /// <summary>
        /// Packs the the leading source bits from 8 32-bit integers into a single 8-bit segment
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target value</param>
        [MethodImpl(Inline), Op]
        public static byte pack8x1(ReadOnlySpan<uint> src)
            => (byte)vpack.vpacklsb(vpack.vpack128x8u(vload(w256, first(src))));

        /// <summary>
        /// Packs 8 1-bit values taken from an index-identified bit of the leading byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The cell-relative bit index from [0,7] </param>
        [MethodImpl(Inline), Op]
        public static byte pack8x1(ReadOnlySpan<byte> src)
            => (byte)pack16x1(cpu.v8u(vscalar(w128,@as<ulong>(src))),0);

        /// <summary>
        /// Packs 16 1-bit values taken from an index-identified bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The cell-relative bit index from [0,7] </param>
        [MethodImpl(Inline), Op]
        public static ushort pack16x1(Cell128 src, byte index)
            => pack16x1(vload(w128,bytes(src)), index);

        /// <summary>
        /// Packs 32 1-bit values taken from an index-identified bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The cell-relative bit index from [0,7] </param>
        [MethodImpl(Inline), Op]
        public static uint pack32x1(ReadOnlySpan<byte> src, byte index)
            => pack32x1(vload(w256,src),index);

        /// <summary>
        /// Packs 64 1-bit values taken from an index-identified bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The cell-relative bit index from [0,7] </param>
        [MethodImpl(Inline), Op]
        public static ulong pack64x1(ReadOnlySpan<byte> src, byte index)
        {
            var a0 = pack32x1(src, index);
            var b0 = pack32x1(slice(src,16), index);
            return join(a0,b0);
        }

        /// <summary>
        /// Packs 64 logical 1-bit values, eqch requiring 8 bits of storage into a 64-bit integer
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static ulong pack64x1(ReadOnlySpan<bit> src)
            => pack64x1(recover<bit,byte>(src), 0);

        [MethodImpl(Inline), Op]
        public static ref byte pack4x2(byte a, byte b, ref byte dst)
        {
            dst = (byte)((a & 0xF) | (b >> 4));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack4x3(byte a0, byte a1, byte a2, ref ushort dst)
        {
            dst = (ushort)((a0 & 0xF) | ((a1 & 0xF0) >> 4)  | ((a2 & 0xF00) >> 8));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack4x4(byte a0, byte a1, byte a2, byte a3, ref ushort dst)
        {
            dst = (ushort)((a0 & 0xF) | ((a1 & 0xF0) >> 4)  | ((a2 & 0xF00) >> 8)  | ((a3 & 0xF000) >> 12));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack8x2(ushort a, ushort b, ref ushort dst)
        {
            dst = (ushort)((a & 0xFF) | (b >> 8));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        static ushort pack16x1(Vector128<byte> src, byte index)
            => cpu.vmovemask(src,index);

        [MethodImpl(Inline), Op]
        static uint pack32x1(Vector256<byte> src, byte index)
            => cpu.vmovemask(src,index);
    }
}