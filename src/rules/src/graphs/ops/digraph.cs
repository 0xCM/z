//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        [MethodImpl(Inline)]
        public static Digraph<V> digraph<V>(params Edge<V>[] src)
            where V : IDataType<V>, IExpr, IVertex<V>
                => new Digraph<V>(src);

        [MethodImpl(Inline)]
        public static Digraph digraph(params Edge[] edges)
            => new Digraph(edges);
    }
}