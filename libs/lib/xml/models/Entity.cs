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
        public readonly struct Entity : IXmlPart<string>
        {
            public string Value {get;}

            public bool Start {get;}

            [MethodImpl(Inline)]
            public Entity(string value, bool start)
            {
                Value = value;
                Start = start;
            }

            public XmlNodeType Kind
                => Start ? XmlNodeType.Entity : XmlNodeType.EndEntity;

            public string Format()
                => string.Format("{0}", Value);
        }
    }
}