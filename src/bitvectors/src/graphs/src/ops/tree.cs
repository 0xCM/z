//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ValueGraphs
    {
        [MethodImpl(Inline)]
        public static Tree<V> tree<V>(V value, params Tree<V>[] targets)
            where V : IDataType<V>, IExpr
                => new Tree<V>(value, targets);

    }
}