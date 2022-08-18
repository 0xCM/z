//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial struct Digital
    {
        [Op]
        public static bool number(ReadOnlySpan<char> src, out uint j, out LineNumber dst)
        {
            j = 0;
            dst = default;
            var i = text.index(src,Chars.Colon);
            if(i == NotFound)
                return false;

            if(uint.TryParse(slice(src,0, i), out var n))
            {
                j = (uint)(i + 1);
                dst = n;
                return true;
            }

            return false;
        }
    }
}