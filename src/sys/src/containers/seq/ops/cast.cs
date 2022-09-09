//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    partial struct Seq
    {
        public static Seq<Y> cast<X,Y>(X[] src)
        {
            var dst = sys.alloc<Y>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = sys.cast<Y>(skip(src,i));
            return dst;
        }
    }
}