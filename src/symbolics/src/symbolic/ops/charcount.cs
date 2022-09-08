//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Symbolic
    {
        [MethodImpl(Inline), Op]
        public static uint charcount(ReadOnlySpan<SymLiteralRow> src)
        {
            var counter = 0u;
            var kSrc = src.Length;
            for(var i=0; i<src.Length; i++)
                counter += skip(src,i).Symbol.CharCount;
            return counter;
        }
    }
}