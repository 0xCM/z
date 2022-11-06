//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;

    partial struct XmlParts
    {
        public readonly struct ElementEnd : IXmlPart<NameOld>
        {
            public NameOld Value {get;}

            public XmlNodeType Kind => XmlNodeType.EndElement;

            [MethodImpl(Inline)]
            public ElementEnd(string value)
            {
                Value = value;
            }

            public string Format()
                => string.Format("</{0}>", Value);
        }
    }
}