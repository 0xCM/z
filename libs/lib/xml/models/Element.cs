//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml;

    using static Root;

    partial struct XmlParts
    {
        public readonly struct Element : IXmlElement
        {
            public IXmlPart Ancestor {get;}

            public NameOld Name {get;}

            public NameOld Value {get;}

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