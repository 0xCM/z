//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class XedFieldWriter
{

}


partial class XedFields
{
    [Op]
    public static XedRegs regs(in XedFieldState src)
    {
        var storage = ByteBlock32.Empty;
        var dst = recover<XedRegId>(storage.Bytes);
        var count = z8;
        if(src.REG0 != 0)
            seek(dst,count++) = src.REG0;
        if(src.REG1 != 0)
            seek(dst,count++) = src.REG1;
        if(src.REG2 != 0)
            seek(dst,count++) = src.REG2;
        if(src.REG3 != 0)
            seek(dst,count++) = src.REG3;
        if(src.REG4 != 0)
            seek(dst,count++) = src.REG4;
        if(src.REG5 != 0)
            seek(dst,count++) = src.REG5;
        if(src.REG6 != 0)
            seek(dst,count++) = src.REG6;
        if(src.REG7 != 0)
            seek(dst,count++) = src.REG7;
        if(src.REG8 != 0)
            seek(dst,count++) = src.REG8;
        if(src.REG9 != 0)
            seek(dst,count++) = src.REG9;
        storage[31] = count;
        return @as<XedRegs>(storage.Bytes);
    }
}