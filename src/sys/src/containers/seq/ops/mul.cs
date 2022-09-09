//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial struct Seq
    {
        public static SeqProduct<T> mul<T>(Index<T> a, Index<T> b)
        {
            var kA = a.Count;
            var kB = b.Count;
            var count = kA*kB;
            var buffer = sys.alloc<Pair<T>>(count);
            var k=0u;
            for(var i=0; i<kA; i++)
            for(var j=0; j<kB; j++)
                seek(buffer, k++) = (a[i], b[j]);
            return new SeqProduct<T>(a,b,buffer);
        }
    }
}