//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Lines
    {
        [Parser]
        public static bool parse(string src, out LineNumber dst)
        {
            dst = LineNumber.Empty;
            var result = NumericParser.parse(src, out uint n);
            if(result)
                dst = n;
            return result;
        }


        static Fence<char> RangeFence
            => (Chars.LBracket, Chars.RBracket);

        const string RangeDelimiter = "..";

        [Parser]
        public static Outcome parse(string src, out LineOffset dst)
        {
            var result = Outcome.Success;
            dst = LineOffset.Empty;
            var i = text.index(src,Chars.Colon);
            if(i>=0)
            {
                var left = text.left(src,i);
                var right = text.right(src,i);
                result = parse(left, out LineNumber line);
                if(result)
                {
                    result = DataParser.parse(right, out uint offset);
                    if(result)
                        dst = new LineOffset(line,offset);
                }
            }
            else
            {
                result = parse(src, out LineNumber line);
            }
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out LineInterval<Identifier> dst)
        {
            var result = Outcome.Success;
            dst = LineInterval<Identifier>.Empty;
            var i = text.index(src,Chars.Colon);
            if(i >= 0)
            {
                var id = text.left(src,i);
                result = Fenced.unfence(src, RangeFence, out var rs);
                if(result.Fail)
                    return result;

                var parts = text.split(rs, RangeDelimiter);
                if(parts.Length != 2)
                {
                    result = (false, string.Format("The range of {0} cannot be determined", src));
                    return result;
                }

                result = parse(skip(parts,0), out LineNumber min);
                if(result.Fail)
                    return result;

                result = parse(skip(parts,1), out LineNumber max);
                if(result.Fail)
                    return result;

                dst = new LineInterval<Identifier>(id,min,max);
            }
            return result;
        }

        [Parser]
        public static Outcome parse<T>(string src, IParser<T> parser,  out LineInterval<T> dst)
        {
            var result = Outcome.Success;
            dst = LineInterval<T>.Empty;
            var i = text.index(src,Chars.Colon);
            if(i >= 0)
            {
                result = Fenced.unfence(src, RangeFence, out var rs);
                if(result.Fail)
                    return result;

                var parts = text.split(rs, RangeDelimiter);
                if(parts.Length != 2)
                {
                    result = (false, string.Format("The range of {0} cannot be determined", src));
                    return result;
                }

                result = parse(skip(parts,0), out LineNumber min);
                if(result.Fail)
                    return result;

                result = parse(skip(parts,1), out LineNumber max);
                if(result.Fail)
                    return result;

                parser.Parse(text.left(src,i), out var id);
                dst = new LineInterval<T>(id,min,max);
            }
            return result;
        }
    }
}