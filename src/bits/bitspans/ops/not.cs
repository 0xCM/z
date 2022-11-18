//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static BitSpan not(in BitSpan a, in BitSpan b)
        {
            var count = b.Length;
            for(var i=0; i< count; i++)
                b[i] = ~ a[i];
            return b;
        }

        [Op]
        public static BitSpan not(in BitSpan x)
            => not(x, alloc(x.BitCount));
    }
}