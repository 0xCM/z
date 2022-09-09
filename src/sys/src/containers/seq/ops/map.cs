//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial struct Seq
    {
        public static Seq<Y> map<X,Y>(ReadOnlySpan<X> src, Func<X,Y> f)
            => select(src,f);

        public static Seq<Y> map<X,Y>(Span<X> src, Func<X,Y> f)
            => select(src,f);

        public static Seq<Z> map<X,Y,Z>(ReadOnlySpan<X> src, Func<X,ReadOnlySeq<Y>> lift, Func<X,Y,Z> project)
        {
            var dst = list<Z>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src, i);
                var y = lift(x);
                for(var j=0; j<y.Count; j++)
                    dst.Add(project(x,y[j]));
            }
            return dst.ToArray();
        }

        public static Seq<Z> map<X,Y,Z>(ReadOnlySpan<X> src, Func<X,Seq<Y>> lift, Func<X,Y,Z> project)
        {
            var dst = list<Z>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                var y = lift(x);
                for(var j=0; j<y.Count; j++)
                    dst.Add(project(x,y[j]));
            }
            return dst.ToArray();
        }

        public static Seq<Y> map<X,Y>(ReadOnlySpan<X> src, Func<X,ReadOnlySeq<Y>> lift)
        {
            var dst = list<Y>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                var y = lift(x);
                for(var j=0; j<y.Count; j++)
                    dst.Add(y[j]);
            }
            return dst.ToArray();
        }

        public static Seq<Y> map<X,Y>(Span<X> src, Func<X,Seq<Y>> lift)
        {
            var dst = sys.list<Y>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                var y = lift(x);
                for(var j=0; j<y.Count; j++)
                    dst.Add(y[j]);
            }
            return dst.ToArray();
        }
    }
}