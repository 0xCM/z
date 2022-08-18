//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        [MethodImpl(Inline)]
        public static Vertex<V> vertex<V>(V value, params Vertex<V>[] targets)
            where V : IDataType<V>, IExpr
                => new Vertex<V>(value, targets);

        [MethodImpl(Inline)]
        public static NamedVertex<V> vertex<V>(Name name, V value, params Vertex<V>[] targets)
            where V : IDataType<V>, IExpr
                => new NamedVertex<V>(name,value, targets);
    }
}