//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Xml;

    public interface IXmlPart
    {
        XmlNodeType Kind {get;}

        dynamic Value {get;}

        IXmlPart Ancestor
            => XmlParts.empty();

        NameOld Name
            => NameOld.Empty;

        bool HasName
            => Name.IsNonEmpty;

        bool IsWhitespace
            => Kind == XmlNodeType.Whitespace || Kind == XmlNodeType.SignificantWhitespace;
    }

    public interface IXmlPart<T> : IXmlPart
    {
        new T Value {get;}

        dynamic IXmlPart.Value
            => Value;
    }
}