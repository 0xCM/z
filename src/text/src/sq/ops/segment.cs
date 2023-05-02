//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Extracts an index-identified substring
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first character in the substring</param>
        /// <param name="i1">The index of the last character in the substring</param>
        [Op]
        public static ReadOnlySpan<char> segment(ReadOnlySpan<char> src, int i0, int i1)
        {
            var length = i1 - i0 + 1;
            if(length < 0  || length - i0 > src.Length)
                @throw($"The segment [{i0},{i1}] is ill-defined");
            return sys.slice(src, i0, length);
        }
    }
}