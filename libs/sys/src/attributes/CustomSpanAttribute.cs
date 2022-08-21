//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct)]
    public class CustomSpanAttribute : Attribute
    {
        public CustomSpanAttribute(string indicator)
            => Indicator = indicator;

        public string Indicator {get;}
    }
}