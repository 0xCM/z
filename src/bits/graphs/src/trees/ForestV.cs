//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public delegate void TreeConnectorReader<V>(TreeConnector<V> e)
        where V : IDataType<V>, IExpr, ITree<V>;

    public class Forest<V>
        where V : IDataType<V>, IExpr, ITree<V>
    {
        readonly Seq<TreeConnector<V>> _Edges;

        public Forest(params TreeConnector<V>[] src)
        {
            _Edges = src;
        }

        public void Trace(TreeConnectorReader<V> f)
        {
            foreach(var e in _Edges)
                f(e);
        }
    }
}