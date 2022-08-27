//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<byte> src, Span<char> dst, bool brackets = false)
        {
            var j = 0u;
            var count = src.Length;
            var max = dst.Length;
            if(brackets)
                seek(dst,j++) = Chars.LBracket;

            for(var i=0; i<count && j<max; i++)
            {
                ref readonly var b = ref skip(src,i);
                seek(dst,j++) = Chars.D0;
                seek(dst,j++) = Chars.x;
                seek(dst,j++) = hexchar(LowerCase, b, 1);
                seek(dst,j++) = hexchar(LowerCase, b, 0);
                if(i != count-1)
                    seek(dst,j++) = Chars.Comma;
            }

            if(brackets)
                seek(dst,j++) = Chars.RBracket;
            return j;
        }
    }
}