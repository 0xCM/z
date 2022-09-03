//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
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
                dst.AppendFormat(RP.pad(pad), Spans.skip(src,i));
            }
            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, char sep, int pad = 0)
        {
            var dst = new StringBuilder();
            var slot = RP.pad(pad);
            for(var i=0; i<src.Length; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.AppendFormat(slot, Spans.skip(src,i));
            }
            return dst.ToString();
        }
    }
}