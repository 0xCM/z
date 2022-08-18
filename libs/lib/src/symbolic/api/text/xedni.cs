//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static int xedni(ReadOnlySpan<char> src, char match)
        {
            var count = src.Length;
            var result = NotFound;
            for(var i=count-1; i>=0; i--)
            {
                ref readonly var c = ref skip(src,i);
                if(c == match)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}