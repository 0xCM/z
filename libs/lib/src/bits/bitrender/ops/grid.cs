//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BitRender
    {
        /// <summary>
        /// Formats a span as a bitgrid
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="rowlen">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        public static string grid(ReadOnlySpan<byte> src, int rowlen, int? maxbits, bool showrow)
        {
            var dst = render8x8(src).View;
            var sb = text.buffer();
            var limit = maxbits ?? dst.Length;
            for(int i=0, rowidx=0; i<limit; i+= rowlen, rowidx++)
            {
                var remaining = dst.Length - i;
                var segment = min(remaining, rowlen);
                var rowbits = dst.Slice(i, segment);
                var rowprefix = showrow ? $"{rowidx.ToString().PadRight(3)} | " : string.Empty;
                var rowformat = rowprefix + sys.@string(rowbits.Intersperse(Chars.Space));
                sb.AppendLine(rowformat);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Formats the content of a generic span of primal cells as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="rowlen">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        public static string grid<T>(Span<T> src, int rowlen, int? maxbits = null, bool showrow = false)
            where T : unmanaged
                => grid(src.Bytes().ReadOnly(), rowlen, maxbits, showrow);

        /// <summary>
        /// Formats the content of a generic span of primal cells as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="rowlen">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        public static string grid<T>(ReadOnlySpan<T> src, int rowlen, int? maxbits = null, bool showrow = false)
            where T : unmanaged
                => grid(src.Bytes(), rowlen, maxbits, showrow);
    }
}