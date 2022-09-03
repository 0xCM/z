//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        public static void Traverse<V>(V src, Action<V> receiver)
            where V : IDataType<V>, IExpr, IVertex<V>
        {
            receiver(src);
            var targets = src.Targets;
            for(var i=0; i<targets.Count; i++)
                Traverse<V>(targets[i].Value, receiver);
        }
    }
}