//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;

    partial struct XmlParts
    {
        public readonly struct Element : IXmlElement
        {
            public IXmlPart Ancestor {get;}

            public string Name {get;}

            public string Value {get;}

            public XmlAttributes Attributes {get;}

            [MethodImpl(Inline)]
            public Element(IXmlPart ancestor, string value, XmlAttributes attributes)
            {
                Ancestor = ancestor;
                Name = value;
                Value = value;
                Attributes = attributes;
            }

            public XmlNodeType Kind
                => XmlNodeType.Element;

            public override string ToString()
                => Name;
        }
    }
}