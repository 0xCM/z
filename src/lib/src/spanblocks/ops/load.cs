//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static CellCalcs;

    partial struct SpanBlocks
    {
        /// <summary>
        /// Creates a 8-bit blocked container from 1 8-bit cell
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock8<byte> load(W8 w, byte src)
            => new SpanBlock8<byte>(cover(src,1));

        /// <summary>
        /// Creates a 16-bit blocked container from 1 16-bit cell
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock16<ushort> load(W16 w, ushort src)
            => new SpanBlock16<ushort>(cover(src,1));

        /// <summary>
        /// Creates a 16-bit blocked container from 1 64-bit cell
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock16<ulong> load(W16 n, ulong src)
            => new SpanBlock16<ulong>(cover(src,1));

        /// <summary>
        /// Creates a 32-bit blocked container from 1 64-bit cell
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock32<ulong> load(W32 n, ulong src)
            => new SpanBlock32<ulong>(cover(src,1));

        /// <summary>
        /// Creates a 32-bit blocked container from 4 8-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock32<byte> load(W32 n, byte x0, byte x1, byte x2, byte x3)
        {
            var dst = 0u;
            seek8(dst,0) = x0;
            seek8(dst,1) = x1;
            seek8(dst,2) = x2;
            seek8(dst,3) = x3;
            return new SpanBlock32<byte>(cover(@as<byte>(dst),4));
        }

        /// <summary>
        /// Creates a 32-bit blocked container from 2 16-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock32<ushort> load(W32 n, ushort x0, ushort x1)
            => new SpanBlock32<ushort>(x0,x1);

        /// <summary>
        /// Creates a 32-bit blocked container from 1 32-bit cell
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock32<uint> load(W32 n, uint x0)
            => new SpanBlock32<uint>(x0);

        /// <summary>
        /// Creates a 64-bit blocked container from 8 8-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock64<byte> load(W64 w, byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7)
            => new SpanBlock64<byte>(x0,x1,x2,x3,x4,x5,x6,x7);

        /// <summary>
        /// Creates a 64-bit blocked container from 4 16-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock64<ushort> load(W64 w, ushort x0, ushort x1, ushort x2, ushort x3)
            => new SpanBlock64<ushort>(x0,x1,x2,x3);

        /// <summary>
        /// Creates a 64-bit data block from 2 32-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock64<uint> load(W64 w, uint x0, uint x1)
            => new SpanBlock64<uint>(x0,x1);

        /// <summary>
        /// Creates a 64-bit data block from 1 64-bit cell
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock64<ulong> load(W64 w, ulong x0)
            => new SpanBlock64<ulong>(x0);

        /// <summary>
        /// Creates a 128-bit blocked span from 8-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock128<byte> load(W128 n,
            byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7,
            byte x8, byte x9, byte xA, byte xB, byte xC, byte xD, byte xE, byte xF)
                => new SpanBlock128<byte>(x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,xA,xB,xC,xD,xE,xF);

        /// <summary>
        /// Creates a 128-bit blocked span from 16-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock128<ushort> load(W128 n,
            ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7)
                => new SpanBlock128<ushort>(x0,x1,x2,x3,x4,x5,x6,x7);

        /// <summary>
        /// Creates a 128-bit blocked span from 4 32-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock128<uint> load(W128 n, uint x0, uint x1, uint x2, uint x3)
            => new SpanBlock128<uint>(x0,x1,x2,x3);

        /// <summary>
        /// Creates a 128-bit blocked container from 2 64-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock128<ulong> load(W128 w, ulong x0, ulong x1)
            => new SpanBlock128<ulong>(x0,x1);

        /// <summary>
        /// Creates a 256-bit blocked container from 32 8-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock256<byte> load(W256 w,
            byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7,
            byte x8, byte x9, byte xA, byte xB, byte xC, byte xD, byte xE, byte xF,
            byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17,
            byte x18, byte x19, byte x1A, byte x1B, byte x1C, byte x1D, byte x1E, byte x1F)
                => new SpanBlock256<byte>(x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,xA,xB,xC,xD,xE,xF,
                    x10,x11,x12,x13,x14,x15,x16,x17,x18, x19,x1A,x1B,x1C,x1D,x1E,x1F);

        /// <summary>
        /// Creates a 256-bit blocked container from 16 16-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock256<ushort> load(W256 n,
            ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7,
            ushort x8, ushort x9, ushort xA, ushort xB, ushort xC, ushort xD, ushort xE, ushort xF)
                => new SpanBlock256<ushort>(x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,xA,xB,xC,xD,xE,xF);

        /// <summary>
        /// Creates a 256-bit blocked container from 8 32-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock256<uint> load(W256 n,
            uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7)
                => new SpanBlock256<uint>(x0,x1,x2,x3,x4,x5,x6,x7);

        /// <summary>
        /// Creates a 256-bit blocked container from 4 64-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock256<ulong> load(W256 n, ulong x0, ulong x1, ulong x2, ulong x3)
            => new SpanBlock256<ulong>(x0,x1,x2,x3);

        /// <summary>
        /// Creates a 512-bit blocked container from 8 64-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock512<ulong> load(W512 w, ulong x0, ulong x1, ulong x2, ulong x3, ulong x4, ulong x5, ulong x6, ulong x7)
            => new SpanBlock512<ulong>(x0,x1,x2,x3,x4,x5,x6,x7);

        /// <summary>
        /// Creates a 512-bit blocked container from 16 32-bit cells
        /// </summary>
        [MethodImpl(Inline), Op]
        public static SpanBlock512<uint> load(W512 n,
            uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7,
            uint x8, uint x9, uint xA, uint xB, uint xC, uint xD, uint xE, uint xF)
                => new SpanBlock512<uint>(x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,xA,xB,xC,xD,xE,xF);

        /// <summary>
        /// Loads a specified count of 8-bit blocks from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock8<T> load<T>(W8 w, ref T src, int count)
            where T : unmanaged
                => new SpanBlock8<T>(cover(src, count*blocklength<T>(w)));

        /// <summary>
        /// Loads a specified count of 16-bit blocks from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock16<T> load<T>(W16 w, ref T src, int count)
            where T : unmanaged
                => new SpanBlock16<T>(cover(src, count*blocklength<T>(w)));

        /// <summary>
        /// Loads a specified count of 32-bit block from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock32<T> load<T>(W32 w, ref T src, int count)
            where T : unmanaged
                => new SpanBlock32<T>(cover(src, count*blocklength<T>(w)));

        /// <summary>
        /// Loads a specified count of 64-bit blocks from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock64<T> load<T>(W64 w, ref T src, int count)
            where T : unmanaged
                => new SpanBlock64<T>(cover(src, count*blocklength<T>(w)));

        /// <summary>
        /// Loads a single 128-bit block from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock128<T> load<T>(W128 w, ref T src)
            where T : unmanaged
                => new SpanBlock128<T>(MemoryMarshal.CreateSpan(ref src, blocklength<T>(w)));

        /// <summary>
        /// Loads a specified count of 128-bit blocks from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock128<T> load<T>(W128 w, ref T src, int count)
            where T : unmanaged
                => new SpanBlock128<T>(cover(src, count*blocklength<T>(w)));

        /// <summary>
        /// Loads a single 256-bit block from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock256<T> load<T>(W256 w, ref T src)
            where T : unmanaged
                => new SpanBlock256<T>(new Span<T>(gptr(src), blocklength<T>(w)));

        /// <summary>
        /// Loads a specified count of 256-bit block sfrom a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock256<T> load<T>(W256 w, ref T src, int count)
            where T : unmanaged
                => new SpanBlock256<T>(cover(src, count*blocklength<T>(w)));

        /// <summary>
        /// Loads a single 512-bit blocks from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock512<T> load<T>(W512 w, ref T src)
            where T : unmanaged
                => new SpanBlock512<T>(new Span<T>(gptr(src), blocklength<T>(w)));

        /// <summary>
        /// Loads a specified count of 512-bit blocks from a reference
        /// </summary>
        /// <param name="w">The target block width</param>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The blocked data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SpanBlock512<T> load<T>(W512 w, ref T src, int count)
            where T : unmanaged
                => new SpanBlock512<T>(cover(src, count*blocklength<T>(w)));

        /// <summary>
        /// Loads 8-bit segments from a span, raising an error if said source does not evenly partition
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock8<T> load<T>(W8 w, Span<T> src, int offset = 0)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length - offset))
                Errors.ThrowBadSize(w, src.Length - offset);

            return unsafeload(w, offset == 0 ? src : slice(src,offset));
        }

        /// <summary>
        /// Loads 16-bit segments from a span, raising an error if said source does not evenly partition
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock16<T> load<T>(W16 w, Span<T> src, int offset = 0)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length - offset))
                Errors.ThrowBadSize(w, src.Length - offset);

            return unsafeload(w, offset == 0 ? src : slice(src,offset));
        }

        /// <summary>
        /// Loads 32-bit segments from a span, raising an error if said source does not evenly partition
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock32<T> load<T>(W32 w, Span<T> src, int offset = 0)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length - offset))
                Errors.ThrowBadSize(w, src.Length - offset);

            return unsafeload(w, offset == 0 ? src : slice(src,offset));
        }

        /// <summary>
        /// Loads 64-bit segments from a span, raising an error if said source does not evenly partition
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock64<T> load<T>(W64 w, Span<T> src, int offset = 0)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length - offset))
                Errors.ThrowBadSize(w, src.Length - offset);

            return unsafeload(w, offset == 0 ? src : slice(src,offset));
        }

        /// <summary>
        /// Loads 128-bit segments from a span, raising an error if said source does not evenly partition
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock128<T> load<T>(W128 w, Span<T> src, int offset = 0)
            where T : unmanaged
        {
            if(!aligned<T>(w, src.Length - offset))
                Errors.ThrowBadSize(w, src.Length - offset);

            return unsafeload(w, offset == 0 ? src : slice(src,offset));
        }

        /// <summary>
        /// Loads 256-bit segments from a span, raising an error if said source does not evenly partition
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock256<T> load<T>(W256 w, Span<T> src, int offset = 0)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length - offset))
                Errors.ThrowBadSize(w, src.Length - offset);

            return unsafeload(w,offset == 0 ? src : slice(src,offset));
        }

        /// <summary>
        /// Loads 256-bit segments from a span, raising an error if said source does not evenly partition
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock512<T> load<T>(W512 w, Span<T> src, int offset = 0)
            where T : unmanaged
        {
            if(!aligned<T>(w,src.Length - offset))
                Errors.ThrowBadSize(w, src.Length - offset);

            return unsafeload(w,offset == 0 ? src : slice(src,offset));
        }
    }
}