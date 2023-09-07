//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IXmlPart
{
    XmlNodeType Kind {get;}

    dynamic Value {get;}

    IXmlPart Ancestor
        => XmlParts.empty();

    string Name
        => EmptyString;

    bool HasName
        => text.nonempty(Name);

    bool IsWhitespace
        => Kind == XmlNodeType.Whitespace || Kind == XmlNodeType.SignificantWhitespace;
}

public interface IXmlPart<T> : IXmlPart
{
    new T Value {get;}

    dynamic IXmlPart.Value
        => Value;
}
