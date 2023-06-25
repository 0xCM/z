//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ByteBlocks
    {
        [MethodImpl(Inline), Op]
        public static void alloc(N1 n, out ByteBlock1 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N2 n, out ByteBlock2 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N3 n, out ByteBlock3 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N4 n, out ByteBlock4 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N5 n, out ByteBlock5 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N6 n, out ByteBlock6 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N8 n, out ByteBlock8 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N10 n, out ByteBlock10 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N12 n, out ByteBlock12 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N14 n, out ByteBlock14 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N16 n, out ByteBlock16 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N18 n, out ByteBlock18 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N20 n, out ByteBlock20 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N24 n, out ByteBlock24 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N30 n, out ByteBlock30 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N32 n, out ByteBlock32 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N64 n, out ByteBlock64 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N80 n, out ByteBlock80 dst)
        {
            dst = default;            
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N128 n, out ByteBlock128 dst)
        {
            dst = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(N256 n, out ByteBlock256 dst)
        {
            dst = default;
        }

        /// <summary>
        /// Allocates 2 16-byte blocks
        /// </summary>
        /// <param name="n">The byte-count selector</param>
        [MethodImpl(Inline), Op]
        public static void alloc(out ByteBlock16 a, out ByteBlock16 b)
        {
            a = default;
            b = default;
        }

        /// <summary>
        /// Allocates 3 64-byte blocks
        /// </summary>
        /// <param name="n">The byte-count selector</param>
        [MethodImpl(Inline), Op]
        public static void alloc(out ByteBlock64 a, out ByteBlock64 b, out ByteBlock64 c)
        {
            a = default;
            b = default;
            c = default;
        }

        /// <summary>
        /// Allocates 4 128-byte blocks
        /// </summary>
        /// <param name="n">The byte-count selector</param>
        [MethodImpl(Inline), Op]
        public static void alloc(out ByteBlock128 a, out ByteBlock128 b, out ByteBlock128 c, out ByteBlock128 d)
        {
            a = default;
            b = default;
            c = default;
            d = default;
        }
    }
}