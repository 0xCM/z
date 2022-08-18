//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NumericIdentity : IIdentifiedType<NumericIdentity>
    {
        public string IdentityText {get;}

        public NumericKind NumericKind {get;}

        [MethodImpl(Inline)]
        public static NumericIdentity define(NumericKind kind)
            => new NumericIdentity(kind);

        [MethodImpl(Inline)]
        NumericIdentity(NumericKind kind)
        {
            NumericKind = kind;
            IdentityText = $"{kind.TypeWidth().FormatValue()}{NumericKind.Indicator().Format()}";
        }

        IIdentifiedType<NumericIdentity> Identified => this;

        public override int GetHashCode()
            => IdentityText?.GetHashCode() ?? 0;

        public override bool Equals(object obj)
            => Identified.Same(obj);

        public override string ToString()
            => Identified.Format();

        [MethodImpl(Inline)]
        public static implicit operator string(NumericIdentity src)
            => src.IdentityText;

        [MethodImpl(Inline)]
        public static implicit operator TypeIdentity(NumericIdentity src)
            => new TypeIdentity(src.IdentityText);

        [MethodImpl(Inline)]
        public static bool operator==(NumericIdentity a, NumericIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(NumericIdentity a, NumericIdentity b)
            => !a.Equals(b);
    }
}