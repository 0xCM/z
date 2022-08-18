//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IIdentityProvider
    {
        IdentityTargetKind ProviderKind {get;}

        IIdentified Identify(object src);
    }

    /// <summary>
    /// Characterizes a services capable of assigning identity to T-values
    /// </summary>
    /// <typeparam name="S">The subject of identification</typeparam>
    [Free]
    public interface IIdentityProvider<S> : IIdentityProvider
    {
        IIdentified Identify(S src);

        IIdentified IIdentityProvider.Identify(object src)
            => Identify((S)src);
    }

    [Free]
    public interface IIdentityProvider<S,T> : IIdentityProvider<S>
        where T : IIdentified
    {
        new T Identify(S src);

        IIdentified IIdentityProvider<S>.Identify(S src)
            => Identify(src);
    }
}