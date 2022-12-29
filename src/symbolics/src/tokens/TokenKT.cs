//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class Token<T,K> : IToken<K>
        where T : Token<T,K>, new()
        where K : unmanaged, Enum
    {
        public readonly uint Index;

        public readonly K Kind;

        public readonly string Name;

        public readonly string Expr;

        protected Token()
        {
            Index = 0;
            Kind = default;
            Expr = typeof(T).Name;
            Name = EmptyString;
        }

        protected Token(K kind)
        {
            Index = sys.u32(kind);
            Kind = kind;
            Expr = Render.Format(kind);
            Name = kind.ToString();
        }

        public Token<K> Record() => new Token<K>{
            Index = Index,
            Kind = Kind,
            Name = Name,
            Expr = Expr
        };

        uint IToken.Index 
            => Index;

        K IToken<K>.Kind 
            => Kind;

        ReadOnlySpan<char> IToken.Name
            => Name;

        ReadOnlySpan<char> IToken.Expr
            => Name;

        public static T Rep = new();

        static EnumRender<K> Render = new();
    }
}