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

        [Op]
        static string pad(int pad)
            => pad == 0 ? "{0}" : "{0," + pad.ToString() + "}";

        /// <summary>
        /// Defines the format pattern '{n,pad}'
        /// </summary>
        /// <param name="n">The zero-based slot index</param>
        /// <param name="pad">The pad width specifier</param>
        [Op]
        static string pad(uint n, int pad)
            => "{0" + n.ToString() + "," + pad.ToString() + "}";

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