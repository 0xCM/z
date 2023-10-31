//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    [Op]
    public static uint bitwidth(BpExpr src)
        => (uint)text.remove(src.Data, Chars.Space).Length;

    [MethodImpl(Inline), Op]
    public static DataSize size(BpExpr src)
        => Sizes.datasize(bitwidth(src));

    [MethodImpl(Inline), Op]
    public static NativeSize packedsize(BpExpr src)
    {
        var width = bitwidth(src);
        if(width <= 8)
            return NativeSizeCode.W8;
        else if(width <= 16)
            return NativeSizeCode.W16;
        else if(width <= 32)
            return NativeSizeCode.W32;
        else if(width <= 64)
            return NativeSizeCode.W64;
        else if(width <= 128)
            return NativeSizeCode.W128;
        else if(width <= 256)
            return NativeSizeCode.W256;
        else
            Throw.message("Width unsupported");

        return default;
    }
}
