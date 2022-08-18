//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class BitSpans32
    {
        [Op]
        public static string format(in BitSpan32 src, BitFormat? fmt = null)
        {
            var options = fmt ?? BitFormat.configure();
            var bitcount = (uint)src.Length;
            var blocked = options.BlockWidth != 0;
            var blocks = (uint)(blocked ? src.Length / options.BlockWidth : 0);
            bitcount += blocks; // space for block separators

            Span<char> buffer = stackalloc char[(int)bitcount];
            ref var dst = ref first(buffer);

            var digits = 0;
            for(uint i = 0, j=bitcount-1; i < bitcount; i++, j--)
            {
                if(blocked && digits % options.BlockWidth == 0)
                    seek(dst, j--) = options.BlockSep;

                seek(dst, j) = src[i].ToChar();
                digits++;
            }

            return new string(buffer);
        }
    }
}