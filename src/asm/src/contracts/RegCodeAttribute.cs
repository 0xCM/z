//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{

    [AttributeUsage(AttributeTargets.Enum)]
    public class RegCodeAttribute : Attribute
    {
        public RegCodeAttribute()
        {

        }

        public RegCodeAttribute(AsmRegTokenKind kind)
        {
            RegKind = kind;
        }

        public AsmRegTokenKind RegKind {get;}
    }
}