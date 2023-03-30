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
        internal static uint asci(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = Bytes.and((byte)skip(src,i), AsciCodeFacets.MaxCodeValue);
            return count;
        }

        [MethodImpl(Inline), Op]
        internal static uint asci(ReadOnlySpan<char> src, int max, ref byte dst)
        {
            var count = (uint)min(src.Length, max);
            for(var i=0; i<count; i++)
                seek(dst,i) = Bytes.and((byte)skip(src,i), AsciCodeFacets.MaxCodeValue);
            return count;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock2 asci(N2 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock2.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock3 asci(N3 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock3.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock4 asci(N4 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock4.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock5 asci(N5 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock5.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock6 asci(N6 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock6.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock7 asci(N7 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock7.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock8 asci(N8 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock8.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock9 asci(N9 n, ReadOnlySpan<char> src)
        {
            var dst = ByteBlock9.Empty;
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock10 asci(N10 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock11 asci(N11 n, ReadOnlySpan<char> src)
        {
            var dst = alloc(n);
            asci(src,dst.Bytes);
            return dst;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock12 asci(N12 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock14 asci(N14 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock16 asci(N16 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock18 asci(N18 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock20 asci(N20 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock24 asci(N24 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock30 asci(N30 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock32 asci(N32 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock64 asci(N64 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock80 asci(N80 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock128 asci(N128 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        /// <summary>
        /// Allocates a block of specified size and fills it to capacity with asci character codes distilled from a specified source
        /// </summary>
        /// <param name="n">The size selector</param>
        /// <param name="src"/>The data source</param>
        [MethodImpl(Inline), Op]
        public static ByteBlock256 asci(N256 n, ReadOnlySpan<char> src)
        {
            alloc(n, out var block);
            asci(src, n, ref block.First);
            return block;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock8 asci(N8 n, ReadOnlySpan<char> src, out ByteBlock8 dst)
        {
            alloc(n, out dst);
            asci(src, n, ref dst.First);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock16 asci(N16 n, ReadOnlySpan<char> src, out ByteBlock16 dst)
        {
            alloc(n, out dst);
            asci(src, n, ref dst.First);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteBlock64 asci(N64 n, ReadOnlySpan<char> src, out ByteBlock64 dst)
        {
            alloc(n, out dst);
            asci(src, n, ref dst.First);
            return dst;
        }
    }
}