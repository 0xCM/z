//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial class text
    {
        [Op]
        public static string untick(string src)
        {
            var content = EmptyString;
            if(ticks(src, out var indices))
                content = left(right(src, indices.Left), indices.Right);
            return content;
        }
    }
}