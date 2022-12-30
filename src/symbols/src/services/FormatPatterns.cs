//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class FormatPatterns
    {
        public readonly struct PatternSource
        {
            public const string FormatPattern = "{0}:{1}";

            readonly FieldInfo Field;

            readonly string Content;

            [MethodImpl(Inline)]
            public PatternSource(FieldInfo src, string content)
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

        [Op]
        public static ReadOnlySeq<PatternSource> from(Type src)
        {
            var values = src.LiteralFieldValues<string>(out var fields);
            var count = values.Length;
            var buffer = sys.alloc<PatternSource>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new PatternSource(skip(fields,i), skip(values,i));
            return buffer;
        }
    }
}