//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;

    partial struct XmlParts
    {
        public readonly struct EntityRef : IXmlPart<TextBlock>
        {
            public TextBlock Value {get;}

            [MethodImpl(Inline)]
            public EntityRef(string value)
            {
                Value = value;
            }

            public XmlNodeType Kind
                => XmlNodeType.EntityReference;

            public string Format()
                => string.Format("{0}", Value);
        }
    }
}