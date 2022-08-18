//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static Span<bit> extract(in BitSpan src, uint offset, uint count)
            => core.slice(src.Storage, offset, count);
    }
}