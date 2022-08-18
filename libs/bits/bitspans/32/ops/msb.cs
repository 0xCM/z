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
        public static int msb(in BitSpan32 src)
        {
            var len = src.Length;
            for(var i = len - 1; i >=0; i--)
                if(src[i])
                    return i;
            return 0;
        }
    }
}