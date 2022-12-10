//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        public static string expr(in BfSegModel src)
        {
            if(src.Width == 1)
                return string.Format("{0}[{1}]", src.SegName, src.MinPos);
            else
                return string.Format("{0}[{1}:{2}]", src.SegName, endpos(src.MinPos, src.Width), src.MinPos);
        }

        public static string expr<K>(in BfSegModel<K> src)
            where K : unmanaged
        {
            if(src.Width == 1)
                return string.Format("{0}[{1}]", src.SegName, src.MinPos);
            else
                return string.Format("{0}[{1}:{2}]", src.SegName, endpos(src.MinPos, src.Width), src.MinPos);
        }
    }
}