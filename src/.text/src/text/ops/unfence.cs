//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op]
        public static string unfence(string src, Fence<char> fence)
        {
            (var i0, var i1) = indices(src, fence);
            if(i0 != NotFound && i1 != NotFound && (i0 < i1))
            {
                var start = i0 + 1;
                var length = i1 - start;
                return slice(src, start, length);
            }

            return EmptyString;
        }
    }
}