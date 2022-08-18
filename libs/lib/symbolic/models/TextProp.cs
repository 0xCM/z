//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TextProp : ITextual
    {
        [MethodImpl(Inline), Op]
        public static TextProp define<T>(NameOld name, T value)
            => new TextProp(name, string.Format("{0}", value));

        public NameOld Name {get;}

        public TextBlock Value {get;}

        [MethodImpl(Inline)]
        public TextProp(NameOld name, TextBlock value)
        {
            Name = name;
            Value = value;
        }

        PropFormat<TextBlock> FormatProp
            => new PropFormat<TextBlock>(Name, Value);
        public string Format()
            => FormatProp.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TextProp((string name, string value) src)
            => new TextProp(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator PropFormat<TextBlock>(TextProp src)
            => src.FormatProp;
    }
}