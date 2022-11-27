//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Tokens;

    [TokenGroup]
    public abstract class TokenGroup<G,K> : ITokenGroup<G,K>
        where G : TokenGroup<G,K>, new()
        where K : unmanaged, Enum
    {
        public static G create()
            => api.group<G,K>();

        public abstract string GroupName {get;}

        public ConstLookup<Type,K> TypeKinds {get; internal set;}

        public Symbols<K> Kinds {get; internal set;}

        public Index<K,Index<GroupedToken>> KindedTokens {get; internal set;}

        public uint KindCount {get; internal set;}

        public uint TokenCount {get; internal set;}

        public ReadOnlySeq<GroupedToken> Tokens {get; internal set;}

        public ReadOnlySpan<Type> TokenTypes
        {
            [MethodImpl(Inline)]
            get => TypeKinds.Keys;
        }

        ReadOnlySeq<GroupedToken> ITokenGroup.Tokens 
            => Tokens;

        public K Kind(Type src)
            => TypeKinds[src];

        public Index<GroupedToken> TokensByType(Type src)
            => KindedTokens[Kind(src)];
    }
}