//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct XmlParts
{
    public readonly struct Declaration : IXmlPart<string>
    {
        public string Value {get;}

        [MethodImpl(Inline)]
        public Declaration(string value)
        {
            Value = value;
        }

        public XmlNodeType Kind
            => XmlNodeType.XmlDeclaration;
    }
}
