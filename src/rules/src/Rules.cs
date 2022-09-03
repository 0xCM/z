//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct Rules
    {
        const NumericKind Closure = UnsignedInts;

        public static RuleValue value(string src, bool terminal = false)
            => new RuleValue(src, terminal);

        [Op, Closures(Closure)]
        public static uint evaluate<T>(Adjacent<T> rule, ReadOnlySpan<T> src, Span<uint> dst)
            where T : IEquatable<T>
        {
            var terms = Math.Min(src.Length - 1, dst.Length);
            var matched = 0u;
            for(var i=0u; i<terms; i++)
            {
                if((skip(src, i).Equals(rule.Content.Left) && skip(src, i + 1).Equals(rule.Content.Right)))
                    seek(dst, matched++) = i;
            }
            return matched;
        }

        public static void emit(ReadOnlySpan<IProduction> src, FilePath dst)
        {
            var count = src.Length;
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i).Format());
        }

        public static TextReplace replace(FilePath src)
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
            return new TextReplace(dst);
        }

        [Op, Closures(Closure)]
        public static Replacements<T> replacements<T>(params Pair<T>[] src)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = sys.alloc<ReplaceRule<T>>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = new ReplaceRule<T>(skip(src,i).Left, skip(src,i).Right);
            return buffer;
        }

        public static TextMap textmap(FilePath src)
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

                dst[source] = target;
            }
            var lu = dst.ToConstLookup();
            return new TextMap(lu, sys.map(lu.Entries, e => production(e.Key, e.Value)));
        }

        static IProduction production(string src, string dst)
        {
            if(Fenced.test(dst, Fenced.Bracketed))
            {
                var content = Fenced.unfence(dst, Fenced.Bracketed);
                var terms = map(text.trim(text.split(content,Chars.Pipe)), x => value(x));
                return new SeqProduction(value(text.trim(src)), new SeqExpr(terms));
            }
            else if(Fenced.test(dst, Fenced.Angled))
            {
                var content = Fenced.unfence(dst, Fenced.Angled);
                var terms = map(text.trim(text.split(content,Chars.Pipe)), x => value(x));
                return new SeqProduction(value(text.trim(src)), new SeqExpr(terms));
            }
            else
                return new Production(value(text.trim(src)), value(text.trim(dst)));
        }

        public static bool IsChoice(string src)
            => Fenced.test(src,ChoiceFence);

        public static bool IsOption(string src)
            => Fenced.test(src, OptionFence);

        public static Outcome parse(string src, out IRuleExpr dst)
        {
            var result = Outcome.Success;
            dst = default;

            if(IsOption(src))
            {
                result = parse(src, out IOptionRule r);
                if(result)
                    dst = r;
            }
            else if(IsChoice(src))
            {
                result = parse(src, out IChoiceRule r);
                if(result)
                    dst = r;
            }
            else
            {
                dst = value(src);
            }
            return result;
        }

        static Outcome parse(string src, out IChoiceRule dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(IsChoice(src))
            {
                var termSrc = text.trim(text.split(Fenced.unfence(src, ChoiceFence), ChoiceSep));
                var count = termSrc.Length;
                var terms = alloc<IRuleExpr>(count);
                for(var i=0; i<count; i++)
                {
                    result = parse(skip(termSrc, i), out seek(terms,i));
                    if(result.Fail)
                         break;
                }

                if(result)
                    dst = new ChoiceRule<IRuleExpr>(terms);
            }
            else
            {
                result = (false,string.Format("{0} fence not found", ChoiceFence));
            }
            return result;
        }

        static Outcome parse(string src, out IOptionRule dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(IsOption(src))
            {
                result = parse(Fenced.unfence(src, OptionFence), out IRuleExpr expr);
                if(result)
                    dst = new Optional<IRuleExpr>(expr);
            }
            else
            {
                result = (false, string.Format("{0} fence not found", OptionFence));
            }
            return result;
        }

        static Fence<char> OptionFence => Fenced.Bracketed;

        static Fence<char> ChoiceFence => Fenced.Angled;

        const char ChoiceSep = Chars.Pipe;
    }
}