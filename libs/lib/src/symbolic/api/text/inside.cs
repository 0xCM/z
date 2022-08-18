//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op]
        public static string inside(string src, char c0, char c1)
        {
            if(empty(src))
                return EmptyString;

            var i0 = index(src, c0);
            if(i0 > 0)
            {
                var i1 = index(src, i0 + 1, c1);
                if(i1 > 0)
                    return segment(src, i0 + 1, i1 - 1);
            }
            return default;
        }

        [Op]
        public static string inside(string src, int i, int j)
        {
            if(empty(src))
                return EmptyString;

            if(j<=i)
                return EmptyString;
            else
                return slice(src, i+1, (j-i) - 1);
        }
    }
}