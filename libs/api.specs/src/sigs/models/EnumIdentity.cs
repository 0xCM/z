//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies an <see cref='Enum'/>
    /// </summary>
    public readonly struct EnumIdentity : IIdentifiedType<EnumIdentity>
    {
        public readonly string IdentityText {get;}

        public readonly Identifier TypeName {get;}

        public readonly NumericKind BaseType {get;}

        [MethodImpl(Inline)]
        public static EnumIdentity define(Type src)
            => src.IsEnum ? new EnumIdentity(src.Name, src.GetEnumUnderlyingType().NumericKind()) : Empty;

        [MethodImpl(Inline)]
        public EnumIdentity(string name, NumericKind basetype)
        {
            TypeName = name;
            BaseType = basetype;
            IdentityText = basetype != 0 ? $"{TypeName}{IDI.ModSep}{basetype.Format()}" : EmptyString;
        }

        IIdentifiedType<EnumIdentity> Identified
            => this;

        public override int GetHashCode()
            => IdentityText?.GetHashCode() ?? 0;

        public override bool Equals(object obj)
            => Identified.Same(obj);

        public override string ToString()
            => Identified.Format();

        [MethodImpl(Inline)]
        public TypeIdentity AsTypeIdentity()
            => TypeIdentity.define(IdentityText);

        [MethodImpl(Inline)]
        public static implicit operator string(EnumIdentity src)
            => src.IdentityText;

        [MethodImpl(Inline)]
        public static implicit operator TypeIdentity(EnumIdentity src)
            => src.AsTypeIdentity();

        [MethodImpl(Inline)]
        public static bool operator==(EnumIdentity a, EnumIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(EnumIdentity a, EnumIdentity b)
            => !a.Equals(b);

        public static EnumIdentity Empty = new EnumIdentity(EmptyString, NumericKind.None);
    }
}