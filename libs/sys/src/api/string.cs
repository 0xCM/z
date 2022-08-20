//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Projects the source onto its textual representation
        /// </summary>
        /// <param name="src">The source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static string @string<T>(T src)
            => src?.ToString() ?? EmptyString;

        [MethodImpl(Options), Op]
        public static unsafe string @string(char* pSrc)
            => new string(pSrc);

        [MethodImpl(Options), Op]
        public static string @string(ReadOnlySpan<char> src)
            => new string(src);
    }
}