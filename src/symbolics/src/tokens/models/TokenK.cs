//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Token<K> : IToken<K>
        where K : unmanaged
    {
        public readonly uint Index;

        public readonly K Kind;

        readonly string _Name;

        readonly string _Expr;

        [MethodImpl(Inline)]
        public Token(uint index,  K kind, string name, string expr)
        {
            Kind = kind;
            Index = index;
            _Name = name;
            _Expr = expr;
        }

        public ReadOnlySpan<char> Name
        {
            [MethodImpl(Inline)]
            get => _Name;
        }

        public ReadOnlySpan<char> Expr
        {
            [MethodImpl(Inline)]
            get => _Expr;
        }

        uint IToken.Index 
            => Index;

        K IToken<K>.Kind 
            => Kind;
    }
}