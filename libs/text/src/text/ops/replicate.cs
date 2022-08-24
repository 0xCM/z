//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Creates a stream of replicated characters
        /// </summary>
        /// <param name="src">The character to replicate</param>
        /// <param name="count">The replication count</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> replicate(char src, int count)
            => new string(src, count);

        /// <summary>
        /// Repeats a string a specified number of times
        /// </summary>
        /// <param name="src">The text content to replicate</param>
        /// <param name="count">The number of copies to produce</param>
        [MethodImpl(Inline), Op]
        public static IEnumerable<string> replicate(string src, int count)
            => src.Replicate(count);
    }
}