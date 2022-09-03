//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Lines
    {
        public static string prop(ReadOnlySpan<TextLine> src, string name)
        {
            var result = EmptyString;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var line = ref Spans.skip(src,i);
                var j = text.index(line.Content,Chars.Colon);
                if(j > 0)
                {
                    var prop = text.left(line.Content,j);
                    if(prop == name)
                    {
                        result = text.right(line.Content,j);
                        break;
                    }
                }
            }
            return result;
        }
    }
}