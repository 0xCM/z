//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static uint bitstring(AsmHexCode src, Span<char> dst)
    {
        var i=0u;
        return BitRender.render8x4(slice(src.Bytes, 0, src.Size), ref i, dst);
    }

    [Op]
    public static string bitstring(in AsmHexCode src)
    {
        if(src.IsEmpty)
            return EmptyString;
        Span<char> dst = stackalloc char[256];
        var data = src.Bytes;
        var j = 0u;
        for(var i=0; i<src.Size; i++)
        {
            if(i!=0)
                seek(dst,j++) = Chars.Space;                
            BitRender.render8(skip(data,i), ref j, dst);            
        }
        return new(slice(dst,0,j));
    }
}
