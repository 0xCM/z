//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost,Free]
    public class Delimiting
    {
        const NumericKind Closure = UInt64k;

        public const char DefaultDelimiter = Chars.Comma; 

        public static DelimitedSeq<T> seq<T>(ReadOnlySeq<T> src, char delimiter = DefaultDelimiter, int pad = 0, Fence<char>? fence = null)
            => new(src,delimiter,pad,fence);

        public static DelimitedSeq<T> seq<T>(ReadOnlySeq<T> src, char delimiter, Fence<char> fence)
            => new(src,delimiter,0,fence);

        [Op]
        static string pad(int pad)
            => pad == 0 ? "{0}" : "{0," + pad.ToString() + "}";

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedSpan<T> delimit<T>(char delimiter, int pad, Span<T> src)
            => new DelimitedSpan<T>(src, delimiter, pad);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedSpan<T> delimit<T>(char delimiter, int pad, ReadOnlySpan<T> src)
            => new DelimitedSpan<T>(src, delimiter, pad);

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, string sep, int pad = 0)
        {
            var dst = new StringBuilder();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i!=0)
                    dst.Append(sep);
                dst.AppendFormat(Delimiting.pad(pad), sys.skip(src,i));
            }
            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, Func<T,string> formatter, string sep, int pad = 0)
        {
            var dst = new StringBuilder();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i!=0)
                    dst.Append(sep);
                dst.AppendFormat(Delimiting.pad(pad), formatter(sys.skip(src,i)));
            }
            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, char sep, int pad = 0)
        {
            var dst = new StringBuilder();
            var slot = Delimiting.pad(pad);
            for(var i=0; i<src.Length; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.AppendFormat(slot, sys.skip(src,i));
            }
            return dst.ToString();
        }         
    }
}