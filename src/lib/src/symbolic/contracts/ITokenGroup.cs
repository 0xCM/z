//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITokenGroup
    {
        string GroupName {get;}

        uint KindCount {get;}

        uint TokenCount {get;}

        Type KindType {get;}

        Type GroupType {get;}

        ReadOnlySpan<Type> TokenTypes {get;}
    }

    public interface ITokenGroup<K> : ITokenGroup
        where K : unmanaged
    {
        Type ITokenGroup.KindType
            => typeof(K);
    }

    public interface ITokenGroup<G,K> : ITokenGroup<K>
        where G : ITokenGroup<G,K>, new()
        where K : unmanaged
    {

        Symbols<K> Kinds {get;}

        ConstLookup<Type,K> TypeKinds {get;}

        Index<K,Index<Token>> KindedTokens {get;}

        Index<Token> Tokens(Type src)
            => KindedTokens[Kind(src)];

        Type ITokenGroup.GroupType
            => typeof(G);

        K Kind(Type src)
            => TypeKinds[src];

        ReadOnlySpan<Type> ITokenGroup.TokenTypes
            => TypeKinds.Keys;

        uint ITokenGroup.KindCount
            => Kinds.Count;

        uint ITokenGroup.TokenCount
            => KindedTokens.Count;
    }
}