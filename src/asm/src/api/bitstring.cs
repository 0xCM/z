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
        var count = bitstring(src, dst);
        if(count == 0)
            return EmptyString;
        return sys.@string(slice(dst, 0, count));
    }
}
