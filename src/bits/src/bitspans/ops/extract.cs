//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static Span<bit> extract(BitSpan src, uint offset, uint count)
            => sys.slice(src.Storage, offset, count);
    }
}