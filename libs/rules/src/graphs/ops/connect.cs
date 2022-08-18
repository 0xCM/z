//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Arrow<Node<T>> connect<T>(in Node<T> src, in Node<T> dst)
            => new Arrow<Node<T>>(src, dst);

        [MethodImpl(Inline)]
        public static Arrow<S,T> connect<S,T>(S src, T dst)
            => new Arrow<S,T>(src, dst);

        [MethodImpl(Inline)]
        public static Arrow<V> connect<V,T>(in Node<V,T> src, in Node<V,T> dst)
            where V : unmanaged
                => new Arrow<V>(src.Index, dst.Index);
    }
}