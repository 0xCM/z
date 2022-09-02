//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static Rules;

    public class TextReplace : Rule
    {
        readonly Dictionary<string,string> Rules;

        public TextReplace(Dictionary<string,string> rules)
        {
            Rules = rules;
        }

        public string Apply(string src)
        {
            var dst = src;
            foreach(var rule in Rules)
                dst = text.replace(dst, rule.Key, rule.Value);
            return dst;
        }

        public override string Format()
        {
            var dst = text.buffer();
            iter(Rules, r => dst.AppendLineFormat("{0} -> {1}", r.Key, r.Value));
            return dst.Emit();
        }
    }
}