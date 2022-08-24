//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Tuples;
    
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static Pair<int> indices(string src, Fence<char> fence)
            => pair(index(src, fence.Left), lastindex(src,fence.Right));

        /// <summary>
        /// Returns the indices of the first occurrences of the first and second strings in the source, if any
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="first">The first character to match</param>
        /// <param name="second">THe second character to match</param>
        [MethodImpl(Inline), Op]
        public static Pair<int> indices(string src, string first, string second)
            => pair(src.IndexOf(first), src.IndexOf(second));

        /// <summary>
        /// Returns the indices of the first occurrences of the first and second strings in the source, if any
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="first">The first character to match</param>
        /// <param name="second">THe second character to match</param>
        [MethodImpl(Inline), Op]
        public static Pair<int> indices(string src, Fence<string> fence)
            => pair(src.IndexOf(fence.Left), src.IndexOf(fence.Right));

        /// <summary>
        /// Returns the indicies of all locations of a specified character within specified text
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The character to match</param>
        [Op]
        public static Index<int> indices(string src, char match)
        {
            var dst = list<int>();
            var count = src.Length;
            ref readonly var c = ref @char(src);
            for(var i=0; i<count; i++)
                if(skip(c,i) == match)
                    dst.Add(i);
            return dst.ToArray();
        }

        /// <summary>
        /// Returns the indicies of all locations of a specified character within specified text
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The character to match</param>
        /// <param name="buffer">The matched index buffer</param>
        [Op]
        public static Span<int> indices(string src, char match, Span<int> buffer)
        {
            var count = src.Length;
            var max = buffer.Length;
            ref readonly var c = ref @char(src);
            var j = 0;
            for(var i=0; i<count && j<max; i++)
                if(skip(c,i) == match)
                    seek(buffer, j++) = i;

            return j != 0 ? sys.slice(buffer,0,j) : Span<int>.Empty;
        }

        /// <summary>
        /// Returns the indicies of all locations of a specified character within specified text
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The character to match</param>
        /// <param name="buffer">The matched index buffer</param>
        [Op]
        public static int indices(string src, string match, Span<int> buffer)
        {
            var count = src.Length;
            var max = buffer.Length;
            var j = 0;
            var i = src.IndexOf(match);
            while(i != NotFound && j<max)
            {
                seek(buffer,j++) = i;
                i = src.IndexOf(match, i + 1);
            }

            return j;
        }
    }
}