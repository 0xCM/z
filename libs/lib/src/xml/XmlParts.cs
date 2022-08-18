//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct XmlParts
    {
        [MethodImpl(Inline), Op]
        public static Element element(IXmlPart ancestore, string name, XmlAttributes attributes)
            => new Element(ancestore, name, attributes);

        [MethodImpl(Inline), Op]
        public static XmlAttributes attributes()
            => new XmlAttributes();

        [MethodImpl(Inline), Op]
        public static ElementEnd close(string name)
            => new ElementEnd(name);

        [MethodImpl(Inline), Op]
        public static XmlAttribute attribute(string name, string value)
            => new XmlAttribute(name,value);

        [MethodImpl(Inline), Op]
        public static XmlDocType doctype(string name, string value)
            => new XmlDocType(name,value);

        [MethodImpl(Inline), Op]
        public static CDATA cdata(string value)
            => new CDATA(value);

        [MethodImpl(Inline), Op]
        public static XmlText xmltext(string value)
            => new XmlText(value);

        [MethodImpl(Inline), Op]
        public static Declaration declaration(string value)
            => new Declaration(value);

        [MethodImpl(Inline), Op]
        public static XmlText fragment(string value)
            => new XmlText(value);

        [MethodImpl(Inline), Op]
        public static Comment comment(string value)
            => new Comment(value);

        [MethodImpl(Inline), Op]
        public static XmlInstruction instruction(string name, string value)
            => new XmlInstruction(name, value);

        [MethodImpl(Inline), Op]
        public static XmlText notation(string value)
            => new XmlText(value);

        [MethodImpl(Inline), Op]
        public static Entity entity(string value, bool start)
            => new Entity(value, start);

        [MethodImpl(Inline), Op]
        public static EntityRef entityref(string value)
            => new EntityRef(value);

        [MethodImpl(Inline), Op]
        public static XmlDoc doc(string value)
            => new XmlDoc(value);

        [MethodImpl(Inline), Op]
        public static Whitespace whitespace(string value, bool significant)
            => new Whitespace(value, significant);

        [MethodImpl(Inline), Op]
        public static Empty empty()
            => new Empty(EmptyString);
    }
}