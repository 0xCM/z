//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Base2 : INumericBase<Base2>
    {
        public static Base2 Base => default;

        public NumericBaseKind Kind
            => NumericBaseKind.Base2;

        public NumericBaseIndicator Indicator
            => NumericBaseIndicator.Base2;

        [MethodImpl(Inline)]
        public static implicit operator int(Base2 src)
            => (int)src.Kind;

        [MethodImpl(Inline)]
        public static implicit operator NumericBaseKind(Base2 src)
            => src.Kind;
    }
}