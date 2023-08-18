//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using K = XedModels.ElementKind;

partial class XedModels
{
    [DataWidth(Width)]
    public readonly record struct ElementType : IComparable<ElementType>
    {
        public const byte Width = num5.Width;

        public readonly ElementKind Kind;

        [MethodImpl(Inline)]
        public ElementType(ElementKind kind)
        {
            Kind = kind;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public bool IsNumber
        {
            get => Indicator != 0;
        }

        public bool IsFloat
        {
            [MethodImpl(Inline)]
            get => Indicator == NumericIndicator.Float;
        }

        public bool IsSignedInt
        {
            [MethodImpl(Inline)]
            get => Indicator == NumericIndicator.Signed;
        }

        public bool IsUnsignedInt
        {
            [MethodImpl(Inline)]
            get => Indicator == NumericIndicator.Unsigned;
        }

        public bool IsInt
        {
            [MethodImpl(Inline)]
            get => IsSignedInt || IsUnsignedInt;
        }

        public int CompareTo(ElementType src)
            => ((byte)src.Indicator).CompareTo((byte)Indicator);

        public NumericIndicator Indicator
            => indicator(Kind);

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ElementType(ElementKind src)
            => new ElementType(src);

        [MethodImpl(Inline)]
        public static implicit operator ElementKind(ElementType src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator byte(ElementType src)
            => (byte)src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator ElementType(byte src)
            => new ElementType((ElementKind)src);

        public static ElementType Empty => default;

        public static NumericIndicator indicator(ElementType src)
        {
            var result = NumericIndicator.None;
            switch(src.Kind)
            {
                case K.BF16:
                case K.F16:
                case K.F32:
                case K.F64:
                case K.F80:
                    result = NumericIndicator.Float;
                    break;

                case K.I1:
                case K.I16:
                case K.I32:
                case K.I64:
                case K.I8:
                case K.INT:
                    result = NumericIndicator.Signed;
                    break;

                case K.U128:
                case K.U16:
                case K.U256:
                case K.U32:
                case K.U64:
                case K.U8:
                case K.UINT:
                    result = NumericIndicator.Unsigned;
                    break;
            }
            return result;
        }
    }
}
