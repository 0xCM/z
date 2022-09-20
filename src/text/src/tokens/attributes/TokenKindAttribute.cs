//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TokenKindAttribute : Attribute
    {
        public readonly object Kind;
        
        public TokenKindAttribute(object kind)
        {
            Kind = kind;
        }
    }
}