//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Token<K,T> : IToken<K,T>
        where K : unmanaged
        where T : unmanaged, ICharBlock
    {
        public readonly uint Index;

        public readonly K Kind;

        public readonly T _Name;

        public readonly T _Expr;

        public Token(uint index, K kind, T name, T expr)
        {
            Kind = kind;
            Index = index;
            _Name = name;
            _Expr = expr;
        }

        public ReadOnlySpan<char> Name
        {
            [MethodImpl(Inline)]
            get => Name;
        }

        public ReadOnlySpan<char> Expr
        {
            [MethodImpl(Inline)]
            get => Expr;
        }

        uint IToken.Index 
            => Index;

        K IToken<K>.Kind 
            => Kind;

        T IToken<K, T>.Name 
            => _Name;

        T IToken<K, T>.Expr 
            => _Expr;
    }
}