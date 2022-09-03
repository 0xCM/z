//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RenderPatternSource
    {
        public const string FormatPattern = "{0}:{1}";

        readonly FieldInfo Field;

        readonly string Content;

        [MethodImpl(Inline)]
        public RenderPatternSource(FieldInfo src, string content)
        {
            Field = src;
            Content = content;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(FormatPattern, Field.Name, Content);

        public override string ToString()
            => Format();
    }
}