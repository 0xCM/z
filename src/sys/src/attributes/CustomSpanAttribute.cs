//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class CustomSpanAttribute : Attribute
    {
        public CustomSpanAttribute(string indicator)
            => Indicator = indicator;

        public string Indicator {get;}
    }
}