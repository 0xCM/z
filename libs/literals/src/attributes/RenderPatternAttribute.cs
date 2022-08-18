//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RenderPatternAttribute : Attribute
    {
        public readonly string PatternText;

        public readonly byte ArgCount;

        public RenderPatternAttribute(byte args, string pattern)
        {
            PatternText = pattern;
            ArgCount = args;
        }
    }
}