//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Xml;

    using static Root;

    partial struct XmlParts
    {
        public readonly struct Comment : IXmlPart<NameOld>
        {
            public NameOld Value{get;}

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