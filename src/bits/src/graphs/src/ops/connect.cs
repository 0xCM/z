//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ValueGraphs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Arrow<ValueNode<T>> connect<T>(in ValueNode<T> src, in ValueNode<T> dst)
            => new Arrow<ValueNode<T>>(src, dst);

        [MethodImpl(Inline)]
        public static Arrow<S,T> connect<S,T>(S src, T dst)
            => new Arrow<S,T>(src, dst);

        [MethodImpl(Inline)]
        public static Arrow<V> connect<V,T>(in ValueNode<V,T> src, in ValueNode<V,T> dst)
            where V : unmanaged
                => new Arrow<V>(src.Index, dst.Index);
    }
}