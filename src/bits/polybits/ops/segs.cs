//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PolyBits
    {
        public static Index<BfSegModel> segs<F,T>(BfDataset<F,T> src)
            where F : unmanaged, Enum
            where T : unmanaged
        {
            var count = src.FieldCount;
            var dst = alloc<BfSegModel>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref src.Field(i);
                ref readonly var width = ref src.Width(field);
                ref readonly var offset = ref src.Offset(field);
                ref readonly var mask = ref src.Mask(field);
                ref readonly var interval = ref src.Interval(field);
                seek(dst,i) = seg(field, offset, offset + width -1, mask);
            }
            return dst;
        }
    }
}