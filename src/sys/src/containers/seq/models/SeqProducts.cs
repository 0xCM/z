//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct SeqProducts
    {
        public static ListProduct<T> dist<T>(Index<T> a, Index<T> b)
        {
            var count = a.Length;
            var dst = alloc<Paired<T,Index<T>>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (a[i], b);
            return new ListProduct<T>(a, b, dst);
        }

        public static SeqProduct<T> mul<T>(Index<T> a, Index<T> b)
        {
            var kA = a.Count;
            var kB = b.Count;
            var count = kA*kB;
            var buffer = alloc<Pair<T>>(count);
            var k=0u;
            for(var i=0; i<kA; i++)
            for(var j=0; j<kB; j++)
                seek(buffer, k++) = (a[i], b[j]);
            return new SeqProduct<T>(a,b,buffer);
        }

        public static string format<T>(SeqProduct<T> src)
        {
            var dst = new StringBuilder();
            var result = src.Result;
            var count = result.PointCount;
            dst.Append(Chars.LBracket);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(", ");

                ref var x = ref src.Result[i];
                dst.Append(x.Format());

            }
            dst.Append(Chars.RBracket);
            return dst.ToString();
        }
    }
}