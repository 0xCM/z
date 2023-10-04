//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class PolyBits
{
    public static Index<string> gridlines(ReadOnlySpan<byte> src, int rowlen, int? maxbits, bool showrow)
    {
        const byte Pad = 3;
        const string Sep = " | ";
        const char Delimit = Chars.Space;
        var limit = maxbits ?? src.Length;
        var remainder = limit%rowlen;
        var bits = BitRender.render8x8(src);
        var count = (limit/rowlen) + (remainder == 0 ? 0 : 1);
        var buffer = alloc<string>(count);
        var rowidx = 0;
        var k=0u;
        for(int i=0; i<limit; i+=rowlen, k++)
        {
            var remains = bits.Length - i;
            var seglen = min(remains, rowlen);
            var row = slice(bits.View, i, seglen);
            if(showrow)
                seek(buffer, k) = text.concat($"{rowidx.ToString().PadRight(Pad)}{Sep}", text.format(row.Intersperse(Delimit)));
            else
                seek(buffer, k) = text.format(row.Intersperse(Delimit));
            rowidx++;
        }

        if(remainder != 0)
        {
            var remains = bits.Length - remainder;
            var seglen = remains;
            var row = slice(bits.View, seglen, remains);
            if(showrow)
                seek(buffer, k) = text.concat($"{rowidx.ToString().PadRight(Pad)}{Sep}", text.format(row.Intersperse(Delimit)));
            else
                seek(buffer, k) = text.format(row.Intersperse(Delimit));
        }
        return buffer;
    }
}
