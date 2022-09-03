//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan and(in BitSpan a, in BitSpan b, in BitSpan dst)
        {
            var count = dst.BitCount;
            for(var i=0u; i<count; i++)
                dst[i] = a[i] & b[i];
            return ref dst;
        }

        public static BitSpan and(in BitSpan a, in BitSpan b)
            => and(a,b, alloc(b.BitCount));
    }
}