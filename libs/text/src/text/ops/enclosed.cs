//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op]
        public static Pair<int> enclosed(string src, int offset, Fence<char> fence)
            => SQ.enclosed(src, offset, fence);
   }
}