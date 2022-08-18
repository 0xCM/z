//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitSpans32
    {
        [MethodImpl(Inline), Op]
        public static BitSpan32 trim(in BitSpan32 src)
        {
            var pos = msb(src);
            if(pos != 0 && pos != src.Length - 1)
                return load(src.Data.Slice(0, pos + 1));
            else
                return src;
        }
    }
}