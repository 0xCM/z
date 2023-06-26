//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        [Op]
        public static string format(in BitSpan src, BitFormat? fmt = null)
            => BitRender.format(src.Storage, fmt);
    }
}