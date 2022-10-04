//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ts
{
    partial class Generators
    {
        class TokenGenerator<K,V> : Cg<TokenGenerator<K,V>,Token<K,V>,string>
            where K : new()
            where V : new()
        {
            TokenTemplate<K,V> Template;

            public TokenGenerator()
            {
                Template = new();
            }

            public override string Gen(Token<K,V> src)
                => Template.Bind(src).Format();
        }    
    }    
}