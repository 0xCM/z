//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Finds the length of the line of greatest length using the <see cref='SQ.eol(char, char)'/> test
        /// to partition the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint maxlength(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var max = 0u;
            var current = 0u;
            for(var pos=0u; pos<count; pos++)
            {
                if(!SQ.eol(skip(src, pos), skip(src, pos + 1)))
                    current++;
                else
                {
                    if(current > max)
                        max = current;
                    current = 0;
                    pos++;
                }
            }
            return max;
        }

        /// <summary>
        /// Computes the maximum line length of the lines represented by asci-encoded bytes
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static uint maxlength(ReadOnlySpan<C> src)
        {
            var size = src.Length;
            var max = 0u;
            var current = 0u;
            for(var pos=0u; pos<size; pos++)
            {
                if(!SQ.eol(skip(src, pos), skip(src, pos + 1)))
                    current++;
                else
                {
                    if(current > max)
                        max = current;
                    current = 0;
                    pos++;
                }
            }
            return max;
        }

        [Op]
        public static int SkipWhitespace(ReadOnlySpan<C> src)
        {
            var count = src.Length;
            var i=0;
            while(i < count)
            {
                if(!whitespace(skip(src,i)))
                    return i;
                else
                    i++;
            }
            return NotFound;
        }

        /// <summary>
        /// Determines whether an asci code defines a whitespace character
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit whitespace(C c)
            => space(c) || tab(c) || cr(c) || nl(c) || vtab(c);

        /// <summary>
        /// Determines whether an asci code defines a whitespace character
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit whitespace(char c)
            => space(c) || tab(c) || cr(c) || nl(c) || vtab(c);

        [MethodImpl(Inline), Op]
        public static bit whitespace(AsciCharSym c)
            => whitespace((char)c);

        /// <summary>
        /// Returns true if only asci whitspace chacter codes are present
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static bit whitespace(ReadOnlySpan<C> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(!whitespace(skip(src,i)))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true if only whitspace chacters are present
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static bit whitespace(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(!whitespace(skip(src,i)))
                    return false;
            }
            return true;
        }
    }
}