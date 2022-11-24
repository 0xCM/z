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

        // protected TokenGroup()
        // {
        //     Kinds = Symbols.index<K>();
        //     KindCount = Kinds.Count;
        //     var types = typeof(G).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
            
        //     TypeKinds = types.Select(t => (t, (K)t.Tag<TokenKindAttribute>().Require().Kind)).ToDictionary();            
        //     KindedTokens = alloc<Index<GroupedToken>>(Kinds.Count);
        //     for(var i=0u; i<Kinds.Count; i++)
        //         KindedTokens[@as<K>(i)] = sys.empty<GroupedToken>();
        //     var counter = 0u;
        //     for(var i=0; i<types.Length; i++)
        //     {
        //         var kind = TypeKinds[skip(types,i)];
        //         KindedTokens[kind] = api.groups(skip(types,i));
        //         counter += KindedTokens[kind].Count;
        //     }

        //     TokenCount = counter;
        //     Tokens = KindedTokens.SelectMany(x => x).ToSeq();
        // }


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