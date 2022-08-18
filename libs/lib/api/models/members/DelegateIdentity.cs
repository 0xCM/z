//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DelegateIdentity : IIdentifiedType<DelegateIdentity>
    {
        /// <summary>
        /// The type parameters that define the full delegate signature that includes the return type
        /// as the last identity in the array
        /// </summary>
        public readonly TypeIdentity[] Parameters {get;}

        /// <summary>
        /// The unadorned name of the delegate type
        /// </summary>
        public readonly string DelegateName {get;}

        /// <summary>
        /// The identifier computed from the name and parameter identities
        /// </summary>
        public readonly string IdentityText {get;}

        /// <summary>
        /// Indicates whether identifier should be rendered with a generic marker
        /// </summary>
        public readonly bool Generic {get;}

        [MethodImpl(Inline)]
        public static DelegateIdentity Define(string identity, string name, bool generic, TypeIdentity[] parameters)
            => new DelegateIdentity(identity, name, generic,  parameters);

        [MethodImpl(Inline)]
        internal DelegateIdentity(string identifier, string name, bool generic, TypeIdentity[] parameters)
        {
            IdentityText = identifier;
            DelegateName = name;
            Parameters = parameters;
            Generic = generic;
        }

        IIdentifiedType<DelegateIdentity> Identified
            => this;

        public override int GetHashCode()
            => IdentityText?.GetHashCode() ?? 0;

        public override bool Equals(object obj)
            => Identified.Same(obj);

        public override string ToString()
            => Identified.Format();

        [MethodImpl(Inline)]
        public static implicit operator string(DelegateIdentity src)
            => src.IdentityText;

        [MethodImpl(Inline)]
        public static bool operator==(DelegateIdentity a, DelegateIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(DelegateIdentity a, DelegateIdentity b)
            => !a.Equals(b);

        public static DelegateIdentity Empty
            => Define(string.Empty, string.Empty, false, Array.Empty<TypeIdentity>());
    }
}