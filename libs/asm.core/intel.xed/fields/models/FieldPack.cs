//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    using K = XedRules.FieldDataKind;

    partial class XedFields
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct FieldPack
        {
            public FieldKind Field;

            public bit Bit;

            public byte Byte;

            public ushort Word;

            public Register Reg;

            public ChipCode Chip;

            public AmsInstClass Class;

            public FieldDataKind DataKind()
            {
                var dst = K.Bit;
                if(Class.IsNonEmpty)
                    dst = K.InstClass;
                else if(Chip != 0)
                    dst = K.Chip;
                else if(Reg.IsNonEmpty)
                    dst = K.Reg;
                else if(Word !=0)
                    dst = K.Word;
                else if(Byte !=0)
                    dst = K.Byte;
                return dst;
            }

            public ushort Value()
            {
                var dst = z16;
                var kind = DataKind();
                switch(kind)
                {
                    case K.Bit:
                        dst = (byte)Bit;
                    break;
                    case K.Byte:
                        dst = Byte;
                    break;
                    case K.Chip:
                        dst = (byte)Chip;
                    break;
                    case K.InstClass:
                        dst = (ushort)Class;
                    break;
                    case K.Reg:
                        dst = (ushort)Reg;
                    break;
                    case K.Word:
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
                    case K.Bit:
                        dst = Bit.ToString();
                    break;
                    case K.Byte:
                        dst = Byte.ToString();
                    break;
                    case K.Chip:
                        dst = XedRender.format(Chip);
                    break;
                    case K.InstClass:
                        dst = XedRender.format(Class);
                    break;
                    case K.Reg:
                        dst = XedRender.format(Reg);
                    break;
                    case K.Word:
                        dst = Word.ToString();
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static FieldPack Empty => default;
        }
    }
}