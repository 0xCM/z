//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class text
    {
        [Op]
        public static string pad(int pad)
            => pad == 0 ? "{0}" : "{0," + pad.ToString() + "}";

        /// <summary>
        /// Defines the format pattern '{n,pad}'
        /// </summary>
        /// <param name="n">The zero-based slot index</param>
        /// <param name="pad">The pad width specifier</param>
        [Op]
        public static string pad(uint n, int pad)
            => "{0" + n.ToString() + "," + pad.ToString() + "}";

        [Op]
        public static string pad(string src, int left, int right, char a, char b)
            => rpad(lpad(src, left, a), right, b);

        [Op]
        public static string pad(string src, uint left, uint right, char a, char b)
            => rpad(lpad(src, left, a), right, b);

        [Op]
        public static Index<string> pad(ReadOnlySpan<string> src, int left, int right, char a, char b)
            => map(src, x => pad(x, left, right, a, b));

        [Op]
        public static Index<string> pad(ReadOnlySpan<string> src, uint left, uint right, char a, char b)
            => map(src, x => pad(x, left, right, a, b));
    }
}