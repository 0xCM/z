//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        public static S concat<S,T>(S a, S b)
            where S : ISeq<S,T>, new()
        {
            var count = a.Count + b.Count;
            var dst = create<S,T>(count);
            var j=0u;
            for(var i=0; i<a.Count; i++, j++)
                dst[j] = a[i];
            for(var i=0; i<b.Count; i++, j++)
                dst[j] = b[i];
            return dst;
        }
    }
}