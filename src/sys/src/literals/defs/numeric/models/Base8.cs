//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Base8 : INumericBase<Base8>
    {
        public static Base8 Base => default;

        public NumericBaseKind Kind
            => NumericBaseKind.Base8;

        public NumericBaseIndicator Indicator
            => NumericBaseIndicator.Base8;

        [MethodImpl(Inline)]
        public static implicit operator int(Base8 src)
            => (int)src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator NumericBaseKind(Base8 src)
            => src.Kind;
    }
}