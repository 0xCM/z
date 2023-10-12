//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
         [MethodImpl(Inline), Op]
         public static BitSpan load(Span<bit> src)
            => new BitSpan(src);

    }
}