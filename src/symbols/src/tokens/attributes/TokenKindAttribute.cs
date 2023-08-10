//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class TokenKindAttribute : Attribute
    {
        public readonly object Kind;
        
        public TokenKindAttribute(object kind)
        {
            Kind = kind;
        }
    }
}