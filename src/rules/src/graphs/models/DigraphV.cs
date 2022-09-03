//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public delegate void EdgeReader<V>(Edge<V> e)
        where V : IDataType<V>, IExpr, IVertex<V>;

    public class Digraph<V>
        where V : IDataType<V>, IExpr, IVertex<V>
    {
        readonly Seq<Edge<V>> _Edges;

        public Digraph(params Edge<V>[] src)
        {
            _Edges = src;
        }

        public void Trace(EdgeReader<V> f)
        {
            foreach(var e in _Edges)
                f(e);
        }
    }
}