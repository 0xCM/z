//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static BitSpan and(BitSpan a, BitSpan b, BitSpan dst)
        {
            var count = dst.BitCount;
            for(var i=0u; i<count; i++)
                dst[i] = a[i] & b[i];
            return dst;
        }

        public static BitSpan and(BitSpan a, BitSpan b)
            => and(a,b, alloc(b.BitCount));
    }
}