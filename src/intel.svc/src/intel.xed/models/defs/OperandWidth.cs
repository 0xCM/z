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

        [MethodImpl(Inline)]
        public OperandWidth(WidthCode code)        
        {
            Code = code;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Code;
        }

        public string Format()
            => EnumRender.format(Code);
        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OperandWidth(WidthCode code)
            => new(code);

        [MethodImpl(Inline)]
        public static implicit operator WidthCode(OperandWidth src)
            => src.Code;
    }
}
