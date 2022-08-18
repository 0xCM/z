//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class UQ
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Returns the number of characters that precede a null-terminator, if any; otherwise returns the lenght of the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<char> src)
        {
            var counter = 0u;
            var max = (uint)src.Length;

            if(max == 0)
                return 0;

            for(var i=0u; i<max; i++)
                if(skip(src,i) == 0)
                    return i;
            return max;
        }

        /// <summary>
        /// Returns true if the source begins with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        public static bool begins(ReadOnlySpan<char> src, char match)
            => length(src) != 0 && first(src) == match;

        /// <summary>
        /// Returns true if the source begins with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        public static bool begins(ReadOnlySpan<char> src, ReadOnlySpan<char> match)
            => length(src) != 0 && src.StartsWith(match);
    }
}