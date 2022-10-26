//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Base16 : INumericBase<Base16>
    {
        public static Base16 Base => default;

        public NumericBaseKind Kind
            => NumericBaseKind.Base16;

        public NumericBaseIndicator Indicator
            => NumericBaseIndicator.Base16;

        [MethodImpl(Inline)]
        public static implicit operator int(Base16 src)
            => (int)src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator NumericBaseKind(Base16 src)
            => src.Kind;
    }
}