//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct XmlDoc : ITextual
    {
        [MethodImpl(Inline)]
        public static XmlDoc define(string content)
            => new XmlDoc(content);

        public TextBlock Content {get;}

        [MethodImpl(Inline)]
        public XmlDoc(TextBlock content)
        {
            Content = content;
        }

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator XmlDoc(string src)
            => new XmlDoc(src);
    }
}