//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeIdentityProviders
    {
        public static ITypeIdentityProvider create(Type t, ITypeIdentityProvider fallback)
        {
            var provider = Option.none<ITypeIdentityProvider>();
            if(t.Tagged<IdentityProviderAttribute>())
                provider = attributed(t);
            else if(t.Reifies<ITypeIdentityProvider>())
                provider = hosted(t);
            return provider.ValueOrElse(() => fallback);
        }

        /// <summary>
        /// Creates a type identity provider from a host type that realizes the required interface, if possible;
        /// otherwise, returns none
        /// </summary>
        /// <param name="host">A type that realizes an identity provider</param>
        public static Option<ITypeIdentityProvider> hosted(Type host)
            => Option.Try(() => Activator.CreateInstance(host) as ITypeIdentityProvider);

        public static Option<ITypeIdentityProvider> attributed(Type t)
            => from a in t.Tag<IdentityProviderAttribute>()
               from tid in hosted(a.Host.ToOption().ValueOrDefault(t))
               select tid;
    }
}