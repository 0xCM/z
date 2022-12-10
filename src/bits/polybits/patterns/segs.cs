//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct BitPatterns
    {
        public static Index<byte> segwidths(in BitPattern src)
        {
            var fields = indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)fields[i].Length;
            return buffer;
        }

        public static Index<BfSegModel> segs(in BitPattern src)
        {
            var names = indicators(src);
            var count = names.Length;
            var buffer = alloc<BfSegModel>(count);
            var offset = z8;
            var size = minsize(src);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var name = ref names[i];
                var width = (byte)name.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                dst = PolyBits.seg(name, min, max, BitMask.mask(size, min, max));
                offset += width;
            }
            return buffer;
        }

        public static Index<BpSeg> segs(ReadOnlySpan<BpInfo> src)
        {
            var count = 0u;
            var counter = 0u;
            iter(src, x => count += x.Segs.Count);
            var dst = alloc<BpSeg>(count);
            var j=0u;
            for(var i=0; i<src.Length; i++)
                segs(skip(src,i), ref j, dst);
            return dst.Sort();
        }

        static uint segs(BpInfo src, ref uint j, Span<BpSeg> dst)
        {
            var i0 = j;
            for(var i=0u; i<src.Segs.Count; i++, j++)
            {
                ref var seg = ref seek(dst,j);
                ref readonly var model = ref src.Segs[i];
                seg.Pattern = src.Name;
                seg.Name = model.SegName;
                seg.Index = i;
                seg.MinPos = model.MinPos;
                seg.MaxPos = model.MaxPos;
                seg.Width = model.Width;
                seg.Expr = model.Format();
                seg.Mask = model.Mask;
            }
            return j - i0;
        }
    }
}