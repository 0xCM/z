//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public readonly partial struct XmlParts
{
    [MethodImpl(Inline), Op]
    public static Element element(IXmlPart ancestore, string name, XmlAttributes attributes)
        => new (ancestore, name, attributes);

    [MethodImpl(Inline), Op]
    public static XmlAttributes attributes()
        => new ();

    [MethodImpl(Inline), Op]
    public static ElementEnd close(string name)
        => new (name);

    [MethodImpl(Inline), Op]
    public static XmlAttribute attribute(string name, string value)
        => new (name,value);

    [MethodImpl(Inline), Op]
    public static XmlDocType doctype(string name, string value)
        => new (name,value);

    [MethodImpl(Inline), Op]
    public static CDATA cdata(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static XmlText xmltext(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static Declaration declaration(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static XmlText fragment(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static Comment comment(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static XmlInstruction instruction(string name, string value)
        => new (name, value);

    [MethodImpl(Inline), Op]
    public static XmlText notation(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static Entity entity(string value, bool start)
        => new (value, start);

    [MethodImpl(Inline), Op]
    public static EntityRef entityref(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static XmlDoc doc(string value)
        => new (value);

    [MethodImpl(Inline), Op]
    public static Whitespace whitespace(string value, bool significant)
        => new (value, significant);

    [MethodImpl(Inline), Op]
    public static Empty empty()
        => new Empty(EmptyString);
}
