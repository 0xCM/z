//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ValueGraphs
    {
        public static void traverse<V>(V src, Action<V> receiver)
            where V : IDataType<V>, IExpr, ITree<V>
        {
            receiver(src);
            var targets = src.Children;
            for(var i=0; i<targets.Count; i++)
                traverse<V>(targets[i].Value, receiver);
        }
    }
}