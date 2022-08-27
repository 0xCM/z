//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines common format function delegates
    /// </summary>
    public readonly struct FormatDelegates
    {
        public delegate string FormatCells<T>(ReadOnlySpan<T> src, char delimiter, int pad);

        /// <summary>
        /// Characterizes a content render function
        /// </summary>
        /// <param name="src">The content value</param>
        /// <typeparam name="T">The content type</typeparam>
        public delegate string FormatCell<T>(in T src);
    }
}