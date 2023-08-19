//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITokenGroup
    {
        string GroupName {get;}

        ReadOnlySpan<Type> TokenTypes {get;}

        ReadOnlySeq<GroupedToken> Tokens {get;}
    }

    public interface ITokenGroup<G,K> : ITokenGroup
        where G : ITokenGroup<G,K>, new()
        where K : unmanaged
    {
        Symbols<K> Kinds {get;}

        ConstLookup<Type,K> TypeKinds {get;}

        K Kind(Type src)
            => TypeKinds[src];

        ReadOnlySpan<Type> ITokenGroup.TokenTypes
            => TypeKinds.Keys;
    }    
}