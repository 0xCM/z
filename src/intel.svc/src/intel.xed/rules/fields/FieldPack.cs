//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;

using DK = XedRules.FieldDataKind;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public struct XedFieldPack
{
    public FieldKind Field;

    public bit Bit;

    public byte Byte;

    public ushort Word;

    public Register Reg;

    public ChipCode Chip;

    public XedInstClass Class;

    public FieldDataKind DataKind()
    {
        var dst = DK.Bit;
        if(Class.IsNonEmpty)
            dst = DK.InstClass;
        else if(Chip != 0)
            dst = DK.Chip;
        else if(Reg.IsNonEmpty)
            dst = DK.Reg;
        else if(Word !=0)
            dst = DK.Word;
        else if(Byte !=0)
            dst = DK.Byte;
        return dst;
    }

    public ushort Value()
    {
        var dst = z16;
        var kind = DataKind();
        switch(kind)
        {
            case DK.Bit:
                dst = (byte)Bit;
            break;
            case DK.Byte:
                dst = Byte;
            break;
            case DK.Chip:
                dst = (byte)Chip;
            break;
            case DK.InstClass:
                dst = (ushort)Class;
            break;
            case DK.Reg:
                dst = (ushort)Reg;
            break;
            case DK.Word:
                dst = Word;
            break;
        }
        return dst;
    }

    public string Format()
    {
        var dst = EmptyString;
        switch(DataKind())
        {
            case DK.Bit:
                dst = Bit.ToString();
            break;
            case DK.Byte:
                dst = Byte.ToString();
            break;
            case DK.Chip:
                dst = XedRender.format(Chip);
            break;
            case DK.InstClass:
                dst = XedRender.format(Class);
            break;
            case DK.Reg:
                dst = XedRender.format(Reg);
            break;
            case DK.Word:
                dst = Word.ToString();
            break;
        }
        return dst;
    }
    public override string ToString()
        => Format();

    public static XedFieldPack Empty => default;
}
