//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public sealed record class Token<K> : IToken<K>
        where K : unmanaged
    {
        public uint Index;

        public K Kind;

        public string Name;

        public string Expr;

        public string Info;

        string IToken.Group
            => typeof(K).Name;

        uint IToken.Index
            => Index;
        K IToken<K>.Kind 
            => Kind;

        string IToken.Name
            => Name;

        string IToken.Expr
            => Name;     

        string IToken.Info
            => Info;
    }
}