//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Dictionary<K,V> ToDictionary<K,V>(this Paired<K,V>[] src)
            => src.Select(x => (x.Left, x.Right)).ToDictionary();
    }
}