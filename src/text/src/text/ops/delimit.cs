//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    partial class text
    {
        [Op]
        public static string delimit(N2 n, string sep)
            => "{0}" + sep + "{1}";

        [Op]
        public static string delimit(N3 n, string sep)
            => "{0}" + sep + "{1}" + sep + "{2}";

        [Op]
        public static string delimit(N4 n, string sep)
            => "{0}" + sep + "{1}" + sep + "{2}" + sep + "{3}";

        [Op]
        public static string delimit(N5 n, string sep)
            => "{0}" + sep + "{1}" + sep + "{2}" + sep + "{3}" + sep + "{4}";

        public static string delimit<T>(ReadOnlySpan<T> src, string sep, int pad = 0)
        {
            var dst = new StringBuilder();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i!=0)
                    dst.Append(sep);
                dst.AppendFormat(RP.pad(pad), sys.skip(src,i));
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
                dst.AppendFormat(slot, sys.skip(src,i));
            }
            return dst.ToString();
        }
    }
}