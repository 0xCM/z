//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ValueGraphs
    {
        [MethodImpl(Inline)]
        public static Forest<V> forest<V>(params TreeConnector<V>[] src)
            where V : IDataType<V>, IExpr, ITree<V>
                => new (src);

        [MethodImpl(Inline)]
        public static Forest forest(params TreeConnector[] edges)
            => new (edges);
    }
}