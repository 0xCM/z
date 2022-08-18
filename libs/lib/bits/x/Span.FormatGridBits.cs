//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Formats a span as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="wRow">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        [Op]
        public static string FormatGridBits(this Span<byte> src, int wRow, int? maxbits = null, bool showrow = false)
            => BitRender.grid(src.ReadOnly(), wRow, maxbits, showrow);

        /// <summary>
        /// Formats a span as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="wRow">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        [Op]
        public static string FormatGridBits(this ReadOnlySpan<byte> src, int wRow, int? maxbits = null, bool showrow = false)
            => BitRender.grid(src, wRow, maxbits, showrow);

        /// <summary>
        /// Formats a span as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="wRow">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        [Op]
        public static string FormatGridBits(this Span<byte> src, uint wRow, uint? maxbits = null, bool showrow = false)
            => BitRender.grid(src.ReadOnly(), (int)wRow, (int?)maxbits, showrow);

        /// <summary>
        /// Formats a span as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="wRow">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        [Op]
        public static string FormatGridBits(this ReadOnlySpan<byte> src, uint wRow, uint? maxbits = null, bool showrow = false)
            => BitRender.grid(src, (int)wRow, (int?)maxbits, showrow);

        /// <summary>
        /// Formats the content of a generic span of primal cells as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="wRow">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        public static string FormatGridBits<T>(this Span<T> src, int wRow, int? maxbits = null, bool showrow = false)
            where T : unmanaged
                => BitRender.grid(src, wRow, maxbits, showrow);

        /// <summary>
        /// Formats the content of a generic span of primal cells as a bitmatrix
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="wRow">The number of bits in each row</param>
        /// <param name="maxbits">The maximum number of bits to format</param>
        /// <param name="showrow">Indicates whether the content of each row shold be preceded by the row index</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        public static string FormatGridBits<T>(this ReadOnlySpan<T> src, int wRow, int? maxbits = null, bool showrow = false)
            where T : unmanaged
                => BitRender.grid(src, wRow, maxbits, showrow);
    }
}