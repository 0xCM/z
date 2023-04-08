//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XmlComments
    {
        static Fence<string> SummaryFence = Fenced.define("<summary>", "</summary>");

        public readonly struct Summary
        {
            public static bool parse(string src, out Summary dst)
            {
                var result = false;
                dst = Empty;
                if(Fenced.test(src, SummaryFence))
                {
                    var data = Fenced.unfence(src, SummaryFence);
                    if(nonempty(data))
                    {
                        var content = text.trim(Fenced.unfence(src, SummaryFence));
                        iter(Replacements, kvp => content = text.replace(content, kvp.Key, kvp.Value));
                        dst = new (map(Lines.read(content), x=> x.Content).Concat(Chars.Eol));
                        result = true;
                    }
                }
                return result;
            }

            public readonly string Content;

            [MethodImpl(Inline)]
            public Summary(string content)
            {
                Content = content;
            }

            public string Format()
                => Content;

            public override string ToString()
                => Content;

            public static Summary Empty => new Summary(EmptyString);
        }
    }
}