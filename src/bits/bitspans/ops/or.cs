//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static BitSpan or(in BitSpan x, in BitSpan y, in BitSpan z)
        {
            var count = z.Length;
            for(var i=0; i< count; i++)
                z[i] = x[i] | y[i];
            return z;
        }

        [Op]
        public static BitSpan or(in BitSpan x, in BitSpan y)
            => or(x,y, alloc(y.BitCount));
    }
}