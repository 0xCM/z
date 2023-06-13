//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class TextMap
    {
        public static TextMap load(FilePath src)
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

        static RuleValue value(string src, bool terminal = false)
            => new RuleValue(src, terminal);

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


        ConstLookup<string,string> Data;

        Index<IProduction> _Productions;

        public TextMap(ConstLookup<string,string> src, IProduction[] productions)
        {
            Data = src;
            _Productions = productions;
        }

        public ReadOnlySpan<IProduction> Productions
        {
            [MethodImpl(Inline)]
            get => _Productions;
        }

        public string Apply(string src)
        {
            if(Data.Find(src, out var dst))
                return dst;
            else
                return src;
        }

        public string Format()
        {
            var dst = text.buffer();
            var count = _Productions.Count;
            for(var i=0; i<count; i++)
            {
                dst.AppendLine(_Productions[i].Format());
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}