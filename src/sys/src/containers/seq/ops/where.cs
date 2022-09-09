//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    partial struct Seq
    {
        [Op, Closures(Closure)]
        public static Seq<X> where<X>(ReadOnlySpan<X> src, Func<X,bool> f)
        {
            var dst = list<X>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                if(f(x))
                    dst.Add(x);
            }
            return dst.ToArray();
        }

        [Op, Closures(Closure)]
        public static Seq<X> where<X>(Span<X> src, Func<X,bool> f)
        {
            var dst = list<X>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                if(f(x))
                    dst.Add(x);
            }
            return dst.ToArray();
        }
    }
}