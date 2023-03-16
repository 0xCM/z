//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XmlParts
    {
        public readonly struct Empty : IXmlPart<string>
        {
            public string Value {get;}

            [MethodImpl(Inline)]
            public Empty(string value)
            {
                Value = value;
            }

            public XmlNodeType Kind
                => XmlNodeType.None;

            public override string ToString()
                => "!!<empty>!!";
        }
    }
}