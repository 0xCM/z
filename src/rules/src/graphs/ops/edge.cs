//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        public static Edge<V> edge<V>(V src, V dst)
            where V : IDataType<V>, IExpr, IVertex<V>
                => new Edge<V>(src, dst);

        public static NamedEdge<V> edge<V>(Name name, V src, V dst)
            where V : IDataType<V>, IExpr, IVertex<V>
                => new NamedEdge<V>(name, src, dst);
    }
}