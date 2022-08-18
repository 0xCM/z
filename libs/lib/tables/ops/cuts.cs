//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        public static ReadOnlySpan<uint> cuts(ReadOnlySpan<byte> widths)
        {
            var count = (uint)widths.Length;
            var dst = span<uint>(count - 1);
            cuts(widths,dst);
            return dst;
        }

        public static ReadOnlySpan<Pair<uint>> segments(ReadOnlySpan<byte> widths)
        {
            const uint SepWidth = 3u;
            var count = (uint)widths.Length;
            var dst = span<Pair<uint>>(count);
            var offset = z32;
            for(var i=0u; i<count; i++)
            {
                ref readonly var width = ref skip(widths,i);
                var cut = math.add(offset, width + 1u);
                seek(dst,i) = (offset, cut - 1u);
                offset += (width + SepWidth);
            }
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void cuts(ReadOnlySpan<byte> widths, Span<uint> dst)
        {
            const uint SepWidth = 3u;
            var count = (uint)widths.Length;
            var offset = z32;
            for(var i=0u; i<count - 1; i++)
            {
                ref readonly var width = ref skip(widths,i);
                var cut = math.add(offset, width + 1u);
                seek(dst,i) = cut;
                offset += (width + SepWidth);
            }
        }
    }
}