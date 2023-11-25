//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Hex
{
    public static bool convert(ReadOnlySpan<char> src, out Seq<HexDigitValue> dst)
    {
        dst = sys.alloc<HexDigitValue>(src.Length);
        return digits(src, dst.Edit);
    }

    public static bool convert(ReadOnlySpan<AsciCode> src, out Seq<HexDigitValue> dst)
    {
        dst = sys.alloc<HexDigitValue>(src.Length);
        return digits(src, dst.Edit);
    }

    public static bool convert(ReadOnlySpan<AsciSymbol> src, out Seq<HexDigitValue> dst)
    {
        dst = sys.alloc<HexDigitValue>(src.Length);
        return digits(src, dst.Edit);
    }

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
