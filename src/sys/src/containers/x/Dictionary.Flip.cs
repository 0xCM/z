//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        public static Dictionary<V, K[]> Flip<K,V>(this IReadOnlyDictionary<K,V> data)
            => (from kvp in data.GroupBy(kvp => kvp.Value)
                 let v = kvp.Key
                 let k = kvp.Map(x => x.Key)
                 select (v,k)).ToDictionary();
    }
}