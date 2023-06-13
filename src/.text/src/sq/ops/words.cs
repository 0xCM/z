//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct SymbolicQuery
    {
        public static Index<string> words(ReadOnlySpan<char> src)
        {
            var words = list<string>();
            var count = src.Length;
            var buffer = span<char>(count);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(SQ.whitespace(c))
                {
                    if(j==0)
                        continue;

                    words.Add(sys.slice(buffer,0,j).Format());
                    buffer.Clear();
                    j=0;
                }
                else
                    seek(buffer,j++) = c;
            }
            if(j != 0)
                words.Add(sys.slice(buffer,0,j).Format());
            return words.ToArray();
        }

        public static Index<string> words(ReadOnlySpan<char> src, char delimiter)
        {
            var words = list<string>();
            var count = src.Length;
            var buffer = span<char>(count);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(c == delimiter)
                {
                    if(j==0)
                        continue;

                    words.Add(sys.slice(buffer,0,j).Format());
                    buffer.Clear();
                    j=0;
                }
                else
                    seek(buffer, j++) = c;
            }
            if(j != 0)
                words.Add(sys.slice(buffer,0,j).Format());
            return words.ToArray();
        }
    }
}