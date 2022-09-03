//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static BitMaskLiterals;

    partial class BitGrid
    {
        /// <summary>
        /// Extracts an index-identified 1-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static bit col<T>(BitGrid16<N1,N16,T> g, int index)
            where T : unmanaged
                => (bit)(g.Content & (Lsb16x16x1 << index));

        /// <summary>
        /// Extracts an index-identified 2-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static ScalarBits<N2,byte> col<T>(BitGrid16<N2,N8,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, (uint)(Lsb16x8x1 << index));

        /// <summary>
        /// Extracts an index-identified 8-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, either 0 or 1</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static ScalarBits<N8,byte> col<T>(BitGrid16<N8,N2,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, (uint)(Lsb16x2x1 << index));

        /// <summary>
        /// Extracts an index-identified 4-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...3</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static ScalarBits<N4,byte> col<T>(BitGrid16<N4,N4,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, (uint)(Lsb16x4x1 << index));

        /// <summary>
        /// Extracts an index-identified 1-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static bit col<T>(BitGrid32<N1,N32,T> g, int index)
            where T : unmanaged
                => bits.gather(g, Lsb32x32x1 << index) == 1;

        /// <summary>
        /// Extracts an index-identified 2-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static ScalarBits<N2,byte> col<T>(BitGrid32<N2,N16,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, Lsb32x16x1 << index);

        /// <summary>
        /// Extracts an index-identified 4-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static ScalarBits<N4,byte> col<T>(BitGrid32<N4,N8,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, Lsb32x8x1 << index);

        /// <summary>
        /// Extracts an index-identified 8-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static ScalarBits<N8,byte> col<T>(BitGrid32<N8,N4,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, Lsb32x4x1 << index);

        /// <summary>
        /// Extracts an index-identified 16-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, either 0 or 1</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static ScalarBits<N16,ushort> col<T>(BitGrid32<N16,N2,T> g, int index)
            where T : unmanaged
                => (ushort)bits.gather(g, Lsb32x2x1 << index);

        /// <summary>
        /// Extracts an index-identified 1-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Bit32 col<T>(BitGrid64<N1,N64,T> g, int index)
            where T : unmanaged
                => bits.gather(g, Lsb64x64x1 << index) == 1;

        /// <summary>
        /// Extracts an index-identified 2-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...31</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N2,byte> col<T>(BitGrid64<N2,N32,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, Lsb64x32x1 << index);

        /// <summary>
        /// Extracts an index-identified 4-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...15</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N4,byte> col<T>(BitGrid64<N4,N16,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, Lsb64x16x1 << index);

        /// <summary>
        /// Extracts an index-identified 8-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N8,byte> col<T>(BitGrid64<N8,N8,T> g, int index)
            where T : unmanaged
                => (byte)bits.gather(g, Lsb64x8x1 << index);

        /// <summary>
        /// Extracts an index-identified 16-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...3</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N16,ushort> col<T>(BitGrid64<N16,N4,T> g, int index)
            where T : unmanaged
                => (ushort)bits.gather(g, Lsb64x4x1<< index);

        /// <summary>
        /// Extracts an index-identified 32-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, either 0 or 1</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N32,uint> col<T>(BitGrid64<N32,N2,T> g, int index)
            where T : unmanaged
                => (uint)bits.gather(g, Lsb64x2x1 << index);

        /// <summary>
        /// Presents grid content as a bitvector
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, either 0 or 1</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N64,ulong> col<T>(BitGrid64<N64,N1,T> g, int index)
            where T : unmanaged
                => g.Content;

        /// <summary>
        /// Extracts an index-identified 16-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N16,ushort> col<T>(in BitGrid128<N16,N8,T> g, int index)
            where T : unmanaged
                => gcpu.vmask16u(gcpu.vsll(g.Content, (byte)(7 - index)));

        /// <summary>
        /// Extracts an index-identified 32-bit grid column
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, in the inclusive range 0...7</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ScalarBits<N32,uint> col<T>(in BitGrid256<N32,N8,T> g, int index)
            where T : unmanaged
                => gcpu.vmask32u(gcpu.vsll(g.Content, (byte)(7 - index)));
    }
}