//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    public static uint segbits(BfSegDef seg, ulong value, Span<bit> dst)
    {
        var extract = bits.extract(value, (byte)seg.MinPos, (byte)seg.MaxPos);
        Span<bit> buffer = stackalloc bit[64];
        for(var i=0; i<seg.Width; i++)
            seek(buffer,i) = bit.test(extract,(byte)i);
        var result = slice(buffer,0,seg.Width);
        result.Reverse();
        for(var i=0; i<seg.Width; i++)
            dst[i] = skip(result,i);
        return seg.Width;        
    }

    public static uint segbits(BfSegDef seg, ulong src, ref uint j, Span<char> dst)
    {
        var extract = bits.extract(src, (byte)seg.MinPos, (byte)seg.MaxPos);
        Span<char> buffer = stackalloc char[64];
        for(var i=0; i<seg.Width; i++)
            seek(buffer,i) = bit.test(extract,(byte)i).ToChar();
        var result = slice(buffer,0,seg.Width);
        result.Reverse();
        for(var i=0; i<seg.Width; i++)
            seek(dst,j++) = skip(result,i);
        return seg.Width;
    }
}