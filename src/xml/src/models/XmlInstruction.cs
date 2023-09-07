//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XmlParts
    {
        public readonly struct XmlInstruction : IXmlPart<string>
        {
            public string Name {get;}

            public string Value {get;}

            [MethodImpl(Inline)]
            public XmlInstruction(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public XmlNodeType Kind
                => XmlNodeType.ProcessingInstruction;

            public string Format()
                => string.Format("{0}:{1}", Name, Value);
        }
    }
}