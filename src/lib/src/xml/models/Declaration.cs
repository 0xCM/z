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
}