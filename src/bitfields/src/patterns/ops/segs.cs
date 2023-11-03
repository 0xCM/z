//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static Seq<BfSegModel> segs(BpExpr src)
    {
        var names = symbols(src);
        var count = names.Length;
        var dst = alloc<BfSegModel>(count);
        var offset = z8;
        var size = packedsize(src);
        if(size.Width <= 8)
        {
            for(var i=count-1; i>=0; i--)
            {
                ref readonly var name = ref names[i];
                var width = (byte)name.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                seek(dst,i) = PolyBits.seg(name, min, max, BitMask.mask(size, min, max));
                offset += width;
            }
        }
        else
        {
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref names[i];
                var width = (byte)name.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                seek(dst,i) = PolyBits.seg(name, min, max, BitMask.mask(size, min, max));
                offset += width;
            }

        }

        return dst;
    }

    // public static Seq<BpSeg> segs(ReadOnlySpan<BpInfo> src)
    // {
    //     var count = 0u;
    //     var counter = 0u;
    //     iter(src, x => count += x.Segs.Count);
    //     var dst = alloc<BpSeg>(count);
    //     var j=0u;
    //     for(var i=0; i<src.Length; i++)
    //         segs(skip(src,i), ref j, dst);
    //     return dst.Sort();
    // }

    // static uint segs(BpInfo src, ref uint j, Span<BpSeg> dst)
    // {
    //     var i0 = j;
    //     for(var i=0u; i<src.Segs.Count; i++, j++)
    //     {
    //         ref var seg = ref seek(dst,j);
    //         ref readonly var model = ref src.Segs[i];
    //         seg.PatternName = src.Name;
    //         seg.SegmentName = model.SegName;
    //         seg.Index = i;
    //         seg.MinPos = model.MinPos;
    //         seg.MaxPos = model.MaxPos;
    //         seg.Width = model.Width;
    //         seg.Expr = model.Format();
    //         seg.Mask = model.Mask;
    //     }
    //     return j - i0;
    // }
}
