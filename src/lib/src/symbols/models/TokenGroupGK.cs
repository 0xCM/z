//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [TokenGroup]
    public abstract class TokenGroup<G,K> : ITokenGroup<G,K>
        where G : TokenGroup<G,K>, new()
        where K : unmanaged, Enum
    {
        public static G create()
            => new G();

        public abstract string GroupName {get;}

        public ConstLookup<Type,K> TypeKinds {get;}

        public Symbols<K> Kinds{get;}

        public Index<K,Index<Token>> KindedTokens {get;}

        public readonly uint KindCount;

        public readonly uint TokenCount;

        protected TokenGroup()
        {
            Kinds = Symbols.index<K>();
            KindCount = Kinds.Count;
            var types = typeof(G).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
            TypeKinds = types.Select(t => (t, t.Tag<TokenKindAttribute<K>>().Require().Kind)).ToDictionary();
            KindedTokens = alloc<Index<Token>>(Kinds.Count);
            for(var i=0u; i<Kinds.Count; i++)
                KindedTokens[@as<K>(i)] = sys.empty<Token>();
            var counter = 0u;
            for(var i=0; i<types.Length; i++)
            {
                var kind = TypeKinds[skip(types,i)];
                KindedTokens[kind] = Symbols.tokenize(skip(types,i));
                counter += KindedTokens[kind].Count;
            }

            TokenCount = counter;
        }

        public ReadOnlySpan<Type> TokenTypes
        {
            [MethodImpl(Inline)]
            get => TypeKinds.Keys;
        }

        public K Kind(Type src)
            => TypeKinds[src];

        public Index<Token> Tokens(Type src)
            => KindedTokens[Kind(src)];
    }
}