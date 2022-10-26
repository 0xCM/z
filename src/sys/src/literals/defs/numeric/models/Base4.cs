//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Base4 : INumericBase<Base4>
    {
        public static Base4 Base => default;

        public NumericBaseKind Kind
            => NumericBaseKind.Base4;

        public NumericBaseIndicator Indicator
            => NumericBaseIndicator.Base4;

        [MethodImpl(Inline)]
        public static implicit operator int(Base4 src)
            => (int)src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator NumericBaseKind(Base4 src)
            => src.Kind;
    }
}