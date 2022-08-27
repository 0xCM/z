//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct FixedLines
    {
        [MethodImpl(Inline), Op]
        public static FixedLineSegment segment(ushort index, ushort min, ushort max)
            => new FixedLineSegment(index,min,max);

        [MethodImpl(Inline), Op]
        public static ushort length(FixedLineFormat src)
        {
            var total = 0u;
            var count = src.SegCount;
            var segs = src.Segments;
            for(var i=0; i<count; i++)
                total += skip(segs,i).Length;
            return (ushort)total;
        }
    }
}