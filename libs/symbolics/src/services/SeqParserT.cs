//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct SeqParser<T> : IParser<T[]>
    {
        readonly IParser<T> TermParser;

        readonly string Delimiter;

        readonly bool SplitClean;

        [MethodImpl(Inline)]
        public SeqParser(IParser<T> terms, string delimiter, bool clean = true)
        {
            Delimiter = delimiter;
            TermParser = terms;
            SplitClean = clean;
        }

        [MethodImpl(Inline)]
        public SeqParser(IParser<T> terms, char delimiter, bool clean = true)
        {
            Delimiter = delimiter.ToString();
            TermParser = terms;
            SplitClean = clean;
        }

        [MethodImpl(Inline)]
        public Outcome Parse(string src, out T[] dst)
        {
            dst = array<T>();
            var components = text.split(src, Delimiter, SplitClean);
            var count = components.Length;
            var result = Outcome.Success;
            if(count != 0)
            {
                dst = alloc<T>(count);
                ref var target = ref first(dst);
                for(var i=0; i<count; i++)
                {
                    ref readonly var component = ref skip(components,i);
                    result = TermParser.Parse(component, out var term);
                    if(result)
                        seek(target,i) = term;
                    else
                        break;
                }
            }
            return result;
        }
    }
}