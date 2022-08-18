//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        /// <summary>
        /// Tests whether a specified <see cref='string'/> is nonempty
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static bit nonempty(string src)
            => !string.IsNullOrEmpty(src);
    }
}