//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XmlParts
    {
        public readonly struct XmlText : IXmlPart<string>
        {
            public string Value {get;}

            public XmlNodeType Kind => XmlNodeType.Text;

            [MethodImpl(Inline)]
            public XmlText(string value)
            {
                Value = value;
            }

            public string Format()
                => string.Format("{0}", Value);

            public static XmlText Empty
            {
                [MethodImpl(Inline)]
                get => new XmlText(EmptyString);
            }
        }
    }
}