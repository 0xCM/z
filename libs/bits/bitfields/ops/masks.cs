//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static BitMask mask(byte width, uint offset)
            => Numbers.max(width) << (int)offset;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T mask<T>(byte width, uint offset)
            => generic<T>(Numbers.max(width) << (int)offset);

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Index<T> masks<T>(ReadOnlySpan<byte> widths, ReadOnlySpan<uint> offsets)
            where T : unmanaged
        {
            var count = Require.equal(offsets.Length, widths.Length);
            var dst = alloc<T>(count);
            masks<T>(widths, offsets, dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static void masks(ReadOnlySpan<byte> widths, Span<BitMask> dst)
        {
            var count = min(widths.Length, dst.Length);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var width = ref skip(widths,i);
                seek(dst,i) = Bitfields.mask(width, offset);
                offset += width;
            }
        }

        /// <summary>
        /// Computes a sequence of segment masks given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void masks<T>(ReadOnlySpan<byte> widths, ReadOnlySpan<uint> offsets, Span<T> dst)
            where T : unmanaged
        {
            var count = dst.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = mask<T>(skip(widths,i), skip(offsets,i));
        }
    }
}