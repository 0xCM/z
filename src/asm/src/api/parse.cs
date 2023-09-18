//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial struct asm
{
    [Op]
    public static bool parse(ReadOnlySpan<char> src, out AsmHexCode dst)
    {
        var buffer = ByteBlock16.Empty;
        var bytes = sys.bytes(buffer);
        var result = Hex.parse(src, bytes);
        if(result)
        {
            var size = Demand.lteq((byte)result.Data,(byte)15);
            var data = slice(bytes,0,size);
            seek(bytes,15) = size;
            dst = new AsmHexCode(@as<ByteBlock16,Cell128>(buffer));
        }
        else
            dst = AsmHexCode.Empty;
        return result;
    }
}
