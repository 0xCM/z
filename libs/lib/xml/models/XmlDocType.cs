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
        public readonly struct XmlDocType : IXmlPart<string>
        {
            public NameOld Name {get;}

            public string Value {get;}

            [MethodImpl(Inline)]
            public XmlDocType(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public XmlNodeType Kind
                => XmlNodeType.DocumentType;

            public string Format()
                => string.Format("<!DOCTYPE {0} [{1}]", Name, Value);
        }
    }
}