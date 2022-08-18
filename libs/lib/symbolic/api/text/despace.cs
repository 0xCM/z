//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {
        /// <summary>
        /// Replaces tabs with spaces and removes space redundancy
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static string despace(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            Span<char> buffer = stackalloc char[count];
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
            return sys.@string(sys.slice(buffer,0,j));
        }
    }
}