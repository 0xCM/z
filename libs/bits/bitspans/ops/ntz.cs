//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitSpans
    {
        [MethodImpl(Inline), Op]
        public static uint ntz(in BitSpan src)
        {
            var count = src.Length;
            var result = 0u;
            for(var i=0; i<count; i++)
            {
                if(!src[i])
                    result++;
                else
                    break;
            }
            return result;
        }
    }
}