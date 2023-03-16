//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XmlParts
    {
        public readonly struct Comment : IXmlPart<TextBlock>
        {
            public TextBlock Value{get;}

            [MethodImpl(Inline)]
            public Comment(string value)
            {
                Value = value;
            }

            public XmlNodeType Kind
                => XmlNodeType.Comment;
        }
    }
}