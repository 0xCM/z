//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class TextReplacements
    {
        public static TextReplacements load(FilePath src)
        {
            const string Sep = " -> ";
            var dst = dict<string,string>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var i = line.Index(Sep);
                if(i == NotFound)
                    continue;

                var source = text.left(line.Content,i);
                var target = text.right(line.Content,i + Sep.Length - 1);
                if(Fenced.test(target, Fenced.SQuote))
                    dst[source] = Fenced.unfence(target, Fenced.SQuote);
                else
                    dst[source] = target;
            }
            return new TextReplacements(dst);
        }

        readonly Dictionary<string,string> Rules;

        public TextReplacements(Dictionary<string,string> rules)
        {
            Rules = rules;
        }

        public string Apply(string src)
        {
            var dst = text.trim(src);
            foreach(var rule in Rules)
                dst = text.replace(dst, rule.Key, rule.Value);
            return text.despace(dst);
        }

        public string Format()
        {
            var dst = text.buffer();
            iter(Rules, r => dst.AppendLineFormat("{0} -> {1}", r.Key, r.Value));
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}