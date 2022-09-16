//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TokenKindAttribute<K> : Attribute
        where K : unmanaged, Enum
    {
        public readonly K Kind;

        public TokenKindAttribute(K kind)
        {
            Kind = kind;
        }
    }
}