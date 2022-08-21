//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FormatPatternAttribute : Attribute
    {
        public FormatPatternAttribute(string pattern)
        {
            Pattern = pattern;
        }

        public string Pattern {get;}
    }
}