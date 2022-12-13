//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ValueGraphs
    {
        [MethodImpl(Inline)]
        public static TreePath<V> path<V>(params V[] src)
            where V : IDataType<V>, IExpr, ITree<V>
                => new TreePath<V>(src);
    }
}