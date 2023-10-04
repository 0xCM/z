//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class PolyBits
{
    [MethodImpl(Inline)]
    public static BfInterval interval(uint offset, byte width)
        => new BfInterval(offset,width);

    /// <summary>
    /// Computes a <see cref='BfInterval'/> sequence given a paired offset/width seqence
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    public static BfIntervals intervals(ReadOnlySpan<uint> offsets, ReadOnlySpan<byte> widths)
    {
        var count = Require.equal(offsets.Length,widths.Length);
        var dst = alloc<BfInterval>(count);
        for(var i=0; i<count; i++)
            seek(dst,i) = interval(skip(offsets,i), skip(widths,i));
        return dst;
    }

    public static BfIntervals<F> intervals<F>(BfDataset<F> src)
        where F : unmanaged, Enum
            => map(src.Fields, field => new BfInterval<F>(field, src.Offset(field), src.Width(field)));

    public static BfIntervals<F> intervals<F,T>(BfDataset<F,T> src)
        where F : unmanaged, Enum
        where T : unmanaged
            => map(src.Fields, field => new BfInterval<F>(field, src.Offset(field), src.Width(field)));
}
