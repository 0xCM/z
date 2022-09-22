//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        [MethodImpl(Inline)]
        public static GraphPath<V> path<V>(params V[] src)
            where V : IDataType<V>, IExpr, IVertex<V>
                => new GraphPath<V>(src);
    }
}