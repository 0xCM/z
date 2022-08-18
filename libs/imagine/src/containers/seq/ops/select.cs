//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;

    partial struct Seq
    {
        [Op, Closures(Closure)]
        public static Seq<T> select<X,T>(ReadOnlySpan<X> src, Func<X,T> f)
        {
            var dst = sys.alloc<T>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = f(src[i]);
            return dst;
        }

        [Op, Closures(Closure)]
        public static Seq<T> select<X,T>(Span<X> src, Func<X,T> f)
        {
            var dst = sys.alloc<T>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = f(src[i]);
            return dst;
        }

        public static Seq<Y> map<X,Y>(ReadOnlySpan<X> src, Func<X,Y> f)
            => select(src,f);

        public static Seq<Y> map<X,Y>(Span<X> src, Func<X,Y> f)
            => select(src,f);

        public static Seq<Z> map<X,Y,Z>(ReadOnlySpan<X> src, Func<X,ReadOnlySeq<Y>> lift, Func<X,Y,Z> project)
        {
            var dst = sys.list<Z>();
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
            var dst = sys.list<Z>();
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

        [Op, Closures(Closure)]
        public static Seq<X> where<X>(ReadOnlySpan<X> src, Func<X,bool> f)
        {
            var dst = sys.list<X>();
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
            var dst = sys.list<X>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var x = ref skip(src,i);
                if(f(x))
                    dst.Add(x);
            }
            return dst.ToArray();
        }

        /// <summary>
        /// Deposits index-identified cells from a specified <see cref='ReadOnlySpan{T}'/> into as specified target <see cref='Span{T}'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="indices">The index selection</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <typeparam name="I">The index type</typeparam>
        [MethodImpl(Inline)]
        public static void select<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            if(sys.size<I>() == 1)
                select8(src, indices, dst);
            else if(sys.size<I>() == 2)
                select16(src, indices, dst);
            else if(sys.size<I>() == 4)
                select32(src, indices, dst);
            else if(sys.size<I>() == 8)
                select64(src, indices, dst);
            else
                throw no<I>();
        }

        [MethodImpl(Inline)]
        static void select8<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (byte)indices.Length;
            for(byte i=0; i<count; i++)
                seek(dst,i) = skip(src, sys.@as<I,byte>(skip(indices,i)));
        }

        [MethodImpl(Inline)]
        static void select16<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (ushort)indices.Length;
            for(ushort i=0; i<count; i++)
                seek(dst,i) = skip(src, sys.@as<I,ushort>(skip(indices,i)));
        }

        [MethodImpl(Inline)]
        static void select32<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (uint)indices.Length;
            for(uint i=0; i<count; i++)
                seek(dst,i) = skip(src, sys.@as<I,uint>(skip(indices,i)));
        }

        [MethodImpl(Inline)]
        static void select64<I,T>(ReadOnlySpan<T> src, ReadOnlySpan<I> indices, Span<T> dst)
            where I : unmanaged
        {
            var count = (ulong)indices.Length;
            for(ulong i=0; i<count; i++)
                seek(dst,i) = skip(src, sys.@as<I,ulong>(skip(indices,i)));
        }
    }
}