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
        /// Replaces tabs with spaces and removes space redundancy
        /// </summary>
        /// <param name="src"></param>
        public static ReadOnlySpan<char> despace(ReadOnlySpan<char> src, Span<char> buffer)
        {
            var count = src.Length;
            var spaces = 0;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(SQ.space(c) || SQ.tab(c))
                {
                    spaces++;
                    if(spaces > 1)
                        continue;
                    else
                        seek(buffer,j++) = Chars.Space;
                }
                else
                {
                    spaces = 0;
                    seek(buffer,j++) = c;
                }
            }
            return sys.slice(buffer,0,j);
        }
    }
}