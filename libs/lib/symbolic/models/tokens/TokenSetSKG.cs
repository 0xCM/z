//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TokenSet<S,K,G>
        where K : unmanaged, Enum
        where S : TokenSet<S,K,G>, new()
        where G : ITokenGroup<G,K>, new()
    {
        public static S create()
            => new S();
    }
}