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
        public readonly struct XmlDoc : IXmlPart<string>
        {
            public string Value {get;}

            [MethodImpl(Inline)]
            public XmlDoc(string value)
            {
                Value = value;
            }

            public XmlNodeType Kind
                => XmlNodeType.Document;

            public override string ToString()
                => "Document";
        }
    }
}