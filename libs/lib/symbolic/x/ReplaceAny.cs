//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static Root;

    partial class XText
    {
        [TextUtility]
        public static string ReplaceAny(this string src, ReadOnlySpan<char> replace, char replacement)
        {
            if(text.empty(src))
                return EmptyString;

            var length = src.Length;
            var chars = span(src);
            var buffer = alloc<char>(length);
            var dst = span(buffer);
            for(var i=0u; i<length; i++)
            {
                ref readonly var c = ref skip(chars,i);
                seek(dst,i) = c;
                for(var j=0u; j<replace.Length; j++)
                {
                    ref readonly var r = ref skip(replace, j);
                    if(c == r)
                    {
                        seek(dst,i) = replacement;
                        break;
                    }
                }
            }
            return new string(buffer);
        }
    }
}