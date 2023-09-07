//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct XmlParts
{
    public readonly struct CDATA : IXmlPart<string>
    {
        public string Value {get;}

        public XmlNodeType Kind => XmlNodeType.CDATA;

        [MethodImpl(Inline)]
        public CDATA(string value)
        {
            Value = value;
        }

        public string Format()
            => string.Format("<![CDATA[{0}]]>", Value);
    }
}
