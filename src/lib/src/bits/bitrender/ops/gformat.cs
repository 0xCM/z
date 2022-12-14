//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static sys;

    partial struct BitRender
    {
        [Op, Closures(Closure)]
        public static string gformat<T>(T src)
            where T : struct
                => gformat(src, BitFormatter.configure());

        [Op, Closures(Closure)]
        public static string gformat<T>(T src, in BitFormat config)
            where T : struct
                => format(sys.bytes(src), config);

        [Op, Closures(Closure)]
        public static string gformat<T>(ReadOnlySpan<T> src, BitFormat? config = null)
            where T : unmanaged
        {
            var dst = new StringBuilder();
            var cells = src.Length;
            var cfg = config ?? BitFormatter.configure();
            for(var i=0; i<cells; i++)
                dst.Append(gformat<T>(skip(src,i), cfg));
            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string gformat<T>(T src, int? digits = null)
            where T : unmanaged
                => gformat(src, digits != null ? BitFormatter.limited((uint)digits.Value, digits.Value) : BitFormatter.configure());

        /// <summary>
        /// Formats a named bitfield segment
        /// </summary>
        /// <param name="value">The field value</param>
        /// <typeparam name="T">The field value type</typeparam>
        [Op, Closures(Closure)]
        public static string gformat<T>(T src, string name, int? zpad = null)
            where T : unmanaged
                => string.Concat(name, Chars.Colon, formatter<T>(BitFormatter.limited((uint)Widths.effective(src), zpad)).Format(src));
    }
}