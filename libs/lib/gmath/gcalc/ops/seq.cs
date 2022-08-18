//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static gmath;

    partial struct gcalc
    {
        [Op, Closures(Closure)]
        public static SeqTerms<T> seq<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            if(count != 0)
            {
                var terms = alloc<SeqTerm<T>>(count);
                var dst = span(terms);
                for(var i=0u; i<count; i++)
                    seek(dst,i) = new SeqTerm<T>(i, skip(src,i));
                return new SeqTerms<T>(terms);
            }
            else
                return SeqTerms<T>.Empty;
        }

        public static SeqTerms<T> seq<T>(Interval<T> limits)
            where T : unmanaged
        {
            var min = limits.LeftClosed ? limits.Left : inc(limits.Left);
            var max = limits.RightClosed ? inc(limits.Right) : limits.Right;
            var k=0u;
            var a = min;
            var count = bw32(sub(max,min));
            SeqTerms<T> dst = alloc<SeqTerm<T>>(count);
            while(lt(a,max))
            {
                dst[k] = (k,a);
                k++;
                inc(ref a);
            }
            return dst;
        }

        public static SeqTerms<Pair<T>> seq<T>(T i0, T i1, T j0, T j1)
            where T : unmanaged, IEquatable<T>
        {
            var dst = default(SeqTerms<Pair<T>>);
            if(lt(i0,i1) && lt(j0,j1))
            {
                var iD = sub(i1,i0);
                var jD = sub(j1,j0);
                var count = mul(u32(iD), u32(jD));
                dst = new SeqTerm<Pair<T>>[count];
                seq(i0, i1, j0, j1, dst);
            }
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint seq<T>(T i0, T i1, T j0, T j1, SeqTerms<Pair<T>> dst)
            where T : unmanaged, IEquatable<T>
        {
            var i = i0;
            var j = j0;
            var k = 0u;
            while(lt(i, i1))
            {
                while(lt(j, j1))
                {
                    dst[k] = (k, pair(i,j));
                    k++;
                    inc(ref j);
                }
                inc(ref i);
            }
            return k;
        }
    }
}