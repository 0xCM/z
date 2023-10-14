//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public readonly record struct OperandWidth
    {
        public readonly WidthCode Code;

        public readonly ushort Bits;

        [MethodImpl(Inline)]
        public OperandWidth(WidthCode code, ushort bits)
        {
            Code = code;
            Bits = bits;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code == 0 && Bits == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => ((uint)Code << 16) | (uint)Bits;
        }

        public string Format()
        {
            var dst = EmptyString;
            if(Code != 0)
                dst = EnumRender.format(Code);
            
            if(Bits != 0)
            {
                if(text.nonempty(dst))
                    dst += ":";
                dst += $"{Bits}";
            }
            return dst;
            //Bits == 0 ? EnumRender.format(Code) : $"{EnumRender.format(Code)}:{Bits}";

        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator WidthCode(OperandWidth src)
            => src.Code;
    }
}
