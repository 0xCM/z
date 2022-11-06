//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Xml;

    using static Root;

    partial struct XmlParts
    {
        public readonly struct Whitespace : IXmlPart<string>
        {
            public string Value {get;}

            public bool Significant {get;}

            [MethodImpl(Inline)]
            public Whitespace(string value, bool significant)
            {
                Value = value;
                Significant = significant;
            }
            public XmlNodeType Kind
                => Significant ? XmlNodeType.SignificantWhitespace : XmlNodeType.Whitespace;
        }
    }
}