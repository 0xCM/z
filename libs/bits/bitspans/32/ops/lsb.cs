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
        public static int lsb(in BitSpan32 src)
        {
            var len = src.Length;
            for(var i = 0; i <len;  i++)
                if(src[i])
                    return i;
            return -1;
        }
    }
}