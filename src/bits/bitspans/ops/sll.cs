//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static BitSpan sll(in BitSpan a, uint offset, in BitSpan dst)
        {
            core.slice(a.Storage, 0, offset).CopyTo(dst.Storage, (int)offset);
            for(var i=0; i<offset; i++)
                dst[i] = bit.Off;
            return dst;
        }
    }
}