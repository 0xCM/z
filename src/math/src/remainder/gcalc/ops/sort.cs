//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        [MethodImpl(Inline), Op]
        public static void sort(ulong[] src)
        {
            var n = (uint)src.Length;
            for(var i=0u; i<n-1; i++)
            {
                for(var j=0u; j<n - i - 1; j++)
                {
                    if (skip(src, j) > skip(src, j + 1))
                    {
                        seek(src,j) ^= skip(src,j + 1);
                        seek(src,j + 1) ^= skip(src, j);
                        seek(src,j) ^= skip(src,j + 1);
                    }
                }
            }
        }
    }
}