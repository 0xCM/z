//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public sealed record class Token<K> : IToken<K>
        where K : unmanaged, Enum
    {
        public uint Index;

        public K Kind;

        public string Name;

        public string Expr;

        public string Description;

        uint IToken.Index 
            => Index;

        K IToken<K>.Kind 
            => Kind;

        ReadOnlySpan<char> IToken.Name
            => Name;

        ReadOnlySpan<char> IToken.Expr
            => Name;     
    }
}